using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Level1AutoClicker : MonoBehaviour
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
        _priceText.text = _clickerStats.Level1UpgradePrice.ToString();
        _currentValues.text = $"Current value : {_clickerStats.Level1Click}";
    }
    private void ButtonClicked()
    {
        if(_coinsController.CurrentCoins >= _clickerStats.Level1UpgradePrice)
        {
            _audioSource.Play();
            _coinsController.AddCoins(_clickerStats.Level1UpgradePrice * -1);
            _clickerStats.UpgradeLevel1();
            _priceText.text = _clickerStats.Level1UpgradePrice.ToString();
            _currentValues.text = $"Current value : {_clickerStats.Level1Click}";
        }
        
    }
}
