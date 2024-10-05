using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum AttributeTypes
{
    HP,
    Speed, 
    Defence, 
    Attack, 
    Vision, 
    MaxWeight, 
    Gather
}

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



    public string DNA; 

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
        if (CurrentHP < 0)
        {
            Destroy(gameObject);//kill it. 
        }
    }

    public void ApplyDNA(string dna)
    {
        MaxHP = MaxWeight = GatherRate = Speed = Attack = Defense = VisionDistance = 0;

        DNA = dna;
        var elements = dna.Split('|');
        foreach (var element in elements)
        {
            var component = GameManager.Instance.ComponentManager.GetComponentDefinition(element);
            if (component != null)
            {
                foreach (var benefit in component.Benefits)
                {
                    switch (benefit.AttributeType)
                    {
                        case AttributeTypes.HP:
                            MaxHP += benefit.Bonus; 
                            break;
                        case AttributeTypes.Speed:
                            Speed += benefit.Bonus;
                            break;
                        case AttributeTypes.Defence:
                            Defense += benefit.Bonus;
                            break;
                        case AttributeTypes.Attack:
                            Attack += benefit.Bonus;
                            break;
                        case AttributeTypes.Vision:
                            VisionDistance += benefit.Bonus;
                            break;
                        case AttributeTypes.MaxWeight:
                            MaxWeight += benefit.Bonus;
                            break;
                        case AttributeTypes.Gather:
                            GatherRate += benefit.Bonus;
                            break;
                    }
                }

            }

        }
        CurrentHP = MaxHP; 
    }

}
