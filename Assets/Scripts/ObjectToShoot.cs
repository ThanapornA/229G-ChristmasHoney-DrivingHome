using UnityEngine;

public class ObjectToShoot : MonoBehaviour
{
    public int shootedCount = 0;
    public float speed;
    public Rigidbody rb;

    public bool isThisHoney = true;

    void Start()
    {
        
    }

    void Update()
    {
        rb.AddForce(Vector3.forward * speed);
    }

    void OnTriggerEnter(Collider obs)
    {
        if ( !isThisHoney )
        {
            if (obs.gameObject.CompareTag("obstacles"))
            {
                Debug.Log("you hit an obstacle");
                Destroy(this.gameObject);
            }
        }
        else if ( isThisHoney )
        {
            if (obs.gameObject.CompareTag("bear"))
            {
                Debug.Log("you hit a bear");
                Destroy(this.gameObject);
            }
        }
    }
}
