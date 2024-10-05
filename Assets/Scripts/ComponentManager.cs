using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    public List<ComponentDefinition> ComponentDefinitions;

    Dictionary<string, ComponentDefinition> _compdefinitions; 

    // Start is called before the first frame update
    void Start()
    {
        Reload(); 
    }

    public void Reload()
    {
        _compdefinitions = new Dictionary<string, ComponentDefinition>();
        foreach (var definition in ComponentDefinitions)
        {
            _compdefinitions.Add(definition.Key, definition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ComponentDefinition GetComponentDefinition(string key)
    {
        return _compdefinitions[key];
    }

    public List<Resource> CostOfDNA(string DNA)
    {
        var split = DNA.Split('|');

        var result = new List<Resource>();

        foreach (var item in split)
        {
            if (!_compdefinitions.ContainsKey(item)) 
                continue;
            foreach (var cost in _compdefinitions[item].Cost)
            {
                if (!result.Contains(cost))
                {
                    result.Add(new Resource()
                    {
                        Type = cost.Type, 
                        Amount = cost.Amount, 
                        IndividualWeight = cost.IndividualWeight//might not be filling this in. 
                    });
                }
                else
                {
                    result.First(x => x == cost).Amount+= cost.Amount;
                }
            }
        }

        return result;
    }

    public List<string> GetKeys()
    {
        return _compdefinitions.Keys.ToList();  
    }
}
