using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{
    [Header("Controler Image")]

    public Image upImage;
    public Image downImage;
    public Image leftImage;
    public Image rightImage;

    public Color32 normalColor;
    public Color32 pressedColor;

    [Header("Sound Effect")]

    public AudioSource audioSource;
    public AudioClip[] clip;

    [Header("Controler Player")]

    public float speed = 5;

    [Header("Level Position")]

    public Vector3[] levelPosition;

    [Header("Cheat")]

    public bool isCheat = false;

    [Header("Android")]

    public Joystick joystick;

	private Rigidbody rb;
    private LoadOptionInLevel options;

    private bool isMobile = false;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        isMobile = true;
#endif

        GameObject gameObject = new GameObject();
        options = gameObject.AddComponent<LoadOptionInLevel>();
        rb = GetComponent<Rigidbody>();

        LevelPosition(LevelManager1.currentEasyLevel);
    }

    public void LevelPosition(int onLevel)
    {
        switch (onLevel)
        {
            case 1:
                transform.position = levelPosition[0];
                Debug.Log("Level: " + onLevel.ToString());
                break;
            case 2:
                transform.position = levelPosition[1];
                Debug.Log("Level: " + onLevel.ToString());
                break;
            case 3:
                transform.position = levelPosition[2];
                Debug.Log("Level: " + onLevel.ToString());
                break;
            case 4:
                transform.position = levelPosition[3];
                Debug.Log("Level: " + onLevel.ToString());
                break;
            case 5:
                transform.position = levelPosition[4];
                Debug.Log("Level: " + onLevel.ToString());
                break;
            default: Debug.LogError("current level not valid"); break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        int currentSound = Random.Range(0, clip.Length);

        audioSource.volume = options.volumeSfx;
        audioSource.pitch = Random.Range(1.2f, 2f);

        audioSource.PlayOneShot(clip[currentSound]);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal;
    	float moveVertical;

        if (isMobile)
        {
            switch (options.controlMode)
            {
                case 0:
                    moveHorizontal = joystick.Horizontal;
                    moveVertical = joystick.Vertical;

                    Debug.Log("Controller Input Mobile Switch To Joystick");
                    break;
                case 1:
                    moveHorizontal = SimpleInput.GetAxis("Horizontal");
                    moveVertical = SimpleInput.GetAxis("Vertical");

                    Debug.Log("Controller Input Mobile Switch To Touch Arrow");
                    break;
                default:
                    moveHorizontal = 0;
                    moveVertical = 0;

                    Debug.LogError("Switch Controller Mobile Not Valid");
                    break;
            }
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

        Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);

        rb.AddForce(movement * speed);

        tryToCheat("up", isCheat);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            upImage.color = pressedColor;
        }
        else
        {
            upImage.color = normalColor;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            downImage.color = pressedColor;
        }
        else
        {
            downImage.color = normalColor;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftImage.color = pressedColor;
        }
        else
        {
            leftImage.color = normalColor;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightImage.color = pressedColor;
        }
        else
        {
            rightImage.color = normalColor;
        }
    }

    //experiment
    public void tryToCheat(string cheat, bool onCheat)
    {
        if (cheat == "up" && onCheat)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.up);
            }
        }
        else if (!onCheat)
        {
            Debug.Log("cheat is disabled");
        }
        else
        {
            Debug.LogError("not valid cheat string");
        }
    }
}
