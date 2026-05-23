using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClyvoDayApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    ClinicId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TradeName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.ClinicId);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FullName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ScoreEngagement = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.TutorId);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarians",
                columns: table => new
                {
                    VeterinarianId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FullName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Crmv = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Specialty = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ClinicId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarians", x => x.VeterinarianId);
                    table.ForeignKey(
                        name: "FK_Veterinarians_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Species = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Breed = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Weight = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TutorId1 = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    TutorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pets_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "TutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Tutors_TutorId1",
                        column: x => x.TutorId1,
                        principalTable: "Tutors",
                        principalColumn: "TutorId");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    CareEventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PetId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TypeEvent = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventCompleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.CareEventId);
                    table.ForeignKey(
                        name: "FK_Events_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitorings",
                columns: table => new
                {
                    MonitoringPetId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PetId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Mood = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnergyLevel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Food = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SleepQuality = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RecentActivities = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Medication = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MonitoringDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitorings", x => x.MonitoringPetId);
                    table.ForeignKey(
                        name: "FK_Monitorings_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PetId",
                table: "Events",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitorings_PetId",
                table: "Monitorings",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TutorId",
                table: "Pets",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TutorId1",
                table: "Pets",
                column: "TutorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarians_ClinicId",
                table: "Veterinarians",
                column: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Monitorings");

            migrationBuilder.DropTable(
                name: "Veterinarians");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Tutors");
        }
    }
}
