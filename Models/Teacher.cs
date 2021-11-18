using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCN2021.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tên Giảng viên")]
        public string Name { get; set; }

        public String Image { get; set; }


        ICollection<ListCourseTC> ListCourseTCs { get; set; }
    }
}