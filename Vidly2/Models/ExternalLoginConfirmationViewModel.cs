using System.ComponentModel.DataAnnotations;

namespace Vidly2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // add DrivingLicence prop to the ExternalLoginConfirmatioViewModel 
        // so external authentication does not fail
        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        // add Phone prop to the ExternalLoginConfirmationViewModel so we can use it 
        // for Social logins
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
