namespace PetHealthHistory.Data;

public class Cat : Pet
{
    public Cat(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }
    
    public override PetType PetType { get; protected set; } = PetType.Cat;
}