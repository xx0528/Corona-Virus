using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickTest : MonoBehaviour
{
    [SerializeField]
    Player player;

    Vector2 centerPos = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

        var listener = GetComponent<DragListener>();
        if (listener == null)
        {
            listener = this.gameObject.AddComponent<DragListener>();
        }
        listener.onDragBegin = OnBeginDrag;
        listener.onDrag = OnDrag;
        listener.onDragEnd = OnEndDrag;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
