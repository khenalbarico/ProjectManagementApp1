using ProjectManagement1.Models.Enums;

namespace ProjectManagement1.Models;

public class Workitem
{
    public string         WorkItem { get; set; } = "";
    public WorkItemStatus Status   { get; set; }
}
