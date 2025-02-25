using System.Collections;
using UnityEngine;
using TMPro; // Untuk TextMeshPro

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Cd text
    public GameObject spawnInstruction; // Spawn Instruction
    public GameObject timerCanvas; // Timer config canvas UI
    public GameObject Player; //attack config object
    void Start()
    {
        Player.SetActive(false);
        spawnInstruction.SetActive(false); // Matikan objek game dulu
        timerCanvas.SetActive(false);
        StartCoroutine(StartCountdown()); // start countdown
    }

    IEnumerator StartCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString(); // Ubah teks countdown
            yield return new WaitForSeconds(1f); 
        }

        countdownText.text = "GO!"; // 
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false); // Hilangkan teks countdown
        spawnInstruction.SetActive(true); // 
        timerCanvas.SetActive(true);
        Player.SetActive(true);

    }
}