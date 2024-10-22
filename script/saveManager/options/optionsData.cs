﻿using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class optionsData : MonoBehaviour
{
    [Header("Options Toggle")]
    public Toggle fullScreenToggle;
    public Toggle fpsToggle;
    public Toggle ctrlToggle;
    public Toggle bloomToggle;

    [Header("Options Slider")]
    public Slider volumeSlider;

    [Header("Options Drop Down")]
    public Dropdown qualityLevelDropdown;
    public Dropdown antiAliasingDropdown;

    [Header("Options GameObject")]
    public GameObject arrowDropDown;
    public GameObject fullscreenObj;
    public GameObject ctrlObj;
    public GameObject bloomObj;
    public GameObject setControllerMobile;

    public float rotatingTime;

    public Options options = new Options();

    private RectTransform rectArrow;
    private Button controllerButtonMobile;

    private bool isRotateArrow = false;
    private bool isMobile;

    private int MobileControlMode = 1;

    private void Start()
    {
        rectArrow = arrowDropDown.GetComponent<RectTransform>();
        controllerButtonMobile = setControllerMobile.GetComponent<Button>();
    }

    void OnEnable()
    {
        LoadOptions();

        #if UNITY_ANDROID
        isMobile = true;
        #endif

        if (isMobile)
        {
            fullscreenObj.SetActive(false);
            ctrlObj.SetActive(false);
            bloomObj.SetActive(false);

            setControllerMobile.SetActive(true);
        }
        else
        {
            fullscreenObj.SetActive(true);
            ctrlObj.SetActive(true);
            bloomObj.SetActive(true);

            setControllerMobile.SetActive(false);
        }
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

    public void rotateArrowOptions()
    {
        Quaternion rotasiAwal = Quaternion.Euler(0, 0, 0);
        Quaternion rotasiAkhir = Quaternion.Euler(0, 0, 180);

        if (isRotateArrow) Quaternion.Slerp(rectArrow.rotation, rotasiAkhir, rotatingTime);
        else Quaternion.Slerp(rotasiAkhir, rotasiAwal, rotatingTime);

        rotatingTime = rotatingTime + Time.deltaTime;
    }

    public void graphicQuality()
    {
        options.qualityLevel = qualityLevelDropdown.value;
        QualitySettings.SetQualityLevel(options.qualityLevel);

        if (options.qualityLevel <= 0)
        {
            bloomToggle.isOn = false;
            options.setBloom = bloomToggle.isOn;

            Debug.Log("Bloom set to " + options.setBloom.ToString());
        }
        else
        {
            bloomToggle.isOn = true;
            options.setBloom = bloomToggle.isOn;

            Debug.Log("Bloom set to " + options.setBloom.ToString());
        }

        Debug.Log("Quality set to " + QualitySettings.names);

        SaveOptions();
    }

    public void antiAliasOptions()
    {
        options.antiAliasling = antiAliasingDropdown.value;
        QualitySettings.antiAliasing = options.antiAliasling = (int)Mathf.Pow(2f, antiAliasingDropdown.value);

        Debug.Log("Anti-Aliasing set to " + QualitySettings.antiAliasing.ToString());

        SaveOptions();
    }

    public void MobileControlJoystick()
    {
        string controlMode;

        options.controlMobile = MobileControlMode = 0;

        switch (options.controlMobile)
        {
            case 0: controlMode = "Joystick"; break;
            case 1: controlMode = "Touch Button"; break;
            default:
                controlMode = "NaN";
                Debug.LogError("control mobile not valid");
                break;
        }

        Debug.Log("Set Control On Mobile To " + controlMode);

        SaveOptions();
    }

    public void MobileControlTouch()
    {
        string controlMode;

        options.controlMobile = MobileControlMode = 1;

        switch (options.controlMobile)
        {
            case 0: controlMode = "Joystick"; break;
            case 1: controlMode = "Touch Button"; break;
            default:
                controlMode = "NaN";
                Debug.LogError("control mobile not valid");
                break;
        }

        Debug.Log("Set Control On Mobile To " + controlMode);

        SaveOptions();
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
        if (File.Exists(Application.persistentDataPath + "/options.json"))
        {
            options = JsonUtility.FromJson<Options>(File.ReadAllText(Application.persistentDataPath + "/options.json"));

            fullScreenToggle.isOn = options.setFullscreen;
            fpsToggle.isOn = options.setFPS;
            ctrlToggle.isOn = options.setController;
            MobileControlMode = options.controlMobile;

            volumeSlider.value = options.volumeSfx;
            qualityLevelDropdown.value = options.qualityLevel;

            bloomToggle.isOn = options.setBloom;
            antiAliasingDropdown.value = options.antiAliasling;

            Debug.Log("Load Options Data File To " + Application.persistentDataPath + "/options.json");
        }
        else
        {
            string jsonDat = JsonUtility.ToJson(options, true);
            File.WriteAllText(Application.persistentDataPath + "/options.json", jsonDat);

            Debug.Log("Created New Options Data File to " + Application.persistentDataPath + "/options.json");
        }
    }

    public void ResetOptions()
    {
        fullScreenToggle.isOn = true;
        fpsToggle.isOn = true;
        ctrlToggle.isOn = true;
        MobileControlMode = 1;
        volumeSlider.value = 1;
        qualityLevelDropdown.value = 2;
        bloomToggle.isOn = true;
        antiAliasingDropdown.value = 0;

        options.setFullscreen = Screen.fullScreen = fullScreenToggle.isOn;
        options.setFPS = fpsToggle.isOn;
        options.setController = ctrlToggle.isOn;
        options.controlMobile = MobileControlMode;
        options.volumeSfx = volumeSlider.value;
        options.setBloom = bloomToggle.isOn;
        options.antiAliasling = antiAliasingDropdown.value;

        if (fullScreenToggle.isOn && fpsToggle.isOn && ctrlToggle.isOn && MobileControlMode == 1 && volumeSlider.value == 1 &&
            qualityLevelDropdown.value == 2 && bloomToggle.isOn && antiAliasingDropdown.value == 0)
        {
            SaveOptions();
            Debug.Log("Reset All Options Data");
        }
        else
            Debug.LogError("Failed to reset All Options Data");
    }
}