using aoc = AdventOfCode2021;
using Utilities;
using System.Reflection.Metadata;

namespace UnitTests.Tests2021
{
    public class Tests
    {
        const string root = "../../../../AdventOfCode2021/";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day1A()
        {
            aoc.Day1.Day1.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day1/Day1_output_a.txt"));
            Assert.That(result, Is.EqualTo("1791"));
        }

        [Test]
        public void Day1B()
        {
            aoc.Day1.Day1.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day1/Day1_output_b.txt"));
            Assert.That(result, Is.EqualTo("1822"));
        }

        [Test]
        public void Day2A()
        {
            aoc.Day2.Day2.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day2/Day2_output_a.txt"));
            Assert.That(result, Is.EqualTo("1990000"));
        }

        [Test]
        public void Day2B()
        {
            aoc.Day2.Day2.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day2/Day2_output_b.txt"));
            Assert.That(result, Is.EqualTo("1975421260"));
        }

        [Test]
        public void Day3A()
        {
            aoc.Day3.Day3.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day3/Day3_output_a.txt"));
            Assert.That(result, Is.EqualTo("3429254"));
        }

        [Test]
        public void Day3B()
        {
            aoc.Day3.Day3.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day3/Day3_output_b.txt"));
            Assert.That(result, Is.EqualTo("5410338"));
        }

        [Test]
        public void Day4A()
        {
            aoc.Day4.Day4.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day4/Day4_output_a.txt"));
            Assert.That(result, Is.EqualTo("71708"));
        }

        [Test]
        public void Day4B()
        {
            aoc.Day4.Day4.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day4/Day4_output_b.txt"));
            Assert.That(result, Is.EqualTo("34726"));
        }

        [Test]
        public void Day5A()
        {
            aoc.Day5.Day5.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day5/Day5_output_a.txt"));
            Assert.That(result, Is.EqualTo("8350"));
        }

        [Test]
        public void Day5B()
        {
            aoc.Day5.Day5.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day5/Day5_output_b.txt"));
            Assert.That(result, Is.EqualTo("19374"));
        }

        [Test]
        public void Day6A()
        {
            aoc.Day6.Day6.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day6/Day6_output_a.txt"));
            Assert.That(result, Is.EqualTo("355386"));
        }

        [Test]
        public void Day6B()
        {
            aoc.Day6.Day6.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day6/Day6_output_b.txt"));
            Assert.That(result, Is.EqualTo("1613415325809"));
        }

        [Test]
        public void Day7A()
        {
            aoc.Day7.Day7.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day7/Day7_output_a.txt"));
            Assert.That(result, Is.EqualTo("356922"));
        }

        [Test]
        public void Day7B()
        {
            aoc.Day7.Day7.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day7/Day7_output_b.txt"));
            Assert.That(result, Is.EqualTo("100347031"));
        }

        [Test]
        public void Day8A()
        {
            aoc.Day8.Day8.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day8/Day8_output_a.txt"));
            Assert.That(result, Is.EqualTo("255"));
        }

        [Test]
        public void Day8B()
        {
            aoc.Day8.Day8.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day8/Day8_output_b.txt"));
            Assert.That(result, Is.EqualTo("982158"));
        }

        [Test]
        public void Day9A()
        {
            aoc.Day9.Day9.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day9/Day9_output_a.txt"));
            Assert.That(result, Is.EqualTo("502"));
        }

        [Test]
        public void Day9B()
        {
            aoc.Day9.Day9.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day9/Day9_output_b.txt"));
            Assert.That(result, Is.EqualTo("1330560"));
        }

        [Test]
        public void Day10A()
        {
            aoc.Day10.Day10.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day10/Day10_output_a.txt"));
            Assert.That(result, Is.EqualTo("469755"));
        }

        [Test]
        public void Day10B()
        {
            aoc.Day10.Day10.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day10/Day10_output_b.txt"));
            Assert.That(result, Is.EqualTo("2762335572"));
        }

        [Test]
        public void Day11A()
        {
            aoc.Day11.Day11.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day11/Day11_output_a.txt"));
            Assert.That(result, Is.EqualTo("1702"));
        }

        [Test]
        public void Day11B()
        {
            aoc.Day11.Day11.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day11/Day11_output_b.txt"));
            Assert.That(result, Is.EqualTo("251"));
        }

        [Test]
        public void Day12A()
        {
            aoc.Day12.Day12.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day12/Day12_output_a.txt"));
            Assert.That(result, Is.EqualTo("3230"));
        }

        [Test]
        public void Day12B()
        {
            aoc.Day12.Day12.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day12/Day12_output_b.txt"));
            Assert.That(result, Is.EqualTo("83475"));
        }

        [Test]
        public void Day13A()
        {
            aoc.Day13.Day13.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day13/Day13_output_a.txt"));
            Assert.That(result, Is.EqualTo("802"));
        }

        [Test]
        public void Day13B()
        {
            aoc.Day13.Day13.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day13/Day13_output_b.txt"));
            Assert.That(result, Is.EqualTo("RKHFZGUB"));
        }

        [Test]
        public void Day14A()
        {
            aoc.Day14.Day14.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day14/Day14_output_a.txt"));
            Assert.That(result, Is.EqualTo("2899"));
        }

        [Test]
        public void Day14B()
        {
            aoc.Day14.Day14.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day14/Day14_output_b.txt"));
            Assert.That(result, Is.EqualTo("3528317079545"));
        }

        [Test]
        public void Day15A()
        {
            aoc.Day15.Day15.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day15/Day15_output_a.txt"));
            Assert.That(result, Is.EqualTo("621"));
        }

        [Test]
        public void Day15B()
        {
            aoc.Day15.Day15.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day15/Day15_output_b.txt"));
            Assert.That(result, Is.EqualTo("2904"));
        }

        [Test]
        public void Day16A()
        {
            aoc.Day16.Day16.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day16/Day16_output_a.txt"));
            Assert.That(result, Is.EqualTo("897"));
        }

        [Test]
        public void Day16B()
        {
            aoc.Day16.Day16.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day16/Day16_output_b.txt"));
            Assert.That(result, Is.EqualTo("9485076995911"));
        }

        [Test]
        public void Day17A()
        {
            aoc.Day17.Day17.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day17/Day17_output_a.txt"));
            Assert.That(result, Is.EqualTo("4278"));
        }

        [Test]
        public void Day17B()
        {
            aoc.Day17.Day17.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day17/Day17_output_b.txt"));
            Assert.That(result, Is.EqualTo("1994"));
        }

        [Test]
        public void Day18A()
        {
            aoc.Day18.Day18.CalculateA();
            var result = File.ReadAllText(Path.Combine(root, "Day18/Day18_output_a.txt"));
            Assert.That(result, Is.EqualTo("3763"));
        }

        [Test]
        public void Day18B()
        {
            aoc.Day18.Day18.CalculateB();
            var result = File.ReadAllText(Path.Combine(root, "Day18/Day18_output_b.txt"));
            Assert.That(result, Is.EqualTo("4664"));
        }
    }
}