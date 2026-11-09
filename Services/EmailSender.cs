using ErrorOr;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MimeKit;
using System.Text.RegularExpressions;

namespace Ivory_Coast.Services
{
    public class EmailSender
    {
        private readonly IConfiguration _config;
        private readonly EmailSettings _emailSettings;
        private readonly IWebHostEnvironment _env;
        private readonly IRazorViewEngine _viewEngine;
        private readonly IServiceProvider _serviceProvider;
        private readonly ITempDataProvider _tempDataProvider;

        public EmailSender(
            IConfiguration config,
            IWebHostEnvironment env,
            IRazorViewEngine viewEngine,
            IServiceProvider serviceProvider,
            ITempDataProvider tempDataProvider)
        {
            _config = config;
            _env = env;
            _viewEngine = viewEngine;
            _serviceProvider = serviceProvider;
            _tempDataProvider = tempDataProvider;
            _emailSettings = _config.GetSection("EmailSettings").Get<EmailSettings>()
                ?? new EmailSettings();
        }

        public async Task<ErrorOr<Success>> SendEmailAsync(
            string emailFrom,
            string emailTo,
            string subject,
            string htmlMessage,
            string? senderName = null,
            bool IsRespondible = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailTo))
                    return Error.Validation("EmailTo", "Recipient email is required");

                if (string.IsNullOrWhiteSpace(htmlMessage))
                    return Error.Validation("HtmlMessage", "Email body is required");

                if (!IsValidEmail(emailTo))
                    return Error.Validation("EmailTo", "Invalid recipient email format");

                var message = CreateMimeMessage(emailFrom, emailTo, subject, htmlMessage, senderName, IsRespondible);

                using var smtp = new SmtpClient();
                await ConfigureAndSendSmtpAsync(smtp, message);

                return Result.Success;
            }
            catch (AuthenticationException ex)
            {
                return Error.Failure("SmtpAuthFailed", $"SMTP authentication failed: {ex.Message}");
            }
            catch (SmtpCommandException ex)
            {
                return Error.Failure("SmtpCommandFailed", $"SMTP error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Error.Failure("EmailSendFailed", $"An error occurred: {ex.Message}");
            }
        }

        // NEW METHOD - Uses your Razor view with HomeViewModel
        public async Task<ErrorOr<Success>> SendEmailWithTemplateAsync(
            string emailFrom,
            string emailTo,
            string subject,
            string message,
            string? senderName = null)
        {
            try
            {

                return await SendEmailAsync(
                    emailFrom,
                    emailTo,
                    subject,
                    message,
                    senderName
                );
            }
            catch (Exception ex)
            {
                return Error.Failure("TemplateRenderFailed", $"Failed to render template: {ex.Message}");
            }
        }


        private MimeMessage CreateMimeMessage(
            string emailFrom,
            string emailTo,
            string subject,
            string htmlMessage,
            string? senderName
            , bool IsRespondible)
        {
            var message = new MimeMessage();
            var fromName = senderName != null ? senderName : "Unique Energy Web";
            message.From.Add(new MailboxAddress(fromName, "UniqueGroupMailer@gmail.com"));
            if (IsRespondible == true)
            {
                message.ReplyTo.Add(new MailboxAddress(senderName, emailFrom));
            }

            message.To.Add(new MailboxAddress("", emailTo));




            message.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = htmlMessage,
                TextBody = StripHtml(htmlMessage)
            };

            message.Body = builder.ToMessageBody();
            return message;
        }

        private async Task ConfigureAndSendSmtpAsync(SmtpClient smtp, MimeMessage message)
        {
            smtp.Timeout = 15000;

            SecureSocketOptions secureOptions;
            if (_emailSettings.Port == 465)
                secureOptions = SecureSocketOptions.SslOnConnect;
            else if (_emailSettings.Port == 587)
                secureOptions = SecureSocketOptions.StartTls;
            else
                secureOptions = SecureSocketOptions.Auto;

            await smtp.ConnectAsync(
                _emailSettings.SmtpServer ?? "smtp.gmail.com",
                _emailSettings.Port > 0 ? _emailSettings.Port : 587,
                secureOptions);

            if (!string.IsNullOrEmpty(_emailSettings.Username) &&
                !string.IsNullOrEmpty(_emailSettings.Password) &&
                _emailSettings.Password != " ")
            {
                await smtp.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password.Trim());
            }
            else
            {
                throw new AuthenticationException("Username or password is missing");
            }

            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailboxAddress("", email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string StripHtml(string html)
        {
            if (string.IsNullOrEmpty(html)) return string.Empty;
            return Regex.Replace(html, "<.*?>", string.Empty);
        }

        private async Task<string> LoadAndPopulateTemplateAsync(string content, string recipientEmail)
        {
            var templatePath = Path.Combine(_env.ContentRootPath, "EmailTemplates", "ContactTemplate.html");

            if (!File.Exists(templatePath))
            {
                return $@"
                    <html>
                        <body style='font-family: Arial, sans-serif; padding: 20px;'>
                            <h2>Message</h2>
                            {content}
                            <hr/>
                            <p style='color: #666; font-size: 12px;'>
                                This email was sent to {recipientEmail}
                            </p>
                        </body>
                    </html>";
            }

            var template = await File.ReadAllTextAsync(templatePath);
            template = template
                .Replace("{CONTENT}", content)
                .Replace("{RECIPIENT_EMAIL}", recipientEmail)
                .Replace("{CURRENT_YEAR}", DateTime.Now.Year.ToString())
                .Replace("{COMPANY_NAME}", "Unique Energy")
                .Replace("{WEBSITE_URL}", "https://uniqueenergy.com")
                .Replace("{UNSUBSCRIBE_URL}", "https://uniqueenergy.com/unsubscribe")
                .Replace("{VIEW_ONLINE_URL}", "https://uniqueenergy.com/view-email");

            return template;
        }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
        public bool UseSsl { get; set; } = false;
        public string SenderName { get; set; } = "Unique Energy Mailer";
        public string SenderEmail { get; set; } = "uniqueenergymailer@gmail.com";
        public string Username { get; set; } = "uniquesolutionsmailer@gmail.com";
        public string Password { get; set; } = string.Empty;
    }
}