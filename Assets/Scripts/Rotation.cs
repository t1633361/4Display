using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var ro = new Vector3(0,0,transform.rotation.eulerAngles.z-5f);
        transform.rotation = Quaternion.Euler(ro);
    }
}
