using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ReservationViewModel
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        public string UserName { get; set; } // see about it in controller
    }
}