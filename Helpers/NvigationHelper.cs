namespace DemyAI.Helpers;

public static class NvigationHelper {

    public static async Task NavigatoToDashboardRoleAsync(DemyUser demyUser) {

        var pageNage = $"{demyUser.CurrentRole}DashboardPage";

        FlyoutHelper.GetDefaultMenuItems();

        FlyoutHelper.CreateFlyoutHeader(demyUser);

        FlyoutHelper.CreateFlyoutMenu(demyUser?.CurrentRole!);

        if (DeviceInfo.Platform == DevicePlatform.MacCatalyst
            || DeviceInfo.Platform == DevicePlatform.WinUI) {

            Shell.Current.FlyoutIsPresented = true;

            Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;

        }

        await Shell.Current.GoToAsync($"//{pageNage}", true);
    }
}