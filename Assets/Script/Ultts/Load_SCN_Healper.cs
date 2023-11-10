using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_SCN_Healper : MonoBehaviour
{
    public void Load(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }

}
