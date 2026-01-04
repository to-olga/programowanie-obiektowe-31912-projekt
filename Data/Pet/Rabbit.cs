namespace PetHealthHistory.Data;

public class Rabbit : Pet
{
    public Rabbit(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Rabbit;
}
