namespace DemyAI.Models;

public class Course {

    public string Uid { get; set; }

    public string DemyId { get; set; }

    public string Name { get; set; }

    public string ProfessorName { get; set; }

    public string ProfessorEmail { get; set; }

    public string InitialRegistrationDate { get; set; }

    public string EndRegistrationDate { get; set; }

    public List<string> Students { get; set; } = [];

    public List<string> ProfessorsAssigned { get; set; } = [];

    public bool IsCourseOpen { get; set; }
}

