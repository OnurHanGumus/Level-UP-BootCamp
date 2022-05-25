using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableVerticalPosition : MonoBehaviour
{
    [SerializeField]
    int destroyTime = 3;
    void Update()
    {
        if (transform.position.y > 0.05f)
        {
            transform.position = new Vector3(transform.position.x, 0.04f, transform.position.z);
        }
        else if (transform.position.y < -2f)
        {
            Destroy(gameObject, destroyTime);

        }
    }

}
