using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfos : MonoBehaviour
{
    public Text objectif;
    public Text description;
    private int lvlIndex;

    public void Start()
    {
        lvlIndex = 1;
    }

    public void SelectLevel(int lvl)
    {
        lvlIndex = lvl;

        if (lvlIndex == 1)
        {
            objectif.text = "Traversez le pont suspendu, et regardez les sphères dans le paysage";
            description.text = "Un pont suspendu entre deux immeubles";
        }
        else if (lvlIndex == 2)
        {
            objectif.text = "";
            description.text = "Une montagne enneigée";
        }
    }

    public void RunLevel()
    {
        if (lvlIndex == 1)
            SceneManager.LoadScene("City");
        else if (lvlIndex == 2)
            SceneManager.LoadScene("Mountain");
    }
}
