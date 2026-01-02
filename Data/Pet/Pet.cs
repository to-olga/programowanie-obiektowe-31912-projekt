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
    
    protected Pet(string name, DateOnly birthDate, string? kind)
    {
        Name = name;
        BirthDate = birthDate;
        Kind = kind;
    }
}

public enum PetType { Cat, Dog }
