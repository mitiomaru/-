using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_field : MonoBehaviour
{
    public float speed = 5;         //移動スピード
    private Transform playerObj;
    //プレイヤーステータス
    int Php = player1.HP, Pmp = player1.MP;
    int mPhp = player1.mHP, mPmp = player1.mMP;
    int atk = player1.ATK, def = player1.DEF;
    int spd = player1.SPD;
    public static int exp;
    public static int gold;

    //ステータス欄に入れる数字
    public GameObject HP_bar = null; // HPとMPを送り出す
    public GameObject MP_bar = null; // Textオブジェクト
    public GameObject ATK = null; // 
    public GameObject DEF = null; // 
    public GameObject SPD = null; // 
    public GameObject EXP = null; // 
    public GameObject GOLD = null; // 

    public GameObject Status_Canvas;//ステータス
    bool Status;//ステータスの表示の有無
    void Start()
    {
        Status = false;
        Status_Canvas.SetActive(false);
        playerObj = GameObject.Find("pl").GetComponent<Transform>();
        exp = 0;gold = 1000;//経験値とお金の初期化

    }

    // Update is called once per frame
    void Update()
    {
        //弾の発射処理
        //if (Input.GetButton ("Fire1")) {	
        if (Input.GetKey(KeyCode.Z))
        {   //
          
        }
        if (Input.GetKeyDown(KeyCode.X))
        {   //Xが押されたら
            if (!Status)//ステータスが表示されていなかったら
            {
                Status_Canvas.SetActive(true);//ステータスを表示
                Status = true;//boolを更新
            }
            else//逆にステータスが表示されていたら
            {
                Status_Canvas.SetActive(false);//ステータスを非表示
                Status = false;//boolを更新
            }
        }

      
        float x = Input.GetAxisRaw("Horizontal");   // 右・左の入力
        float y = Input.GetAxisRaw("Vertical");         // 上・下の入力
        Vector2 direction = new Vector2(x, y).normalized;       // 移動する向きを求める
                                                                // 画面左下のワールド座標を取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // 画面右上のワールド座標を取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;               // プレイヤーの座標を取得
        pos += direction * speed * Time.deltaTime;  // 移動量を加える
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);   // プレイヤーのx位置を画面内で制限する
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);       // プレイヤーのy位置を画面内で制限する
        transform.position = pos;       // 制限をかけた値をプレイヤーの位置とする

        //以下ステータスに関係するもの


        Text HP_text = HP_bar.GetComponent<Text>();//HPの数字を更新させるために必要
        Text MP_text = MP_bar.GetComponent<Text>();//MPの数字を更新させるために必要
        Text ATK_text = ATK.GetComponent<Text>();
        Text DEF_text = DEF.GetComponent<Text>();
        Text SPD_text = SPD.GetComponent<Text>();
        Text EXP_text = EXP.GetComponent<Text>();
        Text GOLD_text = GOLD.GetComponent<Text>();

        HP_text.text = "HP:" + Php + "/" + mPhp;//左に表示させるのが現在HP、右が最大HP
        MP_text.text = "MP:" + Pmp + "/" + mPmp;//左に表示させるのが現在MP、右が最大MP
        ATK_text.text = "attck " + atk; DEF_text.text = "defense " + def;
        SPD_text.text = "speed " + spd; EXP_text.text = "EXP " + exp;
        GOLD_text.text = "GOLD " + gold;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        
        if(c.name == "wood(Clone)")
        {

        }
    }
}
