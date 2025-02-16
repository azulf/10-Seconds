using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string gameSceneName = "GameScene"; // Ganti dengan nama scene game kamu

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
