using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject guiLoginRegisterPart;
    [SerializeField]
    GameObject guiMainPart;

    [SerializeField]
    TMPro.TMP_InputField inputLogin;
    [SerializeField]
    TMPro.TMP_InputField inputPassword;
    [SerializeField]
    TMPro.TMP_Text textError;

    [SerializeField]
    TMPro.TMP_Text textWelcome;
    [SerializeField]
    TMPro.TMP_Text textWinrate;

    public void callback_NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void callback_LogOut()
    {
        guiMainPart.SetActive(false);
        guiLoginRegisterPart.SetActive(true);
    }

    public void callback_Exit()
    {
        Application.Quit();
    }
    
    public void callback_Login()
    {
        textError.text = "";

        string[] user = Database.GetUser(inputLogin.text);
        if (user != null)
        {
            if(user[0] == inputLogin.text && user[1] == inputPassword.text)
            {
                LogedUser.UserName = inputLogin.text;
                textWelcome.text = "Welcome back " + inputLogin.text + "!";

                int victories = Database.GetUsersVictoriesCount(inputLogin.text);
                int defeats = Database.GetUsersDefeatsCount(inputLogin.text);

                int allGames = victories + defeats;

                int winrate = (int)(allGames > 0 ? ((float)victories / allGames) * 100 : 0);

                textWinrate.text = winrate.ToString() + "%";

                inputLogin.text = "";
                inputPassword.text = "";

                guiLoginRegisterPart.SetActive(false);

                guiMainPart.SetActive(true);
            }
            else
            {
                textError.text = "Wrong login or password";
            }
        }
    }

    public void callback_Register()
    {
        textError.text = "";

        if (Database.TryToAddUser(inputLogin.text, inputPassword.text))
        {
            LogedUser.UserName = inputLogin.text;
            textWelcome.text = "Welcome back " + inputLogin.text + "!";

            inputLogin.text = "";
            inputPassword.text = "";

            guiLoginRegisterPart.SetActive(false);

            guiMainPart.SetActive(true);
        }
        else
        {
            textError.text = "User with that login already exists";
        }
    }

    private void Awake()
    {
        Database.CreateDB();
    }

}
