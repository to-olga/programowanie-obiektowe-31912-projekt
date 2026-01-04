namespace PetHealthHistory.Data;

public class Procedure : Visit
{
    public string Name { get; set; }
    
    public override EventType EventType { get; protected set; } = EventType.Procedure;
    
    // nadpisanie metody wyszukiwania dla zabiegów
    // przeszukuje pole Name oraz korzysta z metody bazowej z klasy Visit 
    public override bool Search(string query)
    {
        return base.Search(query)
               || Name.Contains(query, StringComparison.OrdinalIgnoreCase);
    }

    public Procedure(DateOnly date, int petId, string doctor, string clinic, string description, string name) : base(date, petId, doctor, clinic, description)
    {
        Name = name;
    }
}