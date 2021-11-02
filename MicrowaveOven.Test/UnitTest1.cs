using NUnit.Framework;

namespace MicrowaveOven.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Assert.That(1, Is.EqualTo(1));
        }

        [Test]
        public void Jenkins_Test()
        {
            Assert.That(1, Is.EqualTo(1));
        }
    }
}