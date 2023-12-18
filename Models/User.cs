namespace DemyAI.Models;

public partial class User : BaseViewModel {

    public string Uid { get; set; }

    public string Name { get; set; }

    public string Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public string Location { get; set; }

    [JsonIgnore]
    public List<Roles> Roles => GetUserRoles();

    [ObservableProperty]
    public bool isInvited;

    //public double latitude { get; set; }

    //public double longitude { get; set; }

    public List<Roles> GetUserRoles() {

        return [Helpers.Roles.Teacher, Helpers.Roles.Student, Helpers.Roles.Coordinator];
    }
}
