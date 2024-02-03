namespace DemyAI.ViewModels;

public class ScheduleLecturePageViewModel(IAppService appService, IHttpService httpService, IDataService<Models.User> dataService,
    IMeetingService meetingService) : NewLecturePageViewModel(appService, httpService, dataService, meetingService) {
}
