using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadStartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
