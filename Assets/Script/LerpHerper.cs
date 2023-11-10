using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHerper : MonoBehaviour
{
    public Transform target;
    public float LerpSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, LerpSpeed * Time.deltaTime);
    }
}
