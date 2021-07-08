using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class optionsSystem
{
    /*
    public static void SaveOptions (Options options)
    {
        BinaryFormatter formatting = new BinaryFormatter();
        string path = Application.persistentDataPath + "/options.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        optionsData optionsDat = new optionsData(options);

        formatting.Serialize(stream, optionsDat);
        stream.Close();

        Debug.Log("[SaveSystem][Options] Save Data To " + path + " Complete");
    }

    public static optionsData LoadOptionsData ()
    {
        string path = Application.persistentDataPath + "/options.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formating = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            optionsData data = formating.Deserialize(stream) as optionsData;
            stream.Close();

            Debug.Log("[SaveSystem][Options] Load Data To " + path + " Complete");

            return data;
        }
        else
        {
            Debug.LogError("Error, " + path + " Not Found");

            return null;
        }
    }
    */
}
