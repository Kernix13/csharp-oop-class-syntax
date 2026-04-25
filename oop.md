# Most important OOP notes

> method overloading is a feature that allows a class to have multiple methods with the same name but different parameter lists

## 1. Get started with classes and objects

### Examine the .NET type system

- You use the `struct`, `class`, `interface`, `enum`, and `record` constructs to _create your own custom types_
- The .NET class library is a collection of custom types
- Types that you define by using the `struct` keyword are value types - all the built-in numeric types are structs
- Value Types: Int32, Boolean, User-defined structs, all enums
- Types that you define by using the `class` or `record` keyword are reference types
- Reference types: String, Array, ValueType, Enum, User-defined classes & interfaces
- A `class`, `struct`, or `record` declaration is like a blueprint that is used to create instances or objects at run time
  - A **class** is a reference type.
  - A `struct` is a value type
  - Record types can be either reference types (`record class`) or value types (`record struct`)
- Structures typically store data that isn't intended to be modified after the struct is created
- Records typically store data that isn't intended to be modified after the object is created
- There are two categories of value types: `struct` and `enum`
- Value types are sealed: You can't derive a type from any value type
- You use the `struct` keyword to create your own custom value types
- The `class`, `record`, `delegate`, `array`, and `interface` types are _reference types_.
- When you declare a variable of a reference type, it contains the value `null` until you create an instance

```cs
// declaring and initializing an array in one line
int[] numbers2 = new int[] { 1, 2, 3, 4, 5 };
```

### Design and use classes

- Physical attributes are often referred to as `properties`, while behavioral attributes are often referred to as functions (`methods`)
- Classes use **_properties_** to enable access to data and methods to enable behaviors
- Class properties are used to manage the data that differentiates one object (class instance) from another object
- Class properties enable objects to
  - read,
  - write,
  - or compute the value of variables (data fields)
- **Properties appear as public data members, but they're implemented as special methods called _accessors_**
- **Using namespaces**: devs declare their own namespaces to help control the scope of class and method names
- implicit `global using` directives are added to new C# projects
  - you can use types defined in these namespaces without having to specify their fully qualified name or manually add a `using` directive
  - the global using directives are added to a generated file in the project's `obj` directory
- Declaring your own namespaces can help you control the scope of class and method names
- The `using` directive eliminates the requirement to specify the name of the namespace for every class (?)
- The global namespace is the "root" namespace: `global::System` always refers to the .NET System namespace.

```cs
namespace AnimalShelter; // vs:
using AnimalShelter;
```

### Create class constructors and instantiate objects

Static constructor:

- Static constructors are used to initialize any static data, or to perform a particular action that needs to be performed only once
- Static constructors are called automatically before the first instance is created or any static members are referenced
- A static constructor doesn't take access modifiers or have parameters.
- A class can only have one static constructor.
- If you don't provide a static constructor to initialize static fields, all static fields are initialized to their default value.
- A field declared as `static readonly` can only be assigned as part of its declaration or in a static constructor.

> When an explicit static constructor isn't required, initialize static fields at declaration rather than through a static constructor for better runtime optimization

Instance constructor:

- An instance constructor doesn't include a return type.
- When a class has more than one constructor, the constructors usually take different arguments
- classes without constructors are given a public parameterless constructor by the C# compiler in order to enable class instantiation
- Constructors that take parameters must be called using the new operator
- If a field or property has no initializer, its value is set to the default value of the field's or property's type.
- The params passed to a constructor are local to the constructor & are often used to initialize the data fields of a class

```cs
// Constructor expression body definition (single line):
public Car(string model) => modelName = model;
```

### Create classes and objects in C#

- Static fields are initialized before an instance of the class is created
- static fields are accessed using the class name
- **static fields are accessed using the class name, not an instance**
- Readonly fields can be assigned a value only when they’re declared or in a constructor
- A static constructor is called only once
- Static constructors are used to initialize static fields
- The `this` is used to access fields, properties, and methods of the current instance
- **The `this` keyword is not available in a static constructor.**

**Optional parameters must appear after all required parameters**

<span aria-hidden="true"><br></span>

## 2. Implement class properties and methods

### Examine class members

- fields to define the data of an object,
- properties to control access to fields, and
- methods to define the behavior of an object
- Properties look like fields when used, act like methods behind the scenes
- _Fields_: Fields are variables declared at class scope. A field may be a built-in numeric type **or an instance of another class**.
- _Constants_: Constants are fields whose value is set at compile time and can't be changed.
- _Properties_: Properties are methods on a class that are accessed as if they were fields on that class.
- _Methods_: Methods define the actions that a class can perform
- _Events_: Events provide notifications about occurrences, such as button clicks. Events are defined and triggered by using _delegates_

```cs
// field as an instance of another class (in Adoption):
public Pet AdoptedPet { get; set; }
```

### Get started with class properties and accessors

- properties are implemented as special methods called accessors
- Properties combine aspects of both fields and methods
- A property without a `set` accessor is considered read-only
- A property without a `get` accessor is considered write-only
- Properties are declared by
  - specifying the access level of the field,
  - followed by the type of the property,
  - followed by the name of the property,
  - followed by a code block that declares a get and/or a set accessor
- Properties can transparently expose data on a class where that data is retrieved from some other source, such as a database.
- They can take an action when data is changed, such as raising an event, or changing the value of other fields.
- They can validate data before allowing a change.
- The fields that provide the values for property accessors are often called _backing fields_
- The code block for a get accessor can also be used to return a calculated value
- The `set` accessor uses an implicit parameter called `value`, whose type is the type of the property
- Expression-bodied members: An expression body definition consists of the `=>` token followed by the expression

```cs
public int Age {
    get { return age; }
    set { age = value; }
}

// expression body definition
private string? _name;
public string Name
{
    get => _name ?? "NA";
    set => _name = value;
}
```

### Examine automatically implemented properties

- You might need to add validation to an automatically implemented property
- You use the `field` keyword to access the compiler synthesized backing field of an automatically implemented property (?)

```cs
// initialize automatically implemented properties similarly to fields
public string FirstName { get; set; } = "FirstName";
```

### Restrict access to properties

- By default, get and set accessors have the same accessibility level as the property to which they belong
- you can restrict the accessibility of either the get or set accessor
- Typically, you restrict the accessibility of the set accessor, while keeping the get accessor publicly accessible

### Implement class methods and parameters

- Methods are declared in a class, record, or struct by specifying:
  - An optional access level, such as public or private. The default is private.
  - Optional modifiers such as abstract or sealed
  - The return value, or void
  - The method name
  - Any method parameters
- Methods can be either _instance_ or _static_
- To pass a parameter by reference, you use the `ref` or `out` keyword
- By using the `params` keyword to indicate that a parameter is a parameter collection, you allow your method to be called with a variable number of arguments
- Sometimes, you want your method to return more than a single value
- You use tuple types and tuple literals to return multiple values

 <!-- see `ParamsExample` in `m2-w3.md` -->

```cs
// Anyone can call this.
public void StartEngine() {}
// Only derived classes can call this
protected void AddGas(int gallons) {}
// Derived classes can override the base class implementation
public virtual int Drive(int miles, int speed) { return 1; }
// Derived classes can override the base class implementation
public virtual int Drive(TimeSpan time, int speed) { return 0; }
// Derived classes must implement this.
public abstract double GetTopSpeed();
```

### Implement extension methods for a class

- Extension methods let you "add" a method to an existing type without modifying the type itself or implementing the new method in an inherited type
- Extension methods are static methods, but they're called as if they were instance methods on the extended type
- `public static bool IsOverdrawn(this BankAccount account)` - `this` always has to be the 1st param and signals an extension method
- You can use extension methods to extend a class or interface, but not to override them.
- An extension method with the same name and signature as a class method is never called.
- At compile time, extension methods always have lower priority than instance methods defined in the type itself.
- However, modifying an object's code or deriving a new type whenever it's reasonable and possible to do so, is still considered preferable
- Extension methods are an excellent choice when the original source isn't under your control
- NOTE: Extension methods are passed an instance of the class they’re extending as the first parameter

> Extension methods are defined as `static` methods in a `static` class and are used as if they were instance methods of the extended class

```cs
// class is static
public static class BankCustomerExtensions
{
  // method is static
  public static bool IsValidCustomerId(this BankCustomer customer) {}
}
```

<span aria-hidden="true"><br></span>

## 3. Manage class implementations

- Encapsulation is about hiding the data members that users of a class don't need
- Data members are encapsulated, or hidden, using the private accessor keyword
- The lifecycle of a class includes the following steps: Class Definition > Compilation > Loading > Instantiation > Initialization > Usage > Garbage Collection > Destruction
- Class access: `public`, `internal` or `file`
- Class member access: `public`, `private`, `protected`, `protected internal`, `private protected`, or `file`
- Private constructors are often used in classes that contain only static members
- If you don't specify an access modifier for a constructor, it defaults to `private`
- a static class can't be instantiated (and only contains static members)
- you can access the members of a static class by referencing the class name
- the main features of a static class::
  - Contains only static members.
  - Can't be instantiated.
  - Is sealed.
  - Can't contain Instance Constructors.
- Creating a static class is therefore basically the same as creating a class that contains only static members and a private constructor
- Nonstatic classes should also define a static constructor if the class contains static members that require non-trivial initialization
- **The static member is always accessed by the class name, not the instance name**
- _It's more typical to declare a nonstatic class with some static members, than to declare an entire class as static_
- Two common uses of static fields are to keep a count of the number of objects that are instantiated, or to store a value that must be shared among all instances
- You declare static class members by using the `static` keyword before the return type of the member

### Implement classes using partial classes

- _Declaring a class over separate files enables multiple programmers to work on it at the same time_.
- To split a class definition, use the `partial` keyword modifier
- All the parts must have the same accessibility, such as public, private, and so on
- If any part is declared abstract, then the whole type is considered abstract.
- If any part is declared sealed, then the whole type is considered sealed.
- At compile time, attributes of partial-type definitions are merged
- All partial-type definitions meant to be parts of the same type must be modified with partial
- The following keywords on a partial-type definition are optional, but if present on one partial-type definition, the same must be specified on other partial definition for the same type:
  - public, private, protected, internal, abstract, sealed, base class, new modifier (nested parts), generic constraints

```cs
// what is this
[SerializableAttribute]
partial class Moon {/* code */ }
```

### Specify named and optional method arguments

- Named arguments enable you to specify an argument for a parameter by matching the argument with its name rather than with its position in the parameter list
- Optional arguments enable you to omit arguments for some parameters
- When you use named and optional arguments, the arguments are evaluated in the order in which they appear in the argument list, not the parameter list
- A nullable reference type (`T?`) allows arguments to be explicitly null but does not inherently make a parameter optional
- Optional parameters are defined at the end of the parameter list, after any required parameters.
- IntelliSense uses brackets to indicate optional parameters
