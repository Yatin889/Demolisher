using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    gamestatus gms;
    

    private void Start()
    {
        gms = FindObjectOfType<gamestatus>();
    }
    public void loadnextscene() 
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
        

    } 
    public void replaygame() 
    {
        
        SceneManager.LoadScene(0);
        gms.resetScore();

    }
    public void quitgame() 
    {

        Application.Quit();

    }
    
}

