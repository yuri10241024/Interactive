using System.Collections.Generic;
using Newtonsoft.Json;

namespace Interactive_moive
{
    public class Quest
    {
        public string PathToVideoFolder { get; set; }

        public List<Scene> ListOfScenes { get; set; }
    }
}
