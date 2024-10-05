using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public List<PrefebDefinition> PrefebDefinitions;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
        
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
