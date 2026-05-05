using ProjectManagement1.Models.Enums;

namespace ProjectManagement1.Models;

public class WorkItem
{
    public string         Uid        { get; set; } = "";
    public string         Reference  { get; set; } = "";
    public string         Developer  { get; set; } = "";
    public string         ProjectUid { get; set; } = "";
    public WorkItemStatus Status     { get; set; }
}