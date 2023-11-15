using AdventOfCode2018;
using Utilities;

namespace UnitTests.Tests2018
{
    public class Tests
    {
        const string root = "../../../../AdventOfCode2018/";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day1A()
        {
            AdventOfCode2018.Day1.Day1.CalculateA();
            var result = File.ReadAllText(Path.Combine(root,"Day1/Day1_output_a.txt"));
            Assert.That(result, Is.EqualTo("561"));
        }

        [Test]
        public void Day1B()
        {
            AdventOfCode2018.Day1.Day1.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day1/Day1_output_b.txt"));
            Assert.That(result, Is.EqualTo("563"));
        }

        [Test]
        public void Day2A()
        {
            AdventOfCode2018.Day2.Day2.CalculateA();
            var result = File.ReadAllText(Path.Combine(root,"Day2/Day2_output_a.txt"));
            Assert.That(result, Is.EqualTo("5681"));
        }

        [Test]
        public void Day2B()
        {
            AdventOfCode2018.Day2.Day2.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day2/Day2_output_b.txt"));
            Assert.That(result, Is.EqualTo("uqyoeizfvmbistpkgnocjtwld"));
        }

        [Test]
        public void Day3A()
        {
            AdventOfCode2018.Day3.Day3.CalculateA();
            var result = File.ReadAllText(Path.Combine(root,"Day3/Day3_output_a.txt"));
            Assert.That(result, Is.EqualTo("115348"));
        }

        [Test]
        public void Day3B()
        {
            AdventOfCode2018.Day3.Day3.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day3/Day3_output_b.txt"));
            Assert.That(result, Is.EqualTo("188"));
        }
    }
}