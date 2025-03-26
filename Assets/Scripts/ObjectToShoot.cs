using UnityEngine;

public class ObjectToShoot : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obs)
    {
        if (obs.gameObject.CompareTag("obstacles"))
        {
            Debug.Log("you hit the obstacle");
            Destroy(this.gameObject);
        }
    }
}
