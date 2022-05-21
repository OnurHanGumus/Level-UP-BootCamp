using UnityEngine;
using UnityEditor;
using System.Collections;

public class ColliderToFit : MonoBehaviour
{
    public void Start()
    {
        FitToChildren();
    }
    public void FitToChildren()
    {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        GameObject rootGameObject = gameObject;

        for (int i = 0; i < rootGameObject.transform.childCount; ++i)
        {
            Renderer childRenderer = rootGameObject.transform.GetChild(i).GetComponent<Renderer>();
            if (childRenderer != null)
            {
                
                bounds.Encapsulate(childRenderer.bounds);
                
            }
        }

        BoxCollider collider = (BoxCollider)rootGameObject.GetComponent<Collider>();
        collider.center = bounds.center - rootGameObject.transform.position;
        collider.size = bounds.size;

    }
   
}

