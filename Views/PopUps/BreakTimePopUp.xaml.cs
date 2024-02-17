namespace DemyAI.Views.PopUps;

public partial class BreakTimePopUp : PopupPage {
    public BreakTimePopUp() {
        InitializeComponent();

        Speak();
    }

    public async void Speak() {
        await TextToSpeech.Default.SpeakAsync("Hi, we are loosing the students, consider taking a break ");
    }

}