namespace StudentManagement.Models
{
    public class ViewModelForFiltering
    {
        public IEnumerable<Student> Results { get; set; }
        public Status? FilterStatus { get; set; }

    }
}
