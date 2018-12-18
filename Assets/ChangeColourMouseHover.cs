using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourMouseHover : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.magenta;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
