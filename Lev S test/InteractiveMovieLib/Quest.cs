using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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

        static public Quest GetQuest(string fileName)
        {
            Quest quest = JsonConvert.DeserializeObject<Quest>(File.ReadAllText(fileName));
            return quest;
        }

        public void OrganizeScenes()
        {
            //1. Ищем корневую сцену
            //2. Находим все дочерние сцены
            //3. Для каждой дочерний сцены определяем номер
            //4. Для 2 и 3 п-ов будет происходить рекурсия) (вызывание функции самой себя)

            List<Scene> startScenes = GetStartScene();
            for(int i = 0; i < startScenes.Count; i++)
            {
                startScenes[i].Lvl = 0;
                SetID(startScenes[i]);
            }
        }

        private void SetID(Scene scene)
        {
            for(int i = 0; i < scene.ListOfVariants.Count; i++)
            {
                Scene NextScene = ListOfScenes.Where(s => s.countScene == scene.ListOfVariants[i].TargetID).FirstOrDefault();
                if (NextScene == null)
                {
                    NextScene.missedScenes = true;
                }
                if (NextScene.Lvl < scene.Lvl)
                {
                    NextScene.Lvl = scene.Lvl + 1;
                }
                SetID(NextScene);//рекурсия
            }
        }

        private List<Scene> GetStartScene()
        {
            List<Scene> scenes = new List<Scene>();
            scenes = ListOfScenes.Where(s => s.IsStartScene == true).ToList();
            return scenes;
        }
    }
}
/*
            for (int i = 0; i < ListOfScenes.Count; i++)
            {
                IDs.Add(ListOfScenes[i].countScene);
            }
            for (int i = 0; i < ListOfScenes.Count; i++)
            {
                for (int j = 0; j < ListOfScenes[i].ListOfVariants.Count; j++)
                {
                    IDs.Remove(ListOfScenes[i].ListOfVariants[j].TargetID);//обращение через объекта варианта к номеру сцены к которму этот объект видёт, вкусно
                }
            }
            for (int i = 0; i < IDs.Count; i++)
            {
                Scene s = ListOfScenes.Where(sc => sc.countScene == IDs[i]).FirstOrDefault();// пример linq запроса, like SQL принципы
                scenes.Add(s);
            }
            return scenes;*/
// string q = @"D:\_STUDIOS\VISUAL_STUDIO\Programming\Видео для программирования\Тест для ИФ123_1\Готовое\3.1.json"