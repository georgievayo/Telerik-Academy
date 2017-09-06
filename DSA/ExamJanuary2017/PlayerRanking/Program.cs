using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<Player>> playersByType = new SortedDictionary<string, SortedSet<Player>>();
            BigList<Player> orderedPlayers = new BigList<Player>();
            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                switch (command[0])
                {
                    case "add": AddPlayer(command[1], command[2], int.Parse(command[3]), int.Parse(command[4]), playersByType, orderedPlayers);
                        break;
                    case "find": FindPlayer(command[1], playersByType);
                        break;
                    case "ranklist": Ranklist(int.Parse(command[1]), int.Parse(command[2]), orderedPlayers);
                        break;
                    case "end": return;
                }
            }
        }

        private static void Ranklist(int start, int end, BigList<Player> players)
        {
           
            var result = new StringBuilder();
            for (int i = start - 1; i < end; i++)
            {
                if (players[i] != null)
                {
                    if (i == end - 1)
                    {
                        result.Append(string.Format("{0}. {1}({2})", i +1, players[i].Name, players[i].Age));
                        break;
                    }
                    result.Append(string.Format("{0}. {1}({2}); ", i + 1, players[i].Name, players[i].Age));
                }
            }

            Console.WriteLine(result);
        }

        private static void FindPlayer(string type, SortedDictionary<string, SortedSet<Player>> playersByType)
        {
            var result = new StringBuilder(string.Format("Type {0}:", type));
            if (!playersByType.ContainsKey(type))
            {
                Console.WriteLine(result);
                return;
            }
            var found = playersByType[type];
            int counter = 0;
            foreach (var player in found)
            {
                if (counter == 5)
                {
                    break;
                }
                else
                {
                    result.Append(string.Format(" {0}({1});", player.Name, player.Age));
                }
            }
            result.Remove(result.Length - 1, 1);
            Console.WriteLine(result);
        }

        private static void AddPlayer(string firstName, string type, int age, int position, SortedDictionary<string, SortedSet<Player>> playersByType, BigList<Player> orderedPlayers)
        {
            var newPlayer = new Player(firstName, type, age);
            if (!playersByType.ContainsKey(type))
            {
                playersByType.Add(type, new SortedSet<Player>() {newPlayer});
            }
            else
            {
                playersByType[type].Add(newPlayer);
            }

            orderedPlayers.Insert(position - 1, newPlayer);
            Console.WriteLine("Added player {0} to position {1}", firstName, position);
        }
    }

    class ListOfPlayers
    {
        private Player[] list;
        private int count;
        private int capacity;

        public ListOfPlayers()
        {
            this.capacity = 100000;
            this.count = 0;
            this.list = new Player[this.capacity];
        }

        public Player this[int index]
        {
            get { return this.list[index]; }
            set { this.list[index] = value; }
        }

        public void Add(Player player, int position)
        {
            if (position > this.count + 1 || position < 1)
            {
                throw new Exception();
            }

            if (this.capacity <= position)
            {
                this.capacity = position * 2;
                Resize(this.capacity);
                this.list[position] = player;
                
            }

            if (this.list[position] != null)
            {
                Shift(position, player);
            }
            else
            {
                this.list[position] = player;
            }

            this.count++;
        }

        public Player[] FindBy(string type)
        {
            var found = new List<Player>();

            for (int i = 1; i <= this.count; i++)
            {
                if (this.list[i] != null && this.list[i].Type == type)
                {
                    found.Add(this.list[i]);
                }
            }

            var ordered = found.OrderBy(x => x.Name).ThenByDescending(x => x.Age).ToArray();
            return ordered;
        }

        private void Resize(int capacity)
        {
            var newList = new Player[capacity];
            for (int i = 0; i < this.count; i++)
            {
                newList[i] = this.list[i];
            }

            this.list = newList;
        }

        private void Shift(int start, Player player)
        {
            if (this.capacity > this.count + 1)
            {
                Player temp = this.list[start];
                Player next = null;
                for (int i = start; i <= this.count + 1; i++)
                {
                    
                    if (i == start)
                    {
                        this.list[i] = player;
                    }
                    else
                    {
                        next = this.list[i];
                        this.list[i] = temp;
                        temp = next;
                    }
                }
            }
            else
            {
                var newList = new Player[capacity*2];

                for (int i = 0; i < this.count + 1; i++)
                {
                    if (i == start)
                    {
                        newList[i] = player;
                    }
                    else if (i > start)
                    {
                        newList[i] = this.list[i - 1];
                    }
                    else
                    {
                        newList[i] = this.list[i];
                    }
                }

                this.list = newList;
            }
        }
    }

    internal class Player : IComparable<Player>
    {
        private string name;
        private string type;
        private int age;

        public string Name
        {
            set
            {
                if (value.Length < 1 || value.Length > 20)
                {
                    throw new Exception();
                }

                this.name = value;
            }
            get { return this.name; }
        }

        public string Type
        {
            set
            {
                if (value.Length < 1 || value.Length > 10)
                {
                    throw new Exception();
                }

                this.type = value;
            }
            get { return this.type; }
        }


        public int Age
        {
            set
            {
                if (value < 10 || value > 50)
                {
                    throw new Exception();
                }

                this.age = value;
            }

            get { return this.age; }
        }

        public Player(string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }


        public int CompareTo(Player other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age) * -1;
            }

            return result;
        }
    }
}
