Code samples included.
[Video demonstration](https://youtu.be/6cQaLeHo4CU)

Errata: 
- colon is the symbol for extends/implements (not semi-colon) 

Also:
- const variables are usually all caps. MESSAGE. If it were multiple words, instead of camelCasing, we'd separate them with an underscore: INSTUCTOR_MESSAGE. Since the runtime isn't available until after the app is compiled, the value assigned to any const must be a literal value. You can't use variables or methods when storing a const. If you need to have the runtime available before you know what should be assigned to the const, then what you're actually looking for is readonly. 

- the Message string uses the @ symbol followed by quotes. This is a multi-line literal. Whitespace, including new lines, are preserved.

- var is a shortcut in c#. It decides what type the variable is (based on the return type of the method or object on the right side of the assignment is.) It's different than dynamic. Don't use dynamic.

***
OOP Intro

Objects are a natural way to understand code organization and enable a better separation of concerns in your code. Having code organized with their corresponding objects helps readability, reusability, and maintainability of a project. 

Could you imagine a team of 30 people all trying to work on and edit the same file at the same time? Could you imagine needing to understand everything about the application to run your one little part? There can be millions of lines of code, and to work on one file is unreasonable. So, we separate related code into corresponding files. 

But it helps to really keep a single concern in mind when working on each piece of your code. So, instead of simply separating them into different files, we're identifying the different objects in our design. Imagine we have a Basketball Goal. That's an object. It's also comprised of other objects, like a backboard, brackets, mounting hardware, a rim, and a net. Objects are how we organize like-code, not just within our file system, but within how we think about our code itself. 

***Objects:
Every object has properties that describe it, and/or things it can do. These are called properties, and methods… (You may have heard methods referred to as functions. Those are synonymous terms.) 
This is the "has a" pattern. An object "has" or is composed of several components (which are themselves other objects)
	- Objects will typically "have" their own local variables and functions that callers outside of the object don't need to know about. 
	- They will also "have" properties and/or methods that callers outside of the object do need to know about. 

***Class
A 'class' is a special keyword in many programming languages. It is how we describe what an object will look like (what properties and or methods it has). You create an instance of an object which is described in its 'class' using the 'new' keyword.


"has a"
	Properties
	Our basketball goal really does care about what the inner diamater of the pole is. Our pole will have a property called height and another called outerDiameter. 
	
  Methods
	Methods are things our object can do. Let's say we have an object called console. A simple Console may just perform 2 tasks. It can get input and show output. You've done this already in python. So, it will have a method that could be called getInput() and another called showOutput(). In C#, this is the Console class's Readline and Writeline methods.


---

"Is a"
	"is a" relationships are important to classes to. If you have a class named Person each instance of those objects "is a" Person. 
	You might create several instances of a Person class. There could be an instance named Bob (meaning it's stored in a variable or property with the variable name Bob. Bob is an instance of Person.
	Sometimes, we want to be more specific in our types of objects though. We might have Student and Instructor that are more specific objects. They're both a Person, so they have a lot of things in common, but they also have additional properties and methods that aren't available from the other. For example, an Instructor might have a method called Instruct() that wouldn't make since to have on all instances of Person, since it's only available for Instructors. Similarly, students might have a ReceiveInstruction() method. 
	So we have 3 separate classes: Person, Student, and Instructor.
	But both Student and Instructor objects are also Person objects, with all the properties and methods of any other person object. So we say Student and Instructor classes both 'extend' the Person class.
	That means there's a class named Student that extends the Person class. There's a separate class named Instructor that also extends Person. 

When we have an instance of a Student, we can get the property values and call Talk(), Listen(), and ReceiveInstruction(). A person class object will have properties: Height, First Name, Last Name, Full Name. They will also have a method called Speak() and Listen(). Instructors will have a method called Instruct() and Students will have a method called ReceiveInstructions()
	If we have an instance of Student and we tried to call Instruct() there would be a 'compile time error', meaning our code won't even run. 'Compile-time errors' are definitely preferred because you know about it before you even run the application. 
	'Runtime exceptions' occur after the app is started, while it's running and can be difficult to reproduce or troubleshoot once they do reproduce. 
If we try to call the Student's Talk() method while ReceiveInstruction is running we'll cause an InterruptionException. (interrupts are actually a thing, but they're not about exceptions. Different, much more advanced topic. Here, I'm using it metaphorically.)

***Access Modifiers
Scope 
Variables have scopes. If they're defined within a function, then only code within that function can see that it exists. If you define a variable locally  in a class it's only available within the class, unless the class makes it something other than private. Sometimes private and public are inferred if they're not specified, so it's best to always set your "Accessibility modifiers" specifically to avoid unexpected results.

***Static vs instance
You might have several objects created at the same time from the same class, but those are separate "instances" of the 'object' (which is described by its 'class') 
Sometimes, every instance of an object from a specific class will have the same value. Some values are unique to each instance. Let's say you have a person. If a person had a genus and species properties, every single human today would have homo and sapien values. So, if we have a person object we might say that the genus and species are all the same, so they're static. Then we could call Person.Genus and Person.Species without needing an instance of Person. But our Height and name properties are unique to each instance, so we do have to create an instance of person to call those methods.
Console methods are static. That's why we don't need to create a new instance of the console to call them. 

***constructor
This code defines what information is needed to create an instance of the class.
A person object's constructor might accept initial values for height, name, etc that may or may not be changed later in runtime, depending on the behavior specified within the class.

***Interface 
interface and class are similar. 

Classes can 'implement' an interface or several interfaces.

The difference is Interfaces simply state that everything that implements this interface will have 
	- these properties, 
	- and these methods, that accept these parameters.

A class defines the logic for getting to the value of the properties and defines how the method is implemented.

You cannot create a 'new' interface. You can only create instances of an object that implement that interface.

You might have a class named Paper and another interface in our example called IGradePapers that defines a function named GradePaper and accepts a Paper object. 

***abstract classes
It's a combination of interface and class.

They're similar to interfaces and classes can extend an abstract-class similar to the way they can 'implement' an interface. 

Abstract classes are also similar to classes. They can also 'implement' interfaces the same way classes do too. 

The difference between an abstract class and a class is that an abstract class only defines logic for getting some of the properties and the implementation of some of the methods while saying that actual classes that extend this abstract class must define their own implementations for the other methods and properties required to extend the abstract class.

When a class extends an abstract class it must implement the methods and properties that were defined, but not implemented, in the abstract class.

You cannot create an instance of an abstract class. You can only create instances of class objects.

***enum
Similar to class, but very specific. It simply stores a finite list of available choices.

You might have an Enum called GradeLevel. Then the GradeLevel enum would say that you can either be:
	- Freshman
	- Sophomore
	- Junior
	- Senior
	- PostGrad
And that's the entire enum.

An enum stores a number in the background and the name of the property we define is just a more human readable version of that number. In the example above: Freshman is assigned the value of 0, Sophomore is 1, etc. We can manually specific what numbers map to which property names if we choose though. 

Classes don't like when other objects touch things they don't need to know about, so they only expose a property's getter or setter if you allow it. You can have a public getter and a private setter for example.

An object does not need to know everything about a classes inner variables and functions. A class should only expose methods and properties that the caller needs. 
For example:
An object does not need to know whether the Full Name property on our Person class is just an amalgimation of First and Last Name or if it's based on some other logic, such as the person's nick name + last name instead of first name plus last name. All the outside object cares about is what's the person's name (or user name, etc…)

*** const and readonly
Constant values can't be changed once the app is compiled.
Readonly values can't be changed once they're created in runtime. Many times we'll have a constructor that accepts the initial value for a readonly variable. Property's with exposed get but a private set are very similar to, and often backed by a readonly variable.

const variables are usually all caps. MESSAGE. If it were multiple words, instead of camelCasing, we'd separate them with an underscore: INSTUCTOR_MESSAGE. Since the runtime isn't available until after the app is compiled, the value assigned to any const must be a literal value. You can't use variables or methods when storing a const. If you need to have the runtime available before you know what should be assigned to the const, then what you're actually looking for is readonly. 



