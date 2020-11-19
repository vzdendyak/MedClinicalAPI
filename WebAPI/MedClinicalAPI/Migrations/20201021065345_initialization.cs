using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedClinicalAPI.Migrations
{
    public partial class initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Addresses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Region = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        Street = table.Column<string>(nullable: true),
            //        HouseNumber = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Addresses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Schedules",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StartHour = table.Column<int>(nullable: false),
            //        EndHour = table.Column<int>(nullable: false),
            //        IsSaturdayWork = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Schedules", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Services",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Price = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Services", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Departments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentName = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        AddressId = table.Column<int>(nullable: false),
            //        ScheduleId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Departments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Departments_Addresses_AddressId",
            //            column: x => x.AddressId,
            //            principalTable: "Addresses",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Departments_Schedules_ScheduleId",
            //            column: x => x.ScheduleId,
            //            principalTable: "Schedules",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        Discriminator = table.Column<string>(nullable: false),
            //        FirstName = table.Column<string>(nullable: true),
            //        LastName = table.Column<string>(nullable: true),
            //        Age = table.Column<int>(nullable: true),
            //        DepartmentId = table.Column<int>(nullable: true),
            //        RoleId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUsers_Departments_DepartmentId",
            //            column: x => x.DepartmentId,
            //            principalTable: "Departments",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DepartmentServices",
            //    columns: table => new
            //    {
            //        DepartmentId = table.Column<int>(nullable: false),
            //        ServiceId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DepartmentServices", x => new { x.DepartmentId, x.ServiceId });
            //        table.ForeignKey(
            //            name: "FK_DepartmentServices_Departments_DepartmentId",
            //            column: x => x.DepartmentId,
            //            principalTable: "Departments",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DepartmentServices_Services_ServiceId",
            //            column: x => x.ServiceId,
            //            principalTable: "Services",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(nullable: false),
            //        ProviderKey = table.Column<string>(nullable: false),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Records",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DoctorId = table.Column<string>(nullable: true),
            //        PatientId = table.Column<string>(nullable: true),
            //        DateOfRecord = table.Column<DateTime>(nullable: false),
            //        DateOfMeeting = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Records", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Records_AspNetUsers_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Records_AspNetUsers_PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUsers_DepartmentId",
            //    table: "AspNetUsers",
            //    column: "DepartmentId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Departments_AddressId",
            //    table: "Departments",
            //    column: "AddressId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Departments_ScheduleId",
            //    table: "Departments",
            //    column: "ScheduleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DepartmentServices_ServiceId",
            //    table: "DepartmentServices",
            //    column: "ServiceId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Records_DoctorId",
            //    table: "Records",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Records_PatientId",
            //    table: "Records",
            //    column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "DepartmentServices");

            //migrationBuilder.DropTable(
            //    name: "Records");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "Services");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Departments");

            //migrationBuilder.DropTable(
            //    name: "Addresses");

            //migrationBuilder.DropTable(
            //    name: "Schedules");
        }
    }
}
