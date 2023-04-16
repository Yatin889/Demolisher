using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamestatus: MonoBehaviour
{     //configuring parameter
    [Range(0.1f,10f)] [SerializeField] float gameSpeedControl = 1f;

    [SerializeField] int pointsperblockdestroyed = 70;
    [SerializeField] int currentscore = 0;
    [SerializeField] TextMeshProUGUI scoretext;
  
    private void Awake()//awake->start
    {
        int gameStatuscount = FindObjectsOfType<gamestatus>().Length;
        if(gameStatuscount>1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        
     scoretext.text = currentscore.ToString();//if not put in start score will not start at 0 it will only start when addscore is called
    }
    private void Update()
    {
        Time.timeScale = gameSpeedControl;
    }
    public void Addtoscore()
    {    currentscore = currentscore + pointsperblockdestroyed; 

        scoretext.text = currentscore.ToString();
    }
    public void resetScore()
    {
        Destroy(gameObject);
    }
    
    
}
