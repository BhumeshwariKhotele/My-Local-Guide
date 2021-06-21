using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIscriptManager : MonoBehaviour
{

    public Text Lat, Lon;
   

    // Update is called once per frame
    void Update()
    {
        Lat.text = "LAT :" +GPSlocation.latitude.ToString();
        Lon.text = "LONG : " +GPSlocation.longitude.ToString();
    }
}
