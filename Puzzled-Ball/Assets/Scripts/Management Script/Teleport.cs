using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    #region Variables
    [SerializeField]
    private Vector3 teleportPos;

    [SerializeField]
    private bool getArrows;

    private GameObject[] pathArrows;
    private GameObject[] wrongWayArrows;

    #endregion Variables

    #region UnityFunctions

    private void Awake()
    {
        if(getArrows)
        {
            pathArrows = GameObject.FindGameObjectsWithTag("PathArrow");
            wrongWayArrows = GameObject.FindGameObjectsWithTag("WrongPathArrow");

            foreach(GameObject obj in wrongWayArrows)
            {
                obj.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion UnityFunctions

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Ball")
        {
            collider.transform.position = teleportPos;

            if(getArrows)
            {
                foreach(GameObject obj in pathArrows)
                {
                    obj.SetActive(false);
                }
                
                foreach(GameObject obj in wrongWayArrows)
                {
                    obj.SetActive(true);
                }
            }
        }
    }



} // Teleport Scripts

