﻿using BaseLibrary.DTOs;
using BaseLibrary.Responses;

namespace ServerLibrary.Responsitories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
    }
}
