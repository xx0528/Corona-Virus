using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Player m_player;
    public GameObject[] m_policeGos;   //警察
    public GameObject[] m_doorGos;     //普通门
    public GameObject[] m_staffGos;    //职员
    public GameObject[] m_bossGos;     //老板
    public GameObject[] m_trapDoorGos; //机关门
    public GameObject[] m_airPortGos;  //风口

    List<Police>        m_polices;
    List<DoorNormal>    m_doorNormals;
    List<DoorTrap>      m_doorTraps;
    List<AirPort>       m_airPorts;
    List<Staff>         m_staffs;
    List<Boss>          m_bosses;

    public void Init()
    {
        m_player.Init();

        foreach (var go in m_policeGos)
        {
            m_polices.Add(go.GetComponent<Police>());
        }

        foreach (var go in m_doorGos)
        {
            m_doorNormals.Add(go.GetComponent<DoorNormal>());
        }

        foreach (var go in m_trapDoorGos)
        {
            m_doorTraps.Add(go.GetComponent<DoorTrap>());
        }

        foreach (var go in m_airPortGos)
        {
            m_airPorts.Add(go.GetComponent<AirPort>());
        }

        foreach (var go in m_staffGos)
        {
            m_staffs.Add(go.GetComponent<Staff>());
        }

        foreach (var go in m_bossGos)
        {
            m_bosses.Add(go.GetComponent<Boss>());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
