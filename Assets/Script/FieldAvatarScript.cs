using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldAvatarScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    // フィールドの初期化
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // 入力に応じてユニティちゃんを動かす
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", v);
        Vector3 vector = new Vector3(0, 0, v);
        vector = transform.TransformDirection(vector) * 5f;
        transform.localPosition += vector * Time.fixedDeltaTime;
        transform.Rotate(0, h, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", v * 1.5f);
        }
    }

/*
    // 入店時の処理
    void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("Shop",LoadSceneMode.Additive);
        Debug.Log("入店しました。");
    }
*/
}
