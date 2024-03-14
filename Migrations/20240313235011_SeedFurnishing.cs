using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedFurnishing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         migrationBuilder.Sql(@"
       -- Seed Furnishing Types (Fully)
INSERT INTO FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
SELECT 'Fully', NOW(), (SELECT Id FROM Users WHERE Username = 'Demo')
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM FurnishingTypes WHERE Name = 'Fully');

-- Seed Furnishing Types (Semi)
INSERT INTO FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
SELECT 'Semi', NOW(), (SELECT Id FROM Users WHERE Username = 'Demo')
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM FurnishingTypes WHERE Name = 'Semi');

-- Seed Furnishing Types (Unfurnished)
INSERT INTO FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
SELECT 'Unfurnished', NOW(), (SELECT Id FROM Users WHERE Username = 'Demo')
FROM dual
WHERE NOT EXISTS (SELECT 1 FROM FurnishingTypes WHERE Name = 'Unfurnished');


         ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
