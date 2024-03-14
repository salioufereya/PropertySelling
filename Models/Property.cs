using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebApi.Models
{
    public class Property : BaseEntity
    {
        public int Id { get; set; }
        public int SellRent { get; set; }

        public string Name { get; set; }

        public int PropertyTypeId { get; set; }

        public PropertyType PropertyType { get; set; }

        public int BHK { get; set; }

        public int FurnishingTypeId { get; set; }

        public FurnishingType FurnishingType { get; set; }

        public int Price { get; set; }

        public int BuiltArea { get; set; }

        public int CarpetArea { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public int CityId { get; set; }

        public City city { get; set; }

        public int FloorNo { get; set; }

        public int TotalFloors { get; set; }

        public bool ReadyToMove { get; set; }

        public string MainEntrance { get; set; }

        public int Security { get; set; }

        public bool Gated { get; set; }

        public int Maintenance { get; set; }

        public DateTime EstPossession { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public DateTime PostedOn { get; set; }

        [ForeignKey("User")]
        public int PostdBy { get; set; }
        public User User { get; set; }





    }

    
}