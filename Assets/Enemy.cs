using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health;
    public Image HealthBar;

    public GameObject beam;
    public GameObject missile;

    public GameObject shot;

    public GameObject LongBeam;

    public GameObject LongBeam2;

    public GameObject bonk;

    public Transform[] emitters;

    public int attackTimer;

    public Transform[] fancy;

    public AudioSource[] aud;

    public bool doing;

    public ParticleSystem hitparts;

    public int movetarget;

    public Vector3 MoveTargetPosRand;

    public Rigidbody2D rb;

    public int moveTimer;
    //public int maxtimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movetarget = 1;
        moveTimer = 250;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            SceneManager.LoadScene("win");
        }
        HealthBar.fillAmount = (float)((float)health / 250);

        if (attackTimer <= 0 && !doing)
        {
            doing = true;
            attackTimer = (int)(( (float)((float)health / 250) * 175f) + 25f);
            int q = Random.Range(0, 8);
            if(q == 0 || q == 7){
                SkipTurn();
            } else if(q == 1){
                doing = false;
                RandomAttack();
            } else if(q == 2){
                StartCoroutine(Combo0());
            } else if(q == 3){
                StartCoroutine(Combo1());
            } else if(q == 4){
                StartCoroutine(Combo2());
            } else if(q == 5){
                StartCoroutine(Combo3());
            } else if(q == 6){
                StartCoroutine(Combo4());
            }

            
             
        }

        if(moveTimer <= 0){
            moveTimer = 250;
            MoveTargetPosRand = new Vector2(Random.Range(-25f, 25f), Random.Range(-25f, 25f));
            movetarget = Random.Range(0, 5);
        }
    }

    public void SkipTurn(){
        doing = false;
        //do literally nothing and reset the timer
    }

    public void RandomAttack(){
        int r = Random.Range(0, 13);
        ChosenAttack(r);
    }

    public void ChosenAttack(int r){
            if (r == 0)
            {
                StartCoroutine(attack0());
            }
            else if (r == 1)
            {
                StartCoroutine(attack1());
            } else if (r == 2)
            {
                StartCoroutine(attack2());
             } else if (r == 3)
            {
                StartCoroutine(attack3());
             } else if (r == 4)
            {
                StartCoroutine(attack4());
             } else if (r == 5)
            {
                StartCoroutine(attack5());
             } else if (r == 6)
            {
                StartCoroutine(attack6());
             } else if (r == 7)
            {
                StartCoroutine(attack7());
             } else if (r == 8)
            {
                StartCoroutine(attack8());
             } else if (r == 9)
            {
                StartCoroutine(attack9());
             } else if (r == 10)
            {
                StartCoroutine(attack10());
             } else if (r == 11)
            {
                StartCoroutine(attack11());
             } else if (r == 12)
            {
                StartCoroutine(attack12());
             }
    }

    IEnumerator Combo0(){
        ChosenAttack(0);
        yield return new WaitForSeconds(2f);
        ChosenAttack(0);
        ChosenAttack(4);
        doing = false;
        yield return new WaitForSeconds(0f);
    }

    IEnumerator Combo1(){
        RandomAttack();
        yield return new WaitForSeconds(0.25f);
        RandomAttack();
        yield return new WaitForSeconds(1f);
        RandomAttack();
        doing = false;
        yield return new WaitForSeconds(0f);
    }

    IEnumerator Combo2(){
        ChosenAttack(5);
        yield return new WaitForSeconds(1f);
        ChosenAttack(5);
        doing = false;
        yield return new WaitForSeconds(0f);
    }

    IEnumerator Combo3(){
        ChosenAttack(1);
        //yield return new WaitForSeconds(1f);
        ChosenAttack(2);
        doing = false;
        yield return new WaitForSeconds(0f);
    }

    IEnumerator Combo4(){
        ChosenAttack(6);
        
        ChosenAttack(7);
        doing = false;
        yield return new WaitForSeconds(0f);
    }

    IEnumerator attack0()
    { //3 beams at player 3 times
        for (int i = 0; i < 3; i++)
        {
            for (int a = 0; a < 3; a++)
            {
                GameObject bullet = (GameObject)Instantiate(beam, Player.player.transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.5f);
        }
     }

    IEnumerator attack1()
    { //grid
        Vector3 pos = Player.player.transform.position;
        for (int a = 0; a < 10; a++)
        {
            GameObject bullet = (GameObject)Instantiate(beam, new Vector3(pos.x, pos.y + (a * 4) - 20, pos.z), Quaternion.Euler(0f, 0f, 0));
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);
        for (int a = 0; a < 10; a++)
        {
            GameObject bullet = (GameObject)Instantiate(beam, new Vector3(pos.x  + (a * 4) - 20, pos.y, pos.z), Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(0.05f);
        }
     }
     IEnumerator attack2()
    { //grid2
        Vector3 pos = Player.player.transform.position;
        for (int a = 0; a < 10; a++)
        {
            GameObject bullet = (GameObject)Instantiate(beam, new Vector3(pos.x, pos.y + (a * 4) - 20, pos.z), Quaternion.Euler(0f, 0f, 45f));
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);
        for (int a = 0; a < 10; a++)
        {
            GameObject bullet = (GameObject)Instantiate(beam, new Vector3(pos.x  + (a * 4) - 20, pos.y, pos.z), Quaternion.Euler(0f, 0f, 45f + 90f));
            yield return new WaitForSeconds(0.05f);
        }
     }

     IEnumerator attack3()
    { //cross
        //Vector3 pos = Player.player.transform.position;
        for (int a = 0; a < 4; a++)
        {
            GameObject bullet = (GameObject)Instantiate(beam, transform.position, Quaternion.Euler(0f, 0f, a * 45f));
            yield return new WaitForSeconds(0.05f);
        }
     } 

     IEnumerator attack4()
    { //cross
      //Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 4; i++)
        {
            for (int a = 0; a < 2; a++)
            {
                GameObject bullet = (GameObject)Instantiate(beam, transform.position, Quaternion.Euler(0f, 0f, (a * 90f) + (i * 22.5f)));

            }
            yield return new WaitForSeconds(0.25f);
        }
     }
     IEnumerator attack5()
    { //launch missiles
      //Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = (GameObject)Instantiate(missile, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
            float ar = Random.Range(0f, 360f);
            //bullet.GetComponent<Rigidbody2D>().rotation = aimAngle;
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((ar + 90f) * Mathf.Deg2Rad) * 15f, Mathf.Sin((ar + 90f) * Mathf.Deg2Rad) * 15f), ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.1f);
        }
     }

    IEnumerator attack6()
    { //bulletcircle
      //Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 36; i++)
        {
            aud[0].Play();
            GameObject bullet = (GameObject)Instantiate(shot, transform.position, Quaternion.Euler(0f, 0f, (i * 10f)));
            bullet.GetComponent<Rigidbody2D>().rotation = (i * 10f);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * 5f, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * 5f), ForceMode2D.Impulse);
            
            yield return new WaitForSeconds(0.1f);
        }
     }

    IEnumerator attack7()
    { //bulletcircle
      //Vector3 pos = Player.player.transform.position;
        for (int a = 0; a < 4; a++)
        {
            aud[0].Play();
            for (int i = 0; i < 36; i++)
            {

                GameObject bullet = (GameObject)Instantiate(shot, transform.position, Quaternion.Euler(0f, 0f, (i * 10f) + (a * 2.5f)));
                bullet.GetComponent<Rigidbody2D>().rotation = (i * 10f) + (a * 2.5f);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * 5f, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * 5f), ForceMode2D.Impulse);


            }
            yield return new WaitForSeconds(0.25f);
        }
    }
    IEnumerator attack8()
    { //cross
      Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 25; i++)
        {
            GameObject bullet = (GameObject)Instantiate(beam, new Vector3(pos.x + Random.Range(-15f, 15f), pos.y + Random.Range(-15f, 15f), pos.z), Quaternion.Euler(0f, 0f, Random.Range(0, 360f)));
            yield return new WaitForSeconds(0.1f);
        }
     }

     IEnumerator attack9()
    { //rotate
      //Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = (GameObject)Instantiate(LongBeam, transform.position, transform.rotation);
            bullet.GetComponent<FancyBeamAttack>().emitter = emitters[i];
            yield return new WaitForSeconds(0.1f);
        }
     }

    IEnumerator attack10()
    { //cross
      Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = (GameObject)Instantiate(LongBeam2, new Vector3(pos.x + Random.Range(-10f, 10f), pos.y + Random.Range(-10f, 10f), pos.z), Quaternion.Euler(0f, 0f, Random.Range(0, 360f)));
            yield return new WaitForSeconds(0.5f);
        }
     }

     IEnumerator attack11()
    { //bonk
      Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 5; i++)
        {
            GameObject bullet = (GameObject)Instantiate(bonk, new Vector3(pos.x + Random.Range(-10f, 10f), pos.y + Random.Range(-10f, 10f), pos.z), Quaternion.Euler(0f, 0f, Random.Range(0, 360f)));
            yield return new WaitForSeconds(0.5f);
        }
     }
     IEnumerator attack12()
    { //cross
      Vector3 pos = Player.player.transform.position;
        for (int i = 0; i < 5; i++)
        {
            pos = Player.player.transform.position;
            GameObject bullet = (GameObject)Instantiate(beam, new Vector3(pos.x + Random.Range(-1f, 1f), pos.y + Random.Range(-1f, 1f), pos.z), Quaternion.Euler(0f, 0f, i * 36));
            yield return new WaitForSeconds(0.025f);
        }
     }
    
    private void FixedUpdate()
    {
        fancy[0].Rotate(0.2f, 0f, 0.5f * rb.linearVelocity.magnitude);
        fancy[1].Rotate(0.3f, -0.1f, 0.1f * rb.linearVelocity.magnitude);
        fancy[2].Rotate(0, 0, (0.1f * rb.linearVelocity.magnitude) + 1f);
        fancy[3].Rotate(3.15f, 4.211f, 5.82f);
        if (attackTimer > 0)
        {
            attackTimer--;
        }

        if (moveTimer > 0)
        {
            moveTimer--;
        }

        if(movetarget == 1){
            Vector2 aimDirection = new Vector2(-1f * Player.player.transform.position.x, -1f * Player.player.transform.position.y) - rb.position;
            rb.AddForce(aimDirection * 1f, ForceMode2D.Impulse);
        } else if(movetarget == 2){
            Vector2 aimDirection = new Vector2(MoveTargetPosRand.x, MoveTargetPosRand.y) - rb.position;
            rb.AddForce(aimDirection * 1f, ForceMode2D.Impulse);
        } else if(movetarget == 3){
            Vector2 aimDirection = new Vector2(Player.player.transform.position.x, Player.player.transform.position.y) - rb.position;
            rb.AddForce(aimDirection * 3f, ForceMode2D.Impulse);
        } else if(movetarget == 4){
            Vector2 aimDirection = new Vector2(0, 0) - rb.position;
            rb.AddForce(aimDirection * 2f, ForceMode2D.Impulse);
        }
    }
}
