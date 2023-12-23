namespace DemyAI.Models;

public class Course {

    public string Uid { get; set; }

    public string DemyId { get; set; }

    public string Name { get; set; }

    public string ProfessorName { get; set; }

    public string ProfessorEmail { get; set; }

    public string InitialRegistrationDate { get; set; }

    public string EndRegistrationDate { get; set; }

    public List<string>? students { get; set; }

    public string professorAssigned { get; set; }

    public bool isCourseOpen { get; set; }
}

