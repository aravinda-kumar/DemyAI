using User = DemyAI.Models.User;

namespace DemyAI.Helpers;

public class RoleVisibility {

    public static async Task ManageFlyoutItemsVisibility(AppShellViewModel appShellViewModel,
        IDataService<User> dataService, string userUID, IAppService appService) {

        var UsersList = await dataService.GetAllAsync<User>("Users");

        var currentUser = UsersList.FirstOrDefault(user => user.Object.Email == userUID)?.Object;

        if(currentUser != null) {
            switch(currentUser.Role) {
                case nameof(Roles.Coordinator):
                    appShellViewModel.IsCoordinator = true;
                    break;
                case nameof(Roles.Teacher):
                    appShellViewModel.IsTeacher = true;
                    break;
                case nameof(Roles.Student):
                    appShellViewModel.IsStudent = true;
                    break;
            }

            appShellViewModel.User = currentUser;
            await appService.NavigateTo($"//{nameof(WelcomePage)}", true);

        } else {
            // Handle the case where currentUser is null (e.g., user not found)
            // You might want to show an error message or take appropriate action
        }
    }
}
