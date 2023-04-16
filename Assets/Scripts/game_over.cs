using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)//collider is triggered when touched by other object with a collider
    {
        //int currentindex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentindex + 1);
        SceneManager.LoadScene("Game Over");
    }
}
