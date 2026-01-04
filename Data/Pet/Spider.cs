namespace PetHealthHistory.Data;

public class Spider : Pet
{
    public Spider(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Spider;
}
