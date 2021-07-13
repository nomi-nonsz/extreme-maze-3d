using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Controler Image")]

    public Image upImage;
    public Image downImage;
    public Image leftImage;
    public Image rightImage;

    public Color32 normalColor;
    public Color32 pressedColor;

    [Header("Controler Player")]

    public float speed = 5;

    [Header("Level Position")]

    public Vector3[] levelPosition;

    [Header("Cheat")]

    public bool isCheat = false;

	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();

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
            default: Debug.LogError("current level not valid"); break;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
    	float moveY = Input.GetAxis("Vertical");

    	Vector3 movement = new Vector3(-moveY, 0.0f, moveX);

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
        else
        {
            Debug.LogError("not valid cheat string");
        }
    }
}
