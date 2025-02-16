using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Game Start"); // debug game start
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                // Debug.Log(key);
            }
        }
    }
}
