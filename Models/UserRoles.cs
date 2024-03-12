namespace DemyAI.Models;

public partial class UserRoles : ObservableObject {

    [ObservableProperty]
    Role name;

    [ObservableProperty]
    bool isSelected;

    [ObservableProperty]
    Color? selectedColor;

    public static readonly Color DefaultUnselectedColor = Color.FromRgb(255, 255, 255);

    public static readonly Color RoleSelectedColor = Color.FromRgb(100, 149, 237);

    public UserRoles() {
        selectedColor = DefaultUnselectedColor;
    }
}
