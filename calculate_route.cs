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
        routeArray.Add(positional_data.position_4);
        routeArray.Add(positional_data.position_5);

        return routeArray;
    }

    public static graph calculateShortestPathFromSource(graph dGraph, node source)
    {
        source.setDistance(0);

        LinkedList<node> settledNodes = new LinkedList<node>();
        LinkedList<node> unsettledNodes = new LinkedList<node>();

        unsettledNodes.AddLast(source);

        while (unsettledNodes.Count != 0)
        {
            node currentNode = getLowestDistanceNode(unsettledNodes);
            unsettledNodes.Remove(currentNode);
            foreach(KeyValuePair<node, int> entry in currentNode.adjacentNodes)
            {
                node adjacentNode = entry.Key;
                if (!settledNodes.Contains(adjacentNode))
                {
                    calculateMinimumDistance(adjacentNode, entry.Value, currentNode);
                    unsettledNodes.AddLast(adjacentNode);
                }
            }

            settledNodes.AddLast(currentNode);
        }

        return dGraph;
    }

    public static node getLowestDistanceNode(LinkedList<node> unsettledNodes)
    {
        node lowestDistanceNode = null;
        int lowestDistance = int.MaxValue;

        LinkedListNode<node> currentNode = unsettledNodes.First;


        while(currentNode != null)
        {
            int nodeDistance = currentNode.Value.distance;
            if (nodeDistance < lowestDistance)
            {
                lowestDistance = nodeDistance;
                lowestDistanceNode = currentNode.Value;
            }

            currentNode = currentNode.Next;
        }

        return lowestDistanceNode;
    }

    public static void calculateMinimumDistance(node evaluationNode, int edgeWeight, node sourceNode)
    {
        int sourceDistance = sourceNode.distance;

        if(sourceDistance + edgeWeight < evaluationNode.distance)
        {
            evaluationNode.setDistance(sourceDistance + edgeWeight);
            LinkedList<node> shortestPath = new LinkedList<node>(sourceNode.shortestPath);
            shortestPath.AddLast(sourceNode);
            evaluationNode.setShortestPath(shortestPath);
        }
    }
}
