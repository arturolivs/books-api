using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books_api.Migrations
{
    /// <inheritdoc />
    public partial class AddBookFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            ALTER TABLE books
	            ADD COLUMN description TEXT NULL,
	            ADD COLUMN publication_year INT NULL;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            ALTER TABLE books
	            DROP COLUMN description TEXT NULL,
	            DROP COLUMN publication_year INT NULL;");
        }
    }
}
