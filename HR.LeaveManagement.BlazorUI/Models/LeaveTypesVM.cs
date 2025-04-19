﻿using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.Models
{
    public class LeaveTypesVM
    {
        public int Id {get; set;}

        [Required]
        public string Name { get; set;}

        [Required]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }
    }
}
