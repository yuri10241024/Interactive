using Newtonsoft.Json;
using System.IO;

namespace Interactive_moive
{

    public class Scene
    {
        [JsonProperty ("Title")]
        public string Title { get; set; }

        [JsonProperty ("pathToVideo")]
        public string pathToVideo { get; set; }

        [JsonProperty("Number")]
        public int countScene { get; set; }

        [JsonProperty("buttonText")]
        public string[] buttonText { get; set; }

        [JsonProperty("variants")]
        public int[] Variants { get; set; }

        [JsonProperty("intermediateVideo")]
        public string IntermediateVideo { get; set; } //К хардкоду

        void SerealiseScene(string PathToScene)
        {
            string[] str = File.ReadAllLines(PathToScene);
        }

        

    }

}
