using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace VetKlinik.Data
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Email gönderme işlemleri burada yapılacak. (ilerde)
            return Task.CompletedTask;
        }
    }
}
