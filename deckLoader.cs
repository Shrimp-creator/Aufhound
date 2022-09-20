using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class deckLoader
{
    public static void SaveDeck (CardManager cardMan)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/deck.help";
        FileStream stream = new FileStream(path, FileMode.Create);

        deckSaver data = new deckSaver(cardMan);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static deckSaver LoadDeck()
    {
        string path = Application.persistentDataPath + "/deck.help";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            deckSaver data = formatter.Deserialize(stream) as deckSaver;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
