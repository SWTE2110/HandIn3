using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class PowerTubeMaxTest
    {
        private PowerTube uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            
        }
        [TestCase(50,50)]
        [TestCase(50, 99)]
        [TestCase(100, 100)]
        [TestCase(700,49)]
        [TestCase(800, 801)]
        [TestCase(1150, 1171)]
        [TestCase(700, 0)]

        public void MaxPowerSetsCorrectly(int max, int arg)
        {
            uut = new PowerTube(output, arg);
            Assert.That(uut.MaxPower,Is.EqualTo(max));
        }

        [TestCase(1,1)]
        [TestCase(50,500)]
        [TestCase(100,300)]
        [TestCase(700,0)]
        [TestCase(800,800)]
        [TestCase(int.MaxValue-50, int.MaxValue)]
        public void TurnOn_WasOffCorrectPower_CorrectOutput(int power, int max)
        {
            uut = new PowerTube(output, max);
            uut.TurnOn(power);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains($"{power}")));
        }

        [TestCase(-5,50)]
        [TestCase(-1,50)]
        [TestCase(0,100)]
        [TestCase(701,0)]
        [TestCase(100,95)]
        [TestCase(51,50)]
        public void TurnOn_WasOffOutOfRangePower_ThrowsException(int power, int max)
        {
            uut = new PowerTube(output, max);
            Assert.Throws<System.ArgumentOutOfRangeException>(() => uut.TurnOn(power));
        }

    }
}