using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] private float levelLoadDelay = 3f;
    [SerializeField] private float levelExitSlowMoFactor = 0.2f;

    [SerializeField] AudioClip winMusic;

    private bool lockMethod = false;

   
    void OnTriggerEnter2D(Collider2D other)
    {

        if(lockMethod)
        {
            return;
        }

        FindObjectOfType<Player>().DestroyAudioSource();

        AudioSource.PlayClipAtPoint(winMusic, Camera.main.transform.position);

        StartCoroutine(LoadNextLevel());

        lockMethod = true;
        
    }

    IEnumerator LoadNextLevel()
    {

        Time.timeScale = levelExitSlowMoFactor;

        yield return new WaitForSecondsRealtime(levelLoadDelay);

        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
}
