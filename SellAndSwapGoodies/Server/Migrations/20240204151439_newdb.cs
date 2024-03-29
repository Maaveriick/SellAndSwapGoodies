﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellAndSwapGoodies.Server.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItmPic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ConditionID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listings_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Conditions_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deliverys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryStatusID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ListingID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliverys_DeliveryStatuses_DeliveryStatusID",
                        column: x => x.DeliveryStatusID,
                        principalTable: "DeliveryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverys_Listings_ListingID",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverys_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    OfferID = table.Column<int>(type: "int", nullable: true),
                    ListingID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Listings_ListingID",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Offers_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreditCardExpiryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardNumber = table.Column<long>(type: "bigint", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    OfferID = table.Column<int>(type: "int", nullable: true),
                    ListingID = table.Column<int>(type: "int", nullable: true),
                    DeliveryStatusID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_DeliveryStatuses_DeliveryStatusID",
                        column: x => x.DeliveryStatusID,
                        principalTable: "DeliveryStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Listings_ListingID",
                        column: x => x.ListingID,
                        principalTable: "Listings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Offers_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, 0, "cea71b40-afc6-4bd7-8175-d8be715e75b3", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEN0xIVm3beeXYNg7dbV/e5w7LQ8M1g8S7kPBAbVExb+xRSLd6hzi12MzNplz2KDDcA==", null, false, "da2b673d-2787-4e22-b2eb-ce7663140b0b", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8050), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8051), "Shoes", "System" },
                    { 2, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8052), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8052), "Electronics", "System" },
                    { 3, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8054), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8054), "Babies & Kids", "System" },
                    { 4, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8055), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8056), "Men's Fashion", "System" },
                    { 5, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8059), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8059), "Woman's Fashion", "System" },
                    { 6, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8061), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8061), "Watches", "System" },
                    { 7, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8062), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8063), "Furniture", "System" },
                    { 8, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8064), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8064), "Vehicles", "System" },
                    { 9, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8066), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8066), "Sports Equipment", "System" },
                    { 10, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8067), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8068), "Pets", "System" },
                    { 11, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8069), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8070), "Bags", "System" },
                    { 12, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8071), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8071), "Luxury", "System" }
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8391), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8392), "New", "System" },
                    { 2, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8393), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8393), "Fair", "System" },
                    { 3, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8395), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8395), "Poor", "System" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryStatuses",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Status", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7809), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7827), "Shipped", "System" },
                    { 2, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7828), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7828), "Delivered", "System" },
                    { 3, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7830), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7830), "Canceled", "System" },
                    { 4, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7831), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(7832), "Pending", "System" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CreatedBy", "DateCreated", "DateUpdated", "EmailAddress", "Gender", "Name", "Password", "ProfilePicture", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 39, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8604), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8605), "James@gmail.com", "Male", "James", "1234", "data:image/jpeg;base64,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", "System" },
                    { 2, 35, "System", new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8607), new DateTime(2024, 2, 4, 23, 14, 39, 317, DateTimeKind.Local).AddTicks(8608), "Curry@gmail.com", "Male", "Curry", "1234", "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBYWFRYVFhYYGRgZGhoeGRoaHBwfHBkeGBgcGhkeGBweIS4lHh4rIRoeJjgmLC8xNTU1HCQ7QDs0Py40NTEBDAwMEA8QHxISHzYrJCw0ND04NDE/NDU0PTQ0NDQ2MTQ0NDQ0NDY0NDQ0NT00NDY0NDQ0NDQ0NDQ0NTQ9NDo0NP/AABEIAMABBwMBIgACEQEDEQH/xAAcAAEAAgIDAQAAAAAAAAAAAAAABQYEBwECAwj/xAA+EAACAQIEAwUFBgQGAgMAAAABAgADEQQSITEFBkEiUWFxgQcTMpGhQlJicrHwgrLB0SMzkqLC4RQkFVOD/8QAGgEBAAIDAQAAAAAAAAAAAAAAAAIEAQMFBv/EADERAAIBAwMCBAMHBQAAAAAAAAABAgMEERIhMUFREyJhgRSRwQU0obHR8PEkMjNScf/aAAwDAQACEQMRAD8A3NERAEREAREQBERAEREAREQBOjMALnQCY3EeI0qCZ61RKaXAzOQoudtTNDc+8+VMY7UqbFMKrdkDRqmXZmJ1tcXC+Ot+gG2+Oc94HDA5qyu4BtTp9tie7TRfNiBKpivbFTDKKeFqMLjMXdVIHXKBmv62mmlNhYTsDr+9YMm5h7Y6Fz/61bLpY5kzHvut7D5mT/CPaTgK5y+9NJu6qMgPgGvlv4XBnz33TqDp1/e0A+s6NdXUMrBlOxUgg+RG89p8x8t814nBMTQYZT8SOMyN0va4IPkR43m6uSueqOOUI2WniADmpk/Fb7SX3XXbcfWDBcoiIAiIgCIiAIiIAiIgCIiAIiIAiIgCIiAIiIAiIgCIiAJg8Y4gmHoVa7/DTVnNtzlF7DxO3rM6aG9r3Mhr4j/xqdQmjSFnUaK1QE3v94roO4awCr828zVMdX99UGVQAqUwxZUXrY2FyTqTbXTuEhJ3w1FnNlF/KWTBctkjt6eG5+fSQlOMeTZCnKXBWcvh5z0CHumxMBy1SAC5M218xP12EsOD4Ui2tTQW2somp3C7G5W0urNOLRbuPyM6lD3fsdJvFsEpHwJ/pEisZwCi981JNe4W/SFXXVB2z6M1Bee+ExT0nWpTco6G6sN1PePqPWW/inKia5Lqe46j+8qvEOHPS+If2PkZtjUjLg1SpSjyb89nnN6Y6iFZv/YpqPeqQBfpnS26n6XtLlPlbgPGamErriKXxKdQfhdT8SPbcGw+QPSfTHA+JriaFLEICFqKGAO4vuD5G4vJmokYiIAiIgCIiAIiIAiIgCIiAIiIAiIgCIiAIiIAiIgGLj8YlGm9VzZEVmY2Jsqi5NhrsJ8pYutnqPUt8bu9u7Oxa31n0nz7xIYfAYhyAxKMqhhdSzgqAfDXbrt1nzVhk7QEGUWvlvA2TORqTb0H7MtODpgn1kRgtERR0EsGCTQGUJyzJs6UI6YpImcHhhYTPSmJ4YRdLzLUTGBkBJw9IW2nskMJLBjJAcRoDulV49gA9NhbUC/y3+l5d8VTvIHH07GRT0vJlrUsGonQqSDN8ex3ib1sCUcg+5qGmmmoTIrKD0NsxA8AJpbi+GyO2mgbf9Jtr2IU1/8AGrsGJY1QHXotkGUgd5ufkJfTyjnSWHg2fERMkRERAEREAREQBERAEREAREQBERAEREAREQBERAIfmjh5xGDxFFbZnpVFW9rZipy3voNba9PCfL+Ba7Dx+l+s+t581cc4PlxOIemb0/fVAL2DL2zvbS19vC2kjJpck4RcnsTeFOg8Br6Sx4OsqqGNrC3n8pVeG3K+sllxSU/jNydlA1N/HU/vQSklvudBvC2J5eacMrFSxB21knhuJU6mqMD+vylO/wDkErt7tMO2wIJy31LAWBcNuh6X20sQZxw8Mj/hva+vyIOoPgZOSwuCEd+GX+m3WYWO41RpfG+vcNT8hPRn/wAO/W0pmJR3qfDfcgWuTYXJ3At4k+hJmFyZaLEnMFOpfIrHzBA+swOI1FNtR/33TCwnMFgUaiTlzarZgAqqSeyb27W4B2M7e8SoAyfKZku6Ixl2KVzOgDH5/wBZtv2PYZl4ajG1nqVGW24Acpr36qT6zW+M4b72sysSFABJHmdvO0277P1VcBQVRYKGHnZ2uT4nc+Jm+nJNYK1aDTcuhZ4iJtNIiIgCIiAIiIAiIgCIiAIiIAiIgCIiAIiIAiIgHE0fxbDBHxAIsTWqAn73bYfrb5TeE0/x+mUxlValrM7FT07ZzKT/AKh9ZorcIs2z8zIvgNMWF5PpwpDZrC97363lZ4VWytY7i4t4g2MuvDnziVnyXEsowhgiGzBVBuTcaam9yLddT16meFVCLKf31lhqUgBILF10UuzMqKu5YgfUzLb4MJJEyDen6SNaiT2RuNtAfLeZ+ExFNqVw32b9J44Ouj2KsrgjdSD9RMrI2ydcNgCL9lNeoFj+m05fBomoAvbW0k0CkSO4lVyw33GldCvJYVm31692jDX5zYvJQthgN7O31N/63muqDk++Ki5zKAfugBiT9RNmcp4T3eHXUnN2te4gW+gB9ZsorzexouGtPuTcREtFIREQBERAEREAREQBERAEREAREQBERAEREAREQDiUznbgrO6VkUvZSrqoubXupA67kH0lziRlFNYZKMnF5R894hGp4iojKykMDlYENZ1DC4Iv1MsvBMXpvrMT2kXTiVyOy9JLealgQLDxBtqdegtMbAVAr2B0IO3Q2/vKlWGll+jPVEslTiIOpNl7z1I3t4SLx/E6DEArmbocoPh10IkQ2FqN2tGyjRLkaAWGvpt5TKwCO26IpsT2rb91xf8AWFEmnk90qolnIcpqMtgFse9bfrJHBcXorcKpS+pOUa/Kc06FfNbPTsRv7w26CxNt9dvAyMx9JwbZE6a3BHeBtfSScXgJLoT6cQW+jXB0v90nbN4HvkfxbE3Fut7SIp8PZWuzZQw+EEkdrQ76zvxHHBWubalv39Jrcd8Iwpdywcl8FNdajFgEFUq2+Y2poSB0t2t+muk2aqgAAaASj+yRr4N2t8Veob9+ijfrtL1LkIpI59STk9zmIiTICIiAIiIAiIgCIiAIiIAiIgCIiAIiIAiIgCIiAIiIBrb2xcIzYdMUq3aiwDHTRGuDe/TNl0E1bgOJZSAdr/rPpDiSBqNVTsabg+RUifNGL4S4BqICUsGNvs+nhNc9L2ZupOSTa6Fn4PxMPVKkjW4+WlryRrqyEsunpf5ia5w+JyuGGm3WX3hvMyFEUrd9Br6a/u01Sg1ujfTrZ5Panxxr5QoY36A+EzEZ6hzMtgPCw+Q385k08XRFmYJqLmw2kfxTmlFDKgA7j+npMLUzZKeOWRHHOJ2qKqn4bA2PU7+o1kFxXGZnYLqdhbz/AGJH4vEFnYnc76666/PWWHhfCMlL3r/GwJAP2R09TJvTBZZoTlN4RurknghwmEp0Wtm1Z/zMbn5aD0lhnlRe6qw+0AfmLz1m8qiIiAIiIAiIgCIiAIiIAiIgCIiAIiIAiIgCIiAIiIAiJ0zC9ri/dAOmJTMrDvBHzE0hwjVVHQgaek3FxriaYei9RzoAbDq5toq+J+m+wmn+GplCjuA+krV3ui3bLZlV5h4G1Fy6AmmTcWHw9cp8O4+EiqVex/dtJthlBQjv3lSxvLiOSyXU9w2Pp0ko1U9mRlSfMSCPEGyjtdNPKYT4gseuv7+cnaXLLkgFhbr/ANCT/D+WKaDOylm/FsPISbnFEdEpckPylwL3r+8deyp0U9SO/wABvLVxVdCJlcPQICALTxxy5pVnLVuWacVHY2Zy7VzYXDt30qd/PKAfrJKVLkjiyGitBmtUS4sdMwJLLl77A2tvpLUKgvYEX7r6y5F5imUZxxJo9IiJIiIiIAiIgCIiAIiIAiIgCIiAIiIAiIgCIiAcRPCpiUVgpZQxBIUkAkLuQNza4+cx6uLY6IPU/wBB/eZUWzDeCue0jmapgsODRt7yo+RWIuEGVmLWOhPZsAdNb62sdRcBD16mJZqjmq9NGLknOQtamWs24+z6DTabV9oXCjWwTn4mplagvv2Lhz6IzH0mp+CV/cVkqG+UErU/I4Kv52BuPECWvA128tPP6bkY1MTTfBb8TRqVBmquzsFsCzEkC3S+23ruZ1wlPQCWGthxlI/T+nhIyhhyDOJnO51U1jByqTwWlZjJDJPJ11vMGRToCelYdmdVxFtxDOWmcmMHhTGhnY05kU0nqKcxgNkZh8MC7AjQiYPGuHijh8Q6Eo1qWUqSpVxWXKykfCQpfUdCZYKVDtSB53xfZp0Ruxzt5LdEB9S5/wBJm+3pOpWhBd0/ZcmmvU002yf5C5+asyYXFD/FIISqB2XyqWIcfZawJuNDbppfY4N9RNL+zThnvMUapHZooT/E4KL/ALc/ym2QCvwm3eOk6tzShGpiJzoSbjlkhEh+Jcfo4ZUbEP7tXbKGsxXMQTrYHKLA6nTxkjhcUlRA9N1dWF1ZSCpHgRoZVcWt8GxNMyInE5mDIiIgCIiAIiIAiIgCIiAcRPKtWVFLMwVQLliQAB4kysYvnSmLiijVPxHsKfIkE/SRlKMeWSjCUuEWuUznbms0aLrhWDVxa5C51pi/aJO2a17DXxEheIcRxOIuHbKh+wlwCPxHdvU28JxSwKZCltxaafiUpLCyWFavHmZrzAY+qmJp4p3eo6MrFnYszKPiW52BUsLdLz6Dp2IBXUEAg94IuDPn/EYfI7IfssR8puLkHHe9wdO57VO9Nv4Pg/2FZ27qEdEZx4ObCT1OLLC9MEEEXB0I7x1E0ZzBwc4eu9Ejsg3Q96N8Bv17j4qZveV3m/l0YqmClhVS5QnZgd0Y9x6HofWabasqc/NwyVSOVtyUzlLimdPcOe2g7J++i7fxINPygfdMsC4fWa2ZHpvY5kdG8mRlP0MtnBuaFNkrdhvvgdg+YGqHyBH5RNN79nuLdSksxe+Fyjdb3Kxok8PuTtTDTGqUDa4ElUcMAwIZTswIKnyI0M9UpCcjY6EStMPCe1JL2EmKuBU6idaWFCmNOCWTBFG5tM9MPYQUtqJjcR4mlAXqNZiOzTGrt6fZH4j6XkoJuSjFZb4S5ITaisyeEdMfVSkjO5sqjUjfXYL+I7D57AzXGLrtVd6jixc6KNlUCyqPAAAekzuLcUfENd9FU9hB8K36n7zeJ+g0ls5F5XJZcTWXQa0lP2juHI7h9nvOvQE961t1aQdWr/c+nb0OVWqutLTHhFi5I4IcNhwGFnqHO46rcAKp8gNfEtLCVnYic2lSUnKTk+pNLCwa29rdTs4ZOhNVj/CFUfzmVrkDiVTD1nKaoy9pCSFY3Fm02e1xex0Jlj9rAu+GHclQ/Nk/tK/ylRu7/lH1Jl2p5bJyX73IUlqrqLNt8L4/Rr2Ctlf7jaN6dG9LyXmsavD1aKWNxFD4Kr2H2WOZfKzXsPK04cbnujoytf8AV/M2dEr3LvMQxF0YBaqi5Xow+8t9fMdPGWGWIyUllFWUXF4ZzERJGBERAEREA4nlWqqiszEBVBLE7AAXJM9Zr72hcXLOuEQ6WDVbdeqIflmP8MhKSiskoRcpYRD8w8cbGPYXWgh7K7ZiPtOO/uHTzvO/DsPpczFwWFzEDoJYaVEKJQm5SeWdOKjBaUcJTE9AsDeeqrMJBso3NeDy1g33xf1Xf9RLB7MMXlqVaR2dAw80OU/MOP8ATPHnCj2Ebue3zU/2Ej+S6+TGUT0Zip8cylR9bT09u/EssPovy4OHX8lw/X6m34nM4nONhC8e5bo4odoZXAsrr8Q7gfvL4H0tNaca5Yr4a5dcyf8A2Lcrb8XVD56eJm5YlijdTpeq7EJ0oyNF4DG1KJvTdkJ3A1U/mU6N6y18K5tViErKEJ0Dr8B/MDqvnt4Aaywcc5Lo1gWpgUn37I7DH8SjbzFvIzWvEMA9F2p1Fyuu46EHYg9Qe+W3StrzlYl8v5NanVovZ7fgbPJvtOjsFBJIAAuSTYKBuSeglR5V4wQRQc3B0pknZuiE/dPTuOmx0x+a+Il3NFW7CGzEfbcaMfJdgPAnrOP8BVdx4Hvnpg6DvI+FrXPb1MzinNW64YedVh/Ip28zr4CVvD4apXfIqu7tqdyx7ySenidJn8v8HfE1RTU2Udp3t8K/3OwH9jNs8M4VToJkpKFHU7sx72bcn9Olp1sUbJaaazLq3yc9udd6pPYq/LnIy0ytTEZWcahBqqn8R+0fDbz3l1nMSjUqyqS1SZujBRWEBOInMgZNZ+043r0h3Ur/ADcj+kjeUKXbq+Sf8pm+0Vr4oeFJB/uc/wBZ15PT/MP5f+U6Ffawa9Pqa6D/AKle5Nutpi1hfSShSY1alPNOLO4pEHVpMjK6kqym6sN1P9vDul+5d40uITXs1FtnXz2ZfA/TbxNXqUwVMjMLjDh66VReymzjvU/EPHTUeIE2UpuL34NdaCnH1RteJ0U3FxqDO8vHOEREAREQDyrVAqlibAAknuAFyZpQYk161Ss27uWt3A/Cvoth6TZfPuM93gqgB7VS1MeIc9v/AGBprTAJaVq8uEW7WPMifwAtaSqvpIjDmZ9F5XRZZloJ6TxRp6qZkwQ/NX+T/ELfr/SVfhDWr0D3VaZ+TrLPzWf8EfnH6GVjhf8Am0vGpT/nE9J9mfdn7/kca+/zL/iN3zD4djlrKXS5TMyq2lnyHKWXwzAgHra+xExuYKdRsNWWkLuyMAAbE3+IA9+W9vG0oXBTxNVFCirogOhdFULc3Nmddrkmwue6VKdFSi3qS36mXLDxg2dVqqilmYKo3LEADzJkMeZ6TMUoK+IcbimvZH5naygeNzIzB8mZyHxlZ67b5MzZB4XPaPplHhLXhsOlNQiKqKNlUAD5CRapx65fyRlZfoY+DauxzVFpoLaIpZyD0u/ZHoFPn3wHP/ChUoe+UdulqfFCe0D5aN6HvlrnliKQdGRhdXVlYeDCx+hmKdRwmpLoJR1RwzRaXBuNxtOBebCf2er0xDDzQH/kIp+z1euIY+SKP1JnY+No85/BlPwJmV7OMKFoO/2nci/4UAAHzLH1nbF8RrU69UqWYLUKgEj3ZzYdWSn3qxcix0GttzaTnBOFrhqYpKzMASbta92OuwAkkDOLcPxJuSfU6FvJU1iSztgpFbjlYuuSotUqRbIrKCXpVsysoY5spUHLvpbeZ7cadv8ADFRbtUUIbamm1EWdRfpUuPC1t5L4jhKO5ctVF9wtWoq+gVhb0nrS4fTXbOfzVajfzOZp0S7lqVak8YiV3Bccrf4K3UkrTBzizMzG1Rblr51FrixN9TYHST4JxCq+UVcpL0hUBUFcutmUgsb2uNdOsmVUDYTsWmVFrqap1YtYUUjVPP2uMf8AIn8t578nfDU81/SdPaDTti7/AHqaH6sv/GccoVP8xfyn53H9J1brex27Ip2/3j5loInm07Fp5MZ5w7B4VZC8STeTFdpE40XEiyaL1yfi/eYSlfdRkP8A+Zyi/mAD6yclF9nWIsa9E96uo8xlb9Fl6l6DzFM51SOmTRzERJkD/9k=", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ListingID",
                table: "Chats",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_OfferID",
                table: "Chats",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserID",
                table: "Chats",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverys_DeliveryStatusID",
                table: "Deliverys",
                column: "DeliveryStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverys_ListingID",
                table: "Deliverys",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverys_UserID",
                table: "Deliverys",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryID",
                table: "Listings",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ConditionID",
                table: "Listings",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_UserID",
                table: "Listings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ReceiverId",
                table: "Offers",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SenderId",
                table: "Offers",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DeliveryStatusID",
                table: "Transactions",
                column: "DeliveryStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ListingID",
                table: "Transactions",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OfferID",
                table: "Transactions",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Deliverys");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DeliveryStatuses");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
