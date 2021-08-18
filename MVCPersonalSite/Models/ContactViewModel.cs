using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactViewModel
    {
        //Annotations are done in []
        [Required(ErrorMessage = "Ope! Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ope! Please enter your email")]
        [DataType(DataType.EmailAddress)] //this has its own error/required message that displays built in
        public string Email { get; set; }

        [Required (ErrorMessage ="Ope! Please enter a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Ope! Please write your message here")]
        [UIHint("MultilineText")] //provides a text area in the UI
        public string Message { get; set; }

        //private string reCaptcha;

        //public string GetReCaptcha()
        //{
        //    return reCaptcha;
        //}

        //public void SetReCaptcha(string value)
        //{
        //    reCaptcha = value;
        //}
    }
}