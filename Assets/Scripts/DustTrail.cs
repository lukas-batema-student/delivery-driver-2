using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustTrailEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Ground" && collision.otherCollider.tag == "Player Body") && !(collision.collider.tag == "Clouds" && collision.otherCollider.tag == "Player Body"))
        {
            Debug.Log("You told your level 100 Bulbasaur to use explosion, but instead it used explosion!"); // niche Pokémon reference to a glitch in Pokémon Green (not Leaf Green) Pokémon ;)

            dustTrailEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
         Debug.Log("Your level 100 Bulbasaur used explosion!"); // niche Pokémon reference to a glitch in Pokémon Green (not Leaf Green) Pokémon ;)

         dustTrailEffect.Stop();
    }
}
