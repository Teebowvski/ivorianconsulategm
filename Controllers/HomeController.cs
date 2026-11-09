using AspNetCore.Honeypot;
using Ivory_Coast.Models;
using Ivory_Coast.Repo;
using Ivory_Coast.Services;
using Ivory_Coast.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;


namespace Ivory_Coast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsRepository _newsRepository;
        private readonly EmailSender _emailSender;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, INewsRepository newsRepository, EmailSender emailSender, IWebHostEnvironment environment)
        {
            _logger = logger;
            _newsRepository = newsRepository;
            _emailSender = emailSender;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsRepository.GetAllNewsAsync();

            var vm = new HomeViewModel
            {
                NewsList = news
            };
            return View(vm);
        }


        [Route("About-Us")]
        public async Task<IActionResult> About()
        {
            return View();
        }

        [Route("Services")]

        public IActionResult Services()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("News")]
        public async Task<IActionResult> NewsList()
        {
            var news = await _newsRepository.GetAllNewsAsync();

            var vm = new HomeViewModel
            {
                NewsList = news
            };
            return View(vm);
        }

        [Route("News/{id?}")]
        public async Task<IActionResult> News(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return RedirectToAction("NewsList");
            }
            var articles = await _newsRepository.GetAllNewsAsync();
            var news = await _newsRepository.GetNewsByIdAsync(id.Value);
            if (news == null)
            {
                //return RedirectToAction(nameof(ErrorPage));
            }

            var vm = new HomeViewModel
            {
                Article = news,
                NewsList = articles
            };
            return View(vm);
        }

        [HttpGet]
        [Route("Services/Visa-Travel-Information")]
        public IActionResult Visa()
        {
            return View();
        }

        [HttpGet]
        [Route("Services/Visa-Travel-Information/Student-Visa")]
        public IActionResult StudentVisa()
        {
            return View();
        }

        [HttpGet]
        [Route("Services/Visa-Travel-Information/Tourist-Visa")]
        public IActionResult TouristVisa()
        {
            return View();
        }

        [HttpGet]
        [Route("Services/Visa-Travel-Information/Business-Visa")]
        public IActionResult BusinessVisa()
        {
            return View();
        }

        [HttpGet]
        [Route("Services/Visa-Travel-Information/Working-Visa")]
        public IActionResult WorkingVisa()
        {
            return View();
        }

        [HttpGet]
        [Route("Services/Visa-Travel-Information/Family-Visa")]
        public IActionResult FamilyVisa()
        {
            return View();
        }


        [Route("Services/Passport-Services")]
        public IActionResult Passport()
        {
            return View();
        }

        [Route("Services/Citizenship-&-Nationality")]
        public IActionResult Citizenship()
        {
            return View();
        }

        [Route("Services/Counsular-Assistance")]
        public IActionResult CounsularAssistance()
        {
            return View();
        }


        [Route("Gallery")]
        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Blogs()
        {
            return View();
        }


        [Route("Gallery/Vlogs")]
        public IActionResult Vlogs()
        {
            return View();
        }

        [Route("Press-&-Events/Events/")]
        public IActionResult Events()
        {
            return View();
        }

        [Route("Press-&-Events/Events/CAN-2027")]
        public IActionResult CAN()
        {
            return View();
        }


        [Route("Press-&-Events/Official-Statements")]
        public IActionResult Statements()
        {
            return View();
        }

        [Route("Press-&-Events/Official-Statements/Message-To-Ivorian-Community")]
        public IActionResult Community()
        {
            return View();
        }


        [Route("Press-&-Events/Official-Statements/Message-to-Our-Gambian-Brothers-&-Partners")]
        public IActionResult GamMessage()
        {
            return View();
        }

        [Route("Invest-In-Ivory-Coast")]
        public IActionResult Invest()
        {
            return View();
        }

        [Route("Contact/Faqs")]
        public IActionResult Faqs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Download/Invest-In-Ivory-Coast-PDF")]
        public IActionResult Download()
        {
            var path = Path.Combine(_environment.WebRootPath, "Downloadables", "ed602e_a7f8c4ce5360447684b572ea5aa0faba.pdf");

            if (!System.IO.File.Exists(path))
            {
                return NotFound();   // 404
            }

            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/pdf", "Invest-In-Ivory-Coast.pdf");
        }


        [Honeypot]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(HomeViewModel viewModel)
        {


            // Default values
            string controller = "Home";
            string action = "Contact";


            var req = viewModel.Email;
            if (req == null)
            {
                TempData["FailedMessage"] = $"Send email request failed! Email details are required. ";
                return RedirectToAction(action, controller);
            }

            controller = req.Controller;
            action = req.Action;

            if (req.Website != null || req.FaxNumber != null)
            {
                TempData["Success"] = "Thank you for contacting us!";
                return RedirectToAction(action, controller);
            }


            // Validate email
            if (string.IsNullOrEmpty(req.Email))
            {
                TempData["FailedMessage"] = "Send email request failed! Email details are required.";
                return RedirectToAction(action, controller);
            }



            if (string.IsNullOrEmpty(req.FirstName))
            {
                TempData["FailedMessage"] = $"Send email request failed! Email 'First Name' is required. ";
                return RedirectToAction(action, controller);
            }


            if (string.IsNullOrEmpty(req.LastName))
            {
                TempData["FailedMessage"] = $"Send email request failed! Email 'Last Name' is required. ";
                return RedirectToAction(action, controller);
            }



            if (string.IsNullOrEmpty(req.Email))
            {
                TempData["FailedMessage"] = $"Send email request failed! Email 'Email' is required. ";
                return RedirectToAction(action, controller);
            }


            if (string.IsNullOrEmpty(req.Phone))
            {
                TempData["FailedMessage"] = $"Send email request failed! Email 'Phone' is required. ";
                return RedirectToAction(action, controller);
            }


            if (string.IsNullOrEmpty(req.Message))
            {
                TempData["FailedMessage"] = $"Send email request failed! Email 'Message' is required. ";
                return RedirectToAction(action, controller);
            }

            if (string.IsNullOrEmpty(req.Subject))
            {
                TempData["FailedMessage"] = $"Send email request failed! Email 'Subject' is required. ";
                return RedirectToAction(action, controller);
            }

            string? subject = req.Subject;
            string? emailTo = "mjobe@unique.gm";

            // Helper method (put it in a static class or in the same class)
            static string Capitalize(string input)
            {
                if (string.IsNullOrEmpty(input)) return input;
                return char.ToUpper(input[0]) + input.Substring(1);
            }

            // Usage in your code
            var firstName = Capitalize(req.FirstName?.Trim() ?? "");
            var lastName = Capitalize(req.LastName?.Trim() ?? "");

            var messageText = System.Net.WebUtility.HtmlEncode(req.Message)
                .Replace("\r\n", "<br>")
                .Replace("\n", "<br>")
                .Replace("\r", "<br>");

            var message = new TextPart("html")
            {
                Text = $@"
    <div style='font-family: Arial, sans-serif; max-width: 600px; border: 1px solid #eee; border-radius: 10px; padding: 20px;'>
         
        <p style='margin-bottom: 5px;'><strong>Name:</strong> {firstName} {lastName}</p>
        <p style='margin-bottom: 5px;'><strong>Email:</strong> <a href='mailto:{req.Email}'>{req.Email}</a></p>
        <p style='margin-bottom: 5px;'><strong>Subject:</strong> {subject}</p>
        <p style='margin-bottom: 15px;'><strong>Phone:</strong> {req.Phone}</p>
        
        <div style='background-color: #f9f9f9; border-left: 4px solid #ea580c; padding: 15px; color: #555; font-style: italic;'>
            {messageText}
        </div>
        
        <p style='font-size: 12px; color: #aaa; margin-top: 20px; text-align: center;'>
            This message was sent via the Ivorian consulate website mailer.
        </p>
    </div>"
            };

            var mailRequest = await _emailSender.SendEmailAsync(req.Email, emailTo, subject, message.Text, $"{req.FirstName} {req.LastName}", true);
            if (mailRequest.IsError)
            {
                TempData["FailedMessage"] = $"Send email request failed!{mailRequest.Errors.FirstOrDefault().Description}";
                return RedirectToAction(action, controller);
            }

            await SendAutoReplyAsync(req.Email, firstName, subject, emailTo);
            TempData["SuccessMessage"] = $"Email has been sent succesfully!";
            return RedirectToAction(action, controller);
        }


        private async Task SendAutoReplyAsync(string userEmail, string firstName, string subject, string emailTo)
        {
            try
            {
                var autoReplyHtml = $@"
              <p class=""mb-2 text-gray-500 dark:text-gray-400"">Hi {firstName}!</h2>
              <p class=""mb-2 text-gray-500 dark:text-gray-400"">We have received your message and will get back to you within 24-48 hours.</p>
              <p class=""mb-2 text-gray-500 dark:text-gray-400"">Best regards,<br/>Honorary Consulate of Côte d'Ivoire Team</p>
                                <table class=""wInner"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""width: 500px;"">
                                    <tr>
                                        <td class=""header"" align=""left"" valign=""middle"">
                                            <!--light mode logo-->
                                            <a href=""https://ivorianconsulategm.org"" target=""_blank"">
                               
                                                <img class="""" src=""https://localhost:7021/assets/images/logo.png"" width=""200"" height=""40"" alt=""wonderblum"" style=""color: #4a4a4a; text-align:center; font-weight:bold; font-size:24px; line-height:28px; text-decoration: none; padding: 0; display: none;"" border=""0"" />
                                                <!--<![endif]-->
                                            </a>
                                        </td>
                                    </tr>
                                </table>
        ";

                var result = await _emailSender.SendEmailAsync(
                    emailFrom: emailTo,
                    emailTo: userEmail,
                    subject: subject,
                    htmlMessage: autoReplyHtml,
                    senderName: "Honorary Consulate of Côte d'Ivoire Web Autoreply",
                    IsRespondible: false
                );

                if (result.IsError)
                {
                    _logger.LogWarning("Failed to send auto-reply to {UserEmail}: {Errors}",
                        userEmail,
                        string.Join(", ", result.Errors));
                }
            }
            catch (Exception ex)
            {
                // Don't fail the main request if auto-reply fails
                _logger.LogWarning(ex, "Failed to send auto-reply to {UserEmail}", userEmail);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
