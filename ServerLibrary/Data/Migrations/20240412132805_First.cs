using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "applicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_id = table.Column<int>(type: "int", nullable: true),
                    car_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    employee_id1 = table.Column<int>(type: "int", nullable: true),
                    invoice_id = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employees_Admins_admin_id",
                        column: x => x.admin_id,
                        principalTable: "Admins",
                        principalColumn: "admin_id");
                    table.ForeignKey(
                        name: "FK_Employees_Cars_car_id",
                        column: x => x.car_id,
                        principalTable: "Cars",
                        principalColumn: "car_id");
                    table.ForeignKey(
                        name: "FK_Employees_Customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_employee_id1",
                        column: x => x.employee_id1,
                        principalTable: "Employees",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    invoice_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.invoice_id);
                    table.ForeignKey(
                        name: "FK_Invoices_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "car_id");
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_admin_id",
                table: "Employees",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_car_id",
                table: "Employees",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_customer_id",
                table: "Employees",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_employee_id1",
                table: "Employees",
                column: "employee_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_invoice_id",
                table: "Employees",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CarId",
                table: "Invoices",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeId",
                table: "Invoices",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Invoices_invoice_id",
                table: "Employees",
                column: "invoice_id",
                principalTable: "Invoices",
                principalColumn: "invoice_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Admins_admin_id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Cars_car_id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Cars_CarId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Customers_customer_id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Invoices_invoice_id",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "applicationUsers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
