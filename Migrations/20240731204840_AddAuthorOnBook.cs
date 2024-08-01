using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books_api.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorOnBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            ALTER TABLE books ADD COLUMN author_id uuid,
            ADD CONSTRAINT fk_books_authors FOREIGN KEY (author_id) REFERENCES authors (id) ON DELETE CASCADE;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE books DROP COLUMN author_id;");
        }
    }
}
