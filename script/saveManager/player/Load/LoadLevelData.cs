using System.IO;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    public Level level;

    // Start is called before the first frame update
    private void OnEnable()
    {
        loadLevelDat();
    }

    public void createLevelData()
    {
        levelSystem.SaveLevel(level);

        Debug.Log("Create new Level Data");
    }

    public void loadLevelDat()
    {
        if (File.Exists(Application.persistentDataPath + "/level.dat"))
        {
            LevelData data = levelSystem.LoadLevel();

            level.easy = data.easyLevel;
            level.medium = data.mediumLevel;
            level.hard = data.hardLevel;
        }
        else
        {
            createLevelData();
        }
    }
}
