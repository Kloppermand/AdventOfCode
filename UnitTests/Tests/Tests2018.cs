using aoc = AdventOfCode2018;
using Utilities;
using System.Reflection.Metadata;

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
            aoc.Day1.Day1.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day1/Day1_output_a.txt"));
            Assert.That(result, Is.EqualTo("561"));
        }

        [Test]
        public void Day1B()
        {
            aoc.Day1.Day1.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day1/Day1_output_b.txt"));
            Assert.That(result, Is.EqualTo("563"));
        }

        [Test]
        public void Day2A()
        {
            aoc.Day2.Day2.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day2/Day2_output_a.txt"));
            Assert.That(result, Is.EqualTo("5681"));
        }

        [Test]
        public void Day2B()
        {
            aoc.Day2.Day2.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day2/Day2_output_b.txt"));
            Assert.That(result, Is.EqualTo("uqyoeizfvmbistpkgnocjtwld"));
        }

        [Test]
        public void Day3A()
        {
            aoc.Day3.Day3.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day3/Day3_output_a.txt"));
            Assert.That(result, Is.EqualTo("115348"));
        }

        [Test]
        public void Day3B()
        {
            aoc.Day3.Day3.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day3/Day3_output_b.txt"));
            Assert.That(result, Is.EqualTo("188"));
        }

        [Test]
        public void Day4A()
        {
            aoc.Day4.Day4.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day4/Day4_output_a.txt"));
            Assert.That(result, Is.EqualTo("26281"));
        }

        [Test]
        public void Day4B()
        {
            aoc.Day4.Day4.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day4/Day4_output_b.txt"));
            Assert.That(result, Is.EqualTo("73001"));
        }

        [Test]
        public void Day5A()
        {
            aoc.Day5.Day5.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day5/Day5_output_a.txt"));
            Assert.That(result, Is.EqualTo("10978"));
        }

        [Test]
        public void Day5B()
        {
            aoc.Day5.Day5.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day5/Day5_output_b.txt"));
            Assert.That(result, Is.EqualTo("4840"));
        }

        //[Test]
        //public void Day6A()
        //{
        //    aoc.Day6.Day6.CalculateA();
        //    var result = File.ReadAllText(Path.Combine(root, "Day6/Day6_output_a.txt"));
        //    Assert.That(result, Is.EqualTo("NOT SOLVED YET"));
        //}

        //[Test]
        //public void Day6B()
        //{
        //    aoc.Day6.Day6.CalculateB();
        //    var result = File.ReadAllText(Path.Combine(root, "Day6/Day6_output_b.txt"));
        //    Assert.That(result, Is.EqualTo("NOT SOLVED YET"));
        //}
    }
}