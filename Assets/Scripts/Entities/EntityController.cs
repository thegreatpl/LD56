using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseAttributes))]
public class EntityController : MonoBehaviour
{
    public BaseAttributes attributes;

    public Vector3 Distance;

    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<BaseAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Distance != Vector3.zero)
        {
            transform.position += Vector3.ClampMagnitude(Distance, attributes.Speed); 
        }
    }
}
