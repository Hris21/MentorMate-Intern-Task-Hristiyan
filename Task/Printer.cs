using System;

namespace Task
{
    internal class Printer
    {
        private const int minConstraint = 2;
        private const int maxConstraint = 10000;
        private const char emptySpace = '-';
        private const char letterSymbol = '*';
        private const string HelloMessage = "Enter a number bigger than 2: ";

        private static void Main()
        {
            Console.WriteLine(HelloMessage);

            string UserInput = Console.ReadLine();
            int parsedInt = 0;

            parsedInt = isaNumber(ref UserInput);
            isInRange(parsedInt, minConstraint, maxConstraint);

            //Loop control values
            int length = parsedInt + 1;
            int halfLength = length / 2;
            int symbolCounter;
            int sideDashCounter;
            int middleDashCounter;

            symbolCounter = parsedInt;
            middleDashCounter = parsedInt;
            sideDashCounter = parsedInt;

            //Printing upper half
            PrinterOne(halfLength, ref symbolCounter, ref sideDashCounter, ref middleDashCounter);
            middleDashCounter = 0;
            //Printing bottom half
            PrinterTwo(parsedInt, halfLength, ref symbolCounter, ref sideDashCounter, ref middleDashCounter);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine(); //pause
        }

        private static int isaNumber(ref string UserInput)
        {
            bool isANumber = int.TryParse(UserInput, out int parsedInt);
            if (isANumber == false)
            {
                Console.WriteLine("Invalid Input. Please restart and enter a number: ");
                Console.Read();
                Environment.Exit(0);
            }

            return parsedInt;
        }

        internal static void isInRange(int UserInput, int minConstraint, int maxConastraint)
        {
            if (UserInput < minConstraint)
            {
                Console.WriteLine("The number must be bigger than {1}.", minConstraint);
                Console.Read();
                Environment.Exit(0);
            }
            if (UserInput > maxConastraint)
            {
                Console.WriteLine("The number must be lower than {0}.", maxConstraint);
                Console.Read();
                Environment.Exit(0);
            }
            if (UserInput % 2 == 0)
            {
                Console.WriteLine("The number must be odd.");
                Console.Read();
                Environment.Exit(0);
            }
        }

        private static void PrinterOne(int halfLength, ref int symbolCounter, ref int sideDashCounter, ref int middleDashCounter)
        {
            for (int i = 0; i < halfLength; i++)
            {
                //Printing first M's top
                Console.Write(new string(emptySpace, sideDashCounter));
                Console.Write(new string(letterSymbol, symbolCounter));
                Console.Write(new string(emptySpace, middleDashCounter));
                Console.Write(new string(letterSymbol, symbolCounter));
                Console.Write(new string(emptySpace, sideDashCounter));

                //Printing first Second M's top
                Console.Write(new string(emptySpace, sideDashCounter));
                Console.Write(new string(letterSymbol, symbolCounter));
                Console.Write(new string(emptySpace, middleDashCounter));
                Console.Write(new string(letterSymbol, symbolCounter));
                Console.Write(new string(emptySpace, sideDashCounter));

                Console.WriteLine();

                sideDashCounter--;
                symbolCounter += 2;
                middleDashCounter -= 2;
            }
        }

        private static void PrinterTwo(int UserInput, int halfLength, ref int symbolCounter, ref int sideDashCounter, ref int middleDashCounter)
        {
            for (int i = 0; i < halfLength; i++)
            {
                //First M
                Console.Write(new string(emptySpace, sideDashCounter));
                Console.Write(new string(letterSymbol, UserInput));
                Console.Write(new string(emptySpace, middleDashCounter));
                Console.Write(new string(letterSymbol, symbolCounter));
                Console.Write(new string(emptySpace, middleDashCounter));
                Console.Write(new string(letterSymbol, UserInput));
                Console.Write(new string(emptySpace, sideDashCounter));

                //Second M
                Console.Write(new string(emptySpace, sideDashCounter));
                Console.Write(new string(letterSymbol, UserInput));
                Console.Write(new string(emptySpace, middleDashCounter));
                Console.Write(new string(letterSymbol, symbolCounter));
                Console.Write(new string(emptySpace, middleDashCounter));
                Console.Write(new string(letterSymbol, UserInput));
                Console.Write(new string(emptySpace, sideDashCounter));
                Console.WriteLine();
                symbolCounter -= 2;
                middleDashCounter += 2;
                sideDashCounter--;
            }
        }
    }
}