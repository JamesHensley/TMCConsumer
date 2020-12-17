using System;
using System.Text.RegularExpressions;
using Consumer.Models;

namespace Consumer {
    /// Responsible for processing incoming data
    public class extractorClass {
        private Regex regex;
        private lookupClass lookup;

        public extractorClass(string evListLoc, string locListLoc)
        {
            lookup = new lookupClass(evListLoc, locListLoc);
            regex = new Regex(@"event(\d+):(.+), location:(\d+)$");
        }

        public OutputModel ProcessLine(string lineStr) {
            if (!string.IsNullOrEmpty(lineStr)) {
                Match myMatch = regex.Match(lineStr);
                if(myMatch.Success) {
                    string evNum = myMatch.Groups[1].Value;
                    string locNum = myMatch.Groups[3].Value;
                    return lookup.lookup(evNum, locNum);
                }
            }
            return null;
        }
    }
}