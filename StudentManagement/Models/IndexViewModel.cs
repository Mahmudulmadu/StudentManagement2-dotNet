namespace StudentManagement.Models
{
    public class IndexViewModel
    {
        public List<Student> Students { get; set; } = new();
        public string? Search { get; set; }
        public bool AdultsOnly { get; set; } = false;

        public int TotalCount { get; set; }
        public int AdultCount { get; set; }
    }
}
