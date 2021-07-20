using System.IO;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    private Level level = new Level();

    // Start is called before the first frame update
    void Start()
    {
        loadLevelDat();
    }

    public void createLevelData()
    {
        level.Save();

        Debug.Log("Create new Level Data");
    }

    public void loadLevelDat()
    {
        if (File.Exists(Application.persistentDataPath + "/level.dat"))
        {
            level.Load();
        }
        else
        {
            createLevelData();
        }
    }
}
