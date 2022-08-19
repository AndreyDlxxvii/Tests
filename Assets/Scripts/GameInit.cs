using TMPro;
using UnityEngine.UI;

public class GameInit
{
    public GameInit(Controller controllers, ConfigFile configFile, FinalWindowView finalWindowView,
        MainWindowView mainWindowView)
    {
        var gameControlelr = new GameController(configFile,finalWindowView, mainWindowView);
        controllers.Add(gameControlelr);
    }
}
