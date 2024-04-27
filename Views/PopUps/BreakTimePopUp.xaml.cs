namespace DemyAI.Views.PopUps;

public partial class BreakTimePopUp : PopupPage {

    private readonly IAudioManager audioManager;
    IAudioPlayer? audioPlayer;

    public BreakTimePopUp(IAudioManager audioManager) {
        InitializeComponent();
        this.audioManager = audioManager;
        Speak();
    }

    public async void Speak() {

        audioPlayer = audioManager.CreatePlayer(
            await FileSystem.OpenAppPackageFileAsync("demy_message.wav"));

        audioPlayer.Play();
    }

    private void PopupPage_Disappearing(object sender, EventArgs e) {

        audioPlayer?.Stop();
    }
}