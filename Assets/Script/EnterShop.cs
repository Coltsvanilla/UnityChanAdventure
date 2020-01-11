using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShop : MonoBehaviour
{
    public GameObject GameObjectsTohidden;
    public GameObject Maincamera;
    // Start is called before the first frame update
    void Start()
    {
        //シーンが破棄されたときに呼び出されるようにする
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 入店処理
    void OnTriggerEnter(Collider collider)
    {
        // 一部のオブジェクトを非表示にする
        GameObjectsTohidden.SetActive(false);
        Maincamera.SetActive(false);
        // Shopシーンの呼び出し
        SceneManager.LoadScene("Shop",LoadSceneMode.Additive);
        Debug.Log("入店しました。");
    }

    private void OnSceneUnloaded(Scene current)
    {
        GameObjectsTohidden.SetActive(true);
        Maincamera.SetActive(true);
        Vector3 pos = transform.position;
        pos.x = 8.2f;
        pos.y = 0f;
        pos.z = 0f;
        GameObjectsTohidden.transform.position = pos;
        /*
        Vector3 vec = transform.forward;
        vec *= 1;
        vec.y = 0;
        GameObjectsTohidden.transform.position += vec;
        Vector3 vec2 = new Vector3(0,180,0);
        GameObjectsTohidden.transform.Rotate(vec2);
        */
        Debug.Log("ショップを退店しました");
    }
}
