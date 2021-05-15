using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePersists : MonoBehaviour
{
    private int startingSceneIndex;

    private void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersists>().Length;
        if(numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
