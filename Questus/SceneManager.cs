using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using Scenes;

public class SceneManager
{
    private string connectionString;

    public SceneManager(string dbPath)
    {
        connectionString = $"Data Source={dbPath};";
    }

    public void AddScene(SceneHolder scene)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (SqliteCommand command = new SqliteCommand("INSERT INTO Scenes (SceneText, BackgroundImageName, SceneActions, SceneGoTo) VALUES (@SceneText, @BackgroundImageName, @SceneActions, @SceneGoTo)", connection))
            {
                command.Parameters.AddWithValue("@SceneText", scene.SceneText);
                command.Parameters.AddWithValue("@BackgroundImageName", scene.BackgroundImageName);
                command.Parameters.AddWithValue("@SceneActions", JsonConvert.SerializeObject(scene.SceneActions));
                command.Parameters.AddWithValue("@SceneGoTo", JsonConvert.SerializeObject(scene.SceneGoTo));

                command.ExecuteNonQuery();
            }
        }
    }

    public void EditScene(int sceneId, SceneHolder scene)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (SqliteCommand command = new SqliteCommand("UPDATE Scenes SET SceneText = @SceneText, BackgroundImageName = @BackgroundImageName, SceneActions = @SceneActions, SceneGoTo = @SceneGoTo WHERE SceneID = @SceneID", connection))
            {
                command.Parameters.AddWithValue("@SceneID", sceneId);
                command.Parameters.AddWithValue("@SceneText", scene.SceneText);
                command.Parameters.AddWithValue("@BackgroundImageName", scene.BackgroundImageName);
                command.Parameters.AddWithValue("@SceneActions", JsonConvert.SerializeObject(scene.SceneActions));
                command.Parameters.AddWithValue("@SceneGoTo", JsonConvert.SerializeObject(scene.SceneGoTo));

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteScene(int sceneId)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (SqliteCommand command = new SqliteCommand("DELETE FROM Scenes WHERE SceneID = @SceneID", connection))
            {
                command.Parameters.AddWithValue("@SceneID", sceneId);
                command.ExecuteNonQuery();
            }
        }
    }
}