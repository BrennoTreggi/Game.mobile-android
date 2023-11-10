using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SO_FloatUpdate : MonoBehaviour
{

    public SO_Float foguete;
    public TextMeshProUGUI uiText;


    void Start()
    {

        uiText.text = foguete.value.ToString();

    }

    void Update()
    {
        uiText.text = foguete.value.ToString();

    }



}
