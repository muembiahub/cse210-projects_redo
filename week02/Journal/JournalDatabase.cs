using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class JournalDatabase
{
    private string connectionString;
    private string dbFile;
    public List<JournalEntry> Entries { get; private set; } = new List<JournalEntry>();

    public JournalDatabase(string dbFile)
    {
        this.dbFile = dbFile;
        connectionString = $"Data Source={dbFile}";
        EnsureTableExists();
    }

    public void SetFile(string newFile)
    {
        dbFile = newFile;
        connectionString = $"Data Source={dbFile}";
        EnsureTableExists();
    }

    private void EnsureTableExists()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"CREATE TABLE IF NOT EXISTS Entries (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Prompt TEXT NOT NULL,
            Response TEXT NOT NULL,
            Date TEXT NOT NULL
        );";
        command.ExecuteNonQuery();
    }

    public void SaveAllEntries()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        foreach (var entry in Entries)
        {
            var command = connection.CreateCommand();
            command.CommandText =
            @"INSERT INTO Entries (Prompt, Response, Date)
              VALUES ($prompt, $response, $date)";
            command.Parameters.AddWithValue("$prompt", entry.Prompt);
            command.Parameters.AddWithValue("$response", entry.Response);
            command.Parameters.AddWithValue("$date", entry.Date);
            command.ExecuteNonQuery();
        }

       
    }

    public void LoadEntries()
    {
        Entries.Clear();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Prompt, Response, Date FROM Entries";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var entry = new JournalEntry(reader.GetString(0), reader.GetString(1))
            {
                Date = reader.GetString(2)
            };
            Entries.Add(entry);
        }
    }
}
