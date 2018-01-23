using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye {

    private int raysPerEye;
    private float eyePhi;
    private List<Ray> rays;
    private Transform obj;
    private float distance;
    private bool debug;
    private bool follow;

    private class Ray
    {
        public float x;
        public float y;
        public float distance;
    }

    public Eye(int raysPerEye, float eyePhi, float distance, Transform obj, bool debug = true)
    {
        this.obj = obj;
        this.distance = distance;
        this.eyePhi = eyePhi;
        this.raysPerEye = raysPerEye;
        this.rays = new List<Ray>();
        this.debug = debug;
        this.follow = false;
        GenerateRays();
    }

    public void SetFollow(bool follow)
    {
        this.follow = follow;
    }

    public List<double> Update()
    {
        List<double> results = new List<double>();
        
        foreach (Ray ray in rays)
        {
            RaycastHit hitInfo;
            Vector3 from = obj.position;
            //Vector3 to   = obj.position + obj.forward * distance + obj.up * ray.y + obj.right * ray.x;
            Vector3 to = obj.position + obj.forward * ray.x + obj.right * ray.y;

            bool hit = Physics.Linecast(from, to, out hitInfo);
            string tag = (hitInfo.transform == null) ? "" : hitInfo.transform.gameObject.tag;
            
            results.Add(hit ? hitInfo.distance / ray.distance : 1);
            
            results.Add((tag.Equals("Player") && follow) ? 1 : 0);
            results.Add(tag.Equals("Wall") ? 1 : 0);

            if (debug)
            {
                if (tag.Equals("Player"))
                    Debug.DrawLine(from, to, Color.yellow);
                else if (tag.Equals("Wall"))
                    Debug.DrawLine(from, to, Color.red);
                else
                    Debug.DrawLine(from, to, Color.white);
            }
        }

        return results;
    }

    private void GenerateRays()
    {
        float step = eyePhi / (raysPerEye - 1);
        float angle = eyePhi / -2;

        for (int i = 0; i < raysPerEye; ++i)
        {
            Ray ray = new Ray();
            ray.y = distance * Mathf.Sin(angle);
            ray.x = distance * Mathf.Cos(angle);
            ray.distance = distance;
            angle += step;
            rays.Add(ray);
        }

        /*float alpha = 1.6180339887f; // Golden Ratio
        
        for (int k = 1; k < (raysPerEye + 1); ++k)
        {
            float r = Mathf.Sqrt(k - 0.5f) / Mathf.Sqrt(raysPerEye - 0.5f);
            float beta = 6.2831853f * k / (alpha * alpha);
            Ray ray = new Ray();
            ray.x = r * Mathf.Cos(beta) * Mathf.Tan(eyePhi / 2) * distance;
            ray.y = r * Mathf.Sin(beta) * Mathf.Tan(eyePhi / 2) * distance;
            ray.distance = Vector3.Distance(Vector3.zero, obj.forward * distance + obj.up * ray.y + obj.right * ray.x);
            rays.Add(ray);
        }*/
    }
}
