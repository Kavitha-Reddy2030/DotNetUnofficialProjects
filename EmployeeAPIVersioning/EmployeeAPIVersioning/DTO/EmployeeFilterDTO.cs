namespace EmployeeAPIVersioning.DTO
{
    public class EmployeeFilterDTO
    {
        public string FirstName { get; set; }
        public string Department { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string SortBy { get; set; }
        public bool SortDescending { get; set; } = false; // Default to ascending
        public int PageNumber { get; set; } = 1; // Default page number
        public int PageSize { get; set; } = 10; // Default page size
    }
}
