namespace ADOCrud.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    public class Employee
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string NAME { get; set; }

        [Required]
        public string  EMAIL { get; set; }
    }
}