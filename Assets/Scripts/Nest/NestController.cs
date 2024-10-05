using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NestController : MonoBehaviour
{
    public List<Resource> Resources;


    public List<BaseAttributes> Ants; 


    public GameObject WorkerPrefab;


    public int SpawnRate;

    protected int _currentSpawnRate;


    public float MutationChance; 

    // Start is called before the first frame update
    void Start()
    {
        Resources = new List<Resource>();
        WorkerPrefab = GameManager.Instance.GetPrefab("Worker"); 
        Ants = new List<BaseAttributes>();
        _currentSpawnRate = SpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        Ants.RemoveAll(x => x == null);

        if (_currentSpawnRate <= 0)
        {
            MutateAndSpawn();
            
        }
        else
            _currentSpawnRate--;
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


    void MutateAndSpawn()
    {
        var dna = Ants.OrderBy(x => x.ResourcedDelivered).FirstOrDefault()?.DNA;

        if (Random.Range(0, 1.0f) < MutationChance)
        {
            var chance = Random.value;
            var strands = dna.Split('|'); 
            if (chance < 0.33f)
            {
                //change a strand
                var changed = Random.Range(0, strands.Length - 1);
                strands[changed] = GameManager.Instance.ComponentManager.GetKeys().GetRandom();
                dna = ""; 
                foreach (var key in strands) 
                    dna += "|" + key; 
            }
            else if (chance < 0.66f)
            {
                //add a strand. 
                dna += "|"+ GameManager.Instance.ComponentManager.GetKeys().GetRandom(); 
            }
            else
            {
                //remove a strand. 
                var removed = Random.Range(0, strands.Length - 1);
                dna = ""; 
                for (int i = 0; i < strands.Length; i++)
                {
                    if (i == removed)
                        continue;
                    dna += "|" + strands[i]; 
                }
            }

            dna = dna.Trim('|'); 

        }
        if (SpawnWorker(dna))
            _currentSpawnRate = SpawnRate; 
    }

    public bool SpawnWorker(string dna, bool ignoreCosts = false)
    {
        //check to see if it can afford or not. 
        if (!ignoreCosts)
        {
            var costs = GameManager.Instance.ComponentManager.CostOfDNA(dna);
            foreach (var resource in costs)
            {
                if (!Resources.Contains(resource) || Resources.First(x => x == resource).Amount < resource.Amount)
                    return false;
            }
            foreach (var resource in costs)
            {
                Resources.First(x => x == resource).Amount -= resource.Amount;
            }
        }


        var newWorker = Instantiate(WorkerPrefab);
        newWorker.transform.position = transform.position;
        var attri = newWorker.GetComponent<BaseAttributes>();
        attri.ApplyDNA(dna);
        Ants.Add(attri);
        newWorker.GetComponent<BaseAI>().Nest = this; 
        return true; 
    }
}
