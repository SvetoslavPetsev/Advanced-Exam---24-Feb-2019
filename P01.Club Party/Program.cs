namespace P01.Club_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hall
    {

        public Hall(char number)
        {
            this.Number = number;
            this.Guests = new List<int>();
        }
        public char Number { get; set; }
        public List<int> Guests { get; set; }

    }
    class Program
    {
        static void Main()
        {
            int maxCapcity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split().ToArray();

            Stack<string> info = new Stack<string>(input);
            Queue<char> hallsQueue = new Queue<char>();


            while (info.Any())
            {
                string check = info.Peek();
                char letter;

                if (char.TryParse(check, out letter) && char.IsLetter(letter))
                {
                    hallsQueue.Enqueue(letter);
                    info.Pop();
                }

                if (!hallsQueue.Any())
                {
                    info.Pop();
                }

                while (hallsQueue.Any())
                {
                    Hall currHall = new Hall(hallsQueue.Dequeue());
                    bool isFull = false;
                    while (!isFull && info.Any())
                    {
                        char people;
                        if (char.TryParse(info.Peek(), out people) && char.IsLetter(people))
                        {
                            hallsQueue.Enqueue(people);
                            info.Pop();
                            continue;
                        }

                        int sum = currHall.Guests.Sum() + int.Parse(info.Peek());
                        if (sum <= maxCapcity)
                        {
                            currHall.Guests.Add(int.Parse(info.Pop()));
                        }
                        else
                        {
                            isFull = true;
                        }
                    }
                    if (isFull)
                    {
                        Console.WriteLine($"{currHall.Number} -> {string.Join(", ", currHall.Guests)}");
                    }
                }
            }
        }
    }
}
