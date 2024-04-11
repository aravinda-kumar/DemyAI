namespace DemyAI.Helpers;

public static class NvigationHelper {

    public static async Task NavigatoToDashboardRoleAsync(DemyUser demyUser) {

        var pageNage = $"{demyUser.CurrentRole}DashboardPage";

        FlyoutHelper.GetDefaultMenuItems();

        FlyoutHelper.CreateFlyoutHeader(demyUser);

        FlyoutHelper.CreateFlyoutMenu(demyUser?.CurrentRole!);

        await Shell.Current.GoToAsync($"//{pageNage}", true);
    }
}