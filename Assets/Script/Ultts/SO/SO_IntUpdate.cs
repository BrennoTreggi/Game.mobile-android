using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SO_IntUpdate : MonoBehaviour
{
  
  
    public SO_Inst_Coins sOinti;
    public TextMeshProUGUI uiText;

    void Start()
    { 
     
        uiText.text = sOinti.valor.ToString();
        
   
        
    }

     void Update()
    {
        uiText.text = sOinti.valor.ToString();
       
   
       


    }

}
