namespace P02.TronRacers
{
    using System;

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int firstRow = 0;
            int firstCow = 0;

            int secondRow = 0;
            int secondCol = 0;

            char[,] field = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < input.Length; j++)
                {
                    field[i, j] = input[j];

                    if (input[j] == 'f')
                    {
                        firstRow = i;
                        firstCow = j;
                    }
                    else if (input[j] == 's')
                    {
                        secondRow = i;
                        secondCol = j;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdFirst = commands[0];
                string cmdSecond = commands[1];

                firstRow = MovePlayerRow(size, firstRow, cmdFirst);
                firstCow = MovePlayerCol(size, firstCow, cmdFirst);

                secondRow = MovePlayerRow(size, secondRow, cmdSecond);
                secondCol = MovePlayerCol(size, secondCol, cmdSecond);

                if (field[firstRow, firstCow] == '*')
                {
                    field[firstRow, firstCow] = 'f';
                }

                else if (field[firstRow, firstCow] == 's')
                {
                    field[firstRow, firstCow] = 'x';
                    break;
                }

                if (field[secondRow, secondCol] == '*')
                {
                    field[secondRow, secondCol] = 's';
                }

                else if (field[secondRow, secondCol] == 'f')
                {
                    field[secondRow, secondCol] = 'x';
                    break;
                }

            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int MovePlayerRow(int size, int row, string cmd)
        {
            if (cmd == "up")
            {
                if (row == 0)
                {
                    return size - 1;
                }
                row--;
                return row;
            }
            else if (cmd == "down")
            {
                if (row == size - 1)
                {
                    return 0;
                }
                row++;
                return row;
            }
            return row;
        }
        static int MovePlayerCol(int size, int col, string cmd)
        {
            if (cmd == "left")
            {
                if (col == 0)
                {
                    return size - 1;
                }
                col--;
                return col;
            }
            else if (cmd == "right")
            {
                if (col == size - 1)
                {
                    return 0;
                }
                col++;
                return col;
            }
            return col;
        }
    }
}
