namespace DemyAI.ViewModels;

public class ScheduleTestPageViewModel(IAppService appService, IHttpService httpService, IDataService<Models.User> dataService,
    IMeetingService meetingService) : NewLecturePageViewModel(appService, httpService, dataService, meetingService) {
}

