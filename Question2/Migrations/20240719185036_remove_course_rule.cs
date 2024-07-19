using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagement.Migrations
{
    /// <inheritdoc />
    public partial class remove_course_rule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__CourseCat__categ__31EC6D26",
                table: "CourseCategoryAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK__CourseCat__cours__30F848ED",
                table: "CourseCategoryAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK__CourseCat__categ__31EC6D26",
                table: "CourseCategoryAssignments",
                column: "category_id",
                principalTable: "CourseCategories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__CourseCat__cours__30F848ED",
                table: "CourseCategoryAssignments",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__CourseCat__categ__31EC6D26",
                table: "CourseCategoryAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK__CourseCat__cours__30F848ED",
                table: "CourseCategoryAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK__CourseCat__categ__31EC6D26",
                table: "CourseCategoryAssignments",
                column: "category_id",
                principalTable: "CourseCategories",
                principalColumn: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK__CourseCat__cours__30F848ED",
                table: "CourseCategoryAssignments",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id");
        }
    }
}
