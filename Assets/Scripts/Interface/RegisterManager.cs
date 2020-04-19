using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    private Therapeute therapeute;
    private User user;

    public GameObject loginScreen;
    public GameObject registerScreen;

    public Text loginData;
    public Text pswData;
    public Text confirmPswData;
    public Text nomData;
    public Text prenomData;
    public Text type;
    public Text errorLabel;

    public delegate bool Register(string nom, string prenom, string pseudo, string pwd);

    // Start is called before the first frame update
    void Start()
    {
        therapeute = GetComponent<Therapeute>();
        user = GetComponent<User>();
    }

    public void SendProfile()
    {
        string nom = nomData.text;
        string prenom = prenomData.text;
        string pseudo = loginData.text;
        string pwd = pswData.text;
        string confirmPwd = confirmPswData.text;

        if (pwd != confirmPwd)
        {
            errorLabel.text = "Erreur : les mots de passe ne correspondent pas";
        }
        else
        {
            Register register;
            if (type.text == "Patient")
                register = user.create_profile_light;
            else
                register = therapeute.create_profile;

            if (register(nom, prenom, pseudo, pwd))
            {
                loginScreen.SetActive(true);
                registerScreen.SetActive(false);
            }
            else
            {
                errorLabel.text = "Erreur : le profile n'a pas pu être créé";
            }
        }
    }
}
