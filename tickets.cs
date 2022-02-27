using System;
using System.Collections.Generic;
using System.Linq;

namespace ticketsV2 {
    public class Tickets {
        public UInt64 ticketID { get; set; }
        public string summary {get; set;}
        public string status {get; set;}
        public string priority {get; set;}
        public string submitter {get; set;}
        public string assigned {get; set;}
        public List<string> peopleWatching {get; set;}

        public string entry() {
            string peopleWatchingString = "";
            string lastperson = peopleWatching.LastOrDefault();
            foreach (string person in peopleWatching) {
                if (person.Equals(lastperson)) {
                    peopleWatchingString += person;
                }
                else {
                    peopleWatchingString += person + "|";
                }
            }
            return $"{ticketID},{summary},{status},{priority},{submitter},{assigned},{peopleWatchingString}";
        }
    }
}