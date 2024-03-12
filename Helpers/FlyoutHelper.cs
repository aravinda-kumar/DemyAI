namespace DemyAI.Helpers {
    public static class FlyoutHelper {

        public static void CreateFlyoutHeader(DemyUser? updatedUser) {
            Shell.Current.FlyoutHeader = new FlyoutHeader(
                new FlyoutHeaderViewModel(
                                  updatedUser!.Name!,
                                  updatedUser.DemyId!,
                                  updatedUser.Email!,
                                  updatedUser.CurrentRole!
                ));
        }
    }
}
