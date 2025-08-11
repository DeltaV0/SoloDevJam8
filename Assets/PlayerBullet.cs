using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag.Equals("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().health -= 1;
                collision.gameObject.GetComponent<Enemy>().hitparts.Play();
				//collision.gameObject.GetComponent<Enemy>().hurt.Play();
                Destroy(gameObject);
            }
    }
}
