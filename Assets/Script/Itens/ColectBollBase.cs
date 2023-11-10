using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectBollBase : MonoBehaviour
{
    public string comparation = "Player";
    public new ParticleSystem particleSystem;
    public float timecoins = 1.34f;
    public GameObject PFB_GameObject;

    private Collider2D colision2D;
    private SpriteRenderer spriteRenderer;

    [Header("Audition")]
    public AudioSource audioSource;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        colision2D = GetComponentInChildren<Collider2D>();

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(comparation)) 
        {
            OnCollect();
        
        }

    }
    protected virtual void OnCollect() 
    {



        if (PFB_GameObject != null) PFB_GameObject.SetActive(false);
        if (spriteRenderer != null) spriteRenderer.enabled = false;
        if (colision2D != null) colision2D.enabled = false ;
        Invoke("vitualObject", timecoins);
        CollectOkay();
    }

    private void vitualObject()
    {

        gameObject.SetActive(false);
    }

    protected virtual void CollectOkay() 
    {

    if (particleSystem != null) particleSystem.Play();

    if (audioSource != null) audioSource.Play();


    }

}
