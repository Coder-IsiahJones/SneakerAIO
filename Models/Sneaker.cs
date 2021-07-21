using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerAIO.Models
{
    public class Sneaker
    {
        [Key]
        public int ShoeId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ShoeName { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string StyleCode { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string ColorCode { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal Size { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string Condition { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ReleaseDate { get; set; }
    }
}
