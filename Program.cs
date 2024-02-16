namespace InformacijosSaugumas1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userChoice;

            while (true)
            {
                Console.WriteLine("--- Meniu ---");
                Console.WriteLine("1. Teksto šifravimas");
                Console.WriteLine("2. Teksto dešifravimas");
                Console.WriteLine("3. Teksto dešifravimas(ASCII)");
                Console.WriteLine("0. Išeiti");
                Console.Write("Pasirinkite: ");

                if (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("Netinkama įvestis. Įveskite skaičių.\n");
                    continue;
                }

                switch (userChoice)
                {
                    case 0:
                        Console.WriteLine("Išeinama iš programos...");
                        return;
                    case 1:
                        InputHandler.TextEncryption();
                        break;
                    case 2:
                        InputHandler.TextDecryption();
                        break;
                    case 3:
                        InputHandler.TextDecryptionAscii();
                        break;
                    default:
                        Console.WriteLine("Tokio pasirinkimo nėra.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
