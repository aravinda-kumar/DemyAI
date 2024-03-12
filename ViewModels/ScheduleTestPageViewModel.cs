namespace DemyAI.ViewModels;

public class ScheduleTestPageViewModel(IAppService appService, IHttpService httpService, IDataService<DemyUser> dataService,
    IMeetingService meetingService) : NewLecturePageViewModel(appService, httpService, dataService, meetingService) {
}

