using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Scenes;

namespace SceneControl
{
    public class SceneGetter
    {
        private string connectionString;

        public SceneGetter(string dbPath)
        {
            connectionString = $"Data Source={dbPath};";
        }

        public List<SceneHolder> GetScenes()
        {
            if (!TableExists("Scenes"))
            {
                throw new Exception("Table 'Scenes' does not exist in the database.");
            }

            List<SceneHolder> scenes = new List<SceneHolder>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT * FROM Scenes", connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SceneHolder scene = new SceneHolder
                        {
                            SceneText = reader.GetString(1),
                            BackgroundImageName = reader.GetString(2),
                            SceneActions = JsonConvert.DeserializeObject<List<string>>(reader.GetString(3)),
                            SceneGoTo = JsonConvert.DeserializeObject<List<int>>(reader.GetString(4))
                        };
                        scenes.Add(scene);
                    }
                }
            }

            return scenes;
        }

        public bool IsEndingScene(int sceneIndex)
        {
            if (!TableExists("EndingScenes"))
            {
                throw new Exception("Table 'EndingScenes' does not exist in the database.");
            }

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT COUNT(*) FROM EndingScenes WHERE SceneIndex = @SceneIndex", connection))
                {
                    command.Parameters.AddWithValue("@SceneIndex", sceneIndex);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public string GetEndingSceneText(int sceneIndex)
        {
            if (!TableExists("EndingScenes"))
            {
                throw new Exception("Table 'EndingScenes' does not exist in the database.");
            }

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT EndingText FROM EndingScenes WHERE SceneIndex = @SceneIndex", connection))
                {
                    command.Parameters.AddWithValue("@SceneIndex", sceneIndex);
                    return command.ExecuteScalar() as string;
                }
            }
        }

        public Dictionary<int, string> GetEndingScenes()
        {
            if (!TableExists("EndingScenes"))
            {
                throw new Exception("Table 'EndingScenes' does not exist in the database.");
            }

            Dictionary<int, string> endingScenes = new Dictionary<int, string>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand("SELECT * FROM EndingScenes", connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int sceneIndex = reader.GetInt32(0);
                        string endingText = reader.GetString(1);
                        endingScenes[sceneIndex] = endingText;
                    }
                }
            }

            return endingScenes;
        }

        public void SaveScenesToJson(string filePath)
        {
            var scenesData = new
            {
                Scenes = GetScenes(),
                EndingScenes = GetEndingScenes()
            };

            string json = JsonConvert.SerializeObject(scenesData, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private bool TableExists(string tableName)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';", connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}