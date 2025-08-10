using UnityEngine;

public class CamMover : MonoBehaviour
{
    public Transform trans;

    public Transform trans2;

    public Camera cam;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(new Vector3(trans.position.x, trans.position.y, transform.position.z), new Vector3(trans2.position.x, trans2.position.y, transform.position.z), 0.5f), 0.1f);
        
        if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(trans2.position.x, trans2.position.y)) > 5){
				cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(trans2.position.x, trans2.position.y)) + 2f, 0.04f);
			} else {
				cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6f, 0.04f);;
			}
    }
}
