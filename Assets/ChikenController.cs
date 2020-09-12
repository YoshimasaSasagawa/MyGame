using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChikenController : MonoBehaviour
{
    //移動距離
    private float walkDistance = 0.01f;

    private bool isPXButtonDown = false;
    private bool isMXButtonDown = false;
    private bool isPZButtonDown = false;
    private bool isMZButtonDown = false;

    private int xPMove = 0;
    private int xMMove = 0;
    private int zPMove = 0;
    private int zMMove = 0;

    private bool isHovering = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        if (this.isHovering == true && myTransform.position.y < 0.5f)
        {
            pos.y += 0.01f;
            myTransform.position = pos;
        }
        else if(this.isHovering == false && myTransform.position.y > 0.019f)
        {
            pos.y -= 0.02f;
            myTransform.position = pos;
        }

        if (this.isPXButtonDown == true)
        {
            xPMove = 1;
        }
        else
        {
            xPMove = 0;
        }
        if (this.isMXButtonDown == true)
        {
            xMMove = -1;
        }else
        {
            xMMove = 0;
        }
        if (this.isPZButtonDown == true)
        {
            zPMove = 1;
        }else
        {
            zPMove = 0;
        }
        if (this.isMZButtonDown == true)
        {
            zMMove = -1;
        }else
        {
            zMMove = 0;
        }

        if (xPMove + xMMove + zPMove + zMMove == 1 || xPMove + xMMove + zPMove + zMMove == -1)
        {
            this.gameObject.transform.Translate((xPMove + xMMove) * walkDistance, 0, (zPMove + zMMove) * walkDistance, Space.World);
        }
        else
        {
            this.gameObject.transform.Translate(0.7f * (xPMove + xMMove) * walkDistance, 0, 0.7f * (zPMove + zMMove) * walkDistance, Space.World);
        }
    }

    //ボタンを押し続けた場合の処理
    public void GetMyPXButtonDown()
    {
        this.isPXButtonDown = true;
    }
    public void GetMyMXButtonDown()
    {
        this.isMXButtonDown = true;
    }
    public void GetMyPZButtonDown()
    {
        this.isPZButtonDown = true;
    }
    public void GetMyMZButtonDown()
    {
        this.isMZButtonDown = true;
    }

    //ボタンを離した場合の処理
    public void GetMyPXButtonUp()
    {
        this.isPXButtonDown = false;
    }
    public void GetMyMXButtonUp()
    {
        this.isMXButtonDown = false;
    }
    public void GetMyPZButtonUp()
    {
        this.isPZButtonDown = false;
    }
    public void GetMyMZButtonUp()
    {
        this.isMZButtonDown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Closet")
        {
            this.isHovering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Closet")
        {
            this.isHovering = false;
        }
    }
}