using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseAttributes : MonoBehaviour
{

    public float MaxHP;

    public float Speed;

    public float CurrentHP;

    public float Defense;

    public float Attack; 

    public float VisionDistance;

    public float MaxWeight;

    /// <summary>
    /// how fast this entity collects resources. 
    /// </summary>
    public float GatherRate; 

    public float CurrentWeight 
    { 
        get
        {
            return Cargo.Values.Select(x => x.CurrentWeight).Sum();
        }
    }

    public Dictionary<string, Resource> Cargo; 



    // Start is called before the first frame update
    void Start()
    {
        Cargo = new Dictionary<string, Resource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
