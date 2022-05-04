using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Editor_InteractAreaSphereManager : MonoBehaviour
{
    CapsuleCollider interactAreaCollider;

    private void Start()
    {
        interactAreaCollider = this.GetComponentInParent<CapsuleCollider>();
        if(interactAreaCollider == null)
        {
            throw new System.Exception("Capsule Collider not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interactAreaCollider != null)
        {
            transform.localScale = new Vector3(
                interactAreaCollider.radius * 2.0f,
                interactAreaCollider.height * 0.5f,
                interactAreaCollider.radius * 2.0f
                );
        }
    }
}
