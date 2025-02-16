using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeKeeper : MonoBehaviour
{
    public float timer = 10f;
    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void GameOver()
    {
        isGameOver = true;
        Debug.Log ("Kalah! Kamu Cupu.");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime; // kurangin waktu berdasarkan frame per detik

            if (timer <= 0)
            {
                GameOver();
            }
        }
    }
}
