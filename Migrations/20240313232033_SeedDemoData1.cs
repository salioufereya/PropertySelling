using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 migrationBuilder.Sql(@"
             INSERT INTO PropertyTypes(Name, LastUpdatedOn, LastUpdatedBy)
SELECT 'House', NOW(), (SELECT Id FROM Users WHERE Username = 'Demo')
WHERE NOT EXISTS (SELECT Name FROM PropertyTypes WHERE Name = 'House');

INSERT INTO PropertyTypes(Name, LastUpdatedOn, LastUpdatedBy)
SELECT 'Apartment', NOW(), (SELECT Id FROM Users WHERE Username = 'Demo')
WHERE NOT EXISTS (SELECT Name FROM PropertyTypes WHERE Name = 'Apartment');

INSERT INTO PropertyTypes(Name, LastUpdatedOn, LastUpdatedBy)
SELECT 'Duplex', NOW(), (SELECT Id FROM Users WHERE Username = 'Demo')
WHERE NOT EXISTS (SELECT Name FROM PropertyTypes WHERE Name = 'Duplex');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql(@"
       
    ");
}
    }
}
