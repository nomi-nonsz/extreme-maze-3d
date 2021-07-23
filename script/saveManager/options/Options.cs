// this where options are changes
public class Options
{
    // what?
    public string messagesForYouReadThisFile = "Hayoloh ngapain lo :v";

    // General Settings
    public bool setFullscreen = true;
    public bool setFPS = true;
    public bool setController = true;

    public int controlMobile = 1; // 0 means Joystick, 1 means button control

    // Volume Settings
    public float volumeSfx = 1;

    // Graphics Settings
    public int qualityLevel = 2; // 0 means low, 1 means medium, 2 means high, 3 means very high. default is 2
    public int antiAliasling = 0; // 0 means none, 1 means 2x, 2 means 4x, 3 means 8x. default is 0
    public bool setBloom = true;
}