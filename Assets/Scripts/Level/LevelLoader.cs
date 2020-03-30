using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    
    private Button button;

    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        Levelstatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case Levelstatus.Locked:
                Debug.Log("Can't play");
                break;

            case Levelstatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;

            case Levelstatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;

        }
        
    }
}
