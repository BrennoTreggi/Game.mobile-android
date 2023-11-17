using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script.Ultts.Singleton;
using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    //Publics

    [Header("Learp")]
    public Transform target;
    public float LerpSpeed = 1f;

    public float speed = 1f;

    public string TagEnimy = "Enimy";

    public GameObject endScreen;

    [Header("Coin Setup")]
    public GameObject coinCollector;


    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    public bool invencible = true;

    [Header("Animation")]
    public AnimeteManeger animeteManeger;


    //Privete
    private bool _Play;
    private Vector3 _pos;
    private float _correntSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7;
    private void Start()
    {
        _startPosition = transform.position;
       _correntSpeed = speed;
    }

    void Update()
    {
        if (!_Play) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, LerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _correntSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.transform.tag == TagEnimy)
        {
            if (!invencible)
            {
                MoveBack(collision.transform);
                EndGame(AnimeteManeger.AnimationType.DEAD);
            }
        }
    } private void OnTriggerEnter(Collider other)
    {
      
        if (other.transform.tag == TagEnimy)
        {
            if(!invencible) EndGame();
        }
    }
    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, .3f).SetRelative();
    }
    private void EndGame(AnimeteManeger.AnimationType animationType = AnimeteManeger.AnimationType.IDLE)
    {
        _Play = false;
        endScreen.SetActive(true);
        animeteManeger.Play(animationType);
    }
    public void StartGame()
    {
       _Play = true;
        animeteManeger.Play(AnimeteManeger.AnimationType.RUN, _correntSpeed / _baseSpeedToAnimation);
    }
   
    
    
    
    #region PowerUps
    public void SetPowerUpText(string s)
    {
      uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _correntSpeed = f;
    }
    public void ResetSpeed()
    {
        _correntSpeed = speed;
    }
    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
       /* var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p; */

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease); //.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);

    }
    public void ResetHeight()
    {
        /* var p = transform.position;
         p.y = _startPosition.y;
         transform.position = p;*/

        transform.DOMoveY(_startPosition.y, 1.5f);

    }
    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }

    #endregion



}

