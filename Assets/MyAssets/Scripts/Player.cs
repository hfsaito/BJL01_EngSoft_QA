using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jump = 100f;
    private int jumpAmount = 2;
    private int maxJumpAmount = 2;

    [SerializeField] protected internal int vidaMaxima = 3;
    [SerializeField] protected internal int vida = 3;
    public UnityEvent OnLifeChanged;
    
    protected internal int moedas = 0;
    public UnityEvent OnCoinCollected;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        OnLifeChanged.AddListener(GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().SetVida);
    }

    void Update()
    {
        UpdateAnimationParameters();
        HandleHorizontalMovement();
        HandleJumping();
    }

    private void UpdateAnimationParameters()
    {
        animator.SetInteger("VelY", Mathf.RoundToInt(rb.linearVelocity.y));
        animator.SetInteger("VelX", Mathf.RoundToInt(rb.linearVelocity.x));
    }

    private void HandleHorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
            if (horizontalInput > 0)
            {
                sr.flipX = true;
            }
            else if (horizontalInput < 0)
            {
                sr.flipX = false;
            }
        }
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) && jumpAmount > 0)
        {
            jumpAmount--;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jump);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        { 
            jumpAmount = maxJumpAmount;
        }
    }

    public void MudarVida(int quantia)
    {
        vida += quantia;
        OnLifeChanged.Invoke();
    }

    public void CollectCoin()
    {
        moedas++;
        OnCoinCollected.Invoke();
    }
}