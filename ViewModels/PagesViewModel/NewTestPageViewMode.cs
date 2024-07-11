namespace DemyAI.ViewModels;

public partial class NewTestPageViewMode(IAppService appService, IHttpService httpService, IDataService<DemyUser> dataService,
    IMeetingService meetingService) : NewLecturePageViewModel(appService, httpService, dataService, meetingService) {
}
