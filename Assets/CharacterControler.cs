using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    public float speed;
    public GameObject[] points;
    //public int indexStart;
    private int indexFinish;

    public void Start()
    {
        this.gameObject.transform.position = points[1].transform.position;
    }   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Derecha");
            this.gameObject.transform.position = points[2].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Izquierda");
            this.gameObject.transform.position = points[0].transform.position;
        }
    }
}