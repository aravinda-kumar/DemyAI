namespace DemyAI.Controls;

    public partial class MeetingToolbar : ContentView {
        public MeetingToolbar() {
            InitializeComponent();
        }

        public static readonly BindableProperty RoomNameProperty = BindableProperty.Create(
            nameof(RoomName), typeof(string), typeof(MeetingToolbar));

        public string RoomName {
            get => (string)GetValue(RoomNameProperty);
            set => SetValue(RoomNameProperty, value);
        }


        public static readonly BindableProperty TimeProperty = BindableProperty.Create(
            nameof(Time), typeof(string), typeof(MeetingToolbar));

        public string Time {
            get => (string)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }


        public static readonly BindableProperty ShowPeopleProperty = BindableProperty.Create(
            nameof(ShowPeople), typeof(IRelayCommand), typeof(MeetingToolbar));

        public IRelayCommand ShowPeople {
            get => (IRelayCommand)GetValue(ShowPeopleProperty);
            set => SetValue(ShowPeopleProperty, value);
        }

        public static readonly BindableProperty ToolbarVisibilityProperty = BindableProperty.Create(
            nameof(ToolbarVisibility), typeof(bool), declaringType: typeof(MeetingToolbar), false);

        public bool ToolbarVisibility {
            get => (bool)GetValue(ToolbarVisibilityProperty);
            set => SetValue(ToolbarVisibilityProperty, value);
        }




    }