using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{

    private static bool toss;

    public static bool Toss 
    {
        get 
        {
            return toss;
        }
        set 
        {
            toss = value;
        }
    }

    // public static int Deaths 
    // {
    //     get 
    //     {
    //         return deaths;
    //     }
    //     set 
    //     {
    //         deaths = value;
    //     }
    // }

    // public static int Assists 
    // {
    //     get 
    //     {
    //         return assists;
    //     }
    //     set 
    //     {
    //         assists = value;
    //     }
    // }

    // public static int Points 
    // {
    //     get 
    //     {
    //         return points;
    //     }
    //     set 
    //     {
    //         points = value;
    //     }
    // }


}
