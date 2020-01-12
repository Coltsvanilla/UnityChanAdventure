using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCave : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("Dungeon");
        Debug.Log("洞窟へ侵入しました");
    }
}
