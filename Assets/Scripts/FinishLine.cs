using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    bool hasWon;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasWon)
        {
            hasWon = true;
            Debug.Log("Trainer defeated Bug Catcher Joey!");
            SceneManager.LoadScene("SnowRider");
        }
    }
}
