using System;

namespace Consumer.Models {
    public class OutputModel {
        private DateTime unixOffset = new DateTime(1970, 1, 1);
        
        public EventModel eModel { get; set; }

        public LocationModel lModel { get; set; }

        public override string ToString()
        {
            return eModel.ToString() + " " + lModel.ToString();
        }

        public string ToJson() {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(unixOffset)).TotalSeconds;

            string eStr = eModel.ToJson().TrimStart('{').TrimEnd('}');
            string lStr = lModel.ToJson().TrimStart('{').TrimEnd('}');
            return "{ \"timeStamp\": \"" + unixTimestamp.ToString() + "\", " + eStr + "," + lStr + "}";
        }

        public string ToSummaryStr() {
            string eCode = ("000000" + eModel.EventNum);
            string lCode = ("000000" + lModel.LocationNum);
            string qCode = ("0000" + eModel.qVal);
            //return $"{lModel.State} {lModel.Latitude} {lModel.Longitude} {eModel.EventNum} {eModel.EventCategory} {eModel.EventText}";
            return $"e:{eCode.Substring(eCode.Length - 6)} q:{qCode.Substring(qCode.Length - 4)} l:{lCode.Substring(lCode.Length - 6)} - {lModel.State} {lModel.Latitude} {lModel.Longitude} {eModel.EventCategory} {eModel.EventText}";
        }
    }
}