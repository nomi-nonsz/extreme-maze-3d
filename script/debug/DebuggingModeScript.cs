using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DebuggingModeScript : MonoBehaviour
{
    [Header("Game Object")]
    public Text fpsText;
    public Text sceneTextNum;
    public Text sceneTextName;
    public Text inputText;

    public Transform playerObj;
    public Text posX;
    public Text posY;
    public Text posZ;

    DebuggingMode debugMode;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();
        debugMode = gameObject.AddComponent<DebuggingMode>();

        if (debugMode.debugObj)
        {
            sceneTextNum.text = "Scene Index: " + SceneManager.GetActiveScene().buildIndex.ToString();
            sceneTextName.text = "Scene Name: " + SceneManager.GetActiveScene().name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMode.debugObj)
        {
            float fps = 1 / Time.deltaTime;
            fpsText.text = "FPS: " + fps.ToString("F2");

            if (playerObj)
            {
                posX.text = "Position X: " + playerObj.position.x.ToString("F");
                posY.text = "Position Y: " + playerObj.position.y.ToString("F");
                posZ.text = "Position Z: " + playerObj.position.z.ToString("F");
            }

            DebuggingControl();
        }
    }

    void DebuggingControl()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Restart Scene");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Change Scene");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("Change Scene");
        }
    }
}
