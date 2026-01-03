namespace PetHealthHistory.Data;

public class Procedure : Visit
{
    public string Name { get; set; }
    
    public override EventType EventType { get; protected set; } = EventType.Procedure;

    public Procedure(DateOnly date, int petId, string doctor, string clinic, string description, string name) : base(date, petId, doctor, clinic, description)
    {
        Name = name;
    }
}