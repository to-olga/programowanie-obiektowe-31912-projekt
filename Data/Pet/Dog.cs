namespace PetHealthHistory.Data;

public class Dog : Pet
{
    public Dog(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }
    
    public override PetType PetType { get; protected set; } = PetType.Dog;
}