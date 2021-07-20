using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class levelSystem
{
    public static void SaveLevel(Level level)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(level);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Save Level data to " + path);
    }

    public static LevelData LoadLevel()
    {
        string path = Application.persistentDataPath + "/level.dat";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            Debug.Log("Load Level data to " + path);

            return data;
        }
        else
        {
            Debug.LogError("Failed to load level data, File on " + path + " not found");

            return null;
        }
    }
}
