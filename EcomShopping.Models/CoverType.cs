﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcomShopping.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Cover")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


    }
}
