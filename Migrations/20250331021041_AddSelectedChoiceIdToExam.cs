using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamManager.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectedChoiceIdToExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedChoiceId",
                table: "Exams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SelectedChoiceId",
                table: "Exams",
                column: "SelectedChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Choices_SelectedChoiceId",
                table: "Exams",
                column: "SelectedChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Choices_SelectedChoiceId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SelectedChoiceId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "SelectedChoiceId",
                table: "Exams");
        }
    }
}
