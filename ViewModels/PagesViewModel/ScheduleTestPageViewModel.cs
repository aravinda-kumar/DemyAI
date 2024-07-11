namespace DemyAI.ViewModels;

public class ScheduleTestPageViewModel(IAppService appService, IHttpService httpService, IDataService<DemyUser> dataService,
    IMeetingService meetingService) : ScheduleLecturePageViewModel(appService, httpService, dataService, meetingService) {
}

