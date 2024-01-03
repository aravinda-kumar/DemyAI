namespace DemyAI.Models;

public partial class User : BaseViewModel {

    //private string _password;

    public string Uid { get; set; }

    public string DemyId { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    //public string Password {
    //    get => _password;
    //    private init => _password = BCrypt.Net.BCrypt.HashPassword(value);
    //}

    public string Role { get; set; }

    //public double latitude { get; set; }

    //public double longitude { get; set; }

    public List<string> Rooms { get; set; }

    public bool IsAssignedToCourse { get; set; }

    public bool IsParticipant { get; set; }

    [JsonIgnore]
    public List<Roles> Roles => GetUserRoles();

    public List<Roles> GetUserRoles() {

        return [Helpers.Roles.Teacher, Helpers.Roles.Student, Helpers.Roles.Coordinator];
    }

}
