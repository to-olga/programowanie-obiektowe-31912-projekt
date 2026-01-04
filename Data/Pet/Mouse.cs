namespace PetHealthHistory.Data;

public class Mouse : Pet
{
    public Mouse(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Mouse;
}
