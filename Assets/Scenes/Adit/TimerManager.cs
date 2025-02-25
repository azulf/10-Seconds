using UnityEngine;
using TMPro; // Jika pakai TextMeshPro

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Gunakan TextMeshPro
    private float timeElapsed = 0f;
    public bool isRunning = true; // Bisa diubah untuk start/pause
    public bool isGameOver = false;

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime; // Hitung waktu
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("Timer: {0:00}",  seconds);
        if (seconds >= 10)
        {
            StopTimer();
            GameOver();
        }
    }

    public void StartTimer() => isRunning = true;  // Untuk mulai timer
    public void StopTimer() => isRunning = false;  // Untuk menghentikan timer
    public void ResetTimer() { timeElapsed = 0f; UpdateTimerUI(); } // Reset timer

    public bool GameOver()
    {
        isGameOver = true;
        Debug.Log ("Kalah! Kamu Cupu.");
        return isGameOver;
    }
}