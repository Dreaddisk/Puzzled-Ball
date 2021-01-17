using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private bool moveX, moveY, moveZ;

    [SerializeField]
    private float speed;

    #endregion Variables


    #region UnityFunctions
    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    #endregion UnityFunctions

    void MovePlatform()
    {
        if(moveX)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }

        if(moveY)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            transform.position = temp;
        }

        if(moveZ)
        {
            Vector3 temp = transform.position;
            temp.z += speed * Time.deltaTime;
            transform.position = temp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Floor")
        {
            speed *= -1;
        }
    }



} // MovingFloor class

