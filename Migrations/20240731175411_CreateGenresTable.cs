using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateGenresTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE genres (
	            id uuid NOT NULL,
	            name text NOT NULL,
	            CONSTRAINT PK_genres PRIMARY KEY (id)
            );");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE genres;");

        }
    }
}
