using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public SpriteRenderer spr1;

    public Color[] col;

    public Rigidbody2D rb;

    public Transform target;

    public int timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rand = Random.Range(0, col.Length);
        spr1.color = col[rand];
        timer = 500;
        target = Player.player.transform;
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer--;
        }
        else
        {
            Destroy(gameObject);
         }
        Vector2 aimDirection = new Vector2(target.position.x, target.position.y) - rb.position;
        rb.AddForce(aimDirection * 0.05f, ForceMode2D.Impulse);

        transform.Rotate(0, 0, rb.linearVelocity.magnitude);
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
