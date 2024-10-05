using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Resource
{
    public string Type;

    public float Amount;

    public float IndividualWeight;

    public float CurrentWeight { get { return IndividualWeight * Amount; } }
}

