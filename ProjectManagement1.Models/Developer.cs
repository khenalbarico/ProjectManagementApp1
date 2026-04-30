using ProjectManagement1.Models.Enums;

namespace ProjectManagement1.Models;

public class Developer
{
    public string                         Name            { get; set; } = "";
    public DeveloperWorkloadStatus        Workload        { get; set; }
    public DeveloperHealthStatus          Health          { get; set; }
    public Project                        Project         { get; set; } = new Project();
    public DeveloperProjectExposureStatus ProjectExposure { get; set; }
    public IEnumerable<Workitem>          WorkItems       { get; set; } = [];
}
