using UnityEngine;

public class FancyBeamAttack : MonoBehaviour
{
    public bool Detecting;

    public SpriteRenderer spr1;

    public SpriteRenderer spr2;

    public Color[] col;

    public Color[] colwarn;

    public Transform emitter;

    public Transform Beampos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rand = Random.Range(0, col.Length);
        spr1.color = col[rand];
        spr2.color = colwarn[rand];
    }

    // Update is called once per frame
    void Update()
    {
        if (emitter != null)
        {
            transform.position = emitter.position;
            transform.rotation = emitter.rotation;
        }
    }

    private void FixedUpdate()
    {
        if (Detecting)
        {
            DetectPlayer();
        }
    }

    void DetectPlayer()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
        Collider2D[] col = Physics2D.OverlapBoxAll(Beampos.position, new Vector2(1000, 0.5f), transform.rotation.eulerAngles.z);

        foreach (Collider2D c in col)
        {
            Debug.Log(c.gameObject.name);

            if (c.gameObject.name.Equals("player"))
            {
                c.gameObject.GetComponent<Player>().Kill();
                break;
            }
        }
    }
    
    public void Dest()
    {
        Destroy(gameObject);
    }
}
