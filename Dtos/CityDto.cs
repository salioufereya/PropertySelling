using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class CityDto
    {
        public int Id {get;set;}

[Required (ErrorMessage ="Name is mandatory field")]
[StringLength(50,MinimumLength =2)]
[RegularExpression(".*[a-zA-Z0-9]+.*",ErrorMessage ="Only numerics are not allowed")]
        public string Name {get;set;}
        
        [Required]
         public string Country {get;set;}
    }
}