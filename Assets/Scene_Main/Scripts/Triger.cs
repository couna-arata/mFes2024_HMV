using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        MainManager._gazeState = true;
        Debug.Log("Enter");

    }
    private void OnTriggerExit(Collider other)
    {
        MainManager._gazeState = false;
        Debug.Log("Exit");
    }
    private void OnTriggerStay(Collider other)
    {
        MainManager._gazeState = true;
        Debug.Log("Stay");
    }
}
