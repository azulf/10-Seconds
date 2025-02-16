using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;

public class Attacking : MonoBehaviour 
{
    public SpawnInstruction spawnInstruction;
    private KeyCode keyInput;
    private Array arrayChecker;
    private int i =0;

    public void checkInput()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                keyInput = spawnInstruction.activeInput[i];   
                if (key != keyInput)
                {
                    Debug.Log("MISS ! ");
                }
                else {
                    Destroy(spawnInstruction.activeArrows[i]);
                    i += 1;
                    Debug.Log("HIT!");
                    }
            
                Debug.Log(keyInput);

            }
        }
        
    }

}


