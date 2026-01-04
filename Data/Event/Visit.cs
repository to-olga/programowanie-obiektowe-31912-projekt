namespace PetHealthHistory.Data;

public class Visit : Event
{
    public string Doctor
    {
        get;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    
    public string Clinic
    {
        get;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    
    public string Description
    {
        get;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    
    public override EventType EventType { get; protected set; } = EventType.Visit;
    
    // nadpisanie metody wyszukiwania dla wizyt
    // przeszukuję pola takie jak Doctor, Clinic, Description oraz korzysta z metody bazowej klasy Event
    public override bool Search(string query)
    {
        return base.Search(query)
               || Doctor.Contains(query, StringComparison.OrdinalIgnoreCase)
               || Clinic.Contains(query, StringComparison.OrdinalIgnoreCase)
               || Description.Contains(query, StringComparison.OrdinalIgnoreCase);
    }

    public Visit(DateOnly date, int petId, string doctor, string clinic, string description) : base(date, petId)
    {
        Doctor = doctor;
        Clinic = clinic;
        Description = description;
    }
}