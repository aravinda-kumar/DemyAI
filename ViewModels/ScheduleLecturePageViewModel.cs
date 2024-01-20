
namespace DemyAI.ViewModels;

public class ScheduleLecturePageViewModel(IAppService appService, IHttpService httpService, IDataService<Models.User> dataService,
    IMeetingService meetingService, IAuthenticationService authenticationService) :
    NewLecturePageViewModel(appService, httpService, dataService, meetingService, authenticationService) {
}
