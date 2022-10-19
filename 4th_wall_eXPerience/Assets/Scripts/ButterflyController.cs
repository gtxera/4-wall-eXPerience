using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    [SerializeField] Transform dropPoint;
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerController playerController;
    [SerializeField] Rigidbody2D rb;
    private float speed = 3f;
    private Vector2 direction;
    private Vector2 positionToMove;
    private bool hasPlayer;
    void Start()
    {
        
    }

    void Update()
    {
        positionToMove = hasPlayer ?  dropPoint.position : playerTransform.position;

        direction = (positionToMove - (Vector2)transform.position).normalized;

        if (hasPlayer)
        {
            playerTransform.position = transform.position;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            playerController.DisablePlayerMovement();
            hasPlayer = true;
        }

        if (collision.tag == "DropPoint")
        {
            playerController.EnablePlayerMovement();
            Destroy(gameObject);
        }
    }
}
