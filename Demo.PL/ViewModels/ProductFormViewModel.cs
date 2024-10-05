using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModels
{
    public class ProductFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required...!!!")]
        [MaxLength(50, ErrorMessage = "Name Max Length Is 50 char...!!!")]
        [MinLength(4, ErrorMessage = "Name Min Length Is 4 char...!!!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Code Is Required...!!!")]
        [MaxLength(5, ErrorMessage = "Name Max Length Is 5 char...!!!")]
        [MinLength(2, ErrorMessage = "Name Min Length Is 2 char...!!!")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "Price Is Required...!!!")]
        [Range(200, 2000)]
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
