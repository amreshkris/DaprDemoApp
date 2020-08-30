using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaprDemoApp.Data
{
    public class UserFeedback
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(AllowEmptyStrings = false,ErrorMessage = "first name is required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "last name is required")]
        public string LastName { get; set; }

        public bool DoesLikeSession { get; set; } = true;

        [StringLength(50,ErrorMessage = "Please shorten the message to <50 characters.")]
        public string Message { get; set; }
        public string EmailId { get; set; }
    }
}

