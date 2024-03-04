using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;

namespace TblDemoApi.Models
{
    /*
     @Rollno int
, @Name varchar(50)
, @Email varchar(50)
, @Password varchar(50)
, @DOB date
, @Mobile varchar(30)
, @Gender varchar(20)
, @Fee numeric(18,2)
, @Dept varchar(40)
, @Status
     */
    [Table("Tbl_Demo")]
    public class TblDemoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Rollno { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public decimal Fee { get; set; }
        public string Dept { get; set; }
        public bool Status { get; set; }
    }
}
