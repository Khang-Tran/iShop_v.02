﻿using System;
using System.ComponentModel.DataAnnotations;

namespace iShop.Common.DTOs
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Ward { get; set; }
        [StringLength(50)]
        public string District { get; set; }   
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
    }
}
