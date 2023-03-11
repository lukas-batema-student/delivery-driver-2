using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float torqueModifier = 0.75f;

    float originalSpeed = 15f;
    [SerializeField] float speedUp = 35f;
    [SerializeField] float slowDown = 5f;

    Rigidbody2D rb2d;
    SurfaceEffector2D effector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        effector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector2D.speed = speedUp;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            effector2D.speed = slowDown;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            effector2D.speed = originalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount * torqueModifier);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
