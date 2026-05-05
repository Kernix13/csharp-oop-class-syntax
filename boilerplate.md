# Boilerplate code blocks

## Basic class in `ClassName.cs`:

```cs
namespace ProjectName;

class ClassName
{

  // Fields
  private string? _firstName; // firstName field
  private string _lastName; // lastName field
  public int Id { get; set; } = 1;

  // Properties
  public string FirstName { get; set; } // FirstName property
  public string LastName                 // LastName property
  {
      get { return _lastName; }
      set { _lastName = value; }
  }

  // Constructor
  public ClassName(string firstName, string lastName, int IdNumber)
  {
    FirstName = firstName;
    LastName = lastName;
    Id = IdNumber;
  }

  // Method
  public void UpdateName(string firstName, string lastName)
  {
      FirstName = firstName;
      LastName = lastName;
  }
}
```

## Create instances in `Program.cs`:

```cs
using ProjectName;

public string FirstName = "Jon";
public string LastName = "Smith";
public string Id = 123456789;

// <type> <variableName> = new <type()>
ClassName objName = new ClassName(FirstName, LastName, Id);
objName.UpdateName("Jonathon", "Smith")
Console.WriteLine($"{objName.FirstName} {objName.LastName} {objName.Id}");
```

## Static class

```cs
namespace ProjectName;

public static class StaticClass
{
  public static int StaticMethod(int num1, int num2)
  {
      return num1 * num2;
  }
}

// you would call that: StaticClass.StaticMethod(2, 3);
```

## Miscellaneous

- `using System.Globalization;`: en-US culture setting

> Implement class properties and methods: Lesson 4 "Examine automatically implemented properties" & lesson 5 "Restrict access to properties" => confusing

> Manage class implementations: Lesoon 3 "Implement private, static, and nested classes", lesson 6 "Instantiate objects using initializers and copy constructors", & lesson 7 "Examine class finalizers" => confusing

Things to skip or ignore:

1. Automatically implemented properties - just `{ get; set; }`
   - private, anonymous backing field
2. The `field` keyword
3. partial properties in partial classes
4. extension methods
5. copy constructors and object initializers

Confusing:

1. private vs protected vs omitting the set accessor to make the property read-only

<!--
Classes_M1 (Solution folder)
     Classes_M1 (Project folder)
         Dependencies
         Program.cs
 -->
