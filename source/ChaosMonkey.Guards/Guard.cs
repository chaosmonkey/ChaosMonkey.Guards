using System;
using System.Linq.Expressions;

namespace ChaosMonkey.Guards
{
    /// <summary>
    /// A code guard
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Guard<T>
    {
        /// <summary>
        /// Create a new guard
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public Guard(T value, string name)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// The value of the guarded argument
        /// </summary>
        public T Value { get; protected set; }

        /// <summary>
        ///  The name of the guarded argument
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Verify the value of the argument is not null or throw exception
        /// </summary>
        /// <returns></returns>
        /// <exception cref="GuardException"></exception>
        public Guard<T> IsNotNull()
        {
            if (Value == null)
            {
                throw new GuardException($"The argument '{Name}' cannot be null.", new ArgumentNullException(Name));
            }

            return this;
        }

        /// <summary>
        /// Verifies the specified condition evaluates to true, or throws an exception.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="failureMessage"></param>
        /// <returns></returns>
        /// <exception cref="GuardException"></exception>
        public Guard<T> Requires(Func<T, bool> expression, string failureMessage)
        {
            if (!expression.Invoke(Value))
            {
                var message = string.Format(failureMessage ?? "A guard constraint failed.  No failure message was supplied.", Name??"Unknown", Value?.ToString() ?? "[NULL]");
                throw new GuardException(message);
            }

            return this;
        }
    } 

    /// <summary>
    /// Guard Helpers
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Fluent api method for creating a new Guard.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Guard<T> For<T>(T argument, string name)
        {
            return new Guard<T>(argument, name);
        }
    }
}
