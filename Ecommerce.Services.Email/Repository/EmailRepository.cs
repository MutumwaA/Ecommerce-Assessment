using Ecommerce.Services.Email.DbContexts;
using Ecommerce.Services.Email.Messages;
using Ecommerce.Services.Email.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ecommerce.Services.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        IConfiguration _configuration;
        public EmailRepository(DbContextOptions<ApplicationDbContext> dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task SendAndLogEmail(UpdatePaymentResultMessage message)
        {
            var msg = new MailMessage();

            msg.To.Add(new MailAddress(message.Email));

            msg.From = new MailAddress("noreply@noreply.com", "noreply");
            msg.Subject = "Confirmation";

            var plainView = AlternateView.CreateAlternateViewFromString($"Order - {message.OrderId}  has been created successfully. Thank you for doing business with us", null, "text/plain");

            var htmlView = AlternateView.CreateAlternateViewFromString($"Order - {message.OrderId}  has been created successfully. Thank you for doing business with us", null, "text/html");

            msg.AlternateViews.Add(plainView);
            msg.AlternateViews.Add(htmlView);


            //To be refactored 

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("a026ae7167c6f11", "255a61acac35351");
            client.Port = 587;
            client.Host = "smtp.mailtrap.io";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            client.Send(msg);

            EmailLog emailLog = new EmailLog()
            {
                Email = message.Email,
                EmailSent = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully."
            };

            await using var _db = new ApplicationDbContext(_dbContext);
            _db.EmailLogs.Add(emailLog);
            await _db.SaveChangesAsync();
        }
    }
}
