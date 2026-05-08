using ProjectManagement1.Models.Constants;

namespace ProjectManagement1.Models;

public record ManagerInfo(string DisplayName, string ImagePath, string Title)
{
    public static ManagerInfo FromDisplayName(string displayName)
    {
        var imagePath = displayName switch
        {
            DeveloperImagePaths.KhenName    => DeveloperImagePaths.Khen,
            DeveloperImagePaths.EliName     => DeveloperImagePaths.Eli,
            DeveloperImagePaths.JerrickName => DeveloperImagePaths.Jerrick,
            DeveloperImagePaths.LuisName    => DeveloperImagePaths.Luis,
            DeveloperImagePaths.MarcusName  => DeveloperImagePaths.Marcus,
            DeveloperImagePaths.PoloName    => DeveloperImagePaths.Polo,
            DeveloperImagePaths.MabiName    => DeveloperImagePaths.Mabi,
            DeveloperImagePaths.MarlouName  => DeveloperImagePaths.Marlou,
            _ => DeveloperImagePaths.Khen
        };
        var title = string.IsNullOrEmpty(displayName)
            ? "Mngr. Dashboard"
            : $"Mngr. {displayName.Split(' ')[0]}";
        return new ManagerInfo(displayName, imagePath, title);
    }
}
