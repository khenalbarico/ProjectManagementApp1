using ProjectManagement1.Models;
using ProjectManagement1.Models.Enums;

namespace ProjectManagement1.Core.Utilities;

public static class DeveloperWorkloadCalculator
{
    public static DeveloperWorkloadStatus CalculateWorkload(this Developer developer, List<WorkItem> workItems, List<Project> projects)
    {
        var devWorkItems = workItems.Where(w => w.Developer == developer.Name).ToList();

        if (!devWorkItems.Any())
            return DeveloperWorkloadStatus.Standby;

        double total = 0;

        foreach (var wi in devWorkItems)
        {
            var project = projects.FirstOrDefault(p => p.Uid == wi.ProjectUid);
            if (project is null) continue;

            bool isPriority = project.Priority != ProjectPriorityStatus.NotPriority;

            total += (isPriority, project.Activity) switch
            {
                (false, ProjectActivityStatus.LowActivity) => 1.0,
                (false, ProjectActivityStatus.ModerateActivity) => 1.5,
                (false, ProjectActivityStatus.HighActivity) => 2.0,
                (true, ProjectActivityStatus.LowActivity) => 2.5,
                (true, ProjectActivityStatus.ModerateActivity) => 3.0,
                (true, ProjectActivityStatus.HighActivity) => 3.5,
                _ => 0.0
            };
        }

        return total switch
        {
            0 => DeveloperWorkloadStatus.Standby,
            <= 2 => DeveloperWorkloadStatus.UnderLoaded,
            > 2 and <= 5 => DeveloperWorkloadStatus.Balanced,
            _ => DeveloperWorkloadStatus.Overloaded
        };
    }
}
