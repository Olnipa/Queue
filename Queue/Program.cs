namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bills = new Queue<int>();

            bool isWorking = true;
            int totalIncome = 0;

            MakeQueue(bills);

            Console.WriteLine("Welcome to work");

            while (bills.Count > 0 && isWorking)
            {
                Console.WriteLine("\nPress \"1\" to see bills of all customers in queue\nPress 0 to close shop\nPress \"any other key\" to serve next customer\n");
                Console.Write("Press choosen button: ");
                ConsoleKeyInfo choosenMenu = Console.ReadKey();
                
                switch (choosenMenu.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        WriteQueueOfBills(bills);
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        isWorking = false;
                        break;
                    default:
                        SumNextBill(bills, ref totalIncome);
                        Console.Clear();
                        Console.WriteLine($"\n\nTotal income: {totalIncome}");
                        break;
                }
            }
        }

        static void SumNextBill(Queue<int> bills, ref int totalIncome)
        {
            int nextBill = bills.Dequeue();
            totalIncome += nextBill;
        }

        static void MakeQueue(Queue<int> bills)
        {
            Random random = new Random();
            int minBill = 100;
            int maxBill = 1000;
            int minClientsQuantity = 3;
            int maxClientsQuantity = 11;
            int clientQuantity = random.Next(minClientsQuantity, maxClientsQuantity);

            for (int i = 0; i < clientQuantity; i++)
            {
                bills.Enqueue(random.Next(minBill, maxBill));
            }
        }

        static void WriteQueueOfBills(Queue<int> bills)
        {
            int clientNumber = 1;

            Console.WriteLine("\n");

            foreach (var bill in bills)
            {
                Console.WriteLine($"Client No.{clientNumber} need to pay {bill} USD");
                clientNumber++;
            }
        }
    }
}