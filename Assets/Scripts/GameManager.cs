using System.Collections;
using System.Collections.Generic;
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
}
