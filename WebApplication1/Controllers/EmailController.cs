using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net; //added this for email
using System.Configuration; //added this for email
using System.Net.Mail; //added this for email 
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult Contact()
        {//when we added a view here, we used create and checked the use scripts checkbox
            return View();
        }

        [HttpPost] //need this
        [ValidateAntiForgeryToken] //and this
        public ActionResult Contact(ContactViewModel cvm)
        {//when we added a view here, we used create and checked the use scripts checkbox
            //It is best practice to confirm the "state" of the model. There's a strict definition of what the cvm (what we named above) is and will accept. We need to check the model state:
            if (!ModelState.IsValid) //behind the scenes it will take cvm that was passed in through the View and will check to see how it compares to the definition ContactViewModel. If they're not the same, it's invalid. If they are the same, then we'll return the view below. That's the only time we want the view returned.
            {
                //  Send them back to the form, by passing the object to the view, the form returns with the original populated information.
                return View(cvm); //entering this here will make it where the user doesn't have to re-enter everything again, even if there is an error, it will allow them to just fix the error.
            }
            //Below code only executes if the form (object) passes model validation

            //Build the response message back to the user:
            string returnMessage = $"You have received an email from {cvm.Name} with a subject " +
                 $"{cvm.Subject}.  Please respond to {cvm.Email} with your response to " +
                 $"the following message:\n {cvm.Message}";

            Boolean isMailSetUp = true; //if we have an issue in the email setup code, don't want code to run
            //this lets us toggle between whether email works or not
            if (isMailSetUp)
            {
                // Add using statement for the System Mail
                //Mailmessage Package is what sends the email ( using System.Net.Mail)
                MailMessage mm = new MailMessage(
                    //This is who the email is from - the email user
                    ConfigurationManager.AppSettings["EmailUser"].ToString(),
                    //This is who the email is to
                    ConfigurationManager.AppSettings["EmailTo"].ToString(),
                    //email subject and return message
                    cvm.Subject,
                    returnMessage
                    );

                //MailMessage properties
                //Allow HTML formatting
                mm.IsBodyHtml = true;

                //Set the Mail priority
                mm.Priority = MailPriority.High; //default is normal priority

                //Set a reply list
                mm.ReplyToList.Add(cvm.Email);

                // SmtpClient - This is the information from the HOST (smarterAsp.net) that allows the email to actually be sent
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

                //  Client credentials (smarterASP requires your user name and password)
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(), ConfigurationManager.AppSettings["EmailPassword"].ToString());

                //  It is possible that the mailserver is down or we may have configuration issues, so we want to encapsulate our code in a try/catch
                try
                {
                    //Attempt to send the email
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    ViewBag.CustomerMessage = $"Ope. Looks like that didn't work. Please try again later. Error Message:\n {ex.StackTrace}"; //not common practice to actually include the StackTrace error message
                    return View(cvm); //this will repopulate the form for them instead of wiping it all and user has to re-enter everything
                    //throw;
                }//end try catch
            }//end if

            return View("EmailConfirmation", cvm); //message letting them know their email was successful
            //when we created this view, we selected Empty but not the without template, selected the controller, unchecked scripts 
            //make sure to include cvm! otherwise it totally doesn't work

        }//end actionresult
    }
}