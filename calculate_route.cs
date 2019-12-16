using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculate_route
{
    public ArrayList routeArray;


    public ArrayList getRoute()
    {
        routeArray = new ArrayList();

        // get current position -> passende Position zum aktuellen Standort / Raum finden

        // get input -> gesuchter Raum
        // get final position (input) -> passende Position zum gesuchten Raum finden

        // get all nodes

        // add nodes to route / list

        routeArray.Add(positional_data.position_1);
        routeArray.Add(positional_data.position_2);
        routeArray.Add(positional_data.position_3);

        return routeArray;
    }
}
