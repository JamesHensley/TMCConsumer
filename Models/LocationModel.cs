using System.Text.Json;

namespace Consumer.Models {
    public class LocationModel {
        public string LocationNum { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string State { get; set; }
        public string PoliceStation { get; set; }
        public string Special { get; set; }

        public override string ToString()
        {
            return $"{LocationNum} {Latitude} {Longitude} {State}";
        }
        public string ToJson() {
            return JsonSerializer.Serialize(this);
        }
    }
}