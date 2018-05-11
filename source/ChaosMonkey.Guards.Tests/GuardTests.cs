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

        [Fact]
        public void Requires_WhenConditionEvaluatesTrue_ReturnsOriginalGuard()
        {
            var argument = "value";
            var sut = Guard.For(argument, nameof(argument));

            var result = sut.Requires(a=>a==argument, "Argument '{0}' must equal 'value'.");

            Assert.NotNull(result);
            Assert.IsType<Guard<string>>(result);
        }

        [Fact]
        public void Requires_WhenConditionEvaluatesFalse_ThrowsGaurdException()
        {
            string argument = "";
            var sut = Guard.For(argument, nameof(argument));
            
            Assert.Throws<GuardException>(() => sut.Requires(a => a == "value", "Argument '{0}' must equal 'value'."));
        }

        [Fact]
        public void Requires_WhenConditionEvaluatesFalse_ThrowsGaurdExceptionWithExpectedMessage()
        {
            string argument = "";
            var sut = Guard.For(argument, nameof(argument));

            var excepton = Assert.Throws<GuardException>(() => sut.Requires(a => a == "value", "Argument '{0}' must equal 'value'."));

            Assert.Equal("Argument 'argument' must equal 'value'.", excepton.Message);
        }

        [Fact]
        public void Requires_WhenConditionEvaluatesFalseAndFailureMessageIsNull_ThrowsGaurdExceptionWithDefaultMessage()
        {
            string argument = "";
            var sut = Guard.For(argument, nameof(argument));

            var excepton = Assert.Throws<GuardException>(() => sut.Requires(a => a == "value", null));
            Assert.Equal("A guard constraint failed.  No failure message was supplied.", excepton.Message);
        }

        [Fact]
        public void Requires_WhenConditionEvaluatesFalseAndGuardNameIsNull_ThrowsGaurdExceptionWithExpectedMessage()
        {
            string argument = "";
            var sut = Guard.For(argument, null);

            var excepton = Assert.Throws<GuardException>(() => sut.Requires(a => a == "value", "Argument '{0}' must equal '{1}'."));

            Assert.Equal("Argument 'Unknown' must equal ''.", excepton.Message);
        }

        [Fact]
        public void Requires_WhenConditionEvaluatesFalseAndGuardValueIsNull_ThrowsGaurdExceptionWithExpectedMessage()
        {
            string argument = null;
            var sut = Guard.For(argument, nameof(argument));

            var excepton = Assert.Throws<GuardException>(() => sut.Requires(a => a == "value", "Argument '{0}' must equal '{1}'."));

            Assert.Equal("Argument 'argument' must equal '[NULL]'.", excepton.Message);
        }
    }
}