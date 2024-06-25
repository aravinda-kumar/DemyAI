namespace DemyAI.Models;

public partial class UserRoles : ObservableObject {

    [ObservableProperty]
    Roles name;

    [ObservableProperty]
    bool isSelected;

    [ObservableProperty]
    Color? selectedColor;

    public UserRoles() {
        selectedColor = Constants.DefaultUnselectedColor;
    }
}
