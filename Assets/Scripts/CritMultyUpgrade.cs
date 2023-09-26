using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CritMultyUpgrade : MonoBehaviour
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
        _priceText.text = _clickerStats.CritMultyUpgradePrice.ToString();
        _currentValues.text = $"Current value : {_clickerStats.CritMulty}";
    }
    private void ButtonClicked()
    {
        if (_coinsController.CurrentCoins >= _clickerStats.CritMultyUpgradePrice)
        {
            _audioSource.Play();
            _coinsController.AddCoins(_clickerStats.CritMultyUpgradePrice * -1);
            _clickerStats.CritMultyUpgrade();
            _priceText.text = _clickerStats.CritMultyUpgradePrice.ToString();
            _currentValues.text = $"Current value : {_clickerStats.CritMulty}";
        }

    }
}
