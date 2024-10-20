﻿using System.ComponentModel.DataAnnotations;

namespace Appet.Models
{
    public class ClientDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, MaxLength(100)]
        public string Address { get; set; } = "";

        [Required, MaxLength(9)]
        public string Phone { get; set; } = "";
    }
}
