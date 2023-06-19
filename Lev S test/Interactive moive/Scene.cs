using Newtonsoft.Json;
using System.IO;

namespace Interactive_moive
{

    public class Scene
    {
        [JsonProperty ("pathToVideo")]
        public string pathToVideo { get; set; }

        [JsonProperty("countScene")]
        public int countScene { get; set; }

        [JsonProperty("buttonText")]
        public string[] buttonText { get; set; }

        [JsonProperty("variants")]
        public int[] Variants { get; set; }
        
        

        void SerealiseScene(string PathToScene)
        {
            string[] str = File.ReadAllLines(PathToScene);
            
        }

        

    }

}
