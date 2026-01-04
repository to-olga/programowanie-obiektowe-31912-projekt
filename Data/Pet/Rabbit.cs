namespace PetHealthHistory.Data;

public class Rabbit : Pet
{
    public Rabbit(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Rabbit;
    
    public override string[] FunFacts { get; } = 
    [
        "Rabbits' teeth never stop growing.",
        "A rabbit's ears can be rotated 270 degrees.",
        "When rabbits are happy, they do a 'binky' (jump and twist in the air).",
        "Rabbits have near 360-degree panoramic vision.",
        "Rabbits are not rodents; they are lagomorphs."
    ];
}
