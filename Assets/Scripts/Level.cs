using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableblocks;
    SceneLoader Sceneload;
    private void Start()
    {
        Sceneload = FindObjectOfType<SceneLoader>();
    }
    public void countblocks()
    {
        breakableblocks++;
    }
    public void countbrokenblocks()
    {
        breakableblocks--;
        if(breakableblocks<=0)
        {
            Sceneload.loadnextscene();
        }
    }
}
