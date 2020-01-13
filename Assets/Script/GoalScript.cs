using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    // Update is called once per frame
    // ゴールを回転させる
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1));
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject CD = GameObject.Find("ControlDungeonMaker");
        ControlDungeonMakerScript cdms = CD.GetComponent<ControlDungeonMakerScript>();
        if (cdms.DungeonSize < 8)
        {
            cdms.DungeonSize++;
            cdms.OnReSet();
        }
        else
        {
            Debug.Log("ゴール");
            cdms.GoalEnd();
        }
        
    }
}
