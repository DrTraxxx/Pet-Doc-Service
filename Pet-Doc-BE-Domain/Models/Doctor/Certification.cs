namespace Pet_Doc_BE_Domain.Models;

public class Certification : Entity<int>
{
    public string Name { get; set; } = default!;
    public DateTime IssueDate { get; set; } = default!;
}