using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private Therapeute therapeute;
    private User user;

    private string pseudo;
    private bool patient; // true = patient, false = therapeute

    public GameObject loginScreen;
    public GameObject mainMenu;
    public GameObject therapeuteMenu;

    public Text loginData;
    public Text pswData;
    public Text type;
    public Text errorLabel;

    public delegate bool Login(string id, string pwd);

    // Start is called before the first frame update
    void Start()
    {
        therapeute = GetComponent<Therapeute>();
        user = GetComponent<User>();
    }

    public void SendLogin()
    {
        string id = loginData.text;
        string pwd = pswData.text;

        Login login;
        if (type.text == "Patient")
        {
            login = user.login;
            patient = true;
        }
        else
        {
            login = therapeute.login;
            patient = false;
        }

        if (login(id, pwd))
        {
            errorLabel.text = "";
            loginScreen.SetActive(false);
            if (patient)
                mainMenu.SetActive(true);
            else
                therapeuteMenu.SetActive(true);
        }
        else
        {
            errorLabel.text = "Erreur : identifiants incorrects";
        }
    }
}
