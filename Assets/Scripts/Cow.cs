using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MoveManager
{
    public float speed = 3.0f;

    private Color startcolor;
    void OnMouseEnter()
    {
        Debug.Log("Mouse entered");
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }
}
