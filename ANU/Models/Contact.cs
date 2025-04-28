using System;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> 7f9970e15257d02782aba5458dc5b731517a9e5b

namespace ANU.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;
<<<<<<< HEAD
        [NotMapped]
        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;
        [NotMapped]
=======

        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;

>>>>>>> 7f9970e15257d02782aba5458dc5b731517a9e5b
        public bool IsRead { get; set; } = false;
    }
}
