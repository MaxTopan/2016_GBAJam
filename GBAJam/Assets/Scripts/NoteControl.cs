using UnityEngine;
using System.Collections;

public class NoteControl : MonoBehaviour
{
    /* Max Topan 07/10/16
     * noiseVal - 1 is C3, 1.05 is C#, 1.1 is D3 etc.
     * because of the way music works, there is no B# or E#, they are C and F respectively
     * this means things ending in a half value won't always be sharp or flat notes
     * there is a file called PitchesAreBitches.txt in the legends folder to help keep track of the notes
     */

    public bool filled = false;     // tracking if note is full
    public float noiseVal = 1.0f;   // pitch of note when it sounds (1 is 261.6Hz, which is middle C)
    public AudioSource tone;        // stores tone to be manipulated
    private Collider2D col;

    public Texture2D spritesheet;   // sheet of all note sprites
    private SpriteRenderer sr;      // apparently this is never assigned??
    public int spriteIndex = 0;     // 
    private Sprite[] sprites;       // array of all notes

    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();            // get the collider of the note (used for DeathTrigger)
        if (sr == null)
            sr = gameObject.GetComponent<SpriteRenderer>();     // if the spriterenderer is not already referenced, get it

        sprites = Resources.LoadAll<Sprite>(spritesheet.name);  // loads the note spritesheet from the resources folder
        sr.sprite = sprites[spriteIndex];                       // set sprite based on the spriteIndex (there's a guide to the indices in the legends folder)
        tone.pitch = noiseVal;                                  // set pitch of tone

        if (filled)
            Fill(null);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.transform.tag)
        {
            case "Bullet":
                if (!filled)
                    Fill(other.gameObject);
                break;

            case "Player":
                /*TAKE HEALTH AWAY FROM THE PLAYER*/
                //StartCoroutine(DeathTrigger());
                Destroy(col);
                break;

            default:
                break;
        }
        Debug.Log("Collision with: " + other.transform.tag);
    }

    void Fill(GameObject bullet)
    {
        filled = true;
        //percNum += 1;
        sr.sprite = sprites[spriteIndex + 1];
        col.isTrigger = true;
        Destroy(bullet);
    }

    void SoundNote()
    {
        tone.Play();
    }

    public IEnumerator DeathTrigger()
    {
        yield return new WaitForEndOfFrame();
        sr.sprite = sprites[spriteIndex + 2];   // set sprite to death variant
        Destroy(col);
        if (filled)
            tone.Play();
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (filled)
        {
            //SoundNote();
        }
        else
        {
            //percNum -= 1;
            //TAKE HEALTH AWAY FROM PLAYER
        }
    }
}
