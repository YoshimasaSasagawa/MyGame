using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaController : MonoBehaviour
{
    //アニメーションするためのコンポーネント
    private Animator myAnimator;
    //移動させるコンポーネント
    private Rigidbody myRigidbody;
    //歩く力
    private float walkSpeed = 0.01f;
    private float rotateSpeed = 100.0f;

    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isFButtonDown = false;
    private bool isBButtonDown = false;
    private bool isTLButtonDown = false;
    private bool isTRButtonDown = false;

    private bool isGatcha = false;
    private bool isTimeUp = false;

    private int fPMove = 0;
    private int fMMove = 0;
    private int rPMove = 0;
    private int rMMove = 0;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;

    // Use this for initialization
    void Start()
    {

        //アニメータコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        //this.myAnimator.SetFloat("Speed", 1);

        //シーン中のstateTextオブジェクトを取得（追加）
        this.stateText = GameObject.Find("GameResultText");
    }

        // Update is called once per frame
        void Update()
    {
        //移動
        if (this.isFButtonDown == true)
        {
            fPMove = 1;
        }
        else
        {
            fPMove = 0;
        }
        if (this.isBButtonDown == true)
        {
            fMMove = -1;
        }
        else
        {
            fMMove = 0;
        }
        if (this.isRButtonDown == true)
        {
            rPMove = 1;
        }
        else
        {
            rPMove = 0;
        }
        if (this.isLButtonDown == true)
        {
            rMMove = -1;
        }
        else
        {
            rMMove = 0;
        }

        if (fPMove + fMMove + rPMove + rMMove == 1 || fPMove + fMMove + rPMove + rMMove == -1)
        {
            this.gameObject.transform.Translate((rPMove + rMMove) * walkSpeed, 0, (fPMove + fMMove) * walkSpeed);
        }
        else
        {
            this.gameObject.transform.Translate(0.7f * (rPMove + rMMove) * walkSpeed, 0, 0.7f * (fPMove + fMMove) * walkSpeed);
        }

        //回転
        if (this.isTLButtonDown || (this.isTLButtonDown && !this.isTRButtonDown))
        {
            this.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }else if (this.isTRButtonDown || (this.isTRButtonDown && !this.isTLButtonDown))
        {
            this.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }


    //ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyForwardButtonDown()
    {
        this.isFButtonDown = true;
    }
    public void GetMyBackwardButtonDown()
    {
        this.isBButtonDown = true;
    }
    public void GetMyTurnLeftButtonDown()
    {
        this.isTLButtonDown = true;
    }
    public void GetMyTurnRightButtonDown()
    {
        this.isTRButtonDown = true;
    }

    //ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
    public void GetMyForwardButtonUp()
    {
        this.isFButtonDown = false;
    }
    public void GetMyBackwardButtonUp()
    {
        this.isBButtonDown = false;
    }
    public void GetMyTurnLeftButtonUp()
    {
        this.isTLButtonDown = false;
    }
    public void GetMyTurnRightButtonUp()
    {
        this.isTRButtonDown = false;
    }

    void OnTriggerEnter(Collider other)
    {

        //chickenに触れた場合
        if (other.gameObject.name == "Toon Chicken")
        {
            this.isGatcha = true;
            //捕まった表示
            this.stateText.GetComponent<Text>().text = "Gatcha!!";
        }

    }
}