using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace Models
{
    public class City : BaseEntity
    {
        public int Id {get;set;}
        public string Name {get;set;}
        
        public DateTime LastUpdateOn {get;set;}
        public int LastUpdatedBy {get;set;}
       [Required]
         public string Country {get;set;}
    }
}