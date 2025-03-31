using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamManager.Migrations
{
    /// <inheritdoc />
    public partial class FixChoiceRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectChoiceId",
                table: "Exams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CorrectChoiceId",
                table: "Exams",
                column: "CorrectChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Choices_CorrectChoiceId",
                table: "Exams",
                column: "CorrectChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Choices_CorrectChoiceId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CorrectChoiceId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CorrectChoiceId",
                table: "Exams");
        }
    }
}
