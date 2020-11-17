using Microsoft.EntityFrameworkCore.Migrations;

namespace MedClinicalAPI.Migrations
{
    public partial class added_serviceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Records",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_ServiceId",
                table: "Records",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Services_ServiceId",
                table: "Records",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Services_ServiceId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_ServiceId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Records");
        }
    }
}
