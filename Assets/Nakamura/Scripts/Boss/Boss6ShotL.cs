using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss6ShotL : MonoBehaviour
{
    private GameObject boss;
    private float speed = 0.005f;//攻撃のスピード
    float left;
    float down;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        //生成された位置のx座標が0より大きいなら‐方向に飛ばす
	    if(this.transform.position.x > 0)
	    {
		    left =(this.transform.position.x*-2)* speed;
        }

        //それ以外なら＋方向に飛ばす
        else
        {
		    left =(this.transform.position.x*2)* speed;
        }

        //生成された位置のｙ座標が0より大きいなら‐方向に飛ばす
        if (this.transform.position.y >0)
	    {
		    down = (this.transform.position.y*-3)* speed;
        }

        //それ以外なら＋方向に飛ばす
        else
        {
		    down =(this.transform.position.y*3)* speed;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(left, down, 0.0f);
        float x = boss.transform.position.x;//ボスのx座標を取得
        float y = boss.transform.position.y;//ボスのy座標を取得
        //オブジェクトの位置がボスのx座標より45以上または45以下、ｙ座標より45以上または45以下ならfalseにする
        if (this.transform.position.x >= x + 45.0f || this.transform.position.x < x - 45.0f || this.transform.position.y >= y + 45.0f || this.transform.position.y < y - 45.0f)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet、Player、Wall、Partner、Doorのどれかに当たったならfalseにする
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Partner" || other.gameObject.tag == "Door")
        {
            this.gameObject.SetActive(false);
        }
    }
}