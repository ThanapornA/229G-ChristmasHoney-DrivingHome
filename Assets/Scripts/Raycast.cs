using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position , mousePos - transform.position , Color.blue);
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,100))
            {
                Debug.Log("eyyyyykoinnit!");

                if (hit.collider.CompareTag("obstacles"))
                {
                    Debug.Log("this is an obstacle");
                }
                else if (hit.collider.CompareTag("bear"))
                {
                    Debug.Log("this is an bear");
                }
            }
        }
    }
}

/*







if ( hit.collider.name == "Enemy" )
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
 
                    if ( enemy != null )
                    {
                        enemy.TakeDamage( 1 );
                    }
                }










*/