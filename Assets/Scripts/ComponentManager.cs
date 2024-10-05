using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    public List<ComponentDefinition> ComponentDefinitions;

    Dictionary<string, ComponentDefinition> _compdefinitions; 

    // Start is called before the first frame update
    void Start()
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
}
