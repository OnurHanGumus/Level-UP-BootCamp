using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformCanvas : MonoBehaviour
{
    Text puanTxt;
    private void Awake()
    {
        puanTxt = transform.GetChild(1).GetComponent<Text>();
    }
  

    public void GuncellenenTextiGoster(int guncelTopSayisi, int istenenTopSayisi)
    {
        puanTxt.text = guncelTopSayisi.ToString() + "/" + istenenTopSayisi.ToString(); 

    }


}
