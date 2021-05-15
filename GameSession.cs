using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Text liveText;
    [SerializeField] Text scoreText;


    private void Awake()
    {
        int numGameSesions = FindObjectsOfType<GameSession>().Length;
        if(numGameSesions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        
        liveText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

   
    public void AddToScore (int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
       
        if (playerLives > 1)
        {
            StartCoroutine(TakeLifeCoroutine());
        }
        else
        {
            ResetGameSession();
        }
    }

    IEnumerator TakeLifeCoroutine()
    {
      
        yield return new WaitForSecondsRealtime(5f);

        TakeLife();
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        liveText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
