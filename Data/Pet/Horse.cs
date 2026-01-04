namespace PetHealthHistory.Data;

public class Horse : Pet
{
    public Horse(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Horse;
}
