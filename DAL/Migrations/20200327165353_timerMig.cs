using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class timerMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Users_UserId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Log",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "hcTHyaEwO9awIU1/QK6EaIux+hM=", "pGNRmCL0soP0Df+oxlJW/A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Users_UserId",
                table: "Log",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Users_UserId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Log",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xfX9++JBjWEDJTirjz8J0pvBkbA=", "C9h3e3JtAoPxD0sI7HT2SA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Users_UserId",
                table: "Log",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
