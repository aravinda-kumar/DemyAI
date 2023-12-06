namespace DemyAI.ViewModels;
public partial class HomePageViewModel : BaseViewModel {

    public ObservableCollection<Proff> proffs { get; set; } = [];

    public HomePageViewModel() {

        proffs.Add(new Proff { Name = "Eduardo", Description = "Programacion" });

    }
}

public class Proff {

    public string Name { get; set; }

    public string Description { get; set; }
}