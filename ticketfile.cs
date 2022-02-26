using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;

namespace ticketsV2 {
    public class ticketfile {
        public string filePath {get; set;}
        public List<tickets> Tickets {get; set;}
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    }
}