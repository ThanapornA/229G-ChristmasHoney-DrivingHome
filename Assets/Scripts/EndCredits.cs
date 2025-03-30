using UnityEngine;

public class EndCredits : MonoBehaviour
{
    public float scrollSpeed = 10f;

    public void Update()
    {
        gameObject.SetActive(true);
        transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
    }
}
