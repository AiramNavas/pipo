using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpNeat.Phenomes;

using SharpNeat.Genomes.Neat;
using System.Xml;

/* Este script se encarga de gestionar la IA de los enemigos. En este momento,
solo permite el control de la vista */

public class CrawlerPipo : MonoBehaviour
{
    public int raysPerEye;
    public float eyesPhi;
    public float eyesDistance;
    public float speed;
    public float rotSpeed;

    private List<Eye> eyes;
    private HashSet<Vector2> explored;

    /* SharpNeat */
    private IBlackBox box;

    private void Start()
    {
        explored = new HashSet<Vector2>();
        eyes = new List<Eye>();

        foreach (Transform obj in transform) // Obtiene la posición de los ojos
        {
            if (obj.name.Equals("eye")) eyes.Add(new Eye(raysPerEye, eyesPhi, eyesDistance, obj));
        }

        ActivateFromFile();
    }

		// Carga la red neuronal desde archivo
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
        int offset = 0;
        Vector2 gridPos = new Vector2(Mathf.Round(transform.position.x / 3), Mathf.Round(transform.position.z / 3));

				/********* INPUTS **********/
        ISignalArray inputArr = box.InputSignalArray;
        inputArr[offset++] = Random.Range(0, 2);
        inputArr[offset++] = explored.Contains(gridPos) ? 1 : -1;

        float minDist = 99999;
        foreach (Eye eye in eyes)
        {
            eye.SetFollow(true); // Indica que si detecte al jugador
            List<double> rays = eye.Update();

            for (int i = 0; i < rays.Count; i += 3)
            {
                inputArr[i + offset + 0] = (float)rays[i + 0]; // Distance
                inputArr[i + offset + 1] = (float)rays[i + 1]; // Player detected
                inputArr[i + offset + 2] = (float)rays[i + 2]; // Wall detected

                if ((rays[i + 1] == 1) && (rays[i + 0] < minDist))
                    minDist = (float)rays[i + 0];
            }
            offset += rays.Count;
        }

				/********* ACTIVATE **********/
        box.Activate();

				/********* OUTPUTS **********/
        ISignalArray outputArr = box.OutputSignalArray;

				// Cambia la función distancia para que no sea una función lineal (sino una sigmoide)
        minDist = (minDist < 0.9) ? (10f * minDist / Mathf.Sqrt(1f + 100f * minDist * minDist)) : 1;
        if (minDist < 0.2) minDist = 0;

				// El valor de la rotación, cambia la función para que se comporte no como lineal sino como una cúbica
        float rotation = (float)outputArr[0] * (float)outputArr[0] * (float)outputArr[0];

				/********* MOVEMENT **********/
        transform.Rotate(Vector3.up, (rotation * 2 - 1) * rotSpeed);
        transform.position += transform.forward * Time.fixedDeltaTime * speed * minDist;

        explored.Add(gridPos);
    }
}
