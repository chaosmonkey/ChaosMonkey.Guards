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

If the  expected conition is not met a GuardException will be thrown.

