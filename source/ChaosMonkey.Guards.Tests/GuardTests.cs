using Xunit;

namespace ChaosMonkey.Guards.Tests
{
    public class GuardTests
    {
        [Fact]
        public void For_ReturnedGuardHasPassedName()
        {
            var argument = "value";

            var result = Guard.For(argument, nameof(argument));

            Assert.Equal("argument", result.Name);
        }

        [Fact]
        public void For_ReturnedGuardHasPassedValue()
        {
            var argument = "value";

            var result = Guard.For(argument, nameof(argument));

            Assert.Equal("value", result.Value);
        }

        [Fact]
        public void IsNotNull_WhenNotNull_ReturnsOriginalGuard()
        {
            var argument = "value";
            var sut = Guard.For(argument, nameof(argument));

            var result = sut.IsNotNull();

            Assert.NotNull(result);
            Assert.IsType<Guard<string>>(result);
        }

        [Fact]
        public void IsNotNull_WhenNull_ThrowsGuardException()
        {
            string argument = null;
            var sut = Guard.For(argument, nameof(argument));

            Assert.Throws<GuardException>(() => sut.IsNotNull());
        }

        [Fact]
        public void IsNotNull_WhenNull_GuardExceptionContainsNameOfArgument()
        {
            string argument = null;
            var sut = Guard.For(argument, nameof(argument));

            var exception = Assert.Throws<GuardException>(() => sut.IsNotNull());

            Assert.Contains(nameof(argument), exception.Message);
        }
    }
}