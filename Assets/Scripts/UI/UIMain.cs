﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField]
    Player player;

    Vector2 centerPos = Vector2.zero;

    public Button btnBg;
    public Button btnSetting;
    public Button btnTask;
    public Button btnSkin;
    public Button btnEquipt;
    public Button btnMoney;
    public Button btnOther;

    bool IsStart;

    // Start is called before the first frame update
    void Start()
    {
        btnBg.onClick.AddListener(onClickStart);
        btnSetting.onClick.AddListener(onClickSetting);
        btnSkin.onClick.AddListener(onClickSkin);
        btnTask.onClick.AddListener(onClickTask);
        btnEquipt.onClick.AddListener(onClickEquipt);
        btnMoney.onClick.AddListener(onClickMoney);
        btnOther.onClick.AddListener(onClickOther);

        var listener = GetComponent<DragListener>();
        if (listener == null)
        {
            listener = this.gameObject.AddComponent<DragListener>();
        }
        listener.onDragBegin = OnBeginDrag;
        listener.onDrag = OnDrag;
        listener.onDragEnd = OnEndDrag;
        IsStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClickStart()
    {
        btnTask.gameObject.SetActive(false);
        btnEquipt.gameObject.SetActive(false);
        btnSkin.gameObject.SetActive(false);
        btnOther.gameObject.SetActive(false);
        btnBg.gameObject.SetActive(false);
        IsStart = true;

    }

    void OnBeginDrag(PointerEventData eventData)
    {
        player.SetMoveing(true);
        centerPos = eventData.position;
    }


    void OnDrag(PointerEventData eventData)
    {
        var curPos = eventData.position;
        var moveX = curPos.x - centerPos.x;
        var moveY = curPos.y - centerPos.y;
        var dirTemp = new Vector2(moveX, moveY);
        if (dirTemp.sqrMagnitude >= 100)
        {
            dirTemp.x = 10 * Mathf.Cos(Mathf.Atan2(moveY, moveX));
            dirTemp.y = 10 * Mathf.Sin(Mathf.Atan2(moveY, moveX));
            centerPos = new Vector2(curPos.x - dirTemp.x, curPos.y - dirTemp.y);
        }

        player.SetDir(dirTemp);
    }

    void OnEndDrag(PointerEventData eventData)
    {
        player.SetMoveing(false);
        player.SetDir(Vector2.zero);
    }

    void onClickSetting()
    {
        Debug.Log("onClickSetting --- ");
    }
    void onClickSkin()
    {
        Debug.Log("onClickSkin --- ");
    }
    void onClickTask ()
    {
        Debug.Log("onClickTask --- ");
    }
    void onClickEquipt()
    {
        Debug.Log("onClickEquipt --- ");
    }
    void onClickMoney()
    {
        Debug.Log("onClickMoney --- ");
    }
    void onClickOther()
    {
        Debug.Log("onClickOther --- ");
    }
}
