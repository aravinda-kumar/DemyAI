namespace DemyAI.Helpers;

public static class NvigationHelper {

    public static async Task NavigatoToDashboardRoleAsync(string role) {

        var pageNage = $"{role}DashboardPage";

        await Shell.Current.GoToAsync($"//{pageNage}", true);

    }
}
