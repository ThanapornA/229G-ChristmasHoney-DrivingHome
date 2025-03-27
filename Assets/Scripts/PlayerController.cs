using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private Rigidbody rb;
    public Transform spawner;
    public GameObject bullet;
    public GameObject honey;
    public RawImage[] Heart;

    public HoneySpawner honeySpawner;

    public int speed;
    public int turnSpeed = 100;

    public int Health = 5;

    public int HoneyCollected = 0;
    public bool isHoneyCollected = false;

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
            Debug.Log("bullet spawned");
            Instantiate(bullet, spawner.transform.position , Quaternion.identity );
        }
/*
        if ( Health == 0 )
        {

        }*/
        /*
        if ( HoneyCollected >= 1 )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("honey thrown");
                Instantiate( honey , spawner.transform.position , Quaternion.identity );
            }
        }*/
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacles"))
        {
            Health -= 1;
            Debug.Log("you hit" + Health);

            Destroy(Heart[Health]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("honey"))
        {
            Debug.Log("you collected" + HoneyCollected);
            HoneyCollected += 1;
            honeySpawner.honeySpawned -= 1;

            isHoneyCollected = true;
            //Destroy();
        }
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
