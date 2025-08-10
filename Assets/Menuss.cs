using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuss : MonoBehaviour
{
    public bool main;

    public int timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       timer = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load(){
        SceneManager.LoadSceneAsync("Dead");
    }

    private void FixedUpdate()
    {
        if(!main){
        if (timer > 0)
        {
            timer--;
        } else {
            SceneManager.LoadSceneAsync("SampleScene");
            timer = 10000;
        }
        }
    }
}
