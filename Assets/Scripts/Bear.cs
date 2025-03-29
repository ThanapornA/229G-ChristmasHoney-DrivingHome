using UnityEngine;

public class Bear : MonoBehaviour
{
    public int feedCount = 0;


    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("honeyshot"))
        {
            feedCount += 1;
            if ( feedCount >= 1 )
            {
                Destroy(this.gameObject);
            }
        }
    }
}