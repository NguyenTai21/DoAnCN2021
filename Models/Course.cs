using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnCN2021.Models
{
    public class Course
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Tên Khoá học")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public string UrlImage { get; set; }

        [DisplayName("Giá Tiền")]
        public Double Price { get; set; }





        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        ICollection<ListCourseTC> ListCourseTCs { get; set; }
        ICollection<ListCourse> ListCourses { get; set; }
    }
}