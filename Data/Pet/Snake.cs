namespace PetHealthHistory.Data;

public class Snake : Pet
{
    public Snake(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Snake;
}
