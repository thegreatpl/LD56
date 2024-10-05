using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class ComponentDefinition
{
    public string Name;

    public string Key;

    public List<Resource> Cost; 

    public List<ComponentBenefit> Benefits;

}

[Serializable]
public class ComponentBenefit
{
    public AttributeTypes AttributeType;

    public float Bonus; 
}

