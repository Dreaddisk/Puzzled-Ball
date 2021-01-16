using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongWayHandler : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Ball")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }



} // WrongWayHandler class
