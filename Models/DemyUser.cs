namespace DemyAI.Models;

public class DemyUser {

    //private string _password;
    public string? Uid { get; set; }

    public string? DemyId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    //public string Password {
    //    get => _password;
    //    private init => _password = BCrypt.Net.BCrypt.HashPassword(value);
    //}

    public List<string>? Roles { get; set; }

    public string? CurrentRole { get; set; }

    //public double latitude { get; set; }

    //public double longitude { get; set; }

    public bool IsAssignedToCourse { get; set; }

    public bool IsParticipant { get; set; }

}
