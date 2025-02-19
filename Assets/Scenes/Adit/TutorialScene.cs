using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string gameSceneName = "TutorialScene"; // Ganti dengan nama scene game kamu

    public void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
}
