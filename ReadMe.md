# ChaosMonkey.Guards#
A Code Guard Library for .NET

ChaosMonkey.Guards is a library to make it simple to add and easy to read guard clauses in you .Net methods.

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

