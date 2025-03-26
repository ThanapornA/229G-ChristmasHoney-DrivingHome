using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private Rigidbody rb;
    public Transform spawner;
    public GameObject bullet;

    public int speed;
    public int turnSpeed = 100;

    public int Health = 5;
    public int HoneyCollected = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        float horiAction = moveAction.ReadValue<Vector2>().x;
        float verticalAction = moveAction.ReadValue<Vector2>().y;
        rb.AddForce( verticalAction * transform.right * speed , ForceMode.Force);
        
        if (horiAction!= 0)
        {
            transform.Rotate( Vector3.up , horiAction * turnSpeed * Time.deltaTime);
        }
        
        if (Input.GetMouseButtonDown(0)) //note : 0 = Left , 1 = Right , 2 = Middle
        {
            Debug.Log("you clicked");
            Instantiate(bullet, spawner.transform.position , Quaternion.identity );
        }
/*
        if ( Health == 0 )
        {

        }*/
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacles"))
        {
            Health -= 1;
            Debug.Log("you hit" + Health);
        }

        /*if (collision.gameObject.CompareTag("honey"))
        {
            HoneyCollected += 1;
        }*/
    }
/*
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("trigger"))
        {
            Debug.Log("you triggered");
        }
    }*/
}
