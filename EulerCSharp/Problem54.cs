using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler.EulerCSharp
{
    public static class Problem_54
    {
        public static long Problem54(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            long player1Wins = 0;

            for (int i = 0; i < 1000; i++)
            {
                string all = sr.ReadLine();
                string[] cards = all.Split(' ');

                Hand hand1 = new Hand(cards.Where((s, j) => (j < 5)).ToArray());
                Hand hand2 = new Hand(cards.Where((s, j) => (j >= 5)).ToArray());

                Game game = new Game(hand1, hand2);

                HandResult hr = game.Winner();

                if (hr == HandResult.Player1)
                {
                    player1Wins++;
                }
            }

            return player1Wins;
        }

        private enum HandResult
        {
            Player1,
            Player2,
            Tie
        }

        private class Card
        {
            private int pips;  // J=11, Q=12, K=13, A=14
            private int suit;  // S=1, H=2, D=3, C=4

            public int Pips { get { return pips; } }
            public int Suit { get { return suit; } }

            public Card(string s)
            {
                pips = 0;
                suit = 0;

                if (s.Length != 2)
                {
                    throw new Exception();
                }

                string rank = s.Substring(0, 1);

                int p = 0;
                if (int.TryParse(rank, out p))
                    pips = p;

                if (rank == "T")
                    pips = 10;
                if (rank == "J")
                    pips = 11;
                if (rank == "Q")
                    pips = 12;
                if (rank == "K")
                    pips = 13;
                if (rank == "A")
                    pips = 14;

                string suit2 = s.Substring(1, 1);

                if (suit2 == "S")
                    suit = 1;
                if (suit2 == "H")
                    suit = 2;
                if (suit2 == "D")
                    suit = 3;
                if (suit2 == "C")
                    suit = 4;
            }
        }

        private class Hand
        {
            private Card[] cards;

            public Hand(string[] cardStrings)
            {
                if (cardStrings.Count() != 5)
                {
                    throw new Exception();
                }

                cards = cardStrings.Select(s => new Card(s)).ToArray();
            }

            private bool IsFlush
            {
                get
                {
                    return (cards.Select(c => c.Suit).Distinct().Count() == 1);
                }
            }

            private int HighestPips
            {
                get
                {
                    return (cards.Max(c => c.Pips));
                }
            }

            private int LowestPips
            {
                get
                {
                    return (cards.Min(c => c.Pips));
                }
            }

            private int MaxPipsCount
            {
                get
                {
                    return Partition.Max(ig => ig.Count());
                }
            }

            private bool IsStraight
            {
                get
                {
                    return ((MaxPipsCount == 1) && (HighestPips - LowestPips == 4));
                }
            }

            internal List<IGrouping<int, Card>> Partition
            {
                get
                {
                    return cards.GroupBy(c => c.Pips).OrderByDescending(ig => ig.Count()).ThenByDescending(ig2 => ig2.Key).ToList();
                }
            }

            private bool IsFullHouse
            {
                get
                {
                    return (Partition.Count == 2 && MaxPipsCount == 3);
                }
            }

            public int Rank1()
            {

                // royal flush
                if (IsStraight && IsFlush && (HighestPips == 14))
                {
                    return 10;
                }

                // straight flush
                if (IsStraight && IsFlush)
                {
                    return 9;
                }

                // four of a kind
                if (MaxPipsCount == 4)
                {
                    return 8;
                }

                // full house
                if (IsFullHouse)
                {
                    return 7;
                }

                // flush
                if (IsFlush)
                {
                    return 6;
                }

                // straight
                if (IsStraight)
                {
                    return 5;
                }

                // three of a kind
                if (MaxPipsCount == 3)
                {
                    return 4;
                }

                // two pairs
                if (Partition.Count == 3 && MaxPipsCount == 2)
                {
                    return 3;
                }

                // pair
                if (MaxPipsCount == 2)
                {
                    return 2;
                }

                // high card
                return 1;
            }
        }

        private class Game
        {
            public Hand Player1 { get; private set; }
            public Hand Player2 { get; private set; }

            public Game(Hand hand1, Hand hand2)
            {
                Player1 = hand1;
                Player2 = hand2;
            }

            public HandResult Winner()
            {
                int rank1 = Player1.Rank1();
                int rank2 = Player2.Rank1();

                if (rank1 > rank2)
                {
                    return HandResult.Player1;
                }

                if (rank2 > rank1)
                {
                    return HandResult.Player2;
                }

                List<IGrouping<int, Card>> part1 = Player1.Partition;
                List<IGrouping<int, Card>> part2 = Player2.Partition;

                if (part1.Count != part2.Count)
                {
                    throw new Exception("Unexpected result");
                }

                for (int i = 0; i < part1.Count; i++)
                {
                    if (part1[i].Key > part2[i].Key)
                    {
                        return HandResult.Player1;
                    }
                    if (part2[i].Key > part1[i].Key)
                    {
                        return HandResult.Player2;
                    }
                }

                return HandResult.Tie;
            }
        }
    }
}
