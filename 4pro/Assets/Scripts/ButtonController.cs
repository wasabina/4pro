using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManager;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    //TouchManager tm;
    private Image button;
    //private int fingerId = -1;
    //private int fingerNum = 0;
    private bool isTouched = false;

    public bool IsTouched //プロパティ
    {
        get { return this.isTouched; }
    }

    private void Awake()
    {
        //var eventTrigger = GetComponent<EventTrigger>();

        //var pointerDownEntry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };

        /*
        pointerDownEntry
            .callback
            .AddListener((data) => OnPointerDownDelegate((PointerEventData)data));

        eventTrigger
            .triggers
            .Add(pointerDownEntry);
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.tm = new TouchManager();
        button = GetComponent<Image>();
        //button.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {



        // タッチ状態更新
        //this.tm.update();

        // タッチ取得
        //TouchManager touch_state = this.tm.getTouch();

        /* touchManager使ったやつ
        // タッチされていたら処理
        if (touch_state._touch_flag)
        {
            // Rayによる接触判定(Colliderが必要)
            // 座標系変換
            Vector2 world_point = Camera.main.ScreenToWorldPoint(touch_state._touch_position);

            if (touch_state._touch_phase == TouchPhase.Stationary)
            {
                // 指が画面に触れているが動いてはいない時
                RaycastHit2D hit = Physics2D.Raycast(world_point, Vector2.zero);
                // チップ切り替え
                if (hit)
                {
                    Debug.Log("<color=aqua>オブジェクトにヒット</color>");
                    // タッチ時の処理を行う
                    hit.collider.GetComponent<XXX>().タッチした時の処理();
                }
                else
                {
                    Debug.Log("そこにオブジェクトは無いよ");
                }
            }
        }*/


        /*
        var touchCount = Input.touchCount;
        fingerNum = touchCount;

        if (touchCount <= 0)
            return;

        for (var i = 0; i < touchCount; i++)
        {
            var touch = Input.GetTouch(i);

            if (touch.fingerId == fingerId)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        //タップした時
                        isTouched = true;
                        break;
                    case TouchPhase.Moved:
                        break;
                    case TouchPhase.Stationary:
                        // タップしている間
                        button.color = Color.blue;
                        break;
                    case TouchPhase.Ended:
                        button.color = Color.red;
                        fingerId = -1;
                        isTouched = false;
                        break;
                    case TouchPhase.Canceled:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        */
    }

    public void onTouchAct()
    {
        isTouched = true;
    }

    public void onTouchExit()
    {
        isTouched = false;
    }


    /*
    private void OnPointerDownDelegate(PointerEventData data)//タッチされたことと座標を取得
    { //どのタッチがどの指か振り分け
        var touchCount = Input.touchCount;

        var minIndex = 0;
        var minDist = double.PositiveInfinity;
        for (var i = 0; i < touchCount; i++)
        {
            var dist = Vector3.Magnitude(Input.GetTouch(i).position - data.position);
            // 必ず一つは距離がゼロになることが保障されているなら
            if (dist == 0)
            {
                fingerId = Input.GetTouch(i).fingerId;
                break;
            }

            // 必ず一つは距離がゼロになることが保障されていないなら
            if (dist < minDist)
            {
                minIndex = i;
                minDist = dist;
            }
        }
        fingerId = Input.GetTouch(minIndex).fingerId;
    }
    */
}
