using JetBrains.Annotations;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
    }

    void Update()
    {
        // DestroyArrows();
        attacking.checkInput();
    }

    IEnumerator SpawnArrows()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
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

    void DestroyArrows()
    {
        for (int i = activeArrows.Count - 1; i >= 0; i--)
        {
            if (activeArrows[i] != null)
            {   
                if (timeKeeper.timer < 0f)
                {
                    Destroy(activeArrows[i]);
                    activeArrows.RemoveAt(i);
                }
            }
        }
    }

    // void CheckInput()
    // {
    //     if (activeArrows.Count > 0 )
    //     {
    //         foreach(KeyCode key in InputKeys)
    //         {
    //             if (Input.GetKeyDown(key))
    //             {
    //                 GameObject closestArrow = activeArrows[0];
    //                 Destroy(closestArrow);
    //                 activeArrows.RemoveAt(0);
    //                 Debug.Log("Hit!");
    //             }
    //         }
    //     }
    // }
}

    // private void timeSpawn() // ini belum di refactor jadi maklumin 
    // {
    //     float elapsedTime = timeKeeper.timer;
    //     float interval = 3f; 
    //     if (timeKeeper != null)
    //     { 
    //         if (elapsedTime - timeKeeper.timer < interval && isSpawned == false) // Challenge 1
    //         {
    //             Spawn();
    //             isSpawned = true;
    //             noInstruct++;
    //         }
    //     }
    // }

    // public void Spawn()
    // {
    //     if (objectToSpawn.Length < 4) return;

    //     for (int i = 0; i < 4; i ++) // ulang sebanyak objek yang ditentukan
    //     {
    //         Vector3 spawnPos = spawnPoint.position + new Vector3(i * spacing, 0 , 0 ); // nentuin posisi spawn pake posisi spacing
    //         int randomIndex = Random.Range(0, objectToSpawn.Length); // Ambil objek acak
    //         GameObject spawnedObject = Instantiate(objectToSpawn[randomIndex], spawnPos, Quaternion.identity); // clone object yang ingin dispawn pada layar
    //         spawnedObjects.Add(spawnedObject);
    //     }
      

        
    




