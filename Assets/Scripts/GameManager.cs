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
        ComponentManager = GetComponent<ComponentManager>();
        DontDestroyOnLoad(gameObject);


        StartCoroutine(LoadData("Default1")); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPrefab(string name)
    {
        return PrefebDefinitions.FirstOrDefault(x => x.Name == name)?.Prefab;
    }


    IEnumerator LoadData(string ModFolder)
    {
        FileLoader.ModPath = $"{Application.streamingAssetsPath}/{ModFolder}";

        ResourceDefinitions = FileLoader.LoadJson<ResourceFile>($"{FileLoader.ModPath}/Resources.json").definitions;

        yield return null;
        ComponentManager.ComponentDefinitions = FileLoader.LoadJson<ComponentFile>($"{FileLoader.ModPath}/Components.json").ComponentDefinitions; 
        ComponentManager.Reload();
        yield return null;

        yield return StartCoroutine(StartNewMap()); 
    }


    IEnumerator StartNewMap()
    {
        yield return null;
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            var gen = Instantiate(GetPrefab("ResourceGenerator"));
            gen.transform.position = transform.position.RandomLocationInRadius(30); 
            yield return null;
            var gscr = gen.GetComponent<ResourceGeneratorScript>();
            gscr.ResourceDefinition = ResourceDefinitions.GetRandom(); 
            gscr.SpawnDistance = Random.Range(5, 10);
            gscr.MaxNodes = Random.Range(1, 15);
            gscr.SpawnRate = Random.Range(500, 10000);
            gscr.MinResourceAmount = Random.Range(5, 10);
            gscr.MaxResourceAmount = gscr.MinResourceAmount + Random.Range(1, 15);
        }


        yield return null; 
        var nest = Instantiate(GetPrefab("Nest"));
        nest.transform.position = transform.position.RandomLocationInRadius(6); 
        var nestcomp = nest.GetComponent<NestController>();
        yield return null;
        nestcomp.SpawnWorker("H|L|E|E|M|G", true); 
    }
}
