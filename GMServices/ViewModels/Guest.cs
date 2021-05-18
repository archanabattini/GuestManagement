using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMServices.ViewModels
{
    public class Guest
    {
        public int GuestId { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(100, ErrorMessage = "FirstName can't be longer than 100 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(100, ErrorMessage = "LastName can't be longer than 100 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [StringLength(15, ErrorMessage = "Phone number can't be longer than 15 characters")]
        public string PhoneNumber { get; set; }
    }
}
