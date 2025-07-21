using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_list_api.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AspNetUsers_ApplicationUserId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Task",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ApplicationUserId",
                table: "Task",
                newName: "IX_Task_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AspNetUsers_UserId",
                table: "Task",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AspNetUsers_UserId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Task",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UserId",
                table: "Task",
                newName: "IX_Task_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AspNetUsers_ApplicationUserId",
                table: "Task",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
