using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int shotCount = 0;


    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("bullet"))
        {
            shotCount += 1;
            if ( shotCount >= 3 )
            {
                Destroy(this.gameObject);
            }
        }
    }
}
