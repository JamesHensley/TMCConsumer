using System;
using System.IO;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 3) {
                Console.WriteLine("Must pass the EventList file location, the LocationList file location, and output file as strings...");
                return;
            }

            extractorClass msgExtractor = new extractorClass(args[0], args[1]);

            string line = "";
            using (FileStream fStream = new FileStream(args[2], FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read)) {
                using (StreamWriter sr = new StreamWriter(fStream)) {
                    do {
                        line = Console.In.ReadLine();

                        var outMod = msgExtractor.ProcessLine(line);
                        if (outMod != null) {
                            Console.WriteLine(outMod.ToSummaryStr());
                            sr.WriteLine(outMod.ToJson());
                            sr.Flush();
                        }

                    } while (line != null);
                }
            }
        }
    }
}
