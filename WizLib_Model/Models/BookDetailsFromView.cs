using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WizLib_Model.Models
{
    public class BookDetailsFromView
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
