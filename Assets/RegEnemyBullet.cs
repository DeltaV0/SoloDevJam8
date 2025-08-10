using UnityEngine;

public class RegEnemyBullet : MonoBehaviour
{
    public SpriteRenderer spr1;

    public Color[] col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rand = Random.Range(0, col.Length);
        spr1.color = col[rand];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Equals("player"))
            {
                collision.gameObject.GetComponent<Player>().Kill();
                Destroy(gameObject);
            }
    }
}
