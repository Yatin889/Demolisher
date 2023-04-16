using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector2 startingposition;
    [SerializeField] Vector2 movementVector;
    float movementFactor;
    [SerializeField] float period = 4f;

    void Start()
    {
        startingposition = transform.position;
        Debug.Log(startingposition);

    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) 
        { return; }// for protecting period value close to zero
        
        float cycles = Time.time / period;//growing over time

        const float tau = Mathf.PI * 2;// tau=2pi const
        float rawSinWave = Mathf.Sin(cycles * tau);//-1 to +1
        movementFactor = (rawSinWave) / 2f; //to go from 0 to 1
        Vector2 offset = movementVector * movementFactor;
        transform.position = startingposition + offset;

    }
}
