using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            MainManager._gazeState = true;
            StatueManager._gazeState = true;
            Debug.Log("Enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            MainManager._gazeState = false;
            StatueManager._gazeState = false;
            Debug.Log("Exit");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer ==7) { 
        MainManager._gazeState = true;
        StatueManager._gazeState = true;
        Debug.Log("Stay");
        }
    }
}
