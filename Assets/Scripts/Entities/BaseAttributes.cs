using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseAttributes : MonoBehaviour
{

    public int MaxHP;

    public float Speed;

    public int CurrentHP;

    public float Defense;

    public float VisionDistance;

    public float MaxWeight; 

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
