using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]

public class Laser : MonoBehaviour
{
    private Transform goTransform;
    private LineRenderer lineRenderer;

    private Ray ray;
    private RaycastHit hit;

    private Vector3 inDirection;

    public int nReflections = 2;

    private int nPoints;

    void Awake()
    {
        goTransform = this.GetComponent<Transform>();
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    void Update()
    {
        nReflections = Mathf.Clamp(nReflections, 1, nReflections);
        ray = new Ray(goTransform.position, goTransform.forward);

        Debug.DrawRay(goTransform.position, goTransform.forward * 100, Color.magenta);

        nPoints = nReflections;
        lineRenderer.SetVertexCount(nPoints);
        lineRenderer.SetPosition(0, goTransform.position);

        for (int i = 0; i <= nReflections; i++)
        {
            if (i == 0)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 50))
                {
                    inDirection = Vector3.Reflect(ray.direction, hit.normal);
                    ray = new Ray(hit.point, inDirection);

                    Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                    Debug.DrawRay(hit.point, inDirection * 100, Color.magenta);

                    Debug.Log("Object name: " + hit.transform.name);

                    if (nReflections == 1)
                    {
                        lineRenderer.SetVertexCount(++nPoints);
                    }
                    lineRenderer.SetPosition(i + 1, hit.point);
                }
            }
            else
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 50))
                {
                    inDirection = Vector3.Reflect(inDirection, hit.normal);
                    ray = new Ray(hit.point, inDirection);

                    Debug.DrawRay(hit.point, hit.normal * 3, Color.blue);
                    Debug.DrawRay(hit.point, inDirection * 100, Color.magenta);

                    Debug.Log("Object name: " + hit.transform.name);

                    lineRenderer.SetVertexCount(++nPoints);
                    lineRenderer.SetPosition(i + 1, hit.point);
                }
            }
        }
    }
}