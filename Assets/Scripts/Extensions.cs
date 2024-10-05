using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public static partial class Extensions
{
    public static Vector3 FromVector2(Vector2 vector)
    {
        return new Vector3(vector.x, vector.y); 
    }

    /// <summary>
    /// Gets a random location in the area around the location given. 
    /// </summary>
    /// <param name="location"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    public static Vector3 RandomLocationInRadius(this Vector3 location, float radius)
    {
        return FromVector2(UnityEngine.Random.insideUnitCircle * radius) + location; 
    }
}

