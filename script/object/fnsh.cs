using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fnsh : MonoBehaviour
{
    [Header("Animator")]
    public Animator slider;
    public float transitionStart = 1f;

    [Header("Particles")]
    public ParticleSystem finalParticles;

    [Header("Coin")]
    public Text CoinT;
    public float coinTime;
    public Text lvlt;

    [Header("Sfx")]
    public AudioSource sfx;
    public AudioClip clip;

    public float audioVolume;

    LoadOptionInLevel loadOption;

    void Start()
    {
        GameObject gameObject = new GameObject();
        loadOption = gameObject.AddComponent<LoadOptionInLevel>();

        audioVolume = loadOption.volumeSfx / 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            Instantiate(finalParticles, transform.position, Quaternion.Euler(-90, 0, 0));
            CoinT.text = coinManagement.totalCoin.ToString();
            sfx.volume = audioVolume;
            lvlt.text = level.easy.ToString();
            level.easy++;

            sfx.PlayOneShot(clip);

            StartCoroutine(finshAnim());
        }
    }

    IEnumerator finshAnim()
    {
        slider.SetTrigger("move");
        yield return new WaitForSeconds(transitionStart);
        Time.timeScale = 0;
    }
}
