using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private Camera cam;

    public TextMeshProUGUI obstacleText;

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
                if (hit.collider.CompareTag("obstacles"))
                {
                    obstacleText.text = "this is an obstacle!! Avoid hittig it";
                    Debug.Log("this is an obstacle");
                }
                else if (hit.collider.CompareTag("bear"))
                {
                    obstacleText.text = "these are bears!! Throw collected honey to distract them";
                    Debug.Log("this is a bear");
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