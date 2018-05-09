using System;
using System.Runtime.Serialization;
using Xunit;

namespace ChaosMonkey.Guards.Tests
{
    public class GuardExceptionTests
    {
        [Fact]
        public void Instantiation_DefaultConstructor_InitializesMessage()
        {
            var sut = new GuardException();

            Assert.NotNull(sut.Message);
            Assert.Equal(GuardException.DefaultMessage, sut.Message);
        }

        [Fact]
        public void Instantiation_MessageOnlyConstructor_InitializesMessage()
        {
            const string message = "Exceptional Message";
            var sut = new GuardException(message);

            Assert.NotNull(sut.Message);
            Assert.Equal(message, sut.Message);
        }

        [Fact]
        public void Instantiation_InnerExceptionConstructor_InitializesInnerException()
        {
            const string message = "Exceptional Message";
            var inner = new Exception();
            var sut = new GuardException(message, inner);

            Assert.NotNull(sut.InnerException);
            Assert.Same(inner, sut.InnerException);
        }

        [Fact]
        public void Instantiation_InnerExceptionConstructor_InitializesMessage()
        {
            const string message = "Exceptional Message";
            var inner = new Exception();
            var sut = new GuardException(message, inner);

            Assert.NotNull(sut.Message);
            Assert.Same(message, sut.Message);
        }

        [Fact]
        public void Instantiation_WithSerializationInfo_ReinstantiatesException()
        {
            var uniqueMessage = Guid.NewGuid().ToString();
            var helpUrl = string.Format("http://www.url.com/{0}", Guid.NewGuid());
            var info = new SerializationInfo(typeof(GuardException), new FormatterConverter());
            info.AddValue("ClassName", typeof(GuardException).FullName);
            info.AddValue("Message", uniqueMessage);
            info.AddValue("InnerException", null);
            info.AddValue("HelpURL", helpUrl);
            info.AddValue("StackTraceString", string.Empty);
            info.AddValue("RemoteStackTraceString", string.Empty);
            info.AddValue("RemoteStackIndex", 0);
            info.AddValue("ExceptionMethod", string.Empty);
            info.AddValue("HResult", 1);
            info.AddValue("Source", string.Empty);

            var sut = new GuardException(info, new StreamingContext());

            Assert.Equal(uniqueMessage, sut.Message);
            Assert.Equal(helpUrl, sut.HelpLink);
        }
    }
}
