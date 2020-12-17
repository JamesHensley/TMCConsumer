using System.Text.Json;

namespace Consumer.Models {
    public class EventModel {
        private string eventText { get; set;}
        public string EventNum { get; set; }
        public string EventCategory { get; set; }
        public string EventText { get; set; }
        public string nVal { get; set; }
        public string qVal { get; set; }
        public string tVal { get; set; }
        public string dVal { get; set; }
        public string uVal { get; set; }
        public string cVal { get; set; }
        public string rVal { get; set; }
        
        public override string ToString()
        {
            return $"{EventNum} {EventCategory} {EventText}";
        }

        public string ToJson() {
            return JsonSerializer.Serialize(this);
        }
    }
}
