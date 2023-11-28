using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day18
{
    internal class SnailfishNumber
    {
        public string RawNumber { get; set; }
        public (SnailfishNumber val1, SnailfishNumber val2)? InnerNumbers { get; set; }
        public SnailfishNumber Parent { get; set; }
        public int Value { get; set; }
        public int Depth { get; set; }
        public SnailfishNumber(string rawNumber)
        {
            Depth = 0;
            Init(rawNumber);
        }
        public SnailfishNumber(string rawNumber, SnailfishNumber parent)
        {
            Parent = parent;
            Depth = parent.Depth + 1;
            Init(rawNumber);
        }

        public SnailfishNumber((SnailfishNumber a, SnailfishNumber b) innerNumbers)
        {
            Depth = 0;
            InnerNumbers = new(new(innerNumbers.a.ToString()), new(innerNumbers.b.ToString()));
            InnerNumbers.Value.val1.Parent = this;
            InnerNumbers.Value.val2.Parent = this;
            InnerNumbers.Value.val1.IncrementDepth();
            InnerNumbers.Value.val2.IncrementDepth();
        }

        private void Init(string rawNumber)
        {
            RawNumber = rawNumber;
            if (RawNumber[0] == '[')
            {
                InnerNumbers = new();
                int depth = 0;
                for (int i = 0; i < RawNumber.Length; i++)
                {
                    switch (RawNumber[i])
                    {
                        case '[':
                            depth++;
                            break;
                        case ']':
                            depth--;
                            break;
                        case ',':
                            if (depth == 1)
                            {
                                InnerNumbers = (new(RawNumber.Substring(1, i - 1), this), new(RawNumber.Substring(i + 1, RawNumber.Length - i - 2), this));
                            }
                            break;
                    }
                }
            }
            else
            {
                Value = int.Parse(RawNumber);
            }
        }

        public void IncrementDepth()
        {
            Depth++;
            if (InnerNumbers is not null)
            {
                InnerNumbers.Value.val1.IncrementDepth();
                InnerNumbers.Value.val2.IncrementDepth();
            }
        }

        public bool Split()
        {
            if (InnerNumbers is null)
            {
                if (Value > 9)
                {
                    InnerNumbers = new (new($"{Value / 2}",this), new($"{(Value + 1) / 2}",this));
                    Value = 0;
                    return true;
                }
                return false;
            }
            else
            {
                if (InnerNumbers.Value.val1.Split())
                    return true;

                return InnerNumbers.Value.val2.Split();
            }
        }

        public bool Explode()
        {
            if (InnerNumbers is null)
                return false;

            if (Depth == 4)
            {
                // LEFT

                var numToAddTo = this;
                bool hasValueToSide = true;
                while (numToAddTo.Parent is not null)
                {
                    numToAddTo = numToAddTo.Parent;

                    if (numToAddTo.InnerNumbers.Value.val2 == this)
                    {
                        break;
                    }

                    if (numToAddTo.Parent is null)
                    {
                        hasValueToSide = false;
                        break;
                    }

                    if (numToAddTo.Parent.InnerNumbers.Value.val1 != numToAddTo)
                    {
                        numToAddTo = numToAddTo.Parent;
                        break;
                    }
                }
                if (hasValueToSide)
                {
                    numToAddTo = numToAddTo.InnerNumbers.Value.val1;
                    while (numToAddTo.InnerNumbers.HasValue)
                    {
                        numToAddTo = numToAddTo.InnerNumbers.Value.val2;
                    }
                    numToAddTo.Value += InnerNumbers.Value.val1.Value;
                }

                // RIGHT
                numToAddTo = this;
                hasValueToSide = true;
                while (numToAddTo.Parent is not null)
                {
                    numToAddTo = numToAddTo.Parent;
                    if (numToAddTo.InnerNumbers.Value.val1 == this)
                    {
                        break;
                    }

                    if (numToAddTo.Parent is null)
                    {
                        hasValueToSide = false;
                        break;
                    }

                    if (numToAddTo.Parent.InnerNumbers.Value.val2 != numToAddTo)
                    {
                        numToAddTo = numToAddTo.Parent;
                        break;
                    }
                }
                if (hasValueToSide)
                {
                    numToAddTo = numToAddTo.InnerNumbers.Value.val2;
                    while (numToAddTo.InnerNumbers.HasValue)
                    {
                        numToAddTo = numToAddTo.InnerNumbers.Value.val1;
                    }
                    numToAddTo.Value += InnerNumbers.Value.val2.Value;
                }


                InnerNumbers = null;
                Value = 0;

                return true;

            }
            if (InnerNumbers.Value.val1.Explode())
                return true;

            return InnerNumbers.Value.val2.Explode();
        }

        public static SnailfishNumber operator +(SnailfishNumber a, SnailfishNumber b)
        {
            SnailfishNumber sum = new((a, b));


            while (true)
            {
                if (sum.Explode())
                    continue;

                if (sum.Split())
                    continue;

                break;
            }

            return sum;
        }

        public int Magnitude()
        {
            if (InnerNumbers == null)
                return Value;

            return 3*InnerNumbers.Value.val1.Magnitude() + 2*InnerNumbers.Value.val2.Magnitude();
        }

        public string ToString()
        {
            if (InnerNumbers == null)
                return Value.ToString();

            return $"[{InnerNumbers.Value.val1.ToString()},{InnerNumbers.Value.val2.ToString()}]";
        }
    }
}
