using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEdge : MonoBehaviour
{
    public LineRenderer edge;
    public Transform NodeToAttatch;
    public Transform nodeParent;
    
    public int vertexCount = 100;

    public float deformCoef = 1;
    public Vector3 p0, p1, p2;
    private Vector3[] pointList;
    private Vector2 signos;

    public enum BD
    {
        iph_w, reclusorios, mp, repuve, plat_mexico, n_informativo, iph_m, otra
    }
    public BD opcion = BD.otra;

    private void Start()
    {
        ChangeLineColor(opcion);
    }
    // Start is called before the first frame update
   public void ChangeLineColor(BD opc)
    {
        switch (opc)
        {
            case BD.iph_w:
                edge.startColor = Color.blue;
                edge.endColor = edge.startColor;
                break;
            case BD.reclusorios:
                edge.startColor = Color.red;
                break;
            case BD.mp:
                edge.startColor = Color.magenta;
                break;
            case BD.repuve:
                edge.startColor = Color.gray;
                break;
            case BD.plat_mexico:
                edge.startColor = Color.green;
                break;
            case BD.n_informativo:
                edge.startColor = Color.white;
                break;
            case BD.iph_m:
                edge.startColor = Color.yellow;
                break;
            case BD.otra:
                edge.startColor = Color.cyan;
                break;
        }
        edge.endColor = edge.startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (NodeToAttatch)
        {
            pointList = new Vector3[vertexCount];
            edge.positionCount = vertexCount;
            int idx = 0;
            foreach (var point in pointList)
            {
                p0 = nodeParent.InverseTransformPoint(NodeToAttatch.position);
                p2 = this.transform.localPosition;
                p1 = (p0 + p2)/2;
                signos.y = Mathf.Sign(p0.y + p2.y);
                p1.y = signos.y *  Mathf.Abs(p0.y-p2.y);
                float t = idx / (float)vertexCount;
                pointList[idx] = CalculateLerpCurve(t, p0, p1, p2);
                idx++;
            }
            edge.SetPositions(pointList);
        }
    }
    private Vector3 CalculateQuadraticCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        // B(t) = (1-t)2 P0 + 2(1-t)t P1 + t2 P2 , 0 < t < 1
        float u = 1 - t;
        float uu = u * u;
        float tt = t * t;

        Vector3 point = uu * p0 + 2 * u * t * p1 + tt * p2;
        return point;
    }
    private Vector3 CalculateLerpCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        var line1 = Vector3.Lerp(p0, p1, t);
        var line2 = Vector3.Lerp(p1, p2, t);
        var bezier = Vector3.Lerp(line1, line2, t);
        return bezier;
    }
}
