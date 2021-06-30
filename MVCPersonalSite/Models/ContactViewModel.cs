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
        [Required(ErrorMessage = "*Name is required")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)] //this has its own error/required message that displays built in
        public string Email { get; set; }

        [Required (ErrorMessage ="Please enter a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please write your message here")]
        [UIHint("MultilineText")] //provides a text area in the UI
        public string Message { get; set; }
    }
}