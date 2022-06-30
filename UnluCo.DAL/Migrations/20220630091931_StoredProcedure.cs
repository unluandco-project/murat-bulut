using Microsoft.EntityFrameworkCore.Migrations;

namespace UnluCo.DAL.Migrations
{
    public partial class StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetCategories]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Categories
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
