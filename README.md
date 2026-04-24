# Introduction to Object-Oriented Programming (OOP)

This project uses various Object-Oriented Programming concepts and syntax such as classes, fields, properties, and constructors.

<span aria-hidden="true"><br></span>

## Installation & Usage

1. Clone this repository and switch into project folder

   ```sh
   git clone https://github.com/Kernix13/csharp-oop-class-syntax
   cd csharp-oop-class-syntax
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
git clone https://github.com/Kernix13/csharp-oop-class-syntax
cd csharp-oop-class-syntax
dotnet run
```

> [!NOTE]
> There are variables used to create 2 pet objects in `Project.cs`. Those objects are what creates the output in the console. I could create `ReadLine` statements and output the results, but you would only see one object in the console.

Console output:

```sh
$ dotnet run
Pet class initialized
New pet: Buddy, Pet id: 1, Species: dog, Pet Age: 1.5
New pet: Luna, Pet id: 2, Species: cat, Pet Age: 12
Total pets in shelter: 2
Adoption ID: 1, Adopter Name: Jim, Adopted Pet: Luna, Adoption Fee: $100
```

<span aria-hidden="true"><br></span>

## Class syntax used

I use the following syntax/keywords in this project:

1. namespace
1. using
1. public class
1. private static field
1. public static field
1. public field
1. private field
1. public properties with `get`, `set` accessors
1. public property with `private set;`
1. public property with modern syntax: `{ get; set; }`
1. public property with the longer/verbose syntax
1. public property with validation
1. 1 Static constructor
1. 1 Public instance constructor with parameters
1. 1 public method with the `return` keyword
1. 2 public void methods
1. Partial class (weak implementation)
1. new keyword to create objects from the classes

<span aria-hidden="true"><br></span>

## Class syntax _NOT_ used

I did not, or decided not to, use the following due to the fact I did not understand them or did not see a way to work them in:

1. `=>`
1. The `?` in expressions like `public string?`
1. `readonly`
1. `protected`
1. `required`
1. `internal`
1. `abstract`
1. The `this` keyword because I am not sure when/where to use it (_Add later_)
1. `public void` for a method
1. The `init` accessor
1. The `field` keyword
1. Expression methods: `this ClassName paramName`
1. The `ref` or `out` keywords
1. Static classes
1. Nested classes
1. Partial members
1. Named arguments (_Add later_)
1. Optional arguments (_Add later_)
1. Object initializers
1. Copy constructors
1. Class finalizers

I did not use arrays or `Console.ReadLine` or other C# syntax learned previously because there was so much to learn for this project. LAter I could add an array of pet types (dog, cat, rabbit, etc) and use a ReadLine to grab the value and add it to `Species` in `Pet.cs`.

The following keywords and terms were covered in the lessons but I do not know what they are, how to use them, or when to use them:

- `struct`, `interface`, `enum`, `record`, `delegate`

<span aria-hidden="true"><br></span>

## Important notes

1. Static fields are accessed using the class name, not the instance name
1. `this` is used to access fields, properties, and methods of the current instance
1. The `this` keyword is not available in a static constructor
1. Properties combine aspects of both fields and methods
1. Unlike fields, properties aren't classified as variables. Therefore, you can't pass a property as a `ref` or `out` parameter
1. The keyword `value` KW represents the value being assigned to the property
1. Classes declared directly within a namespace can have `public`, `internal` or `file` access. Classes are assigned `internal` access by default when no access modifier is specified.
1. Creating a static class is therefore basically the same as creating a class that contains only static members and a private constructor

<span aria-hidden="true"><br></span>

## Questions

1. Why exactly do I need to use `namespace`?
   1. So that I can use the classes in all files?
   1. Is it similar to `import`/`export` syntax in ES Modules or it that what `partial` does?
1. What exactly are _backing fields_?
1. What is garbage collection and is it important to know?

<span aria-hidden="true"><br></span>

## Code: line-by-line

Examples and descriptiosn for the code I used.

### Pet.cs

#### NAMESPACE

- I removed this from Program.cs and the app crashed:

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
- private backing field: automatic when you use `{ get; set; }`
- 🚫 I forgot to add a note about this: `private set;`

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

### <ins>PetMethods.cs</ins>

#### NAMESPACE

- This is needed here as well

```cs
namespace AnimalShelter;
```

#### CLASS + PARTIAL

- The keyword `partial` is needed in the "parent" class and is the partial files as well - they must match!

```cs
public partial class Pet
```

#### FIELD MODIFIERS

```cs

```

#### PROPERTIES

```cs

```

#### CONSTRUCTOR

```cs

```

#### METHOD

```cs

```

<span aria-hidden="true"><br></span>

### Adoption.cs

#### USING

- This is the only file that needs this code
- `namespace` is not needed in this file unlike the other files.

```cs
using AnimalShelter;
```

#### NEW

-

```cs
// 1.
Pet pet1 = new Pet(pet1Name, pet1Species, pet1Age);

// 2.
Pet pet2 = new Pet(pet2Name, pet2Species, pet2Age);
```

#### STATIC FIELD

```cs
// 1.
Pet.TotalPets

// 2.
Adoption.AdoptionFee
```
