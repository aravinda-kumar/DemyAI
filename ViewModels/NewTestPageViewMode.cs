namespace DemyAI.ViewModels;

public partial class NewTestPageViewMode(IAppService appService, IHttpService httpService, IDataService<Models.User> dataService,
    IMeetingService meetingService, IAuthenticationService authenticationService) :
    NewLecturePageViewModel(appService, httpService, dataService, meetingService, authenticationService) {
}
