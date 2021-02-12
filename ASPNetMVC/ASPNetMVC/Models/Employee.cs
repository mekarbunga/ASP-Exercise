using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNetMVC.Models
{
    [Table("Tb_M_Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Division Division { get; set; }
        //[Required]
        public virtual Account Account { get; set; }
    }
}