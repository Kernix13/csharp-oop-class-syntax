using AnimalShelter;

string pet1Name = "Buddy";
string pet1Species = "dog";
float pet1Age = 1.5f;
Pet pet1 = new Pet(pet1Name, pet1Species, pet1Age);

string pet2Name = "Luna";
string pet2Species = "cat";
float pet2Age = 2f;
Pet pet2 = new Pet(pet2Name, pet2Species, pet2Age);

// Update Luna's age
pet2.UpdateAge(12f);

Console.WriteLine($"New pet: {pet1.PetName}, Pet id: {pet1.PetId}, Species: {pet1.Species}, Pet Age: {pet1.Age}");

Console.WriteLine($"New pet: {pet2.PetName}, Pet id: {pet2.PetId}, Species: {pet2.Species}, Pet Age: {pet2.Age}");

// Static field - call on class, not instance/object
Console.WriteLine($"Total pets in shelter: {Pet.TotalPets}");

Adoption adoption1 = new Adoption("Jim", pet2, 100);
Console.WriteLine($"Adoption ID: {adoption1.AdoptionId}, Adopter Name: {adoption1.AdopterName}, Adopted Pet: {adoption1.AdoptedPet.PetName}, Adoption Fee: {Adoption.AdoptionFee}");

// Adoption Fee: {adoption1.AdoptionFee} - why did that not work? Because AdoptionFee is static, it belongs to the class, not the instance. So you should access it through the class name, not the instance. See Pet.TotalPets above.