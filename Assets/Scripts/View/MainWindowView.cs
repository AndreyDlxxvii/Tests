using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainWindowView : MonoBehaviour
{
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _textCostUpdateClick;
        [SerializeField] private TMP_Text _textCostUpdateAutoClick;
        [SerializeField] private Button _clickButton;
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _clickUpdate;
        [SerializeField] private Button _autoClick;

        public TMP_Text ScoreText => _scoreText;

        public TMP_Text TextCostUpdateClick => _textCostUpdateClick;

        public TMP_Text TextCostUpdateAutoClick => _textCostUpdateAutoClick;

        public Button ClickButton => _clickButton;

        public Button ResetButton => _resetButton;

        public Button ClickUpdate => _clickUpdate;

        public Button AutoClick => _autoClick;
}
