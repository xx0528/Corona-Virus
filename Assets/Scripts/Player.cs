using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float smoothing = 7f;

    Vector2 curDir = Vector2.zero;
    bool isMoveing = false;
    Vector2 offsetPos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
    }


    public void SetDir(Vector2 dir)
    {
        curDir = dir;
    }

    public void SetMoveing(bool bMove)
    {
        isMoveing = bMove;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!isMoveing)
            return;

        if (curDir.x != 0 || curDir.y != 0)//等于0说明摇杆没有被拉动，所以不要移动和转弯
        {
            var dir = (new Vector3(curDir.x, 0, curDir.y));
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
            //dir.y += 10;
            Quaternion qua = Quaternion.LookRotation(dir.normalized);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, qua, Time.deltaTime * smoothing);

        }
    }
}
