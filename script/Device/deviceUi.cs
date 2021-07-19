using UnityEngine;

public class deviceUi : MonoBehaviour
{
    public GameObject androidCanvas;

    private bool isMobile;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        isMobile = true;
#endif

        androidCanvas.SetActive(isMobile);
    }
}
