[System.Serializable]
public class LevelData
{
    public int easyLevel;
    public int mediumLevel;
    public int hardLevel;

    public LevelData (Level level)
    {
        easyLevel = level.easy;
        mediumLevel = level.medium;
        hardLevel = level.hard;
    }
}
