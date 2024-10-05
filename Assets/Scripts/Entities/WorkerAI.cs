using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkerAI : BaseAI
{
    protected enum WorkerState
    {
        Gathering, 
        Returing
    };

    protected WorkerState workerState; 

    public Vector3 WanderTarget; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<EntityController>();
        attributes = GetComponent<BaseAttributes>();
        workerState = WorkerState.Gathering;
    }

    // Update is called once per frame
    void Update()
    {
        switch (workerState)
        {
            case WorkerState.Gathering:
                if (attributes.CurrentWeight >= attributes.MaxWeight)
                    workerState = WorkerState.Returing; 

                Gather();
                break;
            case WorkerState.Returing:
                if (attributes.CurrentWeight <=0)
                    workerState= WorkerState.Gathering; 

                ReturnToNest();
                break;
        }
    }

    void Gather()
    {
        var nodes = SeeObjectsOfLayer(6); //find all nearby resource nodes.

        if (nodes.Length > 0)
        {
            WanderTarget = Vector3.zero;
            var chosen = nodes.OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).First(); 
            MoveToPositionDumb(chosen.transform.position);
        }
        else
        {
            if (WanderTarget == Vector3.zero || Vector3.Distance(WanderTarget, transform.position) < 0.5f)
            {
                WanderTarget = transform.position.RandomLocationInRadius(attributes.VisionDistance * 2);
            }               
            MoveToPositionDumb(WanderTarget);
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //if is a resource. 
        {
            if (attributes.CurrentWeight >= attributes.MaxWeight)
                return;

            var NodeScript = collision.gameObject.GetComponent<ResourceNodeScript>();
            if (!attributes.Cargo.ContainsKey(NodeScript.Type))
            {
                attributes.Cargo.Add(NodeScript.Type, NodeScript.GetResource());
            }
            var weightToGather
                = attributes.CurrentWeight + attributes.GatherRate > attributes.MaxWeight ?
                attributes.MaxWeight = attributes.CurrentWeight : attributes.GatherRate;

            var amountToGather = NodeScript.ResourceDefinition.Weight * weightToGather;

            attributes.Cargo[NodeScript.Type].Amount += NodeScript.TakeResource(amountToGather);
        }
        if (collision.gameObject.layer == 7)
        {
            if (attributes.CurrentWeight > 0)
            {
                var nest = collision.gameObject.GetComponent<NestController>();
                //check if friendly nest here. 

                var weightToDrop = attributes.CurrentWeight - attributes.GatherRate > 0 ?
                    attributes.GatherRate : attributes.CurrentWeight;

                var cargoToDrop = attributes.Cargo.FirstOrDefault(x => x.Value.Amount > 0).Value;

                var amountToDrop = weightToDrop * cargoToDrop.IndividualWeight;
                if (amountToDrop > cargoToDrop.Amount)
                    amountToDrop = cargoToDrop.Amount;
                cargoToDrop.Amount -= amountToDrop;
                nest.DropOffResource(cargoToDrop.Type, amountToDrop);
                attributes.ResourcedDelivered += amountToDrop;

            }
        }
    }
}
