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
    public Vector3 p0, p1, p2, p3;
    private Vector3[] pointList;
    private Vector2 signos;

    // Start is called before the first frame update
    public void ChangeLineColor(Color c1, Color c2)
    {

        edge.startColor = c1;
        edge.endColor = c2;

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
                p1 = (p0 + p2)/4;
                p3 = p1 * 3;
                signos.y = Mathf.Sign(p0.y + p2.y);
                p1.y = signos.y *  Mathf.Abs(p0.y-p2.y);
                float t = idx / (float)vertexCount;
                //                pointList[idx] = CalculateLerpCurve(t, p0, p1, p2);
                //                pointList[idx] = CalculateQuadraticCurve(t, p0, p1, p2);
                pointList[idx] = GetBezierPoint(t, p0, p1, p2,p3);
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

    public Vector3 GetBezierPoint(float t, Vector3 p1, Vector3 c1, Vector3 p2, Vector3 c2, int derivative = 0)//(t,p0,p1,p3,p2)
    {
        derivative = Mathf.Clamp(derivative, 0, 2);
        float u = (1f - t);
        if (derivative == 0)
        {
            return u * u * u * p1 + 3f * u * u * t * c1 + 3f * u * t * t * c2 + t * t * t * p2;

        }
        else if (derivative == 1)
        {
            return 3f * u * u * (c1 - p1) + 6f * u * t * (c2 - c1) + 3f * t * t * (p2 - c2);

        }
        else if (derivative == 2)
        {
            return 6f * u * (c2 - 2f * c1 + p1) + 6f * t * (p2 - 2f * c2 + c1);

        }
        else
        {
            return Vector3.zero;
        }
    }
}
