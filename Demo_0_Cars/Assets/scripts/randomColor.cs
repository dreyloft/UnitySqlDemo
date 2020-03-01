using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour {
    public Material[] color;

    // Use this for initialization
    void Start() {
        switch (Random.Range(0, 5))
        {
            case 0:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 1:
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                break;
            case 2:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 3:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 4:
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                break;
            default:
                gameObject.GetComponent<Renderer>().material.color = Color.grey;
                break;
        }
    }
}