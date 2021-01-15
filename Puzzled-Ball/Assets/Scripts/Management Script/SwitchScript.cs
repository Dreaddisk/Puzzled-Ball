using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    #region Variables
    private GameObject switchWall;

    private bool wallTrunedOff;

    private Renderer myRenderer;
    private Color switchColor;

    #endregion Variables


    #region UnityFunctions
    private void Awake()
    {
        if(gameObject.name == "Red Switch")
        {
            switchWall = GameObject.Find("Red Wall");
            switchColor = Color.red;
        }

        if(gameObject.name == "Blue Switch")
        {
            switchWall = GameObject.Find("Blue Wall");
            switchColor = Color.blue;
        }

        myRenderer = GetComponent<MeshRenderer>();
    }

    #endregion UnityFunctions

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Ball")
        {
            if(wallTrunedOff)
            {
                switchWall.SetActive(true);
                myRenderer.material.color = switchColor;
                wallTrunedOff = false;
            }
            else
            {
                switchWall.SetActive(false);
                myRenderer.material.color = Color.black;
                wallTrunedOff = true;
            }
        }
    }



} // Switch class
