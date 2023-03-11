using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayRestart = 25f;
    [SerializeField] ParticleSystem finishEffect;

    bool medleyPlaying;
    bool effectActive;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!medleyPlaying && !effectActive)
            {
                medleyPlaying = true;
                effectActive = true;

                finishEffect.Play();
                GetComponent<AudioSource>().Play(); // Take Back - by Lunified Calling (AKA. Lukas Batema); used as the finish medley.

                Debug.Log("Trainer defeated Bug Catcher Joey!"); // niche Pok�mon reference to a trainer running out of usable Pok�mon ;)
            }

            Invoke("ReloadScene", delayRestart);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
