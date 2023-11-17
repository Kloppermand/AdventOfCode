using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace AdventOfCode2021.Day16
{
    internal class Packet
    {
        public int Version { get; set; }
        public int Type { get; set; }
        public List<Packet> Packets { get; set; } = new();
        public int Length { get; set; }
        public long Value { get; set; }

        public Packet(string packet)
        {
            int i = 0;
            Version = NumberBases.BinToInt(packet.Substring(i, 3));
            Type = NumberBases.BinToInt(packet.Substring(i + 3, 3));
            i += 6;


            if (Type == 4)
            {
                var literalValue = "";
                char leading;
                do
                {
                    leading = packet[i++];
                    literalValue += packet.Substring(i, 4);
                    i += 4;
                } while (leading == '1');

                Value = NumberBases.BinToLong(literalValue);
                Length = i;
            }
            else
            {
                var lengthType = packet[i++];
                if (lengthType == '0') // Bit length
                {
                    var lengthBits = NumberBases.BinToInt(packet.Substring(i, 15));
                    i += 15;
                    Length = i + lengthBits;
                    int j = 0;
                    while (j < lengthBits)
                    {
                        var innerPacket = packet.Substring(i);
                        if (!innerPacket.Contains("1"))
                        {
                            break;
                        }
                        var tmpPacket = new Packet(innerPacket);
                        j += tmpPacket.Length;
                        Packets.Add(tmpPacket);
                        i += tmpPacket.Length;
                    }
                }
                else // Number of packets
                {
                    var numPakcets = NumberBases.BinToInt(packet.Substring(i, 11));
                    i += 11;
                    while (Packets.Count() < numPakcets)
                    {
                        var tmpPacket = new Packet(packet.Substring(i));
                        i += tmpPacket.Length;
                        Packets.Add(tmpPacket);
                    }
                    Length = i;
                }
            }

        }

        public int SumVersionNumbers()
        {
            return Version + Packets.Sum(p => p.SumVersionNumbers());
        }

        public long GetPacketValue()
        {
            switch (Type)
            {
                case 0:
                    return Packets.Sum(p => p.GetPacketValue());
                case 1:
                    return Packets.Aggregate(1L, (acc, p) => acc * p.GetPacketValue());
                case 2:
                    return Packets.Min(p => p.GetPacketValue());
                case 3:
                    return Packets.Max(p => p.GetPacketValue());
                case 4:
                    return Value;
                case 5:
                    return Packets[0].GetPacketValue() > Packets[1].GetPacketValue() ? 1 : 0;
                case 6:
                    return Packets[0].GetPacketValue() < Packets[1].GetPacketValue() ? 1 : 0;
                case 7:
                    return Packets[0].GetPacketValue() == Packets[1].GetPacketValue() ? 1 : 0;
                default:
                    return 0;
            }
        }
    }
}
