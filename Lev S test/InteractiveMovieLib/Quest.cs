using System.Collections.Generic;
using Newtonsoft.Json;

namespace Interactive_moive
{
    public class Quest
    {
        [JsonProperty("Path")]
        public string PathToVideoFolder { get; set; }

        [JsonProperty("Scenes")]
        public List<Scene> ListOfScenes { get; set; }

        public Quest()
        {
            ListOfScenes = new List<Scene>();
        }
    }
}
