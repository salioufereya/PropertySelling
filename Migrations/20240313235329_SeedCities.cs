using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            -- Seed Cities
INSERT INTO Cities(Name, LastUpdatedBy, LastUpdatedOn, Country)
SELECT 'New York', (SELECT Id FROM Users WHERE Username = 'Demo'), NOW(), 'USA'
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM Cities WHERE Name = 'New York');

INSERT INTO Cities(Name, LastUpdatedBy, LastUpdatedOn, Country)
SELECT 'Houston', (SELECT Id FROM Users WHERE Username = 'Demo'), NOW(), 'USA'
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM Cities WHERE Name = 'Houston');

INSERT INTO Cities(Name, LastUpdatedBy, LastUpdatedOn, Country)
SELECT 'Los Angeles', (SELECT Id FROM Users WHERE Username = 'Demo'), NOW(), 'USA'
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM Cities WHERE Name = 'Los Angeles');

INSERT INTO Cities(Name, LastUpdatedBy, LastUpdatedOn, Country)
SELECT 'New Delhi', (SELECT Id FROM Users WHERE Username = 'Demo'), NOW(), 'India'
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM Cities WHERE Name = 'New Delhi');

INSERT INTO Cities(Name, LastUpdatedBy, LastUpdatedOn, Country)
SELECT 'Bangalore', (SELECT Id FROM Users WHERE Username = 'Demo'), NOW(), 'India'
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM Cities WHERE Name = 'Bangalore');
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
