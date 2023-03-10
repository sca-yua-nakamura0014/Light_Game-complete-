using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotR : MonoBehaviour
{
    private float speed = 0.05f;//攻撃のスピード
    GameObject boss;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        boss = GameObject.Find("Boss");

    }

    // Update is called once per frame
    void Update()
    {
        float x = boss.transform.position.x;//ボスのx座標を取得
        float y = boss.transform.position.y;//ボスのy座標を取得
        transform.position += new Vector3(speed, 0.0f, 0.0f);
        //現在のx座標がボスのx座標より45以上離れていたらfalseにする
        if (this.transform.position.x >= x + 45.0f)
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
