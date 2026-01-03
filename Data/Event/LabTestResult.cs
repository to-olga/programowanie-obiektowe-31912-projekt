namespace PetHealthHistory.Data;

public class LabTestResult
{
    public int Id { get; protected set; }

    public string TestName
    {
        get;
        protected set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    
    public string Value
    {
        get;
        protected set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }
    
    public string? NormalRange 
    { 
        get; 
        protected set
        {
            // zamiast pustego ciągu znaków zapisz null
            if (value == string.Empty)
            {
                value = null;
            }
            // sprawdzenie czy wartość nie zawiera tylko białych znaków (null jest odpowiednią wartością)
            if (value != null && string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Normal range cannot be whitespace only.", nameof(NormalRange));
            }

            field = value;
        }
    }
    
    public bool InNormalRange { get; protected set; }
    
    public int LabTestId { get; protected set; }
    
    public LabTestResult(string testName, string value, string? normalRange, bool inNormalRange)
    {
        TestName = testName;
        Value = value;
        NormalRange = normalRange;
        InNormalRange = inNormalRange;
    }

    public LabTestResult(string testName, string value, string? normalRange, bool inNormalRange, int labTestId)
    {
        TestName = testName;
        Value = value;
        NormalRange = normalRange;
        InNormalRange = inNormalRange;
        LabTestId = labTestId;
    }
}