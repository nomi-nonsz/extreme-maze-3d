using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class rickRoll : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject rickRollObject;
    public VideoPlayer video;

    private Rigidbody rb;

    private void Start()
    {
        rb = playerObject.GetComponent<Rigidbody>();

        video.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            setTimeOut.timerActive = false;

            rb.AddForce(Vector3.zero);
            rickRollObject.SetActive(true);
            playerObject.SetActive(false);

            StartCoroutine(playRickRoll());
        }
    }

    private IEnumerator playRickRoll()
    {
        video.Play();
        yield return new WaitForSeconds(60);

        Debug.Log("Quit");
        Application.Quit();
    }
}
