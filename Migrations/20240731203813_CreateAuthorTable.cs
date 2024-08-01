using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace books_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TABLE authors (
                                    id UUID PRIMARY KEY,
                                    first_name TEXT NOT NULL,
                                    last_name TEXT NOT NULL,
                                    birth_date TIMESTAMP WITH TIME ZONE NOT NULL
                                )");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE authors;");
        }
    }
}
