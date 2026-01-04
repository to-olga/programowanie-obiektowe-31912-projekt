namespace PetHealthHistory.Data;

public abstract class Pet
{
    // klucz główny zwierzęcia w bazie danych
    public int Id { get; protected set; }


    public string Name
    {
        get;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(Name));
            field = value;
        }
    }

    public DateOnly BirthDate
    {
        get;
        set
        {
            // walidacja wartości przypisywanej daty (nie może być w przyszłości ani domyślna (01/01/0001)
            if (value == default || value > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentOutOfRangeException(nameof(BirthDate), "Birth date cannot be in the future or invalid.");
            }
            field = value;
        }
    }

    public string? Kind
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
                throw new ArgumentException("Kind cannot be whitespace only.", nameof(Kind));
            }

            field = value;
        }
    }

    public abstract PetType PetType { get; protected set; }
    
    // kolekcja zdarzeń medycznych powiązanych ze zwierzęciem
    public ICollection<Event> Events { get; protected set; }
    
    // abstrakcyjna właściwość zwracająca ciekawe fakty o danym type zwierzęcia 
    public abstract string[] FunFacts { get; }

    // metoda zwracająca losowy fakt na podstawie abstrakcyjnej tablicy FunFacts
    public string? FunFact()
    {
        if (FunFacts.Length == 0)
        {
            return null;
        }
        
        return FunFacts[Random.Shared.Next(FunFacts.Length)];
    }
    
    protected Pet(string name, DateOnly birthDate, string? kind)
    {
        Name = name;
        BirthDate = birthDate;
        Kind = kind;
        Events = [];
    }
}

public enum PetType { Cat, Dog, Mouse, Hamster, Snake, Horse, Rabbit, Fish, GuineaPig, Spider }

public static class PetTypeExtensions
{
    // rozszerzenie zwracające odpowednią etykietę typu zwierzęcia ('Guinea Pig' zamiast 'GuineaPig')
    public static string GetLabel(this PetType type) => type switch
    {

        PetType.GuineaPig => "Guinea Pig",
        _ => type.ToString()
    };
}
