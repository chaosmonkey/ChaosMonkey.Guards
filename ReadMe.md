# ChaosMonkey.Guards
[![Build status](https://ci.appveyor.com/api/projects/status/ul8uoui2xod86fos?svg=true)](https://ci.appveyor.com/project/chaosmonkey/chaosmonkey-guards)

A Code Guard Library for .NET

ChaosMonkey.Guards is a library to make it simple to add and easy to read guard clauses in you .Net methods.

**Guard**

>*A boolean expression that must evaluate to true if the program execution is to continue in the branch in question.*
-- [Wikipedia](https://en.wikipedia.org/wiki/Guard_(computer_science))

Typically guard statements are added at the beginning of a method call to verify that certain conditions have been met by the arguments that were passed into the call.  For example a null check.  The idea is that it is better to verify that the value is not illegal (null in this case) and fail fast if it is, rather than allow the code to fail at a later point due to the invalid input.
    
    public void DoSomeWork(string text)
    {
        if(text==null)
        {
            throw new ArgumentNullException("text");
        }
        // You should do some work here...
    }

##Usage##
Simply use one of the methods on the Guard class to verify your expectations.
Ex.
```csharp
  public void MethodFoo(object arg)
  {
    Guard.IsNotNull(arg, "arg");
    
    /// Do some actual work here...  
  }
```

If the expected condition is not met a GuardException will be thrown.  The message will either be a short description of the violation including the argument name or the specified custom message as the case may be.  

##Methods##
Most methods accept an argument and the name of the argument as parameters.  Some also require other parameters, for example the IsGreaterThan method takes a parameter that the argument must be greater than.  Most of the parameters should be self explanatory, but intellisense should also provide a description or you can review the xml comments in the source for more details.

* Guard.IsNotNull 
* Guard.IsNotEmpty 
* Guard.IsNotEmpty 
* Guard.IsNotNullOrEmpty 
* Guard.IsNotNullOrEmpty 
* Guard.IsNotNullOrWhiteSpace 
* Guard.IsGreaterThan 
* Guard.IsGreaterThanOrEqualTo 
* Guard.IsLessThan 
* Guard.IsLessThanOrEqualTo 
* Guard.IsEqualTo 
* Guard.IsNotEqualTo 
* Guard.IsInRange 
* Guard.IsInRangeExclusive 
* Guard.IsNotInRange 
* Guard.IsNotInRangeExclusive 
* Guard.IsRequiredThat 
* Guard.IsTrue 
* Guard.IsFalse 


## Builds/ Continuous Integration ##

### Latest Build ###
* [Build Output - Console](https://ci.appveyor.com/project/chaosmonkey/chaosmonkey-guards)
* [Test Results ](https://ci.appveyor.com/project/chaosmonkey/chaosmonkey-guards/build/tests)
* [Build Artifacts](https://ci.appveyor.com/project/chaosmonkey/chaosmonkey-guards/build/artifacts)

### History ###
* [Build History](https://ci.appveyor.com/project/chaosmonkey/chaosmonkey-guards/history)

## NuGet ##
[NuGet Gallery](https://www.nuget.org/packages/ChaosMonkey.Guards/1.0.30 )

**Package Manager Console Installation Command**
<pre>Install-Package ChaosMonkey.Guards </pre>
