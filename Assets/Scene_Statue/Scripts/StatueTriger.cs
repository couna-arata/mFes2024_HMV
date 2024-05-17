using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueTriger : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        StatueManager._gazeState = true;
        Debug.Log("Enter");

    }
    private void OnTriggerExit(Collider other)
    {
        StatueManager._gazeState = false;
        Debug.Log("Exit");
    }
    private void OnTriggerStay(Collider other)
    {
        StatueManager._gazeState = true;
        Debug.Log("Stay");
    }
}
