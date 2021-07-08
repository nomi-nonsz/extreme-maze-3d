using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class optionsData : MonoBehaviour
{
    public Toggle fullScreenToggle;
    public Toggle fpsToggle;
    public Toggle ctrlToggle;
    public Toggle bloomToggle;

    public Slider volumeSlider;
    public Dropdown qualityLevelDropdown;

    public Options options = new Options();

    void OnEnable()
    {
        LoadOptions();
    }

    public void isFullscreen()
    {
        options.setFullscreen = Screen.fullScreen = fullScreenToggle.isOn;
        Debug.Log("Fullscreen is " + options.setFullscreen.ToString());

        SaveOptions();
    }

    public void showFps()
    {
        options.setFPS = fpsToggle.isOn;
        Debug.Log("FPS is " + options.setFullscreen.ToString());

        SaveOptions();
    }

    public void showController()
    {
        options.setController = ctrlToggle.isOn;
        Debug.Log("Controller is " + options.setFullscreen.ToString());

        SaveOptions();
    }

    public void sfxVolume()
    {
        options.volumeSfx = volumeSlider.value;
        Debug.Log("SFX Volume is " + options.volumeSfx.ToString("F"));

        SaveOptions();
    }

    public void postProcessingBloom()
    {
        options.setBloom = bloomToggle.isOn;
        Debug.Log("Bloom is " + options.setBloom.ToString());

        SaveOptions();
    }

    public void graphicQuality()
    {
        string qualityLevelMsg;

        options.qualityLevel = qualityLevelDropdown.value;
        QualitySettings.SetQualityLevel(options.qualityLevel);

        switch (options.qualityLevel)
        {
            case 0: qualityLevelMsg = "low"; break;
            case 1: qualityLevelMsg = "medium"; break;
            case 2: qualityLevelMsg = "high"; break;
            case 3: qualityLevelMsg = "very high"; break;
            default: qualityLevelMsg = "Null"; break;
        }

        Debug.Log("Quality set to " + qualityLevelMsg);
    }

    public void SaveOptions()
    {
        string jsonDat = JsonUtility.ToJson(options, true);
        File.WriteAllText(Application.persistentDataPath + "/options.json", jsonDat);

        if (File.Exists(Application.persistentDataPath + "/options.json"))
            Debug.Log("Saving Options Data File To " + Application.persistentDataPath + "/options.json" + " Succesful");
        else
            Debug.LogError("Unknown Error: Failed to Save Options Data to " + Application.persistentDataPath + "/options.json");
    }
    
    public void LoadOptions()
    {
        options = JsonUtility.FromJson<Options>(File.ReadAllText(Application.persistentDataPath + "/options.json"));

        fullScreenToggle.isOn = options.setFullscreen;
        fpsToggle.isOn = options.setFPS;
        ctrlToggle.isOn = options.setController;
        volumeSlider.value = options.volumeSfx;
        qualityLevelDropdown.value = options.qualityLevel;
        bloomToggle.isOn = options.setBloom;

        Debug.Log("Load Options Data File To " + Application.persistentDataPath + "/options.json");
    }

    public void ResetOptions()
    {
        fullScreenToggle.isOn = true;
        fpsToggle.isOn = true;
        ctrlToggle.isOn = true;
        volumeSlider.value = 1;
        qualityLevelDropdown.value = 2;
        bloomToggle.isOn = true;

        options.setFullscreen = Screen.fullScreen = fullScreenToggle.isOn;
        options.setFPS = fpsToggle.isOn;
        options.setController = ctrlToggle.isOn;
        options.volumeSfx = volumeSlider.value;
        options.setBloom = bloomToggle.isOn;

        if (fullScreenToggle.isOn && fpsToggle.isOn && ctrlToggle.isOn && volumeSlider.value == 1 &&
            qualityLevelDropdown.value == 2 && bloomToggle.isOn)
        {
            SaveOptions();
            Debug.Log("Reset All Options Data");
        }
        else
            Debug.LogError("Failed to reset All Options Data");
    }
}