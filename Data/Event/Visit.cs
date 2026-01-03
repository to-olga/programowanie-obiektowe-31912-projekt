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

    public Visit(DateOnly date, int petId, string doctor, string clinic, string description) : base(date, petId)
    {
        Doctor = doctor;
        Clinic = clinic;
        Description = description;
    }
}