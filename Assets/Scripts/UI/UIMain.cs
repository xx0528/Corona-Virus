using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
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
        Debug.Log("OnBeginDrag --- ");
    }


    void OnDrag(PointerEventData data)
    {
        Debug.Log("OnDrag --- ");
        var cam = data.pressEventCamera;
        Vector2 pos;
        //JoystickDrag(pos);
    }

    void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag --- ");
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
