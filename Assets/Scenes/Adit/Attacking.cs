using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;
using UnityEditor.PackageManager;

public class Attacking : MonoBehaviour 
{
    public SpawnInstruction spawnInstruction;
    private KeyCode keyInput;
    public int score =0;

    public void checkInput()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {   
                if (score < spawnInstruction.activeInput.Count)
                {
                    keyInput = spawnInstruction.activeInput[score];
                }
                else {
                    spawnInstruction.isSpawned = false;
                }
                if (key != keyInput)
                {
                    Debug.Log("MISS ! ");
                }
                else 
                {
                    if (spawnInstruction.activeArrows[score] != false)
                    {
                        Destroy(spawnInstruction.activeArrows[score]);
                        score += 1;
                        Debug.Log("HIT!");
                    }
                }
            
                Debug.Log(keyInput);

            }
        }
        
    }

}


