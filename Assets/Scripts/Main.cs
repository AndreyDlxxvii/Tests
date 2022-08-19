using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private FinalWindowView _finalWindowView;
    [SerializeField] private MainWindowView _mainWindowView;
    [SerializeField] private ConfigFile _configFile;
    
    
    private Controller _controllers;
    private void Start()
    {
        _controllers = new Controller();
        new GameInit(_controllers, _configFile, _finalWindowView, _mainWindowView);
        _controllers.OnStart();
    }
}