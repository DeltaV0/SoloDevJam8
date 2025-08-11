using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public SpriteRenderer spr1;

    public Color[] col;

    public Rigidbody2D rb;

    public Transform target;

    public int timer;

    public GameObject parts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rand = Random.Range(0, col.Length);
        spr1.color = col[rand];
        timer = 250;
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
            GameObject bullet = (GameObject)Instantiate(parts, transform.position, transform.rotation);
            Destroy(gameObject);
         }
        Vector2 aimDirection = new Vector2(target.position.x, target.position.y) - rb.position;
        rb.AddForce(aimDirection * 0.025f, ForceMode2D.Impulse);

        transform.Rotate(0, 0, rb.linearVelocity.magnitude);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Wall"))
        {
            GameObject bullet = (GameObject)Instantiate(parts, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Equals("player"))
            {
                GameObject bullet = (GameObject)Instantiate(parts, transform.position, transform.rotation);
                collision.gameObject.GetComponent<Player>().Kill();
                Destroy(gameObject);
            }
    }
}
