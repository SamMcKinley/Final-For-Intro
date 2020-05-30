using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GroundDetection ground;
    private Rigidbody2D rb2d;
    private Transform tf;
    private SpriteRenderer sr;
    private Animator animator;

    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value > MaxHealth)
            {
                this.currentHealth = MaxHealth;
            }
            else
            {
                this.currentHealth = value;
            }
            if (value <= 0)
            {
                Debug.Log("You Died!");
            }
        }
    }
    private int MaxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        if (xMovement > 0)
        {
            sr.flipX = false;
            animator.Play("PlayerWalk");
        }
        else if (xMovement < 0)
        {
            sr.flipX = true;
            animator.Play("PlayerWalk");
        }
        else
        {
            animator.Play("PlayerIdle");
        }
        //Detect if player is on the ground

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && ground.isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            Debug.Log("Jump");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    
}


