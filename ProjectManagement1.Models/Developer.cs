using ProjectManagement1.Models.Enums;

namespace ProjectManagement1.Models;

public class Developer
{
    public string                  Uid          { get; set; } = "";
    public string                  Name         { get; set; } = "";
    public DeveloperWorkloadStatus Workload     { get; set; }
    public DeveloperHealthStatus   Health       { get; set; }
    public List<ProjectAssignment> Assignments  { get; set; } = [];
    public string                  ImagePath    { get; set; } = "";
}