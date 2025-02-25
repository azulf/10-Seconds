using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // Drag Text UI ke sini
    public TextMeshProUGUI dialogText2; // Drag Text UI Timer ke sini
    public GameObject panel;  // Drag Panel ke sini

    public GameObject panelTimer; // Drag Panel Timer ke sini
    public GameObject panelArrow; // Drag Panel Arrow ke sini
    public float textSpeed = 0.05f;
    public int indexDialog = 0;
    private string[] sentences;
    private string[] timersentences;
    private int index = 0;
    private bool isDialogActive = false;
    private bool isTyping = false;
    private TextDialog textList;
    private SpawnInstruction spawnInstructionScript;
    [SerializeField] private TimerManager TimerController;
    [SerializeField] private GameObject SpawnInstruction;



    void Start()
    {
        spawnInstructionScript = SpawnInstruction.GetComponent<SpawnInstruction>();
        TimerController.StopTimer();
        panel.SetActive(false);  // Sembunyikan panel saat mulai
        textList = GetComponent<TextDialog>();
        sentences = textList.Dialog;
        ShowDialog();
        StartCoroutine(TypeSentence());
    }

    void Update()
    {
        switch(indexDialog)
        {
            case 0 : // Tutorial Dialog
                panelPindah();
            break;
               
            case 1 : // Tutorial Timer
                panelPindah();
                TimerController.StartTimer();
                panel.transform.position = panelTimer.transform.position;
            break;

            case 2 : // Tutorial Arrow
                panelPindah();
                spawnInstructionScript.enabled=true;
                TimerController.StopTimer();
                panel.transform.position = panelArrow.transform.position;
            break;
            
        }
        if (isDialogActive && Input.GetMouseButtonDown(0))
        {
            Debug.Log(index);
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
        if (index < sentences.Length - 1 )
        {
            index++;
            StartCoroutine(TypeSentence());
        }
        else 
        {
            panel.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }

    public void panelPindah()
    {
        if (index > 2 && index < 5 )
        {
            indexDialog = 1;
        }
        if (index >= 5)
        {
            indexDialog = 2;
        }
        
    }
}
