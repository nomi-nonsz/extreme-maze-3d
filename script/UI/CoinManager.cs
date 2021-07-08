using UnityEngine;
using UnityEngine.Audio;

public class CoinManager : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip sound;

    LoadOptionInLevel loadOption;

    public float audioVolume;

    void OnEnable()
    {
        GameObject gameObject = new GameObject();

        loadOption = gameObject.AddComponent<LoadOptionInLevel>();

        audioVolume = loadOption.volumeSfx / 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "coin")
        {
            sfx.volume = audioVolume;
            sfx.PlayOneShot(sound);
            CoinText.coins++;
            coinManagement.totalCoin++;
        }
    }
}
