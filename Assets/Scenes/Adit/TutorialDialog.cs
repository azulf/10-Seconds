using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // Drag Text UI ke sini
    public GameObject panel;  // Drag Panel ke sini
    public float textSpeed = 0.05f;
    private string[] sentences;
    private int index = 0;
    private bool isDialogActive = false;
    private bool isTyping = false;

    void Start()
    {
        panel.SetActive(false);  // Sembunyikan panel saat mulai
        
        
        sentences = new string[]
        {
            "Halo! Selamat datang di petualangan ini.",
            "Ikuti tanda panah yang ditunjukkan dengan menggunakan arrow pada keyboard.",
            "Raih skor sebanyak banyaknya (Semangat !)."
        };
        ShowDialog();
        StartCoroutine(TypeSentence());
        
    }

    void Update()
    {
        if (isDialogActive && Input.GetMouseButtonDown(0))
        {
            if (isTyping == false)
            {
                isTyping = true;
                NextSentence();
            }
            else {
                isTyping = false;
                dialogText.text = sentences[index];
            }
            
            
        }
        
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char letter in sentences[index])
        {
            if (!isTyping == true)break;
            dialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    public void ShowDialog()
    {
        panel.SetActive(true);
        index = 0;
        isDialogActive = true;
        dialogText.text = sentences[index];
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence());
        }
        else 
        {
            panel.SetActive(false);
            isDialogActive = false;
        }
    }
}
