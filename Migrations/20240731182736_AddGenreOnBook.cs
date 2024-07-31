using System;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books_api.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreOnBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            ALTER TABLE books ADD COLUMN genre_id uuid,
            ADD CONSTRAINT fk_books_genres FOREIGN KEY (genre_id) REFERENCES genres (id);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE books DROP COLUMN genre_id;");
        }
    }
}

