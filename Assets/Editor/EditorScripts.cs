using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorScripts : MonoBehaviour
{
    [MenuItem("ModCreation/CreateJsonFiles")]
    static void CreateBasicJson()
    {
        var components = new List<ComponentDefinition>();
        components.Add(new ComponentDefinition()
        {
            Name = "democomponent",
            Key = "A",
            Cost = new List<Resource>
            {
                new Resource()
                {
                    Type = "TestResource", Amount = 1
                }
            }, 
            Benefits = new List<ComponentBenefit>
            {
                new ComponentBenefit()
                {
                    AttributeType = AttributeTypes.HP,
                    Bonus = 1
                }
            }
        });
        FileLoader.SaveAsJson($"{FileLoader.ModPath}/Components.json", new ComponentFile()
        {
            ComponentDefinitions = components
        }); 

        var resources = new List<ResourceDefinition>()
        {
            new ResourceDefinition()
            {
                Color = Color.white,
                Name = "TestResource", Weight = 1
            }
        };
        FileLoader.SaveAsJson($"{FileLoader.ModPath}/Resources.json", new ResourceFile()
        {
            definitions = resources
        });

    }
}
