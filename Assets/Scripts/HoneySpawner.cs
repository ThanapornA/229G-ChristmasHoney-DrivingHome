using UnityEngine;

public class HoneySpawner : MonoBehaviour
{
    public GameObject Honey;
    public Transform[] HoneySpawnPoints;
    public PlayerController playerController;

    public int honeySpawned = 0;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 3);
    }

    void Spawn()
    {
        if ( honeySpawned <= 2 )
        {
            Debug.Log("honey spawned");
            int rndPos = Random.Range(0 , 3);
            Instantiate( Honey , HoneySpawnPoints[rndPos].position , Honey.transform.rotation );
            honeySpawned += 1;
        }
    }
}