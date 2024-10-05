using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGeneratorScript : MonoBehaviour
{
    public GameObject ResourceNodePrefab;


    public List<ResourceNodeScript> ResourceNodes;

    public int MaxNodes;

    public int SpawnRate;

    public float SpawnDistance;

    public int MaxResourceAmount;

    public int MinResourceAmount; 

    public ResourceDefinition ResourceDefinition;

    protected int currentSpawnCount;

    // Start is called before the first frame update
    void Start()
    {
        ResourceNodePrefab = GameManager.Instance.GetPrefab("ResourceNode"); 
        ResourceNodes = new List<ResourceNodeScript>();

        currentSpawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ResourceNodes.RemoveAll(x=> x ==null);

        if (ResourceNodes.Count < MaxNodes)
        {
            if (currentSpawnCount <= 0)
            {
                //spawn in new node. 
                var newNode = Instantiate(ResourceNodePrefab);
                newNode.transform.position = Extensions.FromVector2(Random.insideUnitCircle * SpawnDistance) + transform.position;
                var nodeScript = newNode.GetComponent<ResourceNodeScript>();
                nodeScript.SetDefinition(ResourceDefinition);
                nodeScript.AddResources(Random.Range(MinResourceAmount, MaxResourceAmount));
                ResourceNodes.Add(nodeScript);

                currentSpawnCount = SpawnRate;
            }

            currentSpawnCount--;
        }
    }
}
