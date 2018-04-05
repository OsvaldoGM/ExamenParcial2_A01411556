using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadLevel(string name)
    {   
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   /* void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            GameObject.Find("Playerstats").GetComponent<Playerstats>().score = 0;
            GameObject.Find("Playerstats").GetComponent<Playerstats>().health = 0;
        }
    }*/
}
