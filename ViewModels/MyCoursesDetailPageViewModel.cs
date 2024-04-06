#if MACCATALYST
using DemyAI.Platforms.MacCatalyst;
#elif WINDOWS
using DemyAI.Platforms.Windows;
#endif

namespace DemyAI.ViewModels;

[QueryProperty($"{nameof(Course)}", "Course")]
public partial class MyCoursesDetailPageViewModel : BaseViewModel {

    private readonly IDataService<DemyUser> dataService;

    [ObservableProperty]
    Course? course;

    [ObservableProperty]
    bool isDesktop;

    public ObservableCollection<DemyUser> Students { get; set; } = [];

    private readonly ObservableCollection<DemyUser> OriginalStudentList = [];

    public MyCoursesDetailPageViewModel(IDataService<DemyUser> dataService) {
        this.dataService = dataService;

        if (DeviceInfo.Idiom == DeviceIdiom.Desktop) {
            IsDesktop = true;
        }
    }

    [RelayCommand]
    void ContactPointerEntered(Label emailLabel) {

#if WINDOWS || MACCATALYST
        emailLabel.SetCustomCursor(CursorIcon.Hand, emailLabel.Handler?.MauiContext);
#endif
        emailLabel.TextColor = Color.FromArgb("1f66e5");
    }

    [RelayCommand]
    void ContactPointerExited(Label emailLabel) {

        emailLabel.TextColor = Color.FromArgb("#000000");
    }

    [RelayCommand]
    async Task TapOnContact(Label emailLabel) {

        await EmailHelper.OpenEmailClientAsync(emailLabel.Text);
    }


    [RelayCommand]
    async Task Appearing() {

        if (Course is not null) {

            Students.Clear();

            foreach (var item in Course.Students) {

                var users = await dataService.GetByUidAsync<DemyUser>(Constants.USERS, item);

                Students.Add(users);
                OriginalStudentList.Add(users);

            }
        }
    }

    [RelayCommand]
    void Search(string text) {

        if (!string.IsNullOrEmpty(text)) {
            var newStudents = Students.Where(u => u.FullName.ToLower().Contains(text.Trim().ToLower())).ToList();
            Students.Clear();
            foreach (var student in newStudents) {
                Students.Add(student);
            }
        } else {
            Students.Clear();
            foreach (var item in OriginalStudentList) {
                Students.Add(item);
            }
        }

    }
}