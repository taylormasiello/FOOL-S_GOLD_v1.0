using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator playerAnimator;
    [SerializeField] ParticleSystem runSys;
    [SerializeField] GameObject miningInfoBox;

    Vector2 movement;
    float moveSpeed = 9.75f;

    void Awake()
    {
        runSys.Play();
    }

    void Update()
    {
        CharMovement();
    }

    void FixedUpdate()
    {
        Vector3 playerWorldPos = playerRb.transform.position;

        playerRb.MovePosition(playerRb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (miningInfoBox.activeInHierarchy)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 12;
        }
    }

    void CharMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            FindObjectOfType<AudioManager>().PlaySound("WallBump");
        }

        if(collision.gameObject.tag == "Rocks")
        {
            FindObjectOfType<AudioManager>().PlaySound("RockBump");
        }
    }
}