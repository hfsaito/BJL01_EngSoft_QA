using UnityEngine;

public class Inimigo : MonoBehaviour
{
    protected SpriteRenderer sr;
    
    [SerializeField] private int dano = 1;
    [SerializeField] protected float velocidade = 10f;
    protected int modifier = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * new Vector2(velocidade * modifier * Time.deltaTime, 0f));
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * modifier, 0.5f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            sr.flipX = !sr.flipX;
            modifier *= -1;
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector3 entryDir = collision.transform.position - transform.position;
            entryDir.Normalize();
            if (entryDir.y < 0.5f)
            {
                collision.transform.GetComponent<Player>().MudarVida(-dano);
            }
        }
    }
}
