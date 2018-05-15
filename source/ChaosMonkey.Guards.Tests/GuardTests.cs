using System;
using Xunit;

namespace ChaosMonkey.Guards.Tests
{
    public class GuardTests
    {
        [Fact]
        public void IsNotNull_WhenArgumentIsNull_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNull<string>(null, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Fact]
        public void IsNotNull_WhenArgumentIsNotNull_ReturnsArgument()
        {
            var result = Guard.IsNotNull("Valid", "argumentName");
            Assert.Equal("Valid", result);
        }

        [Fact]
        public void IsNotEmpty_WhenStringIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEmpty(string.Empty, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Fact]
        public void IsNotEmpty_WhenStringIsNotEmpty_ReturnsArgument()
        {
            var result = Guard.IsNotEmpty("Argument", "argumentName");
            Assert.Equal("Argument", result);
        }

        [Fact]
        public void IsNotEmpty_WhenEnumerableIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEmpty(new string[0], "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Fact]
        public void IsNotEmpty_WhenEnumerableIsNotEmpty_ReturnsArgument()
        {
            var data = new[] {"data"};
            var result = Guard.IsNotEmpty(data, "argumentName");
            Assert.Same(data, result);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsNull_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty(null, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty(string.Empty, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsNotNullOrEmpty_ReturnsArgument()
        {
            var result = Guard.IsNotNullOrEmpty("Argument", "argumentName");
            Assert.Equal("Argument", result);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenEnumerableIsNull_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty<string[]>(null, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenEnumerableIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty(new string[0], "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenEnumerableIsNotNullOrEmpty_ReturnsArgument()
        {
            var data = new[] {"item1", "item2"};
            var result = Guard.IsNotNullOrEmpty(data, "argumentName");
            Assert.Same(data, result);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenIsNull_ThrowsWithExpectedException()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrWhiteSpace(null, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenStringIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrWhiteSpace(string.Empty, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be empty or whitespace only.", result.Message);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenStringIsWhitespace_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrWhiteSpace(string.Empty, "argumentName"));
            Assert.Equal("Argument 'argumentName' cannot be empty or whitespace only.", result.Message);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_WhenStringIsNotNullOrWhitespace_ReturnsArgument()
        {
            var result = Guard.IsNotNullOrWhiteSpace("Argument", "argumentName");
            Assert.Equal("Argument", result);
        }

        [Fact]
        public void IsGreaterThan_WhenArgumentIsGreaterThanExpected_ReturnsArgument()
        {
            const int argument = 4;
            const int expected = 2;
            const string name = "argument";
            var result = Guard.IsGreaterThan(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsGreaterThan_WhenArgumentIsLessThanExpected_ThrowsException()
        {
            var argument = new DateTime(2000, 1, 1);
            var expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
        }

        [Fact]
        public void IsGreaterThan_WhenArgumentIsEqualToExpected_ThrowsException()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
        }

        [Fact]
        public void IsGreaterThan_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            var argument = new DateTime(2000, 1, 1);
            var expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Exception resut = Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
            Assert.Contains(name, resut.Message);
        }

        [Fact]
        public void IsGreaterThan_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            var argument = new DateTime(2000, 1, 1);
            var expected = new DateTime(2012, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenArgumentIsGreaterThanExpected_ReturnsArgument()
        {
            const int argument = 4;
            const int expected = 2;
            const string name = "argument";
            var result = Guard.IsGreaterThanOrEqualTo(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenArgumentIsLessThanExpected_ThrowsException()
        {
            var argument = new DateTime(2000, 1, 1);
            var expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsGreaterThanOrEqualTo(argument, expected, name));
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenArgumentIsEqualToExpected_DoesNotThrowException()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            var result = Guard.IsGreaterThanOrEqualTo(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            var argument = new DateTime(2000, 1, 1);
            var expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsGreaterThanOrEqualTo(argument, expected, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            var argument = new DateTime(2000, 1, 1);
            var expected = new DateTime(2012, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsLessThan_WhenArgumentIsLessThanExpected_ReturnsArgument()
        {
            const int argument = 2;
            const int expected = 4;
            const string name = "argument";
            var result = Guard.IsLessThan(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsLessThan_WhenArgumentIsGreaterThanExpected_ThrowsException()
        {
            var argument = new DateTime(2012, 1, 1);
            var expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
        }

        [Fact]
        public void IsLessThan_WhenArgumentIsEqualToExpected_ThrowsException()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
        }

        [Fact]
        public void IsLessThan_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            var argument = new DateTime(2012, 1, 1);
            var expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsLessThan_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            var argument = new DateTime(2012, 1, 1);
            var expected = new DateTime(2000, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenArgumentIsLessThanExpected_ReturnsArgument()
        {
            const int argument = 2;
            const int expected = 4;
            const string name = "argument";
            var result = Guard.IsLessThanOrEqualTo(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenArgumentIsGreaterThanExpected_ThrowsException()
        {
            var argument = new DateTime(2012, 1, 1);
            var expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsLessThanOrEqualTo(argument, expected, name));
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenArgumentIsEqualToExpected_ReturnsArgument()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            var result = Guard.IsLessThanOrEqualTo(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            var argument = new DateTime(2012, 1, 1);
            var expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThanOrEqualTo(argument, expected, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            var argument = new DateTime(2012, 1, 1);
            var expected = new DateTime(2000, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsEqualTo_WhenArgumentAndExpectedEqual_ReturnsArgument()
        {
            const int argument = 2;
            const int expected = 2;
            const string name = "argument";
            var result  = Guard.IsEqualTo(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsEqualTo_WhenArgumentAndExpectedAreNotEqual_ThrowsException()
        {
            const decimal argument = 2.00M;
            const decimal expected = 3.00M;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsEqualTo(argument, expected, name));
        }

        [Fact]
        public void IsEqualTo_WhenExceptionIsThrownAndArgumentNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            const decimal argument = 2.00M;
            const decimal expected = 3.00M;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsEqualTo(argument, expected, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsEqualTo_WhenExceptionIsThrownAndArgumentNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const decimal argument = 2.00M;
            const decimal expected = 3.00M;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsEqualTo(argument, expected, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsNotEqualTo_WhenArgumentAndExpectedAreNotEqual_ReturnsArgument()
        {
            const int argument = 2;
            const int expected = 3;
            const string name = "argument";
            var result = Guard.IsNotEqualTo(argument, expected, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsNotEqualTo_WhenArgumentAndExpectedEqual_ThrowsException()
        {
            const decimal argument = 2.00M;
            const decimal expected = 2.00M;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotEqualTo(argument, expected, name));
        }

        [Fact]
        public void IsNotEqualTo_WhenExceptionIsThrownAndArgumentNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            const decimal argument = 2.00M;
            const decimal expected = 2.00M;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEqualTo(argument, expected, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsNotEqualTo_WhenExceptionIsThrownAndArgumentNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const decimal argument = 2.00M;
            const decimal expected = 2.00M;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEqualTo(argument, expected, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsInRange_WhenArgumentIsInTheSpecifiedRange_ReturnsArgument()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsInRange(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsInRange_WhenArgumentEqualsStartOfRange_ReturnsArgument()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsInRange(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsInRange_WhenArgumentEqualsEndOfRange_ReturnsArgument()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsInRange(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsInRange_WhenArgumentIsNotInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRange(argument, start, end, name));
        }

        [Fact]
        public void IsInRange_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRange(argument, start, end, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsInRange_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRange(argument, start, end, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsInRangeExclusive_WhenArgumentIsInTheSpecifiedRange_ReturnsResult()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsInRangeExclusive(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsInRangeExclusive_WhenArgumentEqualsStartOfRange_ThrowsException()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
        }

        [Fact]
        public void IsInRangeExclusive_WhenArgumentEqualsEndOfRange_ThrowsException()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
        }

        [Fact]
        public void IsInRangeExclusive_WhenArgumentIsNotInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
        }

        [Fact]
        public void IsInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsNotInRange_WhenArgumentIsInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
        }

        [Fact]
        public void IsNotInRange_WhenArgumentEqualsStartOfRange_ThrowsException()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
        }

        [Fact]
        public void IsNotInRange_WhenArgumentEqualsEndOfRange_ThrowsException()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
        }

        [Fact]
        public void IsNotInRange_WhenArgumentIsNotInTheSpecifiedRange_ReturnsArgument()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsNotInRange(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsNotInRange_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsNotInRange_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenArgumentIsInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenArgumentEqualsStartOfRange_ReturnsArgument()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsNotInRangeExclusive(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenArgumentEqualsEndOfRange_ReturnsArgument()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsNotInRangeExclusive(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenArgumentIsNotInTheSpecifiedRange_ReturnsArgument()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            var result = Guard.IsNotInRangeExclusive(argument, start, end, name);
            Assert.Equal(argument, result);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
            Assert.Contains(name, result.Message);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
            Assert.Contains("[unknown]", result.Message);
        }

        [Fact]
        public void IsRequiredThat_WhenConditionIsTrue_DoesNotThrowException()
        {
            const string message = "Custom Exception Message";
            Guard.IsRequiredThat(true, message);
        }

        [Fact]
        public void IsRequiredThat_WhenConditionIsFalse_ThrowsException()
        {
            const string message = "Custom Exception Message";
            Assert.Throws<GuardException>(() => Guard.IsRequiredThat(false, message));
        }

        [Fact]
        public void IsRequiredThat_WhenExceptionThrowsAndMessageIsNotNull_ExceptionMessageIsMessage()
        {
            const string message = "Custom Exception Message";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsRequiredThat(false, message));
            Assert.Equal(result.Message, message);
        }

        [Fact]
        public void IsRequiredThat_WhenExceptionThrownAndMessageIsNull_ExceptionMessageIsRequirementFailed()
        {
            const string message = null;
            const string expectedMessage = "The required expectation was not met.";
            Exception exception = Assert.Throws<GuardException>(() => Guard.IsRequiredThat(false, message));
            Assert.Equal(exception.Message, expectedMessage);
        }

        [Fact]
        public void IsTrue_WhenConditionIsFalse_ThrowsException()
        {
            Assert.Throws<GuardException>(() => Guard.IsTrue(false, "Custom Message"));
        }

        [Fact]
        public void IsTrue_WhenCondition_IsTrue_DoesNotThrowException()
        {
            Guard.IsTrue(true, "Custom Message");
        }

        [Fact]
        public void IsTrue_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMessage()
        {
            const string message = "Custom Message";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsTrue(false, message));
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public void IsTrue_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMustBeTrue()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsTrue(false, null));
            Assert.Equal("Condition must be true.", result.Message);
        }

        [Fact]
        public void IsFalse_WhenConditionIsTrue_ThrowsException()
        {
            Assert.Throws<GuardException>(() => Guard.IsFalse(true, "Custom Message"));
        }

        [Fact]
        public void IsFalse_WhenCondition_IsFalse_DoesNotThrowException()
        {
            Guard.IsFalse(false, "Custom Message");
        }

        [Fact]
        public void IsFalse_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMessage()
        {
            const string message = "Custom Message";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsFalse(true, message));
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public void IsFalse_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMustBeTrue()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsFalse(true, null));
            Assert.Equal("Condition must be true.", result.Message);
        }
    }
}