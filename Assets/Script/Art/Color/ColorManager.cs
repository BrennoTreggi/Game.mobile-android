using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Ultts.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColortSetup> colortSetups;

    public void ChangeColorByType(ArtManager.arttype arttype)
    {
        var setup = colortSetups.Find(i => i.arttype == arttype);

        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_color", setup.colors[i]);
        }

    }






}
[System.Serializable]
public class ColortSetup
{
    public ArtManager.arttype arttype;
    public List<Color> colors;
}
