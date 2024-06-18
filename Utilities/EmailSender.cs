using Microsoft.AspNetCore.Identity.UI.Services;

namespace ProyectoProgramadoLenguajes2024.Utilities
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
