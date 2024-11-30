using System.ComponentModel.DataAnnotations;

namespace ScoreManagement.Model.student_test
{
    public class student_test
    {
        [Key]
        public int row_id { get; set; }
        public string? student_code { get; set; }

        public string? student_name { get; set; }

        public string? university { get; set; }

        public string? faculty { get; set; }

        public string? major { get; set; }
    }
}
