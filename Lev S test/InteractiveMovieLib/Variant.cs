using Newtonsoft.Json;
namespace Interactive_moive
{
    public class Variant
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty ("TargetID")]
        public int TargetID { get; set; }
    }
}
