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
1. What exactly are _backing fields_?
1. The keyword `value` KW represents the value being assigned to the property
1. Classes declared directly within a namespace can have `public`, `internal` or `file` access. Classes are assigned `internal` access by default when no access modifier is specified.
1. Creating a static class is therefore basically the same as creating a class that contains only static members and a private constructor
1. What is garbage collection and is it important to know?
