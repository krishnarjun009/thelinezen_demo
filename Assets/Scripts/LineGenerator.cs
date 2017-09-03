using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour {

    //private LineRenderer Line;

    private float yAxisLength;

    public List<Transform> StandardWalls;
    public List<Transform> AnimatedWalls;

    private Dictionary<string, float> BoundValues;
    
	// Use this for initialization
	void Start () {

        BoundValues = new Dictionary<string, float>();

        yAxisLength = 0.0f;

        CalculateLocalBounds();

        //Initialize();

    }

    public void ResetLines()
    {
        foreach (Transform t in StandardWalls)
            t.gameObject.SetActive(false);
        yAxisLength = 0.0f;
    }

    public void Initialize()
    {
        int rand = Random.Range(0, StandardWalls.Count - 1);
        GameObject go = StandardWalls[12].gameObject;
        go.transform.position = new Vector3(0, yAxisLength, 0);

        yAxisLength += BoundValues[go.name] * 2 - 0.5f; 

        go.SetActive(true);

        GameObject go1 = StandardWalls[rand].gameObject;
        go1.transform.position = new Vector3(0, yAxisLength, 0);

        yAxisLength += BoundValues[go1.name] * 2 - 0.5f;

        go1.SetActive(true);
    }

    private void AddNewLine()
    {
        while(true)
        {
            // Taking random line path.. If there are more line paths,
            // game will be more randomness paths...
            // we can generate level wised paths like,
            // all even paths, odd paths, some predefined calculated number series paths
            int rand = Random.Range(0, StandardWalls.Count);
            GameObject go = StandardWalls[rand].gameObject;
            if (!go.activeInHierarchy)
            {
                go.transform.position = new Vector3(0, yAxisLength, 0);

                yAxisLength += BoundValues[go.name] * 2 - 0.5f;

                go.SetActive(true);

                break;
            }
        }
        
    }

    // This is required when Line Sets are not equal in height
    private void CalculateLocalBounds()
    {
        foreach (Transform t in StandardWalls)
        {
            Bounds bounds = new Bounds(t.position, Vector3.zero);

            foreach (Renderer renderer in t.GetComponentsInChildren<Renderer>())
            {
                bounds.Encapsulate(renderer.bounds);
            }

            Vector3 localCenter = bounds.center - t.position;
            bounds.center = localCenter;

            if (!BoundValues.ContainsKey(t.name))
                BoundValues.Add(t.name, bounds.extents.y);
        }
    }

    private float CalculateLocalBounds(Transform t)
    {
        Bounds bounds = new Bounds(t.position, Vector3.zero);

        foreach (Renderer renderer in t.GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }

        Vector3 localCenter = bounds.center - t.position;
        bounds.center = localCenter;

        return bounds.extents.y * 2 - 0.5f;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("_Line"))
        {
            // Do setactive false
            //Debug.Log("I am in invicible");
            collision.transform.parent.parent.gameObject.SetActive(false);

            AddNewLine();
        }
    }
}
