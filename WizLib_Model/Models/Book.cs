﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WizLib_Model.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }
        [Required]
        public double Price { get; set; }        
        [ForeignKey("Category")]
        public int Category_id { get; set; }
        public Category Category { get; set; }
    }
}