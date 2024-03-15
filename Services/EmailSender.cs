using FluentEmail.Core;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebPWrecover.Services;

public class EmailSender

{
    internal class AuthMessageSenderOptions
    {
        private static void Main()
        {
            Execute().Wait(); 
        }
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("12345");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("hogescu_didii@yahoo.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
// {
//     private readonly ILogger _logger;

//     public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, ILogger<EmailSender> logger)
//     {
//         Options = optionsAccessor.Value;
//         _logger = logger;
//     }

//     public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

//     public async Task sendEmailAsync(string toEmail, string subject, string message)
//     {
//         if(string.IsNullOrEmpty(Options.SendGridKey))
//         {
//             throw new Exception("SendGridKey is not set.");
//         }

//         await Execute(Options.SendGridKey, subject, message, toEmail);
//     }    
    
//     public async Task Execute(string apiKey, string subject, string message, string email)
//     {
//         var client = new SendGridClient(apiKey);
//         var msg = new SendGridMessage()
//         {
//             From = new EmailAddress("nobaror136@cmheia.com", "Password Recovery"),
//             Subject = subject,
//             PlainTextContent = message,
//             HtmlContent = message
//         };
//         msg.AddTo(new EmailAddress(email));

//         msg.SetClickTracking(false, false);
//         var response = await client.SendEmailAsync(msg);
//         _logger.LogInformation(response.IsSuccessStatusCode
//         ? $"Email to {email} sent successfully."
//         : $"Failure Email to {email}");
// }

//     public Task SendEmailAsync(string email, string subject, string htmlMessage)
//     {
//         throw new NotImplementedException();
//     }
// }
    
    
    