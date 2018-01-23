using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpNeat.Phenomes;

using SharpNeat.Genomes.Neat;
using System.Xml;

public class CrawlerPipo : UnitController
{

    public int raysPerEye;
    public float eyesPhi;
    public float eyesDistance;
    public float speed;
    public float rotSpeed;
    public int followStartRange;
    private float elapsedTime;
    public Material deadMaterial;
    public Material searchingMat;

    private List<Eye> eyes;

    /* Fitness */
    private GameObject player;
    private float time;
    private int steps;
    private int lastExploredCount;
    private bool dead;
    private HashSet<Vector2> explored;

    /* SharpNeat */
    private bool isRunning;
    private IBlackBox box;

    private void Start()
    {
        explored = new HashSet<Vector2>();
        time = 0;
        steps = 0;
        lastExploredCount = 0;
        elapsedTime = 0;
        dead = false;
        //isRunning = false;
        eyes = new List<Eye>();
        //transform.position = new Vector3(Random.Range(minX * 0.9f, maxX * 0.9f), 2, Random.Range(minZ * 0.9f, maxZ * 0.9f));
        //player = GameObject.FindGameObjectWithTag("player");
        //player.GetComponent<PlayerTestController>().RandomPos();

        foreach (Transform obj in transform)
        {
            if (obj.name.Equals("eye")) eyes.Add(new Eye(raysPerEye, eyesPhi, eyesDistance, obj));
        }

        ActivateFromFile();
    }

    private void ActivateFromFile()
    {
        NeatGenome genome = null;
        SimpleExperiment experiment = new SimpleExperiment();
        XmlDocument xmlConfig = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load("experiment.config");
        xmlConfig.LoadXml(textAsset.text);

        experiment.Initialize("Tmp Experiment", xmlConfig.DocumentElement, 12 + 2, 1);

        string champFileSavePath = Application.persistentDataPath + "/explorer_follower.xml";
        using (XmlReader xr = XmlReader.Create(champFileSavePath))
            genome = NeatGenomeXmlIO.ReadCompleteGenomeList(xr, false, (NeatGenomeFactory)experiment.CreateGenomeFactory())[0];

        var genomeDecoder = experiment.CreateGenomeDecoder();
        box = genomeDecoder.Decode(genome);
    }

    private void Update()
    {
        
        if (dead) return;
        Vector2 gridPos = new Vector2(Mathf.Round(transform.position.x / 3), Mathf.Round(transform.position.z / 3));
        /*if (!isRunning)
        {
            foreach (Eye eye in eyes)
                eye.Update();
            return;
        }*/

        ISignalArray inputArr = box.InputSignalArray;
        inputArr[0] = Random.Range(0, 2);
        inputArr[1] = explored.Contains(gridPos) ? 1 : -1;
        //inputArr[1] = (elapsedTime / period) * 2f - 1f;

        int start = 2;
        bool behind = false;
        float minDist = 99999;
        foreach (Eye eye in eyes)
        {
            eye.SetFollow((explored.Count > followStartRange));
            List<double> rays = eye.Update();

            for (int i = 0; i < rays.Count; i += 3)
            {
                inputArr[i + start + 0] = (float)rays[i + 0];
                inputArr[i + start + 1] = (float)rays[i + 1];
                inputArr[i + start + 2] = (float)rays[i + 2];
                behind = rays[i + 1] == 1;
                if (behind && (rays[i + 0] < minDist))
                    minDist = (float)rays[i + 0];
            }
            start += rays.Count;
        }

        //
        box.Activate();
        ISignalArray outputArr = box.OutputSignalArray;

        minDist = (minDist < 0.9) ? (10f * minDist / Mathf.Sqrt(1f + 100f * minDist * minDist)) : 1;
        if (minDist < 0.2) minDist = 0;

        float rotation = (float)outputArr[0] * (float)outputArr[0] * (float)outputArr[0];

        transform.Rotate(Vector3.up, (rotation * 2 - 1) * rotSpeed);
        transform.position += transform.forward * Time.fixedDeltaTime * speed * minDist;

        if (behind)
            time += Time.fixedDeltaTime;

        explored.Add(gridPos);

        /*if (++steps == 200)
        {
            if (explored.Count == lastExploredCount)
                Kill();
            steps = 0;
            lastExploredCount = explored.Count;
        }*/
    }

    public override void Stop()
    {
        //isRunning = false;
    }

    public override void Activate(IBlackBox box)
    {
        this.box = box;
        //isRunning = true;
    }

    public override float GetFitness()
    {

        return (explored.Count > followStartRange) ? ((explored.Count - followStartRange) / 2 + followStartRange + time) : explored.Count;
        //return (time < 2) ? 0 : time;
    }

    private void Kill()
    {
        dead = true;
        GetComponent<Renderer>().material = deadMaterial;
    }

    void OnCollisionEnter(Collision collision)
    {

        /*if (collision.collider.tag.Equals("wall"))
            Kill();*/
    }

}
