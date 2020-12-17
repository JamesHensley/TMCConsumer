using System;
using System.IO;
using Consumer.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Consumer {
    /// Performs lookups on incoming data and returns an Output model
    public class lookupClass {
        private Dictionary<string, EventModel> eventDict;
        private Dictionary<string, LocationModel> LocDict;

        public lookupClass(string EventFile, string LocationFile)
        {
            Regex eventRegEx = new Regex("^(.+)\t(.+)\t(.+)\t(.*)\t(.*)\t(.*)\t(.*)\t(.*)\t(.*)\t(.*)$");
            Regex locRegEx =   new Regex("^(.+)\t(.*)\t(.*)\t(.*)\t(.*)\t(.*)$");

            eventDict = new Dictionary<string, EventModel>();
            LocDict = new Dictionary<string, LocationModel>();
            string lines;

            //Console.WriteLine($"Reading event list from {EventFile}");
            using (TextReader textReader = File.OpenText(EventFile)) {
                lines = textReader.ReadToEnd();
                foreach(string line in lines.Split(new [] { Environment.NewLine}, StringSplitOptions.None)) {
                    Match myMatch = eventRegEx.Match(line);
                    if(myMatch.Success) {
                        EventModel eModel = new EventModel {
                                EventCategory = myMatch.Groups[1].Value,
                                EventText = myMatch.Groups[2].Value,
                                EventNum = myMatch.Groups[3].Value,
                                nVal = myMatch.Groups[4].Value,
                                qVal = myMatch.Groups[5].Value,
                                tVal = myMatch.Groups[6].Value,
                                dVal = myMatch.Groups[7].Value,
                                uVal = myMatch.Groups[8].Value,
                                cVal = myMatch.Groups[9].Value,
                                rVal = myMatch.Groups[10].Value
                            };

                        if(eventDict.ContainsKey(eModel.EventNum)) {
                            //Console.WriteLine($"\tSkipping {eModel.EventNum}... already exists");
                        } else {
                            eventDict.Add(eModel.EventNum, eModel);
                        }
                    }
                }
            }

            using (TextReader textReader = File.OpenText(LocationFile)) {
                lines = textReader.ReadToEnd();
                foreach(string line in lines.Split(new [] { Environment.NewLine }, StringSplitOptions.None)) {
                    Match myMatch = locRegEx.Match(line);
                    if(myMatch.Success) {
                        LocationModel lModel = new LocationModel {
                                LocationNum = myMatch.Groups[1].Value,
                                Latitude = myMatch.Groups[2].Value,
                                Longitude = myMatch.Groups[3].Value,
                                State = myMatch.Groups[4].Value,
                                PoliceStation = myMatch.Groups[5].Value,
                                Special = myMatch.Groups[6].Value
                            };
                        if(LocDict.ContainsKey(lModel.LocationNum)) {
                            //Console.WriteLine($"\tSkipping {lModel.LocationNum}... already exists");
                        } else {
                            LocDict.Add(lModel.LocationNum, lModel);
                        };
                    }
                }
            }
        }

        public OutputModel lookup(string evtNum, string locNum) {
            var outObj = new OutputModel {
                eModel = eventDict.GetValueOrDefault(evtNum) ?? new EventModel(),
                lModel = LocDict.GetValueOrDefault(locNum) ?? new LocationModel(),
            };
            
            return outObj;
        }
    }
}