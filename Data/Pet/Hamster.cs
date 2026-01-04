namespace PetHealthHistory.Data;

public class Hamster : Pet
{
    public Hamster(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Hamster;
}
