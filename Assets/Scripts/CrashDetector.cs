using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public GameObject blackOutSquare;

    [SerializeField] float delayRestart = 20f;
    [SerializeField] ParticleSystem blackOutEffect;
    [SerializeField] AudioClip crashMedley;

    bool medleyPlaying;
    bool effectActive;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Ground" && collision.otherCollider.tag == "Player Head") && !(collision.collider.tag == "Clouds" && collision.otherCollider.tag == "Player Head"))
        {
            if (!medleyPlaying && !effectActive)
            {
                medleyPlaying = true;
                effectActive = true;

                blackOutEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashMedley); // Smoothie - by Lunified Calling (AKA. Lukas Batema); used as the crash medley.

                Debug.Log("Trainer blacked out..."); // niche Pokémon reference to a trainer running out of usable Pokémon ;)

                StartCoroutine(FadeBlackOutSquare());
            }

            Invoke("ReloadScene", delayRestart);
            StartCoroutine(FadeBlackOutSquare(false));
        }
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = 0.125f)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}