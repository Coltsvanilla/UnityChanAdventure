using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Start");
        Debug.Log("ゴール");
    }
}
