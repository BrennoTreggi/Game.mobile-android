using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchControler : MonoBehaviour
{
    public Vector2 position2D;
    public float velocity = 1f;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Mouse Position  PRENSENTE  - Mouse Position PASSADO
            Move(Input.mousePosition.x - position2D.x);
        }

        position2D = Input.mousePosition;
    }

    public void Move(float Speed) 
    {

        transform.position += Vector3.right * Time.deltaTime * Speed * velocity;
    }


}
