using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

public class PropertySeeder
{
    private readonly DataContext _context;

    public PropertySeeder(DataContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.Properties.Any())
        {
            var property = new Property
            {
                SellRent = 1, // Exemple de valeur pour SellRent
                Name = "White House Demo",
                PropertyTypeId = _context.PropertyTypes.FirstOrDefault(pt => pt.Name == "Apartment").Id,
                BHK = 2,
                FurnishingTypeId = _context.FurnishingTypes.FirstOrDefault(ft => ft.Name == "Fully").Id,
                Price = 1800,
                BuiltArea = 1400,
                CarpetArea = 900,
                Address = "6 Street",
                Address2 = "Golf Course Road",
                CityId = _context.Cities.FirstOrDefault().Id, // Assurez-vous d'avoir des villes dans votre base de données
                FloorNo = 3,
                TotalFloors = 3,
                ReadyToMove = true,
                MainEntrance = "East",
                Security = 0,
                Gated = true,
                Maintenance = 300,
                EstPossession = new DateTime(2019, 1, 1),
                Age = 0,
                Description = "Well Maintained builder floor available for rent at prime location...",
                PostedOn = DateTime.Now,
                PostdBy = _context.Users.FirstOrDefault(u => u.Username == "Demo").Id // Assurez-vous d'avoir un utilisateur avec le nom d'utilisateur "Demo" dans votre base de données
            };

            _context.Properties.Add(property);
            _context.SaveChanges();
        }
    }
}
