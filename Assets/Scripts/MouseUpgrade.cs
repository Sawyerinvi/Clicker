using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MouseUpgrade : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _currentValues;

    private ClickerStats _clickerStats;
    private CoinsController _coinsController;
    private AudioSource _audioSource;

    [Inject]
    public void Construct(ClickerStats clickerStats, CoinsController coinsController)
    {
        _clickerStats = clickerStats;
        _coinsController = coinsController;
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _upgradeButton.onClick.AddListener(ButtonClicked);
        _priceText.text = _clickerStats.MouseUpgradePrice.ToString();
        _currentValues.text = $"Current value : {_clickerStats.MouseClick}";
    }
    private void ButtonClicked()
    {
        if (_coinsController.CurrentCoins >= _clickerStats.MouseUpgradePrice)
        {
            _audioSource.Play();
            _coinsController.AddCoins(_clickerStats.MouseUpgradePrice * -1);
            _clickerStats.UpgradeMouse();
            _priceText.text = _clickerStats.MouseUpgradePrice.ToString();
            _currentValues.text = $"Current value : {_clickerStats.MouseClick}";
        }

    }
}
