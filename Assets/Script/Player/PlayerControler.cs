using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Publics
    [Header("Learp")]
    public Transform target;
    public float LerpSpeed = 1f;

    public float speed = 1f;

    public string TagEnimy = "Enimy";

    public GameObject endScreen;

    //Privete
    private bool _Play;
    private Vector3 _pos;


    void Update()
    {
        if (!_Play) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == TagEnimy)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
          _Play = false;
           endScreen.SetActive(true);

    }
    public void StartGame()
    {
       _Play = true;
    }
    

}

