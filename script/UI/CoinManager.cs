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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            OnGetCoin();
        }
    }

    public void OnGetCoin()
    {
        sfx.volume = audioVolume;
        sfx.PlayOneShot(sound);
        CoinText.coins++;
        coinManagement.totalCoin++;
    }
}
