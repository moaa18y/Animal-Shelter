using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalShelter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Species = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIndoor = table.Column<bool>(type: "bit", nullable: true),
                    CanFly = table.Column<bool>(type: "bit", nullable: true),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNocturnal = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "CareNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareNotes_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccineDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.VaccineId);
                    table.ForeignKey(
                        name: "FK_Vaccines_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    AdoptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    AdoptedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.AdoptionId);
                    table.ForeignKey(
                        name: "FK_Adoptions_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "AnimalType", "Breed", "CanFly", "Color", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "IsIndoor", "IsNocturnal", "Name", "Size", "Species", "Status", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 3, null, "Golden Retriever", null, null, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(119), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Max", 2, 0, 0, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(121), null },
                    { 2, 2, null, null, null, "Black and White", new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(126), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, null, "Luna", null, 1, 0, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(127), null },
                    { 3, 1, null, null, true, null, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(131), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, "Rio", null, 2, 0, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(133), null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "RoleName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 30, 17, 42, 9, 797, DateTimeKind.Local).AddTicks(5946), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new DateTime(2026, 5, 30, 17, 42, 9, 797, DateTimeKind.Local).AddTicks(5948), null },
                    { 2, new DateTime(2026, 5, 30, 17, 42, 9, 797, DateTimeKind.Local).AddTicks(5953), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new DateTime(2026, 5, 30, 17, 42, 9, 797, DateTimeKind.Local).AddTicks(5954), null },
                    { 3, new DateTime(2026, 5, 30, 17, 42, 9, 797, DateTimeKind.Local).AddTicks(5958), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 0, new DateTime(2026, 5, 30, 17, 42, 9, 797, DateTimeKind.Local).AddTicks(5959), null }
                });

            migrationBuilder.InsertData(
                table: "CareNotes",
                columns: new[] { "Id", "AnimalId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsDeleted", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(266), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Needs at least 30 minutes of daily exercise. Loves playing fetch.", false, "Daily Exercise", new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(268), null },
                    { 2, 2, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(272), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Allergic to chicken. Feed only fish-based food.", false, "Special Diet", new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(273), null },
                    { 3, 3, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(277), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Needs a large cage with space to fly. Prefers morning sun.", false, "Cage Requirements", new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(278), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "RoleId", "UpdatedAt", "UpdatedBy", "UserEmail", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 30, 17, 42, 9, 927, DateTimeKind.Local).AddTicks(5938), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new DateTime(2026, 5, 30, 17, 42, 9, 927, DateTimeKind.Local).AddTicks(6038), null, "john.admin@animalshelter.com", "admin_john", "$2a$11$K7EluGDZikTYuvI.dgNW8O/jLSKEPTL03CMx6KmFHP1PlDWaH1Z3W" },
                    { 2, new DateTime(2026, 5, 30, 17, 42, 10, 45, DateTimeKind.Local).AddTicks(1928), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new DateTime(2026, 5, 30, 17, 42, 10, 45, DateTimeKind.Local).AddTicks(2030), null, "sarah.admin@animalshelter.com", "admin_sarah", "$2a$11$S366zA8udR1DYA/3OYegzuggJT5s1ls0LBkalwWRNnTanzL2dOkre" },
                    { 3, new DateTime(2026, 5, 30, 17, 42, 10, 174, DateTimeKind.Local).AddTicks(7795), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new DateTime(2026, 5, 30, 17, 42, 10, 174, DateTimeKind.Local).AddTicks(7891), null, "mike.employee@animalshelter.com", "employee_mike", "$2a$11$QcTo7mobeq/6.esU3fPpQ.aytwsNO9oJfrzjE9FDnGDltjwGJj1r2" },
                    { 4, new DateTime(2026, 5, 30, 17, 42, 10, 303, DateTimeKind.Local).AddTicks(3875), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new DateTime(2026, 5, 30, 17, 42, 10, 303, DateTimeKind.Local).AddTicks(3963), null, "lisa.employee@animalshelter.com", "employee_lisa", "$2a$11$uby4o6683yPjssA25dPAVOrQVsx7gXXcVlCEfR2qNUoBQzm6OMWAi" },
                    { 5, new DateTime(2026, 5, 30, 17, 42, 10, 432, DateTimeKind.Local).AddTicks(3030), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new DateTime(2026, 5, 30, 17, 42, 10, 432, DateTimeKind.Local).AddTicks(3118), null, "emma.user@example.com", "user_emma", "$2a$11$1R1l3Od.mF1z/ORy/KHIZumNbt7VfRA7r8CnOkbxa3NdCTDCH91pS" },
                    { 6, new DateTime(2026, 5, 30, 17, 42, 10, 556, DateTimeKind.Local).AddTicks(1141), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new DateTime(2026, 5, 30, 17, 42, 10, 556, DateTimeKind.Local).AddTicks(1241), null, "james.user@example.com", "user_james", "$2a$11$Spo5eeFBV6R5gT4FulvoGO.ie5TvRUGKnvjFBns1OQqKl.K/LaDBa" },
                    { 7, new DateTime(2026, 5, 30, 17, 42, 10, 681, DateTimeKind.Local).AddTicks(9122), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new DateTime(2026, 5, 30, 17, 42, 10, 681, DateTimeKind.Local).AddTicks(9219), null, "sophia.user@example.com", "user_sophia", "$2a$11$FHtY7ArLHNrN1wS0F94HueBYG2iXLo2FLWBFSdXyK6Bv2eTgzZaK6" }
                });

            migrationBuilder.InsertData(
                table: "Vaccines",
                columns: new[] { "VaccineId", "AnimalId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "UpdatedAt", "UpdatedBy", "VaccineDate", "VaccineDescription", "VaccineName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(199), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(201), null, new DateTime(2026, 3, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(191), "Rabies vaccination", "Rabies" },
                    { 2, 1, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(207), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(209), null, new DateTime(2026, 4, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(205), "Canine distemper vaccination", "Distemper" },
                    { 3, 2, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(215), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2026, 5, 30, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(217), null, new DateTime(2026, 2, 28, 17, 42, 10, 682, DateTimeKind.Local).AddTicks(213), "Feline viral rhinotracheitis, calicivirus, and panleukopenia", "FVRCP" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_AnimalId",
                table: "Adoptions",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_UserId",
                table: "Adoptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CareNotes_AnimalId",
                table: "CareNotes",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_AnimalId",
                table: "Vaccines",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "CareNotes");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
