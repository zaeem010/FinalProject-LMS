﻿using System.ComponentModel.DataAnnotations;

namespace FinalProject_LMS.Models
{
    public class ActivityType
    {
      
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}