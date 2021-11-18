using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCN2021.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tên Loại")]
        public string Name { get; set; }

        ICollection<Course> Courses { get; set; }
    }
}