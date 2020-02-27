using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLabelDisplay : MonoBehaviour
{
    public Text labelText;
    private int lvl = 1;   // Entier à modifier selon le niveau sélectionné

    // Update is called once per frame
    void Update()
    {
        labelText.text = "Niveau " + lvl;
    }
}
