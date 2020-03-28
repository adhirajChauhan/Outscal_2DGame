using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string Level1;

    private void Awake()
    {
            if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStatus(Level1) == Levelstatus.Locked)
        {
            SetLevelStatus(Level1, Levelstatus.Unlocked);
        } 
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        SetLevelStatus(currentscene.name, Levelstatus.Completed);
        int nextSceneIndex = currentscene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        SetLevelStatus(nextScene.name, Levelstatus.Unlocked);

    }

    public Levelstatus GetLevelStatus(string level)
    {
        Levelstatus levelStatus = (Levelstatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, Levelstatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level :" + level + "Status" + levelStatus);

    }
}
