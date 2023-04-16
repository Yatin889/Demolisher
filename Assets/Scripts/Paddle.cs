using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
     [SerializeField] float screenwidthinUnits = 16f;
     [SerializeField] float Xmax = 15f, Xmin = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // Debug.Log(Screen.width);
       // Debug.Log(Input.mousePosition.x);
        float mousePos = Input.mousePosition.x / Screen.width * screenwidthinUnits;
        Vector2 paddlepos = new Vector2(transform.position.x, transform.position.y);
        paddlepos.x = Mathf.Clamp(mousePos, Xmin, Xmax);
        transform.position = paddlepos;
    
     }
}
