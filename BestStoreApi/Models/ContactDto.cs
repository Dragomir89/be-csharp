﻿using System.ComponentModel.DataAnnotations;

namespace BestStoreApi.Models
{
    public class ContactDto
    {
        
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = "";

        [Required, MaxLength(100)]
        public string LastName { get; set; } = "";

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = "";

        [MaxLength(100)]
        public string? Phone { get; set; }

        [Required, MaxLength(100)]
        public string Subject { get; set; } = "";

        [Required]
        public string Message { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
