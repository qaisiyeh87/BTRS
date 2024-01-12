using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Login
    {
        [Required(ErrorMessage = "please enter the username")]
        public string username { set; get; }
        [Required(ErrorMessage = "please enter the password")]
        public string password { set; get; }

    }
}
