using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class dateNonClusterMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "PhE9iCf5YrltYEmj/47i1epe2dM=", "JU6KifvOxMCyaa5w2tbHSA==" });

            migrationBuilder.CreateIndex(
                name: "Date_Range",
                table: "Log",
                columns: new[] { "EnteredDate", "LeftDate" })
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Date_Range",
                table: "Log");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "hcTHyaEwO9awIU1/QK6EaIux+hM=", "pGNRmCL0soP0Df+oxlJW/A==" });
        }
    }
}
