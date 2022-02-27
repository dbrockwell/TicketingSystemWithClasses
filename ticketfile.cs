using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;

namespace ticketsV2 {
    public class ticketfile {
        public string filePath {get; set;}
        public List<string> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public ticketfile(string ticketFilePath) {
            filePath = ticketFilePath;
            Tickets = new List<string>();
            if(File.Exists(filePath))
            {
                StreamReader ticketRead = new StreamReader(filePath);
                while (!ticketRead.EndOfStream)
                {
                    Tickets.Add(ticketRead.ReadLine());
                }
            }
            else
            {
                logger.Error("File Does Not Exist");
            }
        }
    }
}