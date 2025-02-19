using UnityEngine;
using TMPro; // Jika pakai TextMeshPro

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Gunakan TextMeshPro
    private float timeElapsed = 0f;
    private bool isRunning = true; // Bisa diubah untuk start/pause

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
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer() => isRunning = true;  // Untuk mulai timer
    public void StopTimer() => isRunning = false;  // Untuk menghentikan timer
    public void ResetTimer() { timeElapsed = 0f; UpdateTimerUI(); } // Reset timer
}