namespace AnimalShelter;

public partial class Pet
{
    // Method to return a description of the pet
    public string GetPetDescription()
    {
        return $"Pet ID: {PetId}, Name: {PetName}, Species: {Species}, Age: {Age}";
    }

    // Method to update the pet's age
    public void UpdateAge(float newAge)
    {
        Age = newAge;
    }
}