using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    private Transform target;

    public int numberwaypoint;
    public int waypointIndex = 0;

    private bool show = false;


    void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
        foreach (var item in points)
        {
            item.GetComponent<Renderer>().enabled = show;
            // ou item.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        numberwaypoint = points.Length;
        target = points[0];
        target.GetComponent<Renderer>().enabled = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            Debug.Log("collision détectée");
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= points.Length - 1)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            return;
        }
        target.gameObject.SetActive(false);
        waypointIndex++;
        target = points[waypointIndex];
        target.GetComponent<Renderer>().enabled = true;
    }
}
