namespace PetHealthHistory.Data;

// klasa abstrakcyjna jako podstawa dla różnych rodzajów zdarzeń medycznych
public abstract class Event
{
    // klucz główny zdarzenia w bazie danych
    public int Id { get; protected set; }
    
    public DateOnly Date 
    {
        get; 
        // walidacja wartości przypisywanej daty (nie może być w przyszłości ani domyślna (01/01/0001))
        set
        {
            if (value == default || value > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentOutOfRangeException(nameof(Date), "Date cannot be in the future or invalid.");
            }
            field = value;
        } 
    }
    
    // klucz obcy wskazujący na zwierzęcie, do którego przypisane jest zdarzenie
    public int PetId { get; protected set; }
    
    // 
    public abstract EventType EventType { get; protected set; }
    
    // metoda wirtualna do wyszukiwania, nadpisywana w klasach pochodnych,
    // każda klasa jest w stanie przeszukać swoje pola pod względem zawartości podanego ciągu tekstowego
    public virtual bool Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return true;
        }
        
        return Date.ToShortDateString().Contains(query, StringComparison.OrdinalIgnoreCase);
    }

    protected Event(DateOnly date, int petId)
    {
        Date = date;
        PetId = petId;
    }
}

public enum EventType { Visit, LabTest, Procedure }

public static class EventTypeExtensions
{
    // rozszerzenie zwracające odpowednią etykietę rodzaju zdarzenia ('Lab Test' zamiast 'LabTest')
    public static string GetLabel(this EventType type) => type switch
    {
        EventType.LabTest => "Lab Test",
        _ => type.ToString()
    };
}