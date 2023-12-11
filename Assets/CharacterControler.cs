using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("apreto");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("Solto");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Mantiene"); 
        }
    }
}
