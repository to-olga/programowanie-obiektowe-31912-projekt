namespace PetHealthHistory.Data;

public class LabTest : Event
{
    public string LabName
    {
        get;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }

    public string? OrderedBy
    {
        get;
        set
        {
            // zamiast pustego ciągu znaków zapisz null
            if (value == string.Empty)
            {
                value = null;
            }
            // sprawdzenie czy wartość nie zawiera tylko białych znaków (null jest odpowiednią wartością)
            if (value != null && string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ordered by cannot be whitespace only.", nameof(OrderedBy));
            }

            field = value;
        }
    }
    
    public ICollection<LabTestResult> Results { get; set; }
    
    public override EventType EventType { get; protected set; } = EventType.LabTest;
    
    public LabTest(DateOnly date, int petId, string labName, string? orderedBy) : base(date, petId)
    {
        LabName = labName;
        OrderedBy = orderedBy;
        Results = new List<LabTestResult>();
    }

    public LabTest(DateOnly date, int petId, string labName, string? orderedBy, ICollection<LabTestResult> results) : base(date, petId)
    {
        LabName = labName;
        OrderedBy = orderedBy;
        Results = results;
    }
}