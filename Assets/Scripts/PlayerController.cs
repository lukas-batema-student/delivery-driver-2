using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float torqueModifier = 0.75f;

    float originalSpeed = 15f;
    float finalSpeed = 0f;
    [SerializeField] float speedUp = 35f;
    [SerializeField] float slowDown = 5f;

    Rigidbody2D rb2d;
    SurfaceEffector2D effector2D;

    bool fatesCollided;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Ground" && collision.otherCollider.tag == "Player Head") && !(collision.collider.tag == "Clouds" && collision.otherCollider.tag == "Player Head"))
        {
            fatesCollided = true;
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !fatesCollided)
        {
            effector2D.speed = speedUp;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !fatesCollided)
        {
            effector2D.speed = slowDown;
        }
        else if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) && !fatesCollided)
        {
            effector2D.speed = originalSpeed;
        }
        else if (fatesCollided)
        {
            effector2D.speed = finalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !fatesCollided)
        {
            rb2d.AddTorque(torqueAmount * torqueModifier);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !fatesCollided)
        {
            rb2d.AddTorque(-torqueAmount);
        }
        else if (fatesCollided)
        {
            rb2d.AddTorque(0f);
         }
    }
}
