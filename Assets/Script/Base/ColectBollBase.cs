using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectBollBase : MonoBehaviour
{
    public string comparation = "Player";
    public new ParticleSystem particleSystem;
    public float timecoins = 1.34f;
    public GameObject ItemGraphic;

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
            Collect();        
        }

    }
    protected virtual void Collect() 
    {

        if (ItemGraphic != null) ItemGraphic.SetActive(false);
        if (spriteRenderer != null) spriteRenderer.enabled = false;
        if (colision2D != null) colision2D.enabled = false ;
        Invoke("HideItens", timecoins);
        OnCollect();
    }

    public void HideItens()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() 
    {
    if (particleSystem != null) particleSystem.Play();
    if (audioSource != null) audioSource.Play();

    }

}
