﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testAPI.Models
{
    public class CatalogModel
    {
        [Required]
        public int Catalogs_id { get; set; }
        [Required]
        public string Catalogs_name { get; set; }
        [Required]
        public string Catalogs_image { get; set; }
        [Required]
        public Boolean Catalogs_Status { get; set; }
    }
}