using System.ComponentModel.DataAnnotations;

namespace Ivory_Coast.ViewModels
{
    public class HomeViewModel
    {

        public News Article { get; set; }
        public List<News> NewsList { get; set; }

        public Project ProjectEntity { get; set; }
        public List<Project> Projects { get; set; }
        public ContactForm Email { get; set; }

        public class ContactForm
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Subject { get; set; }

            [EmailAddress]
            public string Email { get; set; }
            public string Phone { get; set; }

            public string Message { get; set; }

            public string Controller { get; set; }
            public string Action { get; set; }
            public string ReturnUrl { get; set; }

            public string? Website { get; set; }      // Common bot target
            public string? FaxNumber { get; set; }    // Another realistic-sounding field

            // Timestamp for time-based bot detection (optional but effective)
            public DateTime? FormStartTime { get; set; }
        }

        public class News
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }

            public string Publication { get; set; }
            public string? Author { get; set; }

            public string Content { get; set; }
            public string Image { get; set; }

            public DateOnly Published { get; set; }
        }

        public class Project
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Location { get; set; }
            public string Category { get; set; }

            public string Challenge { get; set; }

            public string Solution { get; set; }
            public string Introduction { get; set; }
            public DateOnly Completed { get; set; }

            public string FeaturedImage { get; set; }

            public string? FeaturedImage1 { get; set; }
            public string? Placeholder { get; set; }

        }




    }
}
