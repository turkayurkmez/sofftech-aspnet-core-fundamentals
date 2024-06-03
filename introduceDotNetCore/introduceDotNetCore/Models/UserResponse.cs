using System.ComponentModel.DataAnnotations;

namespace introduceDotNetCore.Models
{
    public class UserResponse
    {
        [Required(ErrorMessage = "Lütfen isminizi girin")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Eposta formatı doğru değil")]
        [Required(ErrorMessage = "Lütfen epostanızı girin")]

        public string Email { get; set; }


        public bool IsApproved { get; set; }
    }
}
