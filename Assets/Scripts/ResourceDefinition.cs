using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class ResourceDefinition
{
    public string Name;

    public Color Color;

    public float Weight; 


    public Resource GetResourceFromDefinition()
    {
        return new Resource()
        {
            Type = Name,
            IndividualWeight = Weight,
            Amount = 0
        };
    }
}
