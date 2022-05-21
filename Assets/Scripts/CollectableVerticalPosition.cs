using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableVerticalPosition : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y > 0.05f)
        {
            transform.position = new Vector3(transform.position.x, 0.04f, transform.position.z);
        }
    }
}
