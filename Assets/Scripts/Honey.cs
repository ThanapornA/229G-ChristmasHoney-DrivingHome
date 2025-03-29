using UnityEngine;

public class Honey : MonoBehaviour
{
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.CompareTag("bear") )
        {
            Destroy(other.gameObject);
        }
    }
}
