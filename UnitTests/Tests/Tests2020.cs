using aoc = AdventOfCode2020;
using Utilities;
using System.Reflection.Metadata;

namespace UnitTests.Tests2020
{
    public class Tests
    {
        const string root = "../../../../AdventOfCode2020/";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day1A()
        {
            aoc.Day1.Day1.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day1/Day1_output_a.txt"));
            Assert.That(result, Is.EqualTo("299299"));
        }

        [Test]
        public void Day1B()
        {
            aoc.Day1.Day1.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day1/Day1_output_b.txt"));
            Assert.That(result, Is.EqualTo("287730716"));
        }

        [Test]
        public void Day2A()
        {
            aoc.Day2.Day2.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day2/Day2_output_a.txt"));
            Assert.That(result, Is.EqualTo("445"));
        }

        [Test]
        public void Day2B()
        {
            aoc.Day2.Day2.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day2/Day2_output_b.txt"));
            Assert.That(result, Is.EqualTo("491"));
        }

        [Test]
        public void Day3A()
        {
            aoc.Day3.Day3.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day3/Day3_output_a.txt"));
            Assert.That(result, Is.EqualTo("173"));
        }

        [Test]
        public void Day3B()
        {
            aoc.Day3.Day3.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day3/Day3_output_b.txt"));
            Assert.That(result, Is.EqualTo("4385176320"));
        }

        [Test]
        public void Day4A()
        {
            aoc.Day4.Day4.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day4/Day4_output_a.txt"));
            Assert.That(result, Is.EqualTo("202"));
        }

        [Test]
        public void Day4B()
        {
            aoc.Day4.Day4.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day4/Day4_output_b.txt"));
            Assert.That(result, Is.EqualTo("137"));
        }

        [Test]
        public void Day5A()
        {
            aoc.Day5.Day5.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day5/Day5_output_a.txt"));
            Assert.That(result, Is.EqualTo("890"));
        }

        [Test]
        public void Day5B()
        {
            aoc.Day5.Day5.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day5/Day5_output_b.txt"));
            Assert.That(result, Is.EqualTo("651"));
        }

        [Test]
        public void Day6A()
        {
            aoc.Day6.Day6.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day6/Day6_output_a.txt"));
            Assert.That(result, Is.EqualTo("6763"));
        }

        [Test]
        public void Day6B()
        {
            aoc.Day6.Day6.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day6/Day6_output_b.txt"));
            Assert.That(result, Is.EqualTo("3512"));
        }

        [Test]
        public void Day7A()
        {
            aoc.Day7.Day7.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day7/Day7_output_a.txt"));
            Assert.That(result, Is.EqualTo("103"));
        }

        [Test]
        public void Day7B()
        {
            aoc.Day7.Day7.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day7/Day7_output_b.txt"));
            Assert.That(result, Is.EqualTo("1469"));
        }

        [Test]
        public void Day8A()
        {
            aoc.Day8.Day8.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day8/Day8_output_a.txt"));
            Assert.That(result, Is.EqualTo("2025"));
        }

        [Test]
        public void Day8B()
        {
            aoc.Day8.Day8.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day8/Day8_output_b.txt"));
            Assert.That(result, Is.EqualTo("2001"));
        }

        [Test]
        public void Day9A()
        {
            aoc.Day9.Day9.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day9/Day9_output_a.txt"));
            Assert.That(result, Is.EqualTo("144381670"));
        }

        [Test]
        public void Day9B()
        {
            aoc.Day9.Day9.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day9/Day9_output_b.txt"));
            Assert.That(result, Is.EqualTo("20532569"));
        }

        [Test]
        public void Day10A()
        {
            aoc.Day10.Day10.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day10/Day10_output_a.txt"));
            Assert.That(result, Is.EqualTo("1836"));
        }

        [Test]
        public void Day10B()
        {
            aoc.Day10.Day10.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day10/Day10_output_b.txt"));
            Assert.That(result, Is.EqualTo("43406276662336"));
        }
    }
}