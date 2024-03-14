using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{

    [Table("Photos")]
    public class Photo : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsPrimary { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }

    }
}