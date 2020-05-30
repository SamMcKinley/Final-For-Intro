using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject Player;
    public int currentScene = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Tried to create a second GameManager");
            Destroy(this.gameObject);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
