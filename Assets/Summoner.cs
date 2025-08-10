using UnityEngine;

public class Summoner : MonoBehaviour
{
    public GameObject boss;

    public GameObject Shockwave;

    public GameObject bosstext;

    public GameObject clickabletext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(new Vector3(0, 0, 0), Player.player.transform.position) < 3f)
        {
            clickabletext.SetActive(true);
            if (Input.GetKeyDown("g"))
            {
                bosstext.SetActive(true);
                Player.player.LaunchAway();
                boss.SetActive(true);
                GameObject bullet2 = (GameObject)Instantiate(Shockwave, transform.position, transform.rotation);
                Destroy(gameObject);
             }
        }
        else
        {
            clickabletext.SetActive(false);
        }
    }
}
