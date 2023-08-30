using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mohashan.UserManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    { new Guid("392b2705-8e02-49c2-b157-27c332640f38"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5841), "String", null, null, null, false, null, null, "MobileNumber" },
                    { new Guid("cdcf60cd-fe72-4ce9-84f9-c594a453ba72"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5868), "String", null, null, null, false, null, null, "Email" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("b71e10cf-4d7e-4347-88ca-ffbb851eb2b5"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5947), null, null, false, null, null, "AdminGroup" },
                    { new Guid("f864de16-dd49-4e19-b710-d568c865d747"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5955), null, null, false, null, null, "ReportGroup" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("6ef3262e-8d52-4a76-bada-27f84f227a7e"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5877), null, null, false, null, null, "Human" },
                    { new Guid("d7e652db-56cd-40fe-b370-757a74ca77b5"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5925), null, null, false, null, null, "System" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "Name", "UserTypeId" },
                values: new object[] { new Guid("7f4b464d-cf9b-4174-b1c1-5305ae88785a"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5936), null, null, false, null, null, "Admin", new Guid("6ef3262e-8d52-4a76-bada-27f84f227a7e") });

            migrationBuilder.InsertData(
                table: "userFeatures",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "FeatureId", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("63d9efad-9713-4690-8bbc-eb54e3821b0e"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5987), null, null, new Guid("cdcf60cd-fe72-4ce9-84f9-c594a453ba72"), false, null, null, new Guid("7f4b464d-cf9b-4174-b1c1-5305ae88785a"), "msh200x@gmail.com" },
                    { new Guid("f6318606-bf39-4a75-8559-d668928ba211"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5980), null, null, new Guid("392b2705-8e02-49c2-b157-27c332640f38"), false, null, null, new Guid("7f4b464d-cf9b-4174-b1c1-5305ae88785a"), "09011500119" }
                });

            migrationBuilder.InsertData(
                table: "userGroups",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "GroupId", "IsDeleted", "LastModifiedBy", "LastModifiedDateTime", "UserId" },
                values: new object[,]
                {
                    { new Guid("354960c6-c1ba-4aa9-a1d9-1fe3a193f69a"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5972), null, null, new Guid("f864de16-dd49-4e19-b710-d568c865d747"), false, null, null, new Guid("7f4b464d-cf9b-4174-b1c1-5305ae88785a") },
                    { new Guid("91442ebf-36a4-451e-81f3-003cc7c673ed"), "Seeder", new DateTime(2023, 8, 10, 15, 13, 14, 742, DateTimeKind.Local).AddTicks(5963), null, null, new Guid("b71e10cf-4d7e-4347-88ca-ffbb851eb2b5"), false, null, null, new Guid("7f4b464d-cf9b-4174-b1c1-5305ae88785a") }
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