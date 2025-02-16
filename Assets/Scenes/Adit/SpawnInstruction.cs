using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class SpawnInstruction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public KeyCode[] InputKeys = {KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow};
    public GameObject[] arrowPrefabs; 
    public List<GameObject> activeArrows = new List<GameObject>();
    public List<KeyCode> activeInput = new List<KeyCode>();
    public Transform spawnPoint;
    public Transform targetPoint;

    public TimeKeeper timeKeeper;
    public float spacing = 1.5f;
    public bool isSpawned = false;
    public int noInstruct = 0;
    public Attacking attacking;

    void Start()
    {
        StartCoroutine(SpawnArrows());
        attacking = GameObject.Find("Player").GetComponent<Attacking>();
        timeKeeper = GameObject.Find("Time").GetComponent<TimeKeeper>();
    }

    void Update()
    {
        if (timeKeeper.isGameOver == true)
        {
            Debug.Log(attacking.score);
        }
        else { attacking.checkInput(); };
       
    }

    IEnumerator SpawnArrows()
    {
        while (true)
        {
            yield return new WaitForSeconds(0f);
                if (isSpawned != true)
                {
                    for (int i = 0 ; i < 4 ; i++)
                    {
                        Vector3 spawnPos = spawnPoint.position + new Vector3(i * spacing, 0 , 0 ); // nentuin posisi spawn pake posisi spacing
                        int randomIndex = Random.Range(0, arrowPrefabs.Length);
                        KeyCode inputArrows = InputKeys[randomIndex];
                        GameObject arrow = Instantiate(arrowPrefabs[randomIndex], spawnPos, Quaternion.identity);
                        activeArrows.Add(arrow);
                        activeInput.Add(inputArrows);
                        Debug.Log(inputArrows);
                    }
                    isSpawned = true;
                }
        }
    }

}
      

        
    




