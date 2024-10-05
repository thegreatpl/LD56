using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NestController : MonoBehaviour
{
    public List<Resource> Resources;

    // Start is called before the first frame update
    void Start()
    {
        Resources = new List<Resource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropOffResource(string type, float amount)
    {
        var res = Resources.FirstOrDefault(x => x.Type == type);
        if (res == null)
        {
            Resources.Add(GameManager.Instance.ResourceDefinitions.FirstOrDefault(x => x.Name == type).GetResourceFromDefinition());
            res = Resources.FirstOrDefault(x => x.Type == type);
        }
        res.Amount += amount; 
    }
}
