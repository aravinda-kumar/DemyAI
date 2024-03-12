namespace DemyAI.Controls;

public partial class FlyoutHeader : Grid {
    public FlyoutHeader(FlyoutHeaderViewModel flyoutHeaderViewModel) {
        InitializeComponent();
        BindingContext = flyoutHeaderViewModel;
    }
}