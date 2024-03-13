namespace DemyAI.Helpers;

public static class NvigationHelper {

    public static async Task NavigatoToDashboardRoleAsync(string role) {

        var pageNage = $"{role}DashboardPage";

        if(Shell.Current.Items.) {

        }

        await Shell.Current.GoToAsync($"//{pageNage}", true);


    }
}
