using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;


namespace Interactive_moive
{

    public class Scene
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("pathToVideo")]
        public string pathToVideo { get; set; }

        [JsonProperty("Number")]
        public int countScene { get; set; }

        [JsonProperty("ListOfVariants")]
        public List<Variant> ListOfVariants { get; set; }

        [JsonProperty("IsFinalScene")]
        public bool IsFinalScene { get; set; }

        [JsonProperty("intermediateVideo")]
        public string IntermediateVideo { get; set; } //К хардкоду

        public Scene()
        {
            ListOfVariants = new List<Variant>();
        }

        void SerealiseScene(string PathToScene)
        {
            string[] str = File.ReadAllLines(PathToScene);
        }
    }

}
