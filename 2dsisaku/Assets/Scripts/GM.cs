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
    int mPhp = player1.mHP, mPmp = player1.mMP;     //MAXHPとMAXMP
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
        P_Guard = false;//最初はガードしていない
        turnNo = 1;//最初のターン数は１
        Instantiate(enemy, transform.position, transform.rotation);
        //バトル開始時、敵を召還する（まだ試験段階なので一体だけ）
        playerObj = GameObject.Find("pl").GetComponent<Transform>();
        enemyObj = GameObject.Find("en").GetComponent<Transform>();
        TurnObj = GameObject.Find("Turn").GetComponent<Transform>();//ターン数を表示させるために必要
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
        Text HP_text = HP_bar.GetComponent<Text>();//HPの数字を更新させるために必要
        Text MP_text = MP_bar.GetComponent<Text>();//MPの数字を更新させるために必要
        Text Turn_text = Turn.GetComponent<Text>();//ターン数を以下略
        // テキストの表示を入れ替える
        if (Php < 0) Php = 0;//オーバーフロー阻止
        if (Pmp < 0) Pmp = 0;//オーバーフロー阻止
        HP_text.text = "HP:" + Php + "/" + mPhp;//左に表示させるのが現在HP、右が最大HP
        MP_text.text = "MP:" + Pmp + "/" + mPmp;//左に表示させるのが現在MP、右が最大MP
        Turn_text.text = "Turn" + turnNo;//「ターン」と「ターン数」を表示

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
            command = 1;//コマンド一番、攻撃
        Main_Phase();//入力したコマンドを実行に移しに行きます
    }
    public void PushButtonGuard()//防御をタップ
    {
        P_Guard = true;//ガード、防御するけど行動はしない
        Main_Phase();//入力したコマンドを実行に移しに行きます
    }
    public void PushButtonItem()//アイテムをタップ
    {
        //アイテム欄がないとなんもできんので実装まで待機
    }
    void Main_Phase()
    {
        scroll_View_comand.SetActive(false);//コマンドは決まったので二重判定とかならんように非表示化
        if (Pspd >= Espd)//相手以上に速いかどうかで先制を決める
        {
            Playr_Action(command);//プレイヤーがコマンドに対応した行動をとる
            Enemy_Action();//敵はランダムに選ばれた行動をとる
        }
        else
        {
            Enemy_Action();//敵はランダムに選ばれた行動をとる
            Playr_Action(command);//プレイヤーがコマンドに対応した行動をとる
        }
        scroll_View_comand.SetActive(true);//処理が終わったらコマンドを再起動させて待機
        turnNo++;
        command = 0;//コマンド初期化
    }
    void Playr_Action(int com)//プレイヤー行動内容
    {
        switch (com)//選んだコマンドによって分かれる
        {
            case 0:
                break;//何も設定していないとかだと棒立ちをかまします
            case 1://攻撃選択時
                random = Random_Generator();//乱数が欲しいときに前段階として使ってください
                if (random < 90)//命中判定（一割外れ）
                {
                    Ehp -= damage = (Patk - Edef);          //プレイヤーが敵に攻撃
                    Debug.Log("playr attack" + damage);     //ダメージを表示
                }
                else Debug.Log("playr attack miss" + (random + 1));     //今回は1～100の数値を必要としているため
                                                                        //出力される乱数に+1しています
                break;

            default:
                Debug.Log("playr comand unknown" + com);//正体不明のコマンドが算出されたとき用
                break;
        }
    }
    void Enemy_Action()//敵行動内容
    {





    }
}