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
        public int ID { get; set; }

        [JsonProperty("ListOfVariants")]
        public List<Variant> ListOfVariants { get; set; }

        [JsonProperty("IsFinalScene")]
        public bool IsFinalScene { get; set; }

        [JsonProperty("IsStartScene")]
        public bool IsStartScene { get; set; }

        [JsonProperty("intermediateVideo")]
        public string IntermediateVideo { get; set; } //К хардкоду

        [JsonProperty("Lvl")]
        public int Lvl { get; set; }

        [JsonProperty("missedScenes")]
        public bool missedScenes { get; set; }
        
        [JsonIgnore]
        public bool IsDone;

        [JsonIgnore]
        public int XStep;



        //public bool IsParent;

        //public bool IsChild;



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
