using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoints : MonoBehaviour
{

    // Indicate if the checkpoint is activated
    public bool activated = true;

    // List with all checkpoint objects in the scene
    private static Checkpoint[] checkPoints;

    public int numberpoints;

    public int currentCheckPoint = 0;

    [SerializeField]
    private Text objectifCube;

    // Start is called before the first frame update
    void Start()
    {
        // We search all the checkpoints in the current scene
        checkPoints = GetComponentsInChildren<Checkpoint>();
        foreach (Checkpoint cp in checkPoints)
        {
            cp.gameObject.SetActive(false);
        }
        checkPoints[currentCheckPoint].gameObject.SetActive(true);
        numberpoints = checkPoints.Length;
        objectifCube.gameObject.gameObject.SetActive(true);
    }

     public void NextCheckpoint()
    {
        checkPoints[currentCheckPoint].gameObject.SetActive(false);
        currentCheckPoint++;
        if (currentCheckPoint<=numberpoints-1)
        {
            checkPoints[currentCheckPoint].gameObject.SetActive(true);
        }
        else
        {
            objectifCube.gameObject.SetActive(false);
        }

    }
}
