using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NKC_Resource_Allocation.Migrations
{
    /// <inheritdoc />
    public partial class updateColsAtDocumentsTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Machine_Res_5",
                table: "Documents",
                newName: "Machine_Res_5_Value");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_4",
                table: "Documents",
                newName: "Machine_Res_5_Name");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_3",
                table: "Documents",
                newName: "Machine_Res_4_Value");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_2",
                table: "Documents",
                newName: "Machine_Res_4_Name");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_1",
                table: "Documents",
                newName: "Machine_Res_3_Value");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_8",
                table: "Documents",
                newName: "Machine_Res_3_Name");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_7",
                table: "Documents",
                newName: "Machine_Res_2_Value");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_6",
                table: "Documents",
                newName: "Machine_Res_2_Name");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_5",
                table: "Documents",
                newName: "Machine_Res_1_Value");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_4",
                table: "Documents",
                newName: "Machine_Res_1_Name");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_3",
                table: "Documents",
                newName: "BarrelAndCO2_Res_8_Value");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_2",
                table: "Documents",
                newName: "BarrelAndCO2_Res_8_Name");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_1",
                table: "Documents",
                newName: "BarrelAndCO2_Res_7_Value");

            migrationBuilder.RenameColumn(
                name: "AuditorNRCFront",
                table: "Documents",
                newName: "BarrelAndCO2_Res_7_Name");

            migrationBuilder.RenameColumn(
                name: "AuditorNRCBack",
                table: "Documents",
                newName: "BarrelAndCO2_Res_6_Value");

            migrationBuilder.AddColumn<string>(
                name: "AuditorNRCBack_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditorNRCBack_Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditorNRCFront_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditorNRCFront_Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_1_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_1_Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_2_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_2_Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_3_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_3_Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_4_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_4_Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_5_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_5_Value",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarrelAndCO2_Res_6_Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditorNRCBack_Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AuditorNRCBack_Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AuditorNRCFront_Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AuditorNRCFront_Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_1_Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_1_Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_2_Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_2_Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_3_Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_3_Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_4_Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_4_Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_5_Name",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_5_Value",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "BarrelAndCO2_Res_6_Name",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_5_Value",
                table: "Documents",
                newName: "Machine_Res_5");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_5_Name",
                table: "Documents",
                newName: "Machine_Res_4");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_4_Value",
                table: "Documents",
                newName: "Machine_Res_3");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_4_Name",
                table: "Documents",
                newName: "Machine_Res_2");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_3_Value",
                table: "Documents",
                newName: "Machine_Res_1");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_3_Name",
                table: "Documents",
                newName: "BarrelAndCO2_Res_8");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_2_Value",
                table: "Documents",
                newName: "BarrelAndCO2_Res_7");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_2_Name",
                table: "Documents",
                newName: "BarrelAndCO2_Res_6");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_1_Value",
                table: "Documents",
                newName: "BarrelAndCO2_Res_5");

            migrationBuilder.RenameColumn(
                name: "Machine_Res_1_Name",
                table: "Documents",
                newName: "BarrelAndCO2_Res_4");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_8_Value",
                table: "Documents",
                newName: "BarrelAndCO2_Res_3");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_8_Name",
                table: "Documents",
                newName: "BarrelAndCO2_Res_2");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_7_Value",
                table: "Documents",
                newName: "BarrelAndCO2_Res_1");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_7_Name",
                table: "Documents",
                newName: "AuditorNRCFront");

            migrationBuilder.RenameColumn(
                name: "BarrelAndCO2_Res_6_Value",
                table: "Documents",
                newName: "AuditorNRCBack");
        }
    }
}
