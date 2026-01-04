namespace PetHealthHistory.Data;

public class Dog : Pet
{
    public Dog(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }
    
    public override PetType PetType { get; protected set; } = PetType.Dog;
    
    public override string[] FunFacts { get; } = 
    [
        "Dogs' noses are as unique as human fingerprints.",
        "A dog's sense of smell is 10,000 to 100,000 times stronger than a human's.",
        "Three dogs survived the sinking of the Titanic.",
        "Dogs have three eyelids.",
        "Basenji dogs don't bark, they yodel."
    ];
}