namespace JobApplication.Models;

public class JobApplicationModel
{
    public Applicant Applicant { get; set; } = new();
    public int YearsOfExperience { get; set; }
    public List<string> TechStackList { get; set; } = default!;
}

