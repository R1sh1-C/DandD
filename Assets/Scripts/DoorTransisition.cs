using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    public string sceneToLoad;
    public string spawnPointName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("SpawnPoint", spawnPointName);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}