using UnityEngine;

public class ControllerMobile : MonoBehaviour
{
    public GameObject joystickController;
    public GameObject touchButtonController;

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

        if (isMobile)
        {
            switch (options.controlMode)
            {
                case 0:
                    joystickController.SetActive(true);
                    touchButtonController.SetActive(false);

                    Debug.Log("Controller switch to joystick");
                    break;
                case 1:
                    joystickController.SetActive(false);
                    touchButtonController.SetActive(true);

                    Debug.Log("Controller switch to touch button arrow");
                    break;
                default: Debug.LogError("Switch Controoller value not valid"); break;
            }
        }
    }
}
