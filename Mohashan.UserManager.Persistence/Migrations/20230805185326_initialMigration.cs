using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mohashan.UserManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userFeatures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DataType", "DeletedBy", "DeletedDateTime", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("b8d7034b-176f-46ca-8a77-ddbf8d5518cc"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7484), "String", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Email" },
                    { new Guid("d72c5f77-667d-4a73-a426-1f76e18a93b5"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7453), "String", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MobileNumber" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0446761a-0d10-4a85-afb6-c0c0a1ed4fbd"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7561), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AdminGroup" },
                    { new Guid("6f74e22b-04a3-4eda-b7b0-b9e1fe8b963d"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7568), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ReportGroup" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("6ab3ffdf-8381-45b7-aa87-08829ba2e38e"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7538), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System" },
                    { new Guid("743478cc-0688-4fb0-abae-e920cd7a52bd"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7494), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "Name", "UserTypeId" },
                values: new object[] { new Guid("34d442ac-d567-4603-9ff8-f78727330629"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7549), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new Guid("743478cc-0688-4fb0-abae-e920cd7a52bd") });

            migrationBuilder.InsertData(
                table: "userFeatures",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "FeatureId", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("2969947c-a78d-44eb-9c11-0091d5711ef5"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7597), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b8d7034b-176f-46ca-8a77-ddbf8d5518cc"), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34d442ac-d567-4603-9ff8-f78727330629"), "msh200x@gmail.com" },
                    { new Guid("3cb6e6de-914f-4fae-83c1-e6dc65c23eb3"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7589), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d72c5f77-667d-4a73-a426-1f76e18a93b5"), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34d442ac-d567-4603-9ff8-f78727330629"), "09011500119" }
                });

            migrationBuilder.InsertData(
                table: "userGroups",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "GroupId", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "UserId" },
                values: new object[,]
                {
                    { new Guid("6121ab3e-fc99-4cc2-8874-221fea3e77f3"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7582), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f74e22b-04a3-4eda-b7b0-b9e1fe8b963d"), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34d442ac-d567-4603-9ff8-f78727330629") },
                    { new Guid("74efd38f-70c1-4261-aed8-3932800c0df3"), "Seeder", new DateTime(2023, 8, 5, 22, 23, 26, 73, DateTimeKind.Local).AddTicks(7575), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0446761a-0d10-4a85-afb6-c0c0a1ed4fbd"), false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("34d442ac-d567-4603-9ff8-f78727330629") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userFeatures_FeatureId",
                table: "userFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_userFeatures_UserId",
                table: "userFeatures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userGroups_GroupId",
                table: "userGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_userGroups_UserId",
                table: "userGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userFeatures");

            migrationBuilder.DropTable(
                name: "userGroups");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
