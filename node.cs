using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node
{
    public string name;
    public int distance = int.MaxValue;

    public LinkedList<node> shortestPath;

    public Dictionary<node, int> adjacentNodes;


    public node(string name)
    {
        this.name = name;
    }



    public void addDestination(node destination, int distance)
    {
        adjacentNodes.Add(destination, distance);
    }

    public void setDistance(int distance)
    {
        this.distance = distance;
    }

    public void setShortestPath(LinkedList<node> path)
    {
        this.shortestPath = path;
    }  
}
