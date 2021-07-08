using System.IO;
using UnityEngine;

public class SetOptionsData : MonoBehaviour
{
    Options options = new Options();

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/options.json"))
        {
            createNewOptionsData();
        }
    }

    public void createNewOptionsData()
    {
        string jsonDat = JsonUtility.ToJson(options, true);
        File.WriteAllText(Application.persistentDataPath + "/options.json", jsonDat);

        Debug.Log("Created new options data to " + Application.persistentDataPath + "/options.json");
    }
}
