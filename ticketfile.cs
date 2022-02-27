using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ticketsV2 {
    public class TicketFile {
        public string filePath {get; set;}
        public List<Ticket> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public TicketFile(string ticketFilePath) {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();
            if(File.Exists(filePath))
            {
                StreamReader ticketRead = new StreamReader(filePath);
                while (!ticketRead.EndOfStream)
                {
                    Ticket ticket = new Ticket();
                    Tickets.Add(ticket);
                }
                ticketRead.Close();
            }
            else
            {
                logger.Error("File Does Not Exist");
            }
        }

        public void AddTicket(Ticket ticket) {
            if(File.Exists(filePath)) {
                ticket.ticketID = Tickets.Max(t => t.ticketID) + 1;
                File.AppendAllText(filePath, ticket.entry());
            }
            else {
                StreamWriter ticketWrite = new StreamWriter(filePath);
                ticket.ticketID = 1;
                ticketWrite.Write(ticket.entry());
                ticketWrite.Close();
            }
        }
    }
}