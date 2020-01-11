using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewScript : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    // カメラの位置を調整する
    void Update()
    {
        Vector3 vec = target.position;
        Vector3 fvec = target.forward;
        vec.y = 2.5f;
        fvec *= 4f;
        Camera.main.transform.position = vec -fvec;
        Camera.main.transform.LookAt(vec);
    }
}
