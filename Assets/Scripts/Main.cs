using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main instance;
    

    private void Awake()
    {
        instance = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoInit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoInit()
    {
        float beginTime = Time.realtimeSinceStartup;

        UIMgr.instance.Init();
        LevelMgr.instance.Init();

        //UIMgr.instance.Open<UILoading>();
        LevelMgr.instance.ChangeLevel(GetLevel());
        yield break;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level", 1);
    }

    public void SetLevel(int level)
    {
        PlayerPrefs.SetInt("Level", level);
    }

}
