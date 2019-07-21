using System.ComponentModel.DataAnnotations;

namespace UserCrud.WebUI.ViewModels
{
    public class UserDetailViewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}