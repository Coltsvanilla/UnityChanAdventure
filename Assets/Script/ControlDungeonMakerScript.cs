using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDungeonMakerScript : MonoBehaviour
{
  // GUI部品関連
    public Text GoalText;
    public GameObject panel;

    public GameObject GoalPanel;

    private System.Random rnd;      // 乱数用クラス
    private bool toolFlg = false;   // ツールフラグ
    public int DungeonSize = 4;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random(System.Environment.TickCount);
        ReSet();
    }

    // Update is called once per frame
    void Update()
    {
        // 裏コマンドダンジョンリセットパネル表示　space + Vの同時押し
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.V))
        {
            toolFlg = !toolFlg;
            if ( toolFlg == true)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }

    // リセットボタンを押した処理
    public void OnReSet()
    {
        ReSet();
    }

    // リセット処理
    private void ReSet()
    {
        DeleteWall();
        CreateDungeonData();
    }

    // ダンジョンデータ生成
    void CreateDungeonData()
    {
        if (DungeonSize < 4)
        {
            DungeonSize = 4;
        }
        else
        {

        }
        int wall = DungeonSize * 4 + 2;
        bool[,] fdata = new bool[wall, wall];
        // 外周の生成
        for (int i = 0; i < wall; i++)
        {
            for (int j = 0; j < wall; j++)
            {
                if (i == 0 || i == (wall -1) ||
                    j == 0 || j == (wall-1))
                {
                    fdata[i,j] = true;
                }
                else
                {
                    fdata[i,j] = false;
                }
            }
        }
        int[,] arw = new int[,]{
            {0,-1},{0,1},{-1,0},{1,0}
        };
        for (int i = 0; i < (DungeonSize / 2)*
            (DungeonSize / 2); i++)
        {
            while(true)
            {
                int x = rnd.Next(1, DungeonSize) * 4;
                int y = rnd.Next(1, DungeonSize) * 4;
                if (fdata[x,y]){continue;}
                int n = i % 4;
                fdata[x,y] = true;
                while (true)
                {
                    x += arw[n, 0];
                    y += arw[n, 1];
                    if (fdata[x, y])
                    {
                        break;
                    }
                    else
                    {
                        fdata[x, y] = true;
                    }
                }
                break;
            }
        }
        // ユニティちゃん初期位置
        int cp = wall / 2;
        fdata[cp, cp] = false;
        GameObject.Find("unitychan").transform
            .position = new Vector3(cp, 0, cp);
        CreateWall(fdata);
        // ゴール位置設定
        int[,] gdatas = new int[,]{
            {1,1},{1,wall -2},{wall-2,1},
            {wall -2,wall-2}
        };
        int gn = rnd.Next(4);
        Vector3 goalpos = new Vector3(gdatas[gn, 0],
            1.5f, gdatas[gn, 1]);
        GameObject.Find("goal").transform.position = goalpos;
    }

    // キューブオブジェクトの生成
    void CreateWall(bool[,] data)
    {
        int wall = DungeonSize * 4 + 2;
        Texture txtr = Resources.Load<Texture>("CliffAlbedoSpecular");
        for (int i = 0; i < wall; i++)
        {
            for (int j = 0; j < wall; j++)
            {
                if(data[i,j])
                {
                    GameObject obj = GameObject.
                        CreatePrimitive(PrimitiveType.Cube);
                    obj.tag = "ob_wall";
                    obj.transform.localScale = new Vector3(1, 2, 1);
                    obj.transform.position = new Vector3(i, 1, j);
                    obj.GetComponent<Collider>().isTrigger = false;
                    obj.GetComponent<Renderer>().material.mainTexture = txtr;
                }
            }
        }
    }

    // キューブオブジェクトの削除
    void DeleteWall()
    {
        GameObject[] walls = GameObject.
            FindGameObjectsWithTag("ob_wall");
        foreach (GameObject obj in walls)
        {
            GameObject.Destroy(obj);
        }
    }

    // 階層表示
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 80), "Floar:" + (DungeonSize-3));
    }

    // ゲームクリア
    public void GoalEnd()
    {
        GoalPanel.SetActive(true);
        GoalText.text = "CLEAR!";
    }

    //ゴール時の処理
    public void OnGoal()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }
}
