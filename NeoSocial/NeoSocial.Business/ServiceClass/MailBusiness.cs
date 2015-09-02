using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;
using System.Net;
using System.Net.Mail;



namespace NeoSocial.Business
{
    
  public  class MailBusiness :IMailBusiness

    {
        UserContext _userContext;
       

        public MailBusiness() {

            _userContext = new UserContext(new DbContextFactory());
        
        }

        public List<UserLogin> findPassword(int registerID) {

            int id = registerID;

             return _userContext.UserLoginRepository.Get(x => x.UserRegisterID == id).ToList();

            
        
        }

        public void sendMail(Mail mail) {

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("mertkozcan@outlook.com", "");

            MailMessage mm = new MailMessage(mail.FromEmail, mail.ToEmail, mail.Subject, mail.Message);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        
        }



    }
}
