using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnCN2021.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Điểm")]
        public float Score { get; set; }

        ICollection<Course> Courses { get; set; }
    }
}