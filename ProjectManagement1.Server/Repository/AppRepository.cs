using ClosedXML.Excel;
using ProjectManagement1.Core.Utilities;
using ProjectManagement1.Models;
using ProjectManagement1.Models.Constants;
using ProjectManagement1.Models.Enums;

namespace ProjectManagement1.Core.Repository;

public class AppRepository : IAppRepository
{
    public TResult LoadDatasource<TResult>()
    {
        using var workbook = new XLWorkbook(DataSource.FilePath);

        var resultType = typeof(TResult);

        if (resultType == typeof(List<Project>))
            return (TResult)(object)LoadProjects(workbook);

        if (resultType == typeof(List<Developer>))
            return (TResult)(object)LoadDevelopers(workbook);

        if (resultType == typeof(List<WorkItem>))
            return (TResult)(object)LoadWorkItems(workbook);

        throw new NotSupportedException($"Type {resultType.Name} is not supported.");
    }

    static List<Project> LoadProjects(IXLWorkbook workbook)
    {
        var sheet = workbook.Worksheet("Projects");
        var projects = new List<Project>();

        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            projects.Add(new Project
            {
                Uid       = row.Cell(1).GetString().Trim(),
                Title     = row.Cell(2).GetString().Trim(),
                Priority  = row.Cell(3).GetString().ParseEnum<ProjectPriorityStatus>(),
                Activity  = row.Cell(4).GetString().ParseEnum<ProjectActivityStatus>(),
                KeyPerson = row.Cell(5).GetString().ParseEnum<KeyPersons>()
            });
        }

        return projects;
    }

    static List<Developer> LoadDevelopers(IXLWorkbook workbook)
    {
        var sheet = workbook.Worksheet("Developers");
        var developers = new List<Developer>();

        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            var projectsRaw = row.Cell(5).GetString().Trim();
            var projectList = projectsRaw
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToList();

            var name = row.Cell(2).GetString().Trim();

            developers.Add(new Developer
            {
                Uid             = row.Cell(1).GetString().Trim(),
                Name            = name,
                Workload        = row.Cell(3).GetString().ParseEnum<DeveloperWorkloadStatus>(),
                Health          = row.Cell(4).GetString().ParseEnum<DeveloperHealthStatus>(),
                Project         = projectList,
                ProjectExposure = row.Cell(6).GetString().ParseEnum<DeveloperProjectExposureStatus>(),
                ImagePath       = ResolveDeveloperImagePath(name)
            });
        }

        return developers;
    }

    static string ResolveDeveloperImagePath(string name) => name switch
    {
        DeveloperImagePaths.EliName => DeveloperImagePaths.Eli,
        DeveloperImagePaths.JerrickName => DeveloperImagePaths.Jerrick,
        DeveloperImagePaths.LuisName => DeveloperImagePaths.Luis,
        DeveloperImagePaths.MarcusName => DeveloperImagePaths.Marcus,
        DeveloperImagePaths.PoloName => DeveloperImagePaths.Polo,
        _ => ""
    };

    static List<WorkItem> LoadWorkItems(IXLWorkbook workbook)
    {
        var sheet = workbook.Worksheet("Work Items");
        var workItems = new List<WorkItem>();

        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            workItems.Add(new WorkItem
            {
                Uid       = row.Cell(1).GetString().Trim(),
                Reference = row.Cell(2).GetString().Trim(),
                Developer = row.Cell(3).GetString().Trim(),
                Status    = row.Cell(5).GetString().ParseEnum<WorkItemStatus>()
            });
        }

        return workItems;
    }

    public void PostDeveloper(Developer payload)
    {
        using var workbook = new XLWorkbook(DataSource.FilePath);
        var sheet = workbook.Worksheet("Developers");
        var nextRow = sheet.LastRowUsed()!.RowNumber() + 1;

        payload.Uid = Prefixes.DeveloperPrefix.Generate();
        sheet.Cell(nextRow, 1).Value = payload.Uid;
        sheet.Cell(nextRow, 2).Value = payload.Name;
        sheet.Cell(nextRow, 3).Value = payload.Workload.ToString();
        sheet.Cell(nextRow, 4).Value = payload.Health.ToString();
        sheet.Cell(nextRow, 5).Value = string.Join(", ", payload.Project);
        sheet.Cell(nextRow, 6).Value = payload.ProjectExposure.ToString();

        workbook.Save();
    }

    public void PostProject(Project payload)
    {
        using var workbook = new XLWorkbook(DataSource.FilePath);
        var sheet = workbook.Worksheet("Projects");
        var nextRow = sheet.LastRowUsed()!.RowNumber() + 1;

        payload.Uid = Prefixes.ProjectPrefix.Generate();
        sheet.Cell(nextRow, 1).Value = payload.Uid;
        sheet.Cell(nextRow, 2).Value = payload.Title;
        sheet.Cell(nextRow, 3).Value = payload.Priority.ToString();
        sheet.Cell(nextRow, 4).Value = payload.Activity.ToString();
        sheet.Cell(nextRow, 5).Value = payload.KeyPerson.ToString();

        workbook.Save();
    }

    public void PostWorkItem(WorkItem payload)
    {
        using var workbook = new XLWorkbook(DataSource.FilePath);
        var sheet = workbook.Worksheet("Work Items");
        var nextRow = sheet.LastRowUsed()!.RowNumber() + 1;

        payload.Uid = Prefixes.WorkitemPrefix.Generate();
        sheet.Cell(nextRow, 1).Value = payload.Uid;
        sheet.Cell(nextRow, 2).Value = string.Join(", ", payload.Reference);
        sheet.Cell(nextRow, 3).Value = string.Join(", ", payload.Developer);
        sheet.Cell(nextRow, 4).Value = payload.Status.ToString();

        workbook.Save();
    }

    public void PatchDeveloper(Developer payload)
    {
        using var workbook = new XLWorkbook(DataSource.FilePath);
        var sheet = workbook.Worksheet("Developers");

        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            if (row.Cell(1).GetString().Trim() != payload.Uid) continue;

            row.Cell(2).Value = payload.Name;
            row.Cell(3).Value = payload.Workload.ToString();
            row.Cell(4).Value = payload.Health.ToString();
            row.Cell(5).Value = string.Join(", ", payload.Project);
            row.Cell(6).Value = payload.ProjectExposure.ToString();

            break;
        }

        workbook.Save();
    }

    public void PatchProject(Project payload)
    {
        using var workbook = new XLWorkbook(DataSource.FilePath);
        var sheet = workbook.Worksheet("Projects");

        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            if (row.Cell(1).GetString().Trim() != payload.Uid) continue;

            row.Cell(2).Value = payload.Title;
            row.Cell(3).Value = payload.Priority.ToString();
            row.Cell(4).Value = payload.Activity.ToString();
            row.Cell(5).Value = payload.KeyPerson.ToString();

            break;
        }

        workbook.Save();
    }

    public void PatchWorkItem(WorkItem payload)
    {
        using var workbook = new XLWorkbook(DataSource.FilePath);
        var sheet = workbook.Worksheet("Work Items");

        foreach (var row in sheet.RowsUsed().Skip(1))
        {
            if (row.Cell(1).GetString().Trim() != payload.Uid) continue;

            row.Cell(2).Value = string.Join(", ", payload.Reference);
            row.Cell(3).Value = string.Join(", ", payload.Developer);
            row.Cell(5).Value = payload.Status.ToString();

            break;
        }

        workbook.Save();
    }
}
