using System;
using System.IO;
using NLog.Web;

namespace ticketsV2
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string ticketFilePath = Directory.GetCurrentDirectory() + "\\tickets.csv";
            logger.Info("Program started");
            TicketFile ticketsFile = new TicketFile(ticketFilePath);
            string choice;
            do {
                Console.WriteLine("1) Read ticket information");
                Console.WriteLine("2) Add ticket infomation");
                Console.WriteLine("Enter any other key to exit");
                choice = Console.ReadLine();

                if (choice == "1") {
                    foreach(string ticket in ticketsFile.Tickets)
                    {
                        Console.WriteLine(ticket);
                    }
                }

                if (choice == "2") {

                }
            } while (choice == "1" || choice == "2");
        }

        public string NullCheck(string question, string errorName) {
            bool continueLoop = true;
            string entry = "";
            do {
                Console.WriteLine(question);
                entry = Console.ReadLine();
                if (entry == "") {
                    logger.Error("No input for {0} was entered", errorName);
                    continueLoop = true;
                }
                else {
                    continueLoop = false;
                }
            } while (continueLoop == true);

            return entry;
        }
    }
}
