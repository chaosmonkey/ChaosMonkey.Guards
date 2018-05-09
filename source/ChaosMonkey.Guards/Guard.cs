using System;

namespace ChaosMonkey.Guards
{
    public class Guard<T>
    {
        public Guard(T value, string name)
        {
            Value = value;
            Name = name;
        }

        public T Value { get; protected set; }

        public string Name { get; protected set; }

        public Guard<T> IsNotNull()
        {
            if (Value == null)
            {
                throw new GuardException($"The argument '{Name}' cannot be null.", new ArgumentNullException(Name));
            }

            return this;
        }

        public Guard<T> IsNotEmpty()
        {

        }
    }

    public static class Guard
    {
        public static Guard<T> For<T>(T argument, string name)
        {
            return new Guard<T>(argument, name);
        }
    }
}
