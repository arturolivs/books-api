using System;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books_api.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleAndAuthorUK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE books ADD CONSTRAINT uk_books_title_author_id UNIQUE (title, author_id);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE books DROP CONSTRAINT uk_books_title_author_id;");
        }
    }
}




