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

    [Header("Sfx")]
    public AudioSource sfx;
    public AudioClip clip;
    public float audioVolume;

    [Header("level")]
    public GameObject levelTextObj;
    public Level level;

    private LoadOptionInLevel loadOption;
    private Text levelText;

    void Start()
    {
        GameObject gameObject = new GameObject();
        loadOption = gameObject.AddComponent<LoadOptionInLevel>();
        levelText = levelTextObj.GetComponent<Text>();

        levelTextObj.SetActive(false);
        levelText.text = "Level " + LevelManager1.currentEasyLevel.ToString() + " Complete";

        audioVolume = loadOption.volumeSfx / 5;
    }

    public void SaveLevel()
    {
        levelSystem.SaveLevel(level);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            Instantiate(finalParticles, transform.position, Quaternion.Euler(-90, 0, 0));
            CoinT.text = coinManagement.totalCoin.ToString();
            levelTextObj.SetActive(true);
            sfx.volume = audioVolume;
            LevelUpdate();

            sfx.PlayOneShot(clip);

            StartCoroutine(finshAnim());
        }
    }

    private void LevelUpdate()
    {
        if (level.easy == LevelManager1.currentEasyLevel - 1)
        {
            level.easy++;
            SaveLevel();

            if (level.easy == LevelManager1.currentEasyLevel)
                Debug.Log("level up!");

            Debug.Log("Level after finish: " + level.easy.ToString());
        }

        if (level.medium == LevelManager1.currentMediumLevel - 1)
        {
            level.medium++;
            SaveLevel();

            if (level.medium == LevelManager1.currentMediumLevel)
                Debug.Log("level up!");

            Debug.Log("Level after finish: " + level.easy.ToString());
        }

        if (level.hard == LevelManager1.currentHardLevel - 1)
        {
            level.hard++;
            SaveLevel();

            if (level.hard == LevelManager1.currentHardLevel)
                Debug.Log("level up!");

            Debug.Log("Level after finish: " + level.easy.ToString());
        }
    }

    private IEnumerator finshAnim()
    {
        slider.SetTrigger("move");
        yield return new WaitForSeconds(transitionStart);
        Time.timeScale = 0;
    }
}
