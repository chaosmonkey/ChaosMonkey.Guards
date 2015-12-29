using System;
using NUnit.Framework;

namespace ChaosMonkey.Guards.Tests
{
    [TestFixture]
    public class GuardTests
    {
        // SetUp & Mocks
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        // Tests
        [Test]
        public void IsNull_WhenargumentIsNull_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNull<string>(null, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Test]
        public void IsNull_WhenargumentIsNotNull_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => Guard.IsNotNull("Valid", "argumentName"));
        }

        [Test]
        public void IsNotEmpty_WhenStringIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEmpty(string.Empty, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Test]
        public void IsNotEmpty_WhenStringIsNotEmpty_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => Guard.IsNotEmpty("Argument", "argumentName"));
        }

        [Test]
        public void IsNotEmpty_WhenEnumerableIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEmpty(new string[0], "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Test]
        public void IsNotEmpty_WhenEnumerableIsNotEmpty_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Guard.IsNotEmpty(new[] { "data" }, "argumentName"));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenStringIsNull_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty(null, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Test]
        public void IsNotNullOrEmpty_WhenStringIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty(string.Empty, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Test]
        public void IsNotNullOrEmpty_WhenStringIsNotNullOrEmpty_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Guard.IsNotNullOrEmpty("Argument", "argumentName"));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenEnumerableIsNull_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty<string[]>(null, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Test]
        public void IsNotNullOrEmpty_WhenEnumerableIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrEmpty(new string[0], "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be empty.", result.Message);
        }

        [Test]
        public void IsNotNullOrEmpty_WhenEnumerableIsNotNullOrEmpty_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Guard.IsNotNullOrEmpty(new[] { "item1", "item2" }, "argumentName"));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenIsNull_ThrowsWithExpectedException()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrWhiteSpace(null, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be null.", result.Message);
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenStringIsEmpty_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrWhiteSpace(string.Empty, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be empty or whitespace only.", result.Message);
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenStringIsWhitespace_ThrowsWithExpectedMessage()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotNullOrWhiteSpace(string.Empty, "argumentName"));
            Assert.AreEqual("Argument 'argumentName' cannot be empty or whitespace only.", result.Message);
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenStringIsNotNullOrWhitespace_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Guard.IsNotNullOrWhiteSpace("Argument", "argumentName"));
        }

        [Test]
        public void IsGreaterThan_WhenargumentIsGreaterThanExpected_DoesNotThrowException()
        {
            const int argument = 4;
            const int expected = 2;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsGreaterThan(argument, expected, name));
        }

        [Test]
        public void IsGreaterThan_WhenargumentIsLessThanExpected_ThrowsException()
        {
            DateTime argument = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
        }

        [Test]
        public void IsGreaterThan_WhenargumentIsEqualToExpected_ThrowsException()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
        }

        [Test]
        public void IsGreaterThan_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsargumentName()
        {
            DateTime argument = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Exception resut = Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
            Assert.IsTrue(resut.Message.Contains(name));
        }

        [Test]
        public void IsGreaterThan_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            DateTime argument = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenargumentIsGreaterThanExpected_DoesNotThrowException()
        {
            const int argument = 4;
            const int expected = 2;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsGreaterThanOrEqualTo(argument, expected, name));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenargumentIsLessThanExpected_ThrowsException()
        {
            DateTime argument = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsGreaterThanOrEqualTo(argument, expected, name));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenargumentIsEqualToExpected_DoesNotThrowException()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsGreaterThanOrEqualTo(argument, expected, name));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsargumentName()
        {
            DateTime argument = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsGreaterThanOrEqualTo(argument, expected, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            DateTime argument = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsGreaterThan(argument, expected, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsLessThan_WhenargumentIsLessThanExpected_DoesNotThrowException()
        {
            const int argument = 2;
            const int expected = 4;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsLessThan(argument, expected, name));
        }

        [Test]
        public void IsLessThan_WhenargumentIsGreaterThanExpected_ThrowsException()
        {
            DateTime argument = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
        }

        [Test]
        public void IsLessThan_WhenargumentIsEqualToExpected_ThrowsException()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
        }

        [Test]
        public void IsLessThan_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsargumentName()
        {
            DateTime argument = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsLessThan_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            DateTime argument = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenargumentIsLessThanExpected_DoesNotThrowException()
        {
            const int argument = 2;
            const int expected = 4;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsLessThanOrEqualTo(argument, expected, name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenargumentIsGreaterThanExpected_ThrowsException()
        {
            DateTime argument = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsLessThanOrEqualTo(argument, expected, name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenargumentIsEqualToExpected_DoesNotThrowException()
        {
            const float argument = 2.0f;
            const float expected = 2.0f;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsLessThanOrEqualTo(argument, expected, name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsargumentName()
        {
            DateTime argument = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThanOrEqualTo(argument, expected, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            DateTime argument = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsLessThan(argument, expected, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsEqualTo_WhenargumentAndExpectedAreEqual_DoesNotThrowException()
        {
            const int argument = 2;
            const int expected = 2;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsEqualTo(argument, expected, name));
        }

        [Test]
        public void IsEqualTo_WhenargumentAndExpectedAreNotEqual_ThrowsException()
        {
            const decimal argument = 2.00M;
            const decimal expected = 3.00M;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsEqualTo(argument, expected, name));
        }

        [Test]
        public void IsEqualTo_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsargumentName()
        {
            const decimal argument = 2.00M;
            const decimal expected = 3.00M;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsEqualTo(argument, expected, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsEqualTo_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            const decimal argument = 2.00M;
            const decimal expected = 3.00M;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsEqualTo(argument, expected, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsNotEqualTo_WhenargumentAndExpectedAreNotEqual_DoesNotThrowException()
        {
            const int argument = 2;
            const int expected = 3;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsNotEqualTo(argument, expected, name));
        }

        [Test]
        public void IsNotEqualTo_WhenargumentAndExpectedAreEqual_ThrowsException()
        {
            const decimal argument = 2.00M;
            const decimal expected = 2.00M;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotEqualTo(argument, expected, name));
        }

        [Test]
        public void IsNotEqualTo_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsargumentName()
        {
            const decimal argument = 2.00M;
            const decimal expected = 2.00M;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEqualTo(argument, expected, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsNotEqualTo_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            const decimal argument = 2.00M;
            const decimal expected = 2.00M;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotEqualTo(argument, expected, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsInRange_WhenargumentIsInTheSpecifiedRange_DoesNotThrowException()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsInRange(argument, start, end, name));
        }

        [Test]
        public void IsInRange_WhenargumentEqualsStartOfRange_DoesNotThrowException()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsInRange(argument, start, end, name));
        }

        [Test]
        public void IsInRange_WhenargumentEqualsEndOfRange_DoesNotThrowException()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsInRange(argument, start, end, name));
        }

        [Test]
        public void IsInRange_WhenargumentIsNotInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRange(argument, start, end, name));
        }

        [Test]
        public void IsInRange_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRange(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsInRange_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRange(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsInRangeExclusive_WhenargumentIsInTheSpecifiedRange_DoesNotThrowException()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenargumentEqualsStartOfRange_ThrowsException()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenargumentEqualsEndOfRange_ThrowsException()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenargumentIsNotInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsInRangeExclusive(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsNotInRange_WhenargumentIsInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenargumentEqualsStartOfRange_ThrowsException()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenargumentEqualsEndOfRange_ThrowsException()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenargumentIsNotInTheSpecifiedRange_DoesNotThrowException()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsNotInRange(argument, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsNotInRange_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRange(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenargumentIsInTheSpecifiedRange_ThrowsException()
        {
            const int argument = 5;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.Throws<GuardException>(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenargumentEqualsStartOfRange_DoesNotThrowException()
        {
            const int argument = 3;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenargumentEqualsEndOfRange_DoesNotThrowException()
        {
            const int argument = 7;
            const int start = 3;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenargumentIsNotInTheSpecifiedRange_DoesNotThrowException()
        {
            const int argument = 5;
            const int start = 10;
            const int end = 7;
            const string name = "argument";
            Assert.DoesNotThrow(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNotNull_ExceptionMessageContainsName()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = "argument";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains(name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenExceptionIsThrownAndargumentNameIsNull_ExceptionMessageContainsUnknownargument()
        {
            const int argument = 8;
            const int start = 5;
            const int end = 10;
            const string name = null;
            Exception result = Assert.Throws<GuardException>(() => Guard.IsNotInRangeExclusive(argument, start, end, name));
            Assert.IsTrue(result.Message.Contains("[unknown]"));
        }

        [Test]
        public void IsRequiredThat_WhenConditionIsTrue_DoesNotThrowException()
        {
            const string message = "Custom Exception Message";
            Assert.DoesNotThrow(() => Guard.IsRequiredThat(true, message));
        }

        [Test]
        public void IsRequiredThat_WhenConditionIsFalse_ThrowsException()
        {
            const string message = "Custom Exception Message";
            Assert.Throws<GuardException>(() => Guard.IsRequiredThat(false, message));
        }

        [Test]
        public void IsRequiredThat_WhenExceptionThrowsAndMessageIsNotNull_ExceptionMessageIsMessage()
        {
            const string message = "Custom Exception Message";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsRequiredThat(false, message));
            Assert.AreEqual(result.Message, message);
        }

        [Test]
        public void IsRequiredThat_WhenExceptionThrownAndMessageIsNull_ExceptionMessageIsRequirementFailed()
        {
            const string message = null;
            const string expectedMessage = "The required expectation was not met.";
            Exception exception = Assert.Throws<GuardException>(() => Guard.IsRequiredThat(false, message));
            Assert.AreEqual(exception.Message, expectedMessage);
        }

        [Test]
        public void IsTrue_WhenConditionIsFalse_ThrowsException()
        {
            Assert.Throws<GuardException>(() => Guard.IsTrue(false, "Custom Message"));
        }

        [Test]
        public void IsTrue_WhenCondition_IsTrue_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => Guard.IsTrue(true, "Custom Message"));
        }

        [Test]
        public void IsTrue_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMessage()
        {
            const string message = "Custom Message";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsTrue(false, message));
            Assert.AreEqual(message, result.Message);
        }

        [Test]
        public void IsTrue_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMustBeTrue()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsTrue(false, null));
            Assert.AreEqual("Condition must be true.", result.Message);
        }

        [Test]
        public void IsFalse_WhenConditionIsTrue_ThrowsException()
        {
            Assert.Throws<GuardException>(() => Guard.IsFalse(true, "Custom Message"));
        }

        [Test]
        public void IsFalse_WhenCondition_IsFalse_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => Guard.IsFalse(false, "Custom Message"));
        }

        [Test]
        public void IsFalse_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMessage()
        {
            const string message = "Custom Message";
            Exception result = Assert.Throws<GuardException>(() => Guard.IsFalse(true, message));
            Assert.AreEqual(message, result.Message);
        }

        [Test]
        public void IsFalse_WhenExceptionIsThrownAndMessageIsNotNull_ExceptionMessageIsMustBeTrue()
        {
            Exception result = Assert.Throws<GuardException>(() => Guard.IsFalse(true, null));
            Assert.AreEqual("Condition must be true.", result.Message);
        }
    }
}