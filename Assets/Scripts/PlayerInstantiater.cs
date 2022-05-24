using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstantiater : MonoBehaviour
{
    void Start()
    {
        Instantiate(Resources.Load("importantObjects"), new Vector3(0, 0.11f, 0), Quaternion.identity);
    }

  
}
