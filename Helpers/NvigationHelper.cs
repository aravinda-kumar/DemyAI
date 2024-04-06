namespace DemyAI.Helpers;

public static class NvigationHelper {

    public static async Task NavigatoToDashboardRoleAsync(string role) {

        var pageNage = $"{role}DashboardPage";

        Debug.WriteLine(Shell.Current.Items);

        await Shell.Current.GoToAsync($"//{pageNage}", true);
    }
}