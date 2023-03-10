using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    bool hasConcussion;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasConcussion && collision.collider.tag == "Ground" && collision.otherCollider.tag == "Player Head")
        {
            hasConcussion = true;
            Debug.Log("Trainer blacked out..."); // niche Pokémon reference to a trainer running out of usable Pokémon ;)
            SceneManager.LoadScene("SnowRider");
        }
    }
}
