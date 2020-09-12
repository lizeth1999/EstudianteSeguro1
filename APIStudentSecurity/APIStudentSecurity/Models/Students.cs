

namespace APIStudentSecurity.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Students
    {
        [Key]
        public int StudentID { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "YOU MUST ENTER THE FIELD {0}")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "THE FIELD {0} MUST CONTAIN BETEEN {2} AND {1} CHARACTERS", MinimumLength = 2)]
        [Required(ErrorMessage = "YOU MUST ENTER THE FIELD {0}")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime EnrollmentDate { get; set; }
    }
}