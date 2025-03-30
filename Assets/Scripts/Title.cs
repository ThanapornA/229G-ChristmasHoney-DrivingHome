using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
