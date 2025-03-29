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
    public RawImage[] HoneyIcon;

    public HoneySpawner honeySpawner;
    public GameObject honeyToShoot;

    public int speed;
    public int turnSpeed = 100;

    public int Health = 5;
    public int HoneyIconActivated = 0;

    public int HoneyCollected = 0;
    public bool isHoneyCollected = false;
    public float force;
    public float mass;
    public float acceleration;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass  = GetComponent<Rigidbody>().mass;

        acceleration = this.rb.linearVelocity.magnitude; //note : magnitude = convert vector3 to one value

        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Newton2();
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
        
        if ( HoneyCollected >= 1 )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("honey thrown");
                Instantiate( honeyToShoot , spawner.transform.position , Quaternion.identity );
                HoneyCollected -= 1;
                Destroy(HoneyIcon[HoneyCollected]);
            }
        }

        /*
        if ( Health == 0 )
        {

        }*/
    }

    void Newton2()
    {
        force = mass * acceleration;
        force = speed;
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
            Destroy(other.gameObject);

            HoneyIcon[HoneyIconActivated].gameObject.SetActive(true);
            HoneyIconActivated += 1;
        }
    }
}
