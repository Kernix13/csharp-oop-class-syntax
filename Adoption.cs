namespace AnimalShelter;

public class Adoption
{
    private static int s_nextAdoptionId = 1;
    public int AdoptionId { get; }
    public string AdopterName { get; set; }
    public Pet AdoptedPet { get; set; }
    public static int AdoptionFee { get; set; } = 50;

    public Adoption(string adopterName, Pet adoptedPet, int adoptionFee)
    {
        AdoptionId = s_nextAdoptionId++;
        AdopterName = adopterName;
        AdoptedPet = adoptedPet;
        AdoptionFee = adoptionFee;
    }
}