using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NKC_Resource_Allocation.Migrations
{
    /// <inheritdoc />
    public partial class initTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditors",
                columns: table => new
                {
                    AuditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuditorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditorNRC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NKCAuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditors", x => x.AuditorId);
                });

            migrationBuilder.CreateTable(
                name: "Outlets",
                columns: table => new
                {
                    OutletId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OutletSerialNo = table.Column<int>(type: "int", nullable: false),
                    OutletName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutletCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlets", x => x.OutletId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OutletId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BarrelAndCO2_Res_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrelAndCO2_Res_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrelAndCO2_Res_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrelAndCO2_Res_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrelAndCO2_Res_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrelAndCO2_Res_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrelAndCO2_Res_7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrelAndCO2_Res_8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Machine_Res_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Machine_Res_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Machine_Res_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Machine_Res_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Machine_Res_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorNRCFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorNRCBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Auditors_AuditorId",
                        column: x => x.AuditorId,
                        principalTable: "Auditors",
                        principalColumn: "AuditorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Outlets_OutletId",
                        column: x => x.OutletId,
                        principalTable: "Outlets",
                        principalColumn: "OutletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AuditorId",
                table: "Documents",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OutletId",
                table: "Documents",
                column: "OutletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Auditors");

            migrationBuilder.DropTable(
                name: "Outlets");
        }
    }
}
