using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelMgr instance;
    Level curLevel;

    public void Init()
    {

    }


    public void ChangeLevel(int levelID, object param = null)
    {
        Main.instance.StartCoroutine(CoChangeLevel(levelID, param));
    }

    IEnumerator CoChangeLevel(int levelID, object param = null)
    {
        var scene = SceneManager.GetActiveScene();
        GameObject[] rootGos = scene.GetRootGameObjects();
        foreach (var go2 in rootGos)
        {
            if (go2.name == "Main" || go2.name == "UIRoot" || go2.name == "DontDestroyOnLoad")
                continue;

            GameObject.Destroy(go2);
        }
        yield return 2;
        Resources.UnloadUnusedAssets();//卸载没有用的资源
        yield return 2;
        AsyncOperation op = SceneManager.LoadSceneAsync("Level" + levelID);
        while (!op.isDone)
        {
            yield return 1;
        }

        GameObject level = GameObject.Find("Level");
        if (level == null)
        {
            Debug.LogError("没有找到Level节点");
            yield break;
        }
        curLevel = level.GetComponent<Level>();
        curLevel.Init();
        yield break;

    }

}
