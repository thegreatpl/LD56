using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

[RequireComponent(typeof(EntityController))]
public class BaseAI : MonoBehaviour
{
    public EntityController controller;


    public Vector3 Target; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EntityController>();
    }

    // Update is called once per frame
    void Update()
    {
       // MoveToPositionDumb(Target); 
    }

    protected void MoveToPositionDumb(Vector3 position)
    {
        var distance = position - transform.position;

        controller.Distance = distance;
    }


    protected bool CanSee(GameObject other)
    {
        var hit = Physics2D.Raycast(transform.position, other.transform.position - transform.position, controller.attributes.VisionDistance);
        if (hit.transform?.gameObject == other)
        { return true; }
        return false;
    }
}
