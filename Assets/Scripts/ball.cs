using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    
    [SerializeField] float xpush=2f,ypush=14f;
    [SerializeField] float randomfactor=1f;//for preventing ball to get stuck on same path for ever
    Vector2 balltopaddleVector;
    bool launchclick = false;

    //cached parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballsounds;
    AudioSource myAudioSource;
    Rigidbody2D myRBdy;

    void Start()
    {   
            balltopaddleVector = transform.position - paddle1.transform.position;//ball position to paddle vector
        myAudioSource = GetComponent<AudioSource>();
        myRBdy = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
          
            launchballonclick();
            launchclick = true;
            
        }
        else if(!launchclick)
        { 
            lockballtopaddle();
        }
        
    }

    private void lockballtopaddle()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        transform.position = paddlepos + balltopaddleVector;
    }
    private void launchballonclick()
    {
        
            myRBdy.velocity = new Vector2(xpush,ypush);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (launchclick)
        {
            velocitytweaking();

            AudioClip clips = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            myAudioSource.PlayOneShot(clips);
        }
    }

    private void velocitytweaking()
    {
        Vector2 velocitytweak = new Vector2(Random.Range(0f, randomfactor), Random.Range(0f, randomfactor));
        myRBdy.velocity = myRBdy.velocity + velocitytweak;
    }
}
