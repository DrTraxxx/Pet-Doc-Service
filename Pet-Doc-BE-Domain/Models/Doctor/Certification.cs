namespace Pet_Doc_BE_Domain.Models;

public class Certification : Entity<int>
{
    internal Certification(string name = default! ,DateTime issueDate = default!)
    {
        Name = name;
        IssueDate  = issueDate;
    }

    public string Name { get; set; } = default!;
    public DateTime IssueDate { get; set; } = default!;
}