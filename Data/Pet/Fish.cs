namespace PetHealthHistory.Data;

public class Fish : Pet
{
    public Fish(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Fish;
}
