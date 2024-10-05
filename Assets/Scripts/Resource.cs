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

    public override bool Equals(object obj)
    {
        return this.ToString() == obj.ToString();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Type;
    }

    public static bool operator ==(Resource a, Resource b)
    {
        return a?.Type == b?.Type; 
    }

    public static bool operator !=(Resource a, Resource b) { return !(a == b); }
}

