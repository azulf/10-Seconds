using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeKeeper : MonoBehaviour
{
    public float timer = 10f;
    public bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public bool GameOver()
    {
        isGameOver = true;
        Debug.Log ("Kalah! Kamu Cupu.");
        return isGameOver;
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
