using System;
using System.Collections.Generic;
using System.Text;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizLib_Model.Models;

namespace WizLib_Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }

        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
