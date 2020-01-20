using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graph
{
    public LinkedList<node> nodes;

    public void addNode(node nodeA)
    {
        nodes.AddLast(nodeA);
    }

}
