using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Ultts.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum arttype
    {
        tipe_01,
        tipe_02,
        Black,
        Start

    }

    public List<artSetup> artSetups;

    public artSetup GetSetupbyType(arttype arttype)
    {
        return artSetups.Find(i => i.arttype == arttype);




    }



}


[System.Serializable]
public class artSetup
{
    public ArtManager.arttype arttype;
    public GameObject gameObject;
}
