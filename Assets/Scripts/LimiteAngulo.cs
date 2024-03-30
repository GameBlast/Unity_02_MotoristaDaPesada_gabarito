using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteAngulo : MonoBehaviour
{
    public float limite1, limite2;
    private float rotZ;

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z < (360 - transform.eulerAngles.z))
            rotZ = Mathf.Clamp(transform.eulerAngles.z, 0, limite1);
        else
            rotZ = Mathf.Clamp(transform.eulerAngles.z, 360 + limite2, 360);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotZ);
    }
}
