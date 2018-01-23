using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpNeat.Phenomes;

using SharpNeat.Genomes.Neat;
using System.Xml;

public class PipoCubeController : UnitController
{
    public int raysPerEye;
    public float eyesPhi;
    public float eyesDistance;
    public float speed;
    public float rotSpeed;
    public int explorationNeeded;
    public int soundNeeded;
    public int soundSensibility;
    private float elapsedTime;
    public Material deadMaterial;
    public Material searchingMat;
    public Material soundSearchMat;

    private List<Eye> eyes;

    /* Fitness */
    private GameObject player;
    private float time;
    private int steps;
    private int lastExploredCount;
    private bool dead;
    private HashSet<Vector2> explored;

    /* Sound */
    private GameObject generator;
    private bool soundFound;
    private bool searchingSound;
    private float timeTook;
    private float timeElapsed;
    public float soundDuration;
    private float totalDist;
    private Vector3 initPos;

    private float totalAngle;

    /* SharpNeat */
    private bool isRunning;
    private IBlackBox box;

    private void Start()
    {
        initPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        explored = new HashSet<Vector2>();
        time = 0;
        steps = 0;
        totalDist = 0;
        totalAngle = 0;
        lastExploredCount = 0;
        elapsedTime = 0;
        dead = false;
        soundFound = false;
        searchingSound = false;
        //isRunning = false;
        eyes = new List<Eye>();
        generator = GameObject.FindGameObjectWithTag("noise");
        generator.GetComponent<NoiseTestGenerator>().RandomPos();
        //transform.position = new Vector3(Random.Range(minX * 0.9f, maxX * 0.9f), 2, Random.Range(minZ * 0.9f, maxZ * 0.9f));
        //player = GameObject.FindGameObjectWithTag("player");
        //player.GetComponent<PlayerTestController>().RandomPos();

        foreach (Transform obj in transform)
        {
            if (obj.name.Equals("eye")) eyes.Add(new Eye(raysPerEye, eyesPhi, eyesDistance, obj));
        }

        //ActivateFromFile();
    }

    private void ActivateFromFile()
    {
        NeatGenome genome = null;
        SimpleExperiment experiment = new SimpleExperiment();
        XmlDocument xmlConfig = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load("experiment.config");
        xmlConfig.LoadXml(textAsset.text);

        experiment.Initialize("Tmp Experiment", xmlConfig.DocumentElement, 8 + 2, 1);

        string champFileSavePath = Application.persistentDataPath + "/car_movement.champ.xml";
        using (XmlReader xr = XmlReader.Create(champFileSavePath))
            genome = NeatGenomeXmlIO.ReadCompleteGenomeList(xr, false, (NeatGenomeFactory)experiment.CreateGenomeFactory())[0];

        var genomeDecoder = experiment.CreateGenomeDecoder();
        box = genomeDecoder.Decode(genome);
    }

    private void ProcessSound(ISignalArray inputArr, int offset)
    {
        Vector3 dir = generator.transform.position - transform.position;
        float value = Mathf.Atan2(dir.x, dir.z);
        float step = 2 * Mathf.PI / soundSensibility;

        /*for (int i = 0; i < soundSensibility; ++i)
        {
            float min = (-1) * Mathf.PI + i * step;
            float max = min + step;
            inputArr[offset + i] = ((value <= max) && (value >= min)) ? 1 : 0;
        }*/
        //inputArr[offset + 0] = (value > 0) ? value / +Mathf.PI : 0;
        //inputArr[offset + 1] = (value < 0) ? value / -Mathf.PI : 0;
        float angle = Vector3.Angle(dir, transform.forward);
        Vector3 cross = Vector3.Cross(dir, transform.forward);
        if (cross.y < 0) angle = -angle;
        inputArr[offset + 0] = (angle > 0) ? 1 : 0;
        inputArr[offset + 1] = (angle < 0) ? 1 : 0;
    }

    private bool done1 = false;
    private bool done2 = false;
    private void FixedUpdate()
    {
        if (dead) return;

        ISignalArray inputArr = box.InputSignalArray;

        /*int start = 0;
        foreach (Eye eye in eyes)
        {
            eye.SetFollow((explored.Count > explorationNeeded) && !searchingSound);
            List<double> rays = eye.Update();

            for (int i = 0; i < rays.Count; i += 2)
            {
                inputArr[start + i + 0] = (float)rays[i + 0];
                //inputArr[i + start + 1] = (float)rays[i + 1]; este sería el +1 y el ed abajo el +2. Hay que reactivar el comentario en Eye.cs
                inputArr[start + i + 1] = (float)rays[i + 1];
            }
        }*/

        ProcessSound(inputArr, 0);

        box.Activate();
        ISignalArray outputArr = box.OutputSignalArray;

        float rotationR = (float)outputArr[0];
        float rotationL = (float)outputArr[1];

        if (rotationR > rotationL)
            transform.Rotate(Vector3.up, rotationR * rotSpeed);
        else
            transform.Rotate(Vector3.up, rotationL * -rotSpeed);

        //transform.position += transform.forward * Time.fixedDeltaTime * speed;

        totalDist += Vector3.Distance(transform.position, generator.transform.position);
        totalAngle += Vector3.Angle(transform.forward, generator.transform.position - transform.position);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, transform.position + transform.forward.normalized * 12);
        steps++;
    }

    public override void Stop()
    {
    }

    public override void Activate(IBlackBox box)
    {
        this.box = box;
    }

    public override float GetFitness()
    {
        /*float maxD = Vector3.Distance(initPos, generator.transform.position);
        float avgD = (totalDist / steps);
        float fitness = (1 - avgD / maxD) * 100;
        return (fitness < 0) ? 0 : fitness;*/
        float avgA = (totalAngle / steps);
        return 360 - Mathf.Abs(avgA);
        //return soundFound ? (timeTook - soundDuration) : 0;
    }

    private void Kill()
    {
        dead = true;
        GetComponent<Renderer>().material = deadMaterial;
    }

    void OnCollisionEnter(Collision collision)
    {
    }
}
