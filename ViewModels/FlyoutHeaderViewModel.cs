

namespace DemyAI.ViewModels;

public partial class FlyoutHeaderViewModel(
    string displyName,
    string demyId,
    string email,
    string currentRole,
    IAppService appService) : BaseViewModel {

    [ObservableProperty]
    string demyId = demyId;

    [ObservableProperty]
    string name = displyName;

    [ObservableProperty]
    string email = email;

    [ObservableProperty]
    string currentRole = currentRole;

    [RelayCommand]
    async Task ChangeRolesAsync() {

        // appService.DisplayAlert("ddd", email!, "ok");

        FlyoutHelper.GetDefaultMenuItems();

        await appService.NavigateTo($"//{nameof(RoleSelectionPage)}", true);

    }
}

