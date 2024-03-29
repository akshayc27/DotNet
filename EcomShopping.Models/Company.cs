﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcomShopping.Models
{
    public class Company
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAuthorisedCompany { get; set; }
    }
}
