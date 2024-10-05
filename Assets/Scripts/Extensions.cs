using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public static partial class Extensions
{
    public static Vector3 FromVector2(Vector2 vector)
    {
        return new Vector3(vector.x, vector.y); 
    }
}

