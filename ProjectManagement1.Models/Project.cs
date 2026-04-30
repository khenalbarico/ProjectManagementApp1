using ProjectManagement1.Models.Enums;

namespace ProjectManagement1.Models;

public class Project
{
    public string                Title     { get; set; } = "";
    public ProjectPriorityStatus Priority  { get; set; }
    public ProjectActivityStatus Activity  { get; set; }
    public KeyPersons            KeyPerson { get; set; }
}
