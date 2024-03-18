namespace DemyAI.Views.PopUps;

public partial class BreakTimePopUp : PopupPage {

    private readonly IAudioManager audioManager;

    public BreakTimePopUp(IAudioManager audioManager) {
        InitializeComponent();
        this.audioManager = audioManager;
        Speak();
    }

    public async void Speak() {

        CancellationToken token = CancellationToken.None;
        var player = audioManager.CreateAsyncPlayer(await FileSystem.OpenAppPackageFileAsync("demy_message.wav"));

        await player.PlayAsync(token);
    }

}