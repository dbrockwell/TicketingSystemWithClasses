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
        }
    }
}
