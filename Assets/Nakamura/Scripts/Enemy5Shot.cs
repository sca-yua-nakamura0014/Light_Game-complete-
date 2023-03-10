using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Shot : MonoBehaviour
{
    [SerializeField] private GameObject enemyshotR;//攻撃(右)
    [SerializeField] private GameObject enemyshotL;//攻撃(左)
    [SerializeField] private GameObject enemyshotU;//攻撃(上)
    [SerializeField] private GameObject enemyshotD;//攻撃(下)
    [SerializeField] private GameObject Shot;//攻撃(追跡)
    GameObject player;
    GameObject enemy4;
    private float span = 5.0f;//enemyshotR〜enemyshotDが生成させる間隔
    private float span2 = 8.0f;//Shotが生成される間隔
    private float time = 0f;
    private float time2 = 0f;
    private float arealr = 0.0f;//攻撃範囲(左右)
    private float areaud = 0.0f;//攻撃範囲(上下)
    // Start is called before the first frame update
    void Start()
    {
        enemy4 = GameObject.Find("Enemy4");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        arealr = player.transform.position.x - this.transform.position.x;
        areaud = player.transform.position.y - this.transform.position.y;
        //プレイヤーが範囲内に入ったら時間を計測
        if (arealr < 50.0f && arealr > -50.0f)
        {
            if (areaud < 50.0f && areaud > -50.0f)
            {
                float x = enemy4.transform.position.x;
                float y = enemy4.transform.position.y;
                time += Time.deltaTime;
                time2 += Time.deltaTime;
                //span秒経過したらenemyshotR〜enemyshotDを生成
                if (time > span)
                {
                    Instantiate(enemyshotR);
                    Instantiate(enemyshotL);
                    Instantiate(enemyshotU);
                    Instantiate(enemyshotD);
                    enemyshotR.transform.position = new Vector2(x, y);
                    enemyshotL.transform.position = new Vector2(x, y);
                    enemyshotU.transform.position = new Vector2(x, y);
                    enemyshotD.transform.position = new Vector2(x, y);
                    time = 0f;
                }
                //span2秒経過したらshotを生成
                if (time2 % 10 > span2)
                {
                    Instantiate(Shot);
                    Shot.transform.position = new Vector2(x, y);
                    time2 = 0f;
                }
               

            }
        }


    }


}