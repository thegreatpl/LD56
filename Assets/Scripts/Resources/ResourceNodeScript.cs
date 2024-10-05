using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNodeScript : MonoBehaviour
{
    public ResourceDefinition ResourceDefinition;


    public Resource Resource; 

    public string Type { get { return ResourceDefinition.Name; } }

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

    public Resource GetResource()
    {
        return new Resource()
        {
            Type = ResourceDefinition.Name,
            IndividualWeight = ResourceDefinition.Weight,
            Amount = 0
        };
        
    }

    public void AddResources(float amount)
    {   
        Resource.Amount += amount;  
    }

    public float TakeResource(float amount)
    {
        if (Resource.Amount < amount)
        {
            var toTake = Resource.Amount; 
            Resource.Amount = 0;
            return toTake;
        }

        Resource.Amount -= amount;
        return amount;
    }
}
