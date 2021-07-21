using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SneakerAIO.Models
{
    public class SneakerModel
    {
        [Key]
        public int ShoeId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string Shoe { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(15)")]
        [MaxLength(15)]
        public string Style { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(15)")]
        [MaxLength(15)]
        public string Color { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public double Size { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(4)")]
        [MaxLength(4)]
        public string Condition { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "Date")]
        [DisplayName("Release Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Image File")]
        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string ImagePath { get; set; }
    }
}