using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNodeScript : MonoBehaviour
{
    public ResourceDefinition ResourceDefinition;


    public Resource Resource; 

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().color = ResourceDefinition.Color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Resource.Amount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDefinition(ResourceDefinition definition)
    {
        ResourceDefinition = definition;
        Resource = new Resource()
        {
            Type = ResourceDefinition.Name,
            IndividualWeight = ResourceDefinition.Weight,
            Amount = 0
        };
        GetComponent<SpriteRenderer>().color = ResourceDefinition.Color;
    }

    public void AddResources(int amount)
    {   
        Resource.Amount += amount;  
    }
}
