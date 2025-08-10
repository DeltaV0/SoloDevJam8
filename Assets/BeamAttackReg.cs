using UnityEngine;

public class BeamAttackReg : MonoBehaviour
{
    public SpriteRenderer spr1;

    public SpriteRenderer spr2;

    public Color[] col;

    public Color[] colwarn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rand = Random.Range(0, col.Length);
        spr1.color = col[rand];
        spr2.color = colwarn[rand];
    }
    void DetectPlayer()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
        Collider2D[] col = Physics2D.OverlapBoxAll(transform.position, new Vector2(1000, 0.5f), transform.rotation.eulerAngles.z);

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
