using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private Therapeute therapeute;
    private User user;

    public GameObject loginScreen;
    public GameObject mainMenu;

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
            login = user.login;
        else
            login = therapeute.login;

        if (login(id, pwd))
        {
            errorLabel.text = "";
            loginScreen.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            errorLabel.text = "Erreur : identifiants incorrects";
        }
    }
}
