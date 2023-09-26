using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CritChanceUpgrade : MonoBehaviour
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
        _upgradeButton.onClick.AddListener(ButtonClicked);
        _priceText.text = _clickerStats.CritChanceUpgradePrice.ToString();
        _currentValues.text = $"Current value : {_clickerStats.CritChance}";
        _audioSource = GetComponent<AudioSource>();
    }
    private void ButtonClicked()
    {
        if (_coinsController.CurrentCoins >= _clickerStats.CritChanceUpgradePrice)
        {
            _audioSource.Play();
            _coinsController.AddCoins(_clickerStats.CritChanceUpgradePrice * -1);
            _clickerStats.CritChanceUpgrade();
            _priceText.text = _clickerStats.CritChanceUpgradePrice.ToString();
            _currentValues.text = $"Current value : {_clickerStats.CritChance}";
        }

    }
}
