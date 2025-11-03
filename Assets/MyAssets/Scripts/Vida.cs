using UnityEngine;

public class Vida : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Player>().MudarVida(1);
            Destroy(gameObject);
        }
    }
}
