using MySql.Data.MySqlClient;

namespace MiniProject.Data;

internal class SQLData
{
    static void DBConnect()
    {
        string connectionString = "Server=192.168.0.53;Port=3306;Database=gamedata;Uid=noblesi;Password=minsung0516!;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            SavePlayerInfo(connection, id, name, hp, atk, def, speed);

            connection.Close();
        }
    }

    static void SavePlayerInfo(MySqlConnection connection,
        int id, string name, int hp, int atk, int def, int speed)
    {
        string query = "INSERT INTO player (ID, NAME, HP, ATK, DEF, SPEED) VALUES (@ID, @NAME, @HP, @ATK, @DEF, @SPEED);";

        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@NAME", name);
            command.Parameters.AddWithValue("@HP", hp);
            command.Parameters.AddWithValue("@ATK", atk);
            command.Parameters.AddWithValue("@DEF", def);
            command.Parameters.AddWithValue("@SPEED", speed);

            command.ExecuteNonQuery();
        }
    }

    static void LoadMosterInfo(MySqlConnection connection)
    {

    }
}
