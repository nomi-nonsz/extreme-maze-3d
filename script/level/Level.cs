public class Level
{
    public int easy = 0;
    public int medium = 0;
    public int hard = 0;

    public void Save()
    {
        levelSystem.SaveLevel(this);
    }

    public void Load()
    {
        LevelData data = levelSystem.LoadLevel();

        easy = data.easyLevel;
        medium = data.mediumLevel;
        hard = data.hardLevel;
    }
}