﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public string ImageUrl{ get; set; }
    }
}
