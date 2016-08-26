using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class UnbookViewModel
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        public string UserName { get; set; } // see about it in controller
    }
}