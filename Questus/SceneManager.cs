using Scenes;
using Newtonsoft.Json;

namespace SceneControl
{
    public class SceneManager
    {
        private List<SceneHolder> listScenes;
        private Dictionary<int, string> endingScenes;

        public SceneManager()
        {
            InitializeScenes();
            InitializeEndingScenes();
            SaveScenesAsJSON("scenes.json");
        }

        private void InitializeScenes()
        {
            listScenes = new List<SceneHolder>
            {
                new SceneHolder // 0
                {
                    SceneActions = new List<string> { "Принять опасное задание гильдии", "Выйти из гильдии и отправиться за границу", "Не взять заказ" },
                    SceneGoTo = new List<int> { 1, 9, 10 },
                    SceneText = "В монастырях не давали курить, в тюрьме - пить. Оставалась только гильдия. \nГильдия - прекрасная страна свободы.",
                    BackgroundImageName = "scene0"
                },
                new SceneHolder // 1
                {
                    SceneActions = new List<string> { "Пойти по отмеченному пути", "Попробовать найти дорогу самостоятельно", "Передумать" },
                    SceneGoTo = new List<int> { 2, 12, 11 },
                    SceneText = "На потертом свитке содержится карта к заброшенным шахтам",
                    BackgroundImageName = "scene1"
                },
                new SceneHolder // 2
                {
                    SceneActions = new List<string> { "Войти внутрь", "Обыскать округу", "Бросить всё" },
                    SceneGoTo = new List<int> { 5, 3, 11 },
                    SceneText = "Вы отправились по указанной дороге и благополучно добрались к пещерам",
                    BackgroundImageName = "scene2"
                },
                new SceneHolder // 3
                {
                    SceneActions = new List<string> { "Поговорить", "Проигнорировать", "Убраться подальше" },
                    SceneGoTo = new List<int> { 4, 2, 15 },
                    SceneText = "Вам встретился на пути молодой Экзорцист",
                    BackgroundImageName = "scene3"
                },
                new SceneHolder // 4
                {
                    SceneActions = new List<string> { "Всё равно войти в пещеру", "Убраться от опасности восвоясе", "Поболтать ещё" },
                    SceneGoTo = new List<int> { 5, 15, 4 },
                    SceneText = "Парень поведал вам о мрачной истории шахты",
                    BackgroundImageName = "scene4"
                },
                new SceneHolder // 5
                {
                    SceneActions = new List<string> { "Зажечь факел и углубиться внутрь", "Повернуть назад", "Потупить в стену" },
                    SceneGoTo = new List<int> { 6, 3, 6 },
                    SceneText = "Внутри царила кромешная тьма. Воздух был спёрт и тяжел",
                     BackgroundImageName = "scene5"
                },
                new SceneHolder // 6
                {
                    SceneActions = new List<string> { "Замереть", "Заорать и убежать", "Страшно выругаться" },
                    SceneGoTo = new List<int> { 7, 3, 7 },
                    SceneText = "Тьма сгущалась и уже даже огонь не спасал положение. \nИз-за поворота выплало нечто светящиеся",
                    BackgroundImageName = "scene6"
                },
                new SceneHolder // 7
                {
                    SceneActions = new List<string> { "Поболтать", "Напасть", "Притвориться стенкой" },
                    SceneGoTo = new List<int> { 8, 16, 8 },
                    SceneText = "Призрак смерил вас взглядом и подлетел ближе",
                     BackgroundImageName = "scene7"
                },
                new SceneHolder // 8
                {
                    SceneActions = new List<string> { "Убить", "Оставить в покое", "Позвать экзорциста" },
                    SceneGoTo = new List<int> { 13, 15, 14 },
                    SceneText = "Фантом поведал вам свою душещипательную историю о жизни и смерти",
                    BackgroundImageName = "scene8"
                },
                new SceneHolder // 9
                {
                   SceneActions = new List<string> { "Идти дальше", "Всё же вернуться в гильдию", "Свернуть в камыши" },
                    SceneGoTo = new List<int> { 17, 0, 12 },
                    SceneText = "Под ногами шелестела мягкая зеленая трава. \nЖизнь казалась на удивление спокойной",
                    BackgroundImageName = "scene20"
                },
                new SceneHolder // 10
                {
                    SceneActions = new List<string> { "Всё таки принять задание", "Уйти в закат", "Выйти из гильдии" },
                    SceneGoTo = new List<int> { 1, 17, 11 },
                    SceneText = "Вы приняли решение отказаться от тяжелого заказа, \nно всё ещё оставались в здании родной гильдии",
                    BackgroundImageName = "scene21"
                },
                new SceneHolder // 11
                {
                    SceneText = string.Empty,
                    BackgroundImageName = "scene9"
                },
                new SceneHolder // 12
                {
                    SceneText = string.Empty,
                    BackgroundImageName = "scene10"
                },
                new SceneHolder // 13
                {
                    SceneText = string.Empty,
                    BackgroundImageName = "scene11"
                },
                new SceneHolder // 14
                {
                    SceneText = string.Empty,
                    BackgroundImageName = "scene12"
                },
                new SceneHolder // 15
                {
                    SceneText = string.Empty,
                    BackgroundImageName = "scene13"
                },
                new SceneHolder // 16
                {
                    SceneText = string.Empty,
                    BackgroundImageName = "scene14"
                },
                new SceneHolder // 17
                {
                    SceneText = string.Empty,
                    BackgroundImageName = "scene15"
                }
            };
        }

        private void InitializeEndingScenes()
        {
            endingScenes = new Dictionary<int, string>
            {
                { 11, "Вы не получили деняг и умерли голодной смертью" },
                { 12, "Вы пошли своим путем и споткнулись на кочке, пропав в болотной тине" },
                { 13, "Вы убили неожидающее подставы приведение и получили награду" },
                { 14, "Экзорцист отправил призрака в лучший мир" },
                { 15, "Вы вернулись обратно ни с чем" },
                { 16, "Призрак ожидал удара и ответным убил вас. Вы ПОМЕР." },
                { 17, "Дальше обитают драконы. Возвращайтесь. Вам приходит мысль, \nчто тут пригодился бы портал." }
            };
        }

        public List<SceneHolder> GetScenes() => listScenes;

        public bool IsEndingScene(int sceneIndex)
        {
            return endingScenes.ContainsKey(sceneIndex);
        }

        public string GetEndingSceneText(int sceneIndex)
        {
            return endingScenes.ContainsKey(sceneIndex) ? endingScenes[sceneIndex] : string.Empty;
        }

        private SceneDataJSON ConvertScenesToJSON()
        {
            var sceneData = new SceneDataJSON
            {
                Scenes = listScenes
            };

            sceneData.EndingScenes = endingScenes.Select(kvp => new EndingSceneJSON
            {
                SceneIndex = kvp.Key,
                EndingText = kvp.Value
            }).ToList();

            return sceneData;
        }

        public void SaveScenesAsJSON(string filePath)
        {
            var sceneData = ConvertScenesToJSON();
            string json = JsonConvert.SerializeObject(sceneData, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}