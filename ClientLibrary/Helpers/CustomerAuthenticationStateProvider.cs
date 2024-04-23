using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ClientLibrary.Helpers
{
    //nguoi dung thong bao cho he thong la chua duoc dang ky hoac chua duoc xac thuc
    public class CustomerAuthenticationStateProvider(LocalStorageService localStorageService) : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal anonyous = new (new ClaimsIdentity());
        //xac thuc quyen so huu cho nguoi dung
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var stringToken = await localStorageService.GetToken();
            // kiem tra xem co null hay khong
            if (string.IsNullOrEmpty(stringToken)) return await Task.FromResult(new AuthenticationState(anonyous));

            var deserializeToken = Serializations.DeserializeJsonString<UserSession>(stringToken);
            if (deserializeToken == null) return await Task.FromResult(new AuthenticationState(anonyous));

            var getUserClaims = DecryptToken(deserializeToken.Token!);
            if (getUserClaims == null) return await Task.FromResult(new AuthenticationState(anonyous));

            var claimsPrincipal = SetClaimPrincipal(getUserClaims);
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
        //cập nhật trạng thái xác thực của người dùng sau khi họ đăng nhập hoặc đăng xuất.
        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            //khởi tạo một đối tượng ClaimsPrincipal trống.
            var claimsPrincipal = new ClaimsPrincipal();
            // nó kiểm tra xem liệu userSession.Token hoặc userSession.refreshToken có khác null không.
            // Nếu có ít nhất một trong chúng khác null,
            // đồng nghĩa với việc người dùng đã đăng nhập thành công hoặc phiên làm việc của họ đang được duy trì.
            if (userSession.Token != null || userSession.RefreshToken != null )
            {
                //chuyển đổi đối tượng userSession thành một chuỗi JSON
                var serializeSession = Serializations.SerializeObj(userSession);
                // lưu trữ chuỗi đó vào localStorage sử dụng dịch vụ localStorageService.
                await localStorageService.SetToken(serializeSession);
                //giải mã token của người dùng từ userSession.Token
                var getUserClaims = DecryptToken(userSession.Token!);
                //sử dụng hàm SetClaimPrincipal để tạo một ClaimsPrincipal từ các thông tin người dùng được giải mã.
                claimsPrincipal = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                //Nếu cả hai userSession.Token và userSession.refreshToken đều là null,
                //điều này có thể xảy ra khi người dùng đăng xuất hoặc phiên làm việc của họ hết hạn.
                //Trong trường hợp này, nó gọi hàm localStorageService.RemoveToken() để xóa các thông tin xác thực được lưu trữ
                await localStorageService.RemoveToken();
            }
            // thông báo cho hệ thống xác thực rằng trạng thái xác thực đã được cập nhật và cần phải cập nhật UI tương ứng để phản ánh trạng thái mới.
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }



        /*Mục đích chính của hàm này là tạo ra một đối tượng ClaimsPrincipal chứa các claim cụ thể về người dùng từ đối tượng CustomUserClaims được cung cấp.
        Nếu email trong CustomUserClaims là null, hàm sẽ trả về một ClaimsPrincipal trống.
        Nếu email không phải là null, hàm sẽ tạo ra một ClaimsPrincipal mới với một ClaimsIdentity chứa các claim NameIdentifier, Name, Email, và Role tương ứng với các giá trị từ đối tượng CustomUserClaims.*/
        public static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims.Email is null) return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new (ClaimTypes.NameIdentifier,claims.Id!),
                 new (ClaimTypes.Name,claims.Name!),
                  new (ClaimTypes.Email,claims.Email!),
                   new (ClaimTypes.Role,claims.Role!)
            }, "JwtAuth"));
        }

        //nhận một chuỗi JWT (JSON Web Token) và trả về các thông tin người dùng đã được giải mã từ token đó.
        private static CustomUserClaims DecryptToken(string JwtToken)
        {
            if (string.IsNullOrEmpty(JwtToken)) return new CustomUserClaims();

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(JwtToken);
            var userId = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier);
            var name = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Name);
            var email = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Email);
            var role = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Role);
            return new CustomUserClaims(userId!.Value!,name!.Value!,email!.Value!,role!.Value!); 
        }
    }
}
