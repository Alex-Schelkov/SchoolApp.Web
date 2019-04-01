using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Web.Models
{
    public class Password
    {
        [Required]
        [Display(Name ="Введите пароль")]
        [DataType(DataType.Password)]
        public string Value { get; set; }
    }
}
