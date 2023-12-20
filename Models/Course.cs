namespace DemyAI.Models;

public class Course {

    public string Uid { get; set; }

    public string DemyId { get; set; } = NumberGenerator.GenerateRandomNumberString(4);

    public string Name { get; set; }

    public string Description { get; set; }

    public string teacher { get; set; }

    public DateTime initialDate { get; set; }

    public DateTime endDate { get; set; }

}

