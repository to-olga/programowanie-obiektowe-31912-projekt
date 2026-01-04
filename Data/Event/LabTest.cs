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
    
    // nadpisanie metody wyszukiwania dla wyników badań laboratoryjnych
    // przeszukuje pola takie jak LabName, OrderedBy czy pola związane z wynikami testów
    // koszysta też z bazowej metody z klasy Event
    public override bool Search(string query)
    {
        return base.Search(query)
               || LabName.Contains(query, StringComparison.OrdinalIgnoreCase)
               || (OrderedBy != null && OrderedBy.Contains(query, StringComparison.OrdinalIgnoreCase))
               || Results.Any(r => r.TestName.Contains(query, StringComparison.OrdinalIgnoreCase)
                                   || r.Value.Contains(query, StringComparison.OrdinalIgnoreCase)
                                   || (r.NormalRange != null && r.NormalRange.Contains(query, StringComparison.OrdinalIgnoreCase)));
    }
    
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