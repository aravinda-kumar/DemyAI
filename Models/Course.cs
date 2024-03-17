namespace DemyAI.Models;

public class Course {

    public string Uid { get; set; }

    public string? DemyId { get; set; }

    public string? Name { get; set; }

    public List<string> Students { get; set; } = [];

    public List<DemyUser> ProfessorsAssigned { get; set; } = [];
}

