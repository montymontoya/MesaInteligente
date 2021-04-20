using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGraph<TnodeValue>
{

    public MyGraph()
    {
        nodes = new List<MyNode<TnodeValue>>();
        edges = new List<MyEdge>();
    }

    public List<MyNode<TnodeValue>> nodes { get; private set; }
    public List<MyEdge> edges { get; private set; }
}

public class MyNode<TnodeValue>
{
    public Color edgeColor
    {
        get; set;
    }
    public TnodeValue value
    {
        get;
        set;
    }
}

public class MyEdge
{

}
