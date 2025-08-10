using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player player;

    public float innacuracy = 1f;

    public GameObject bulletPrefab;

    public ParticleSystem dashparts;

    public AudioSource[] auds;

    public float fireForce = 30f;

    Vector2 moveDir;
    Vector2 mousePos;

    public float moveSpeed = 0.001f;
    public Rigidbody2D rb;

    public int timer;

    public int timer2;

    public Collider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this;
    }

    public void Kill()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        gameObject.SetActive(false);
     }

    public void LaunchAway()
    {
        Vector2 aimDirection = new Vector2(0, 0) - rb.position;
            rb.AddForce(aimDirection.normalized * -250, ForceMode2D.Impulse);
     }
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw ("Horizontal");
		float moveY = Input.GetAxisRaw ("Vertical");
		
		moveDir = new Vector2 (moveX, moveY).normalized;
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        if (Input.GetKeyDown("space"))
        {
            //auds[1].Play();
            Vector2 aimDirection = mousePos - rb.position;
            rb.AddForce(aimDirection * 10, ForceMode2D.Impulse);
            col.enabled = false;
            timer2 = 15;
            dashparts.Play();
        }

        if (Input.GetMouseButton(0) && timer <= 0)
        {
            auds[0].pitch = Random.Range(0.9f, 1.1f);
            auds[0].Play();
            timer = 10;

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

            Vector2 aimDirection = new Vector2(transform.position.x, transform.position.y) - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f + Random.Range(-1f * (innacuracy * 0.5f), (innacuracy * 0.5f));

            bullet.GetComponent<Rigidbody2D>().rotation = aimAngle;


            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce), ForceMode2D.Impulse);
            // bullet.GetComponent<Bullet>().player = true;
            // bullet.GetComponent<Bullet>().damage = damage;
            //bullet.GetComponent<Bullet>().flaming = burningBullets;
            //bullet.GetComponent<Bullet>().enemytype = gameObject;
            //aud[0].pitch = Random.Range(1.9f, 2.1f);
            //aud[0].Play();


        }
    }

    void FixedUpdate()
    {
        Vector2 aimDirection = mousePos - rb.position;

        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
        //rb.velocity = new Vector2 (moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        rb.AddForce(moveDir * moveSpeed, ForceMode2D.Impulse);

        if (timer > 0)
        {
            timer--;
        }
        if (timer2 > 0)
        {
            timer2--;
        }
        else
        {
            col.enabled = true;
         }
        /* if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
             float rot2 = (rb.rotation + (Input.GetKey(KeyCode.W) ? 90f : (Input.GetKey(KeyCode.A) ? 180f : (Input.GetKey(KeyCode.S) ? -90f : 0)))) * Mathf.Deg2Rad;
             rb.AddForce(new Vector2((Mathf.Cos(rot2)) * moveSpeed, (Mathf.Sin(rot2)) * moveSpeed), ForceMode2D.Impulse);
         } *///seqdyhhjhsxjjkelinmsknmn medjmnionjm msm,merddkmnsnnamkjs
    }
}
