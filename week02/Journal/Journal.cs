using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class JournalDatabase
{
    private string connectionString = "Data Source=journal.db";

    public JournalDatabase()
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

    public void SaveEntry(JournalEntry entry)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"INSERT INTO Entries (Prompt, Response, Date)
          VALUES ($prompt, $response, $date)";
        command.Parameters.AddWithValue("$prompt", entry.Prompt);
        command.Parameters.AddWithValue("$response", entry.Response);
        command.Parameters.AddWithValue("$date", entry.Date);

        command.ExecuteNonQuery();
    }

    public List<JournalEntry> LoadEntries()
    {
        var entries = new List<JournalEntry>();
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
            entries.Add(entry);
        }
        return entries;
    }
}
