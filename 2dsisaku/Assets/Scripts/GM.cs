using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject enemy;  // Enemyプレハブ
    public int command = 0;
    private Transform playerObj; private Transform enemyObj; private Transform TurnObj;
    public player1 player;
    public enemy_script enemy0;
    //プレイヤーステータス
    int Php = player1.HP, Pmp = player1.MP;
    int mPhp = player1.mHP, mPmp = player1.mMP;
    int Patk = player1.ATK, Pdef = player1.DEF;
    int Pspd = player1.SPD;
    //エネミーステータス
    int Ehp = enemy_script.HP, Emp = enemy_script.MP;
    int mEhp = enemy_script.mHP, mEmp = enemy_script.mMP;
    int Eatk = enemy_script.ATK, Edef = enemy_script.DEF;
    int Espd = enemy_script.SPD;
    //現在ステータス変数は五種存在し、最大/現在の体力と魔力、攻撃力、防御力、素早さでできている
    //予定としては魔撃力（MAT）抵抗力（MDF）を入れたらなと

    public GameObject HP_bar = null; // HPとMPを送り出す
    public GameObject MP_bar = null; // Textオブジェクト

    public GameObject scroll_View_comand;//スクロールするコマンド

    public GameObject buttonAttack;//ボタン：攻撃
    public GameObject buttonGuard;//ボタン：防御
    public GameObject buttonItem;//ボタン：アイテム

    public GameObject Turn = null; // Textオブジェクト
    int turnNo, damage;
    bool P_Guard, E_Guard;//互いのガードフラグ
    float random;

    // Start is called before the first frame update
    void Start()
    {
        int Attack;
        P_Guard = false;//最初はガードしていない
        turnNo = 1;//最初のターン数は１
        Instantiate(enemy, transform.position, transform.rotation);
        //バトル開始時、敵を召還する（まだ試験段階なので一体だけ）
        playerObj = GameObject.Find("pl").GetComponent<Transform>();
        enemyObj = GameObject.Find("en").GetComponent<Transform>();
        TurnObj = GameObject.Find("Turn").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerObj == null) SceneManager.LoadScene("GAMEOVER"); ;
        //if (enemyObj == null) SceneManager.LoadScene("WIN"); ;
        //PL_ATK();
        //EN_ATK();

        //以下必ず更新枠
        // オブジェクトからTextコンポーネントを取得
        Text HP_text = HP_bar.GetComponent<Text>();
        Text MP_text = MP_bar.GetComponent<Text>();
        Text Turn_text = Turn.GetComponent<Text>();
        // テキストの表示を入れ替える
        if (Php < 0) Php = 0;
        if (Pmp < 0) Pmp = 0;
        HP_text.text = "HP:" + Php + "/" + mPhp;
        MP_text.text = "MP:" + Pmp + "/" + mPmp;
        Turn_text.text = "Turn" + turnNo;

    }
    int Random_Generator()//これを使うことで0～99の乱数ができる
    {
        return (int)UnityEngine.Random.Range(0.0f, 100.0f);//※100は出ないぞ
    }                       //※ルール的に0=100なので注意
    /*
    void PL_ATK()//プレイヤーの攻撃
    {
        //if (Random() % 100 > 10)//命中判定（一割外れ） 
        Ehp -= (Patk - Edef);//敵にプレイヤーが攻撃
    }
    void EN_ATK()//プレイヤーの攻撃
    {
        //if (Random() % 100 > 10)// 命中判定（一割外れ）
        Php -= (Eatk - Pdef);//プレイヤーに敵が攻撃
    }*/
    public void PushButtonAttack()//攻撃をタップ
    {
        
        
            command = 1;
        
        
        Main_Phase();
    }
    public void PushButtonGuard()//防御をタップ
    {
        P_Guard = true;
    }
    public void PushButtonItem()//アイテムをタップ
    {
    }
    void Main_Phase()
    {
        scroll_View_comand.SetActive(false);
        if (Pspd >= Espd)//相手以上に速いかどうかで先制を決める
        {
            Playr_Action(command);
            Enemy_Action();
        }
        else
        {
            Enemy_Action();
            Playr_Action(command);
        }
        scroll_View_comand.SetActive(true);//処理が終わったらコマンドを再起動させて待機
        turnNo++;
        command = 0;//コマンド初期化
    }
    void Playr_Action(int com)//プレイヤー行動内容
    {
        switch (com)//選んだコマンドによって分かれる
        {
            case 1://攻撃選択時
                random = Random_Generator();//乱数が欲しいときに
                if (random < 90)//命中判定（一割外れ）
                {
                    Ehp -= damage = (Patk - Edef);//プレイヤーが敵に攻撃
                    Debug.Log("playr attack" + damage);//ダメージを表示
                }
                else Debug.Log("playr attack miss" + (random + 1));//0が100のため一つずらします

                break;

            default:
                break;//何も設定していないとかだと棒立ちをかまします
        }
    }
    void Enemy_Action()//敵行動内容
    {





    }
}