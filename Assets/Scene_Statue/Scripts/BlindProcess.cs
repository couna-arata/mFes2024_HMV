using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindProcess : MonoBehaviour
{
    Transform BlindTransform;
    GameObject Camera;
    private void OnEnable()
    {
        BlindTransform = GetComponent<Transform>();
        Camera = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        BlindTransform.position = Camera.transform.position;
    }


}
