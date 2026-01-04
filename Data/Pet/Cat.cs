namespace PetHealthHistory.Data;

public class Cat : Pet
{
    public Cat(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }
    
    public override PetType PetType { get; protected set; } = PetType.Cat;
    
    public override string[] FunFacts { get; } = 
    [
        "Cats have 32 muscles in each ear.",
        "A cat has been mayor of a town in Alaska for 20 years.",
        "Cats can't taste sweetness.",
        "A group of cats is called a clowder.",
        "Cats spend 70% of their lives sleeping."
    ];
}