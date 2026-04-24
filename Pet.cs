namespace AnimalShelter;

public partial class Pet
{
    private static int s_nextPetId = 1;
    public static int TotalPets { get; private set; }

    // This can only be set inside the class, not from outside so no 'set;'
    // You do not want pet1.PetId = 999;
    public int PetId { get; }

    // Species and Age should be similar to _petName for validation
    // I'll skip that because I want to know the various syntax options for properties.
    private string _petName = "Unknown";

    // shorthand / modern syntax
    public string Species { get; set; }
    private float _age;

    public string PetName
    {
        get { return _petName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                _petName = "Unknown";
            else
                _petName = value;
        }
    }

    // Verbose syntax.
    public float Age
    {
        get { return _age; }
        set { _age = value; }
    }

    static Pet()
    {
        Console.WriteLine("Pet class initialized");
    }

    public Pet(string name, string species, float age)
    {
        PetId = s_nextPetId++;
        PetName = name;
        Species = species;
        Age = age;
        TotalPets++;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Pet ID: {PetId}, Name: {PetName}, Species: {Species}, Age: {Age}");
    }
}