using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerSystem.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "ID is required")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname{ get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Town is required")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "E-Mail Address is required")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Display(Name = "Date-of-Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="Date-of-Birth is required")]
        [DataType(DataType.DateTime)]         
        public DateTime Date_of_birth { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }
    }
}