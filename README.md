# Introduction to Object-Oriented Programming (OOP)

This project uses various Object-Oriented Programming concepts and syntax such as classes, fields, properties, and constructors.

<span aria-hidden="true"><br></span>

## Installation & Usage

1. Clone this repository and switch into project folder

   ```sh
   git clone https://github.com/Kernix13/csharp-oop-class-syntax.git AnimalShelter
   cd AnimalShelter
   ```

2. Run the application

   ```bash
   dotnet run
   ```

3. Build the application

   ```bash
   dotnet build
   ```

### Quick Start

```sh
git clone https://github.com/Kernix13/csharp-oop-class-syntax.git AnimalShelter
cd AnimalShelter
dotnet run
```

> [!NOTE]
> There are variables used to create 2 pet objects in `Project.cs`. Those objects are what creates the output in the console. I could create `ReadLine` statements and output the results, but you would only see one object in the console.

Console output:

```
$ dotnet run
Pet class initialized
New pet: Buddy, Pet id: 1, Species: dog, Breed: AmStaff, Pet Age: 1.5
New pet: Luna, Pet id: 2, Species: cat, Breed: DSH, Pet Age: 12
New pet: Logan, Pet id: 3, Species: dog, Breed: unknown, Pet Age: 3
Total pets in shelter: 3
Adoption ID: 1, Adopter Name: Jim, Adopted Pet: Luna, Adoption Fee: $100

Pet ID: 3, Name: Logan, Age: 3, Species: dog, Breed: unknown
```

<span aria-hidden="true"><br></span>

## Class syntax used

I used the following syntax/keywords in this project:

1. namespace
1. using
1. `public class`
1. `public` field
1. `public static` field
1. `private` field
1. `private static` field
1. public properties with `get`, `set` accessors
1. public property with `private set;`
1. public property with modern syntax: `{ get; set; }`
1. public property with the longer/verbose syntax
1. public property with validation
1. Use of `=>` in property accessor
1. 1 Static constructor
1. 1 Public instance constructor with parameters
1. 2 optional parameters in instance constructor
1. 2 named arguments used in Program.js
1. 2 public methods with the `return` keyword
1. 1 public void method
1. Partial class (weak implementation)
1. `new` keyword to create objects from the classes

<span aria-hidden="true"><br></span>

## Class syntax _NOT_ used

I did not, or decided not to, use the following due to the fact I did not understand them or did not see a way to work them in.

### My to-do list to learn or add to projects

1. `readonly` access level: how does this differ from `private set;`?
1. `params` method keyword
1. The `this` keyword in methods to access fields, properties, and methods of the current instance (_Add later_)
1. Extension methods: `this ClassName paramName`
1. `abstract` method modifier

### Skip learning for now

1. The `init` accessor
1. `protected` access level
1. `required` access level
1. `internal` access level
1. The `ref` or `out` keywords
1. The `field` keyword: You must set your `<LangVersion>` element to preview in your project file in order to use the `field` contextual keyword. What is `@field`?
1. Static classes - unsure about this one
1. Nested classes - don't do this one
1. Partial members - don't do this one
1. Object initializers?
1. Copy constructors?
1. Class finalizers?

### Other points

I did not use arrays or `Console.ReadLine` or other C# syntax learned previously because there was so much to learn for this project. Later I could add an array of pet types (dog, cat, rabbit, etc) and use a `ReadLine` to grab the value and add it to `Species` in `Pet.cs`.

The following keywords and terms were covered in the lessons but I do not know what they are, how to use them, or when to use them:

- `struct`, `interface`, `enum`, `record`, `delegate`

> See [oop.md](./oop.md) for notes on all of the above.

<span aria-hidden="true"><br></span>

## Important notes

1. Static fields are accessed using the class name, not the instance name
   - For example: `Adoption.AdoptionFee` ✔️ vs `pet1.AdoptionFee` ❌
1. The `this` keyword is not available in a static constructor
1. Properties combine aspects of both fields and methods
1. The keyword `value` represents the value being assigned to the property (what is passed to the class constructor during instantiation I think)

<span aria-hidden="true"><br></span>

## Questions

1. Why exactly do I need to use `namespace`?
   1. So that I can use the classes in all files?
   1. Is it similar to `import`/`export` syntax in ES Modules or it that what `partial` does?
1. Can I use `using AnimalShelter;` instead of `namespace AnimalShelter;`? (Try it and see)
1. What is garbage collection and is it important to know or is it an automatic thing to just be aware of?
1. What is the difference between field vs. property?
   1. If you add some form of `{ get; set; }` to a _field_, does that turns it into a property? If so, why/when use fields without that?

<span aria-hidden="true"><br></span>

## Code: line-by-line

Examples and descriptions for the code I used.

### Pet.cs

#### NAMESPACE

- I removed this from Program.cs and the app crashed
- This line says, "This class lives inside `AnimalShelter`"

```cs
namespace AnimalShelter;
```

#### CLASS + PARTIAL

- I did not see the value of using partial classes. I can see how a class filled with many methods could be a problem.
- Is this similar to import/export syntax in JavaScript ES Modules?

```cs
public partial class Pet {}
```

#### FIELD MODIFIERS

- `private`: Hidden from all other classes; only accessible within this class.
- `static`: Belongs to the class itself; shared by all instances.
- `private static`: Accessible only inside the class; shared by all instances of that class.
  - `s_nextPetId`: incremented for each new instance of Pet inside the instance constructor.
- `public`: Visible to all project code; any class can see and change this.
- `public static`: Visible to all project code and shared as a single instance by the class.

```cs
/* PRIVATE + STATIC */
// 1.
private static int s_nextPetId = 1;

// 2.
private string _petName = "Unknown";

// 3.
private float _age;

/* PUBLIC + STATIC */
// 1.
public static int TotalPets { get; private set; }

// 2.
public int PetId { get; }

// 3.
public string Species { get; set; }
```

#### PROPERTIES

- Backing Fields: `_petName`, `_age` - marked private, the secret spot where the data is actually stored
- The Property: `PetName`, `Age` - marked public, the public "gatekeeper" that controls how data is read or changed
- Private backing field: automatic when you use `{ get; set; }`
- `{ get; private set; }`: Anyone can read the value, but only this class can change it.
- `{ get; }`: Read-only - the value is set when the object is born and can never change.
- `{ get; set; }`: Full access; any part of the project can read or change this at any time.

```cs
// 1. MODERN SYNTAX
public static int TotalPets { get; private set; }
public int PetId { get; }
public string Species { get; set; }

// 2. OLDER/VERBOSE SYNTAX
private float _age;
public float Age
{
   get { return _age; }
   set { _age = value; }
}

// 3. VALIDATION
private string _petName = "Unknown";
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
```

#### CONSTRUCTOR

- static constructor: to initialize any static data, or to perform an action that needs to be performed only once
- public instance constructor: this builds the instance objects

```cs
// 1. static constructor
static Pet() {}

// 2. public instance constructor - 1 version with params
public Pet(string name, string species, float age) {}
```

#### METHOD

- public void: basic method that does not return a value

```cs
// 1.
public void DisplayInfo() {}
```

<span aria-hidden="true"><br></span>

### PetMethods.cs

#### NAMESPACE

- This is needed here as well

```cs
namespace AnimalShelter;
```

#### CLASS + PARTIAL

- The keyword `partial` is needed in the "parent" class and is the partial files as well - they must match!
- I forgot to add the fields and properties here and did not notice that it worked anyway.
  - I assume the `partial` keyword brings the code into `Pet.cs` so that is not necessary.

```cs
public partial class Pet {}
```

#### METHOD

- Nothing special here - 1 method that returns a value and 1 void method

```cs
// 1.
public string GetPetDescription() {}

// 2.
public void UpdateAge(float newAge) {}
```

<span aria-hidden="true"><br></span>

### Adoption.cs

#### NAMESPACE

- This is needed here as well

```cs
namespace AnimalShelter;
```

#### FIELD MODIFIERS

- `private static`, `public`, and `public static` similar to above
- Custom Type Property: This property links the Adoption class to the Pet class

```cs
/* PRIVATE + STATIC */
// 1.
private static int s_nextAdoptionId = 1;

/* PUBLIC + STATIC */
// 1. read-only
public int AdoptionId { get; }
// 2.
public string AdopterName { get; set; }
// 3. Auto-Property Initializer
public static int AdoptionFee { get; set; } = 50;

// 4. Custom Type Property
public Pet AdoptedPet { get; set; }
```

#### CONSTRUCTOR

- A single instance constructor

```cs
public Adoption(string adopterName, Pet adoptedPet, int adoptionFee) {}
```

<span aria-hidden="true"><br></span>

### Program.cs

#### USING

- This is the only file that needs this code
- `namespace` is not needed in this file unlike the other files.
- `Program.js` has to use a "Visitor's Pass" (the `using` statement) to reach inside and talk to the classes living there

```cs
using AnimalShelter;
```

#### NEW

- Just like in JavaScript, the `new` keyword is needed to create class instances (objects)

```cs
// 1.
Pet pet1 = new Pet(pet1Name, pet1Species, pet1Age);

// 2.
Pet pet2 = new Pet(pet2Name, pet2Species, pet2Age);
```

#### STATIC FIELD

- Static Member Access: Accessed using the Class Name (`Pet` and `Adoption`) instead of an object name, because the data belongs to the blueprint itself

```cs
// 1.
Pet.TotalPets

// 2.
Adoption.AdoptionFee
```
