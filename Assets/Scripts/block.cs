using UnityEngine;

public class block : MonoBehaviour
{    
    //config parameters
    [SerializeField] AudioClip breaksound;
    [SerializeField] GameObject blocksparkleVFX;//particle system
    [SerializeField] Sprite[] spriteshow;


    //cached reference
    Level lvl; //way to call another script by making it a class
    gamestatus calcScore;

    //state parameter
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;//just for looking purpose
   
    private void Start()
    {
        CountBreakableBlocks();
        calcScore = FindObjectOfType<gamestatus>();
    }

    private void CountBreakableBlocks()
    {
        lvl = FindObjectOfType<Level>();
        if (tag == "breakable")
        { lvl.countblocks(); }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag=="breakable")
        {
            timesHit++;
            handlehit();
        }


    }

    private void handlehit()
    {
        if (timesHit >= maxHits)
        {
            Destroyblock();
        }
        else
        {     
            int spriteindex = timesHit - 1;
            if (spriteshow[spriteindex] != null)
            { 
                GetComponent<SpriteRenderer>().sprite = spriteshow[spriteindex];
            }
            else
            {
                Debug.LogError("sprite in missing in block" + gameObject.name);
            }
        }
    }

    private void Destroyblock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        lvl.countbrokenblocks();
        calcScore.Addtoscore();
        // Debug.Log(collision.gameObject.name);
        TriggerBdestroyVFX();

    }

    private void PlayBlockDestroySFX()
    {
        //findobjectoftype<gamestatus>.addtoscore();
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position);
    }
    private void TriggerBdestroyVFX()
    {
        Instantiate(blocksparkleVFX, transform.position, transform.rotation);
        Destroy(blocksparkleVFX, 1f); 
    }
}
