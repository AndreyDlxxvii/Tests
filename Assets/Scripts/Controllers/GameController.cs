using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : IOnController, IDisposable
{
    private readonly TMP_Text _scoreText;
    private readonly TMP_Text _textCostUpdateClick;
    private readonly TMP_Text _textCostUpdateAutoClick;
    
    private readonly Button _clickButton;
    private readonly Button _resetButton;
    private readonly Button _updateClick;
    private readonly Button _autoClicker;
    
    private readonly ConfigFile _configFile;
    
    private ulong _score;
    
    private ulong _costUpdate;
    private ulong _baseCostClick;
    
    private ulong _costUpdateAutoClicker;
    private ulong _baseCostAutoClick;
    
    private ulong _countUpdatesClick;
    private ulong _countUpdatesAutoClicker;

    private ulong _maxCountUpdateClick;
    private ulong _maxCountUpdateAutoClick;
    
    private bool _isAutoClickOn = false;
    private MyCoroutine _myCoroutine;
    private readonly FinalWindowView _finalWindowView;
    public GameController(ConfigFile configFile, FinalWindowView finalWindowView, MainWindowView mainWindowView)
    {
        _finalWindowView = finalWindowView;
        _configFile = configFile;
        _scoreText = mainWindowView.ScoreText;
        _clickButton = mainWindowView.ClickButton;
        _resetButton = mainWindowView.ResetButton;
        _updateClick = mainWindowView.ClickUpdate;
        _autoClicker = mainWindowView.AutoClick;
        _textCostUpdateClick = mainWindowView.TextCostUpdateClick;
        _textCostUpdateAutoClick = mainWindowView.TextCostUpdateAutoClick;
        Init();
    }
    private void Init()
    {
        _maxCountUpdateClick = _configFile.MAXCountUpdateClick;
        _maxCountUpdateAutoClick = _configFile.MAXCountUpdateAutoClick;
        _baseCostClick = _configFile.BaseCostClick;
        _costUpdate = _configFile.CostUpdate;
        _costUpdateAutoClicker = _configFile.CostUpdateAutoClicker;
        _textCostUpdateClick.text = $"{_costUpdate.ToString()}";
        _textCostUpdateAutoClick.text = $"{_costUpdateAutoClicker.ToString()}";
        _clickButton.onClick.AddListener(() => AddScore(_baseCostClick));
        _resetButton.onClick.AddListener(ResetGame);
        _updateClick.onClick.AddListener(UpdateClick);
        _autoClicker.onClick.AddListener(AutoCLickAndUpdate);
    }

    private void AutoCLickAndUpdate()
    {
        if ((int)(_score - _costUpdateAutoClicker) >= 0)
        {
            StartAutoclick();
            if (_countUpdatesAutoClicker >= _maxCountUpdateAutoClick)
            {
                _autoClicker.onClick.RemoveAllListeners();
                _autoClicker.interactable = false;
                return;
            }
            _score -= _costUpdateAutoClicker;
            _scoreText.text = _score.NumReduction();
            _countUpdatesAutoClicker++;
            _baseCostAutoClick = _countUpdatesAutoClicker * _costUpdateAutoClicker;
            _costUpdateAutoClicker = _baseCostAutoClick;
            _textCostUpdateAutoClick.text = $"{_costUpdateAutoClicker.NumReduction()}";
        }
    }

    private void StartAutoclick()
    {
        if (_isAutoClickOn)
            return;
        _isAutoClickOn = !_isAutoClickOn;
        _myCoroutine = new MyCoroutine();
        _myCoroutine.StartMyCoroutine(1f);
        _myCoroutine.End += () => AddScore(_baseCostAutoClick);
    }

    private void UpdateClick()
    {
        if (_countUpdatesClick >= _maxCountUpdateClick)
        {
            _updateClick.onClick.RemoveAllListeners();
            _updateClick.interactable = false;
            return;
        }
        
        if ((int)(_score - _costUpdate) >= 0)
        {
            _score -= _costUpdate;
            _countUpdatesClick++;
            _baseCostClick += _countUpdatesClick * _costUpdate;
            _costUpdate = _baseCostClick;
            _textCostUpdateClick.text = $"{_costUpdate.NumReduction()}";
            _scoreText.text = _score.NumReduction();
        }
    }
    private void AddScore(ulong countScore)
    {
        if (_score < ulong.MaxValue && countScore < ulong.MaxValue)
        {
            _score += countScore;
            _scoreText.text = _score.NumReduction();
        }
        else
        {
            _finalWindowView.gameObject.SetActive(true);
            if (_myCoroutine != null)
            {
                _myCoroutine.StopMyCoroutine();
            }
            _finalWindowView.ButtonRestart.onClick.AddListener(ResetGame);
        }
    }
    private static void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Dispose()
    { 
        _finalWindowView.ButtonRestart.onClick.RemoveAllListeners();
        _myCoroutine.StopMyCoroutine();
        _clickButton.onClick.RemoveAllListeners();
        _resetButton.onClick.RemoveAllListeners();
        _updateClick.onClick.RemoveAllListeners();
        _autoClicker.onClick.RemoveAllListeners();
    }
}
