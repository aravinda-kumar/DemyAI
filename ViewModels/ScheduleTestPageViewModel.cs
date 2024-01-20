namespace DemyAI.ViewModels;

public class ScheduleTestPageViewModel(IAppService appService, IHttpService httpService, IDataService<Models.User> dataService,
    IMeetingService meetingService, IAuthenticationService authenticationService) : 
    NewLecturePageViewModel(appService, httpService, dataService, meetingService, authenticationService) {
}

