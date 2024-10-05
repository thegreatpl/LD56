using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ComponentManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ComponentManager ComponentManager;

    public List<PrefebDefinition> PrefebDefinitions;


    public List<ResourceDefinition> ResourceDefinitions;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
        ComponentManager componentManager = GetComponent<ComponentManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPrefab(string name)
    {
        return PrefebDefinitions.FirstOrDefault(x => x.Name == name)?.Prefab;
    }
}
