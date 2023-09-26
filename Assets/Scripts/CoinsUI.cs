using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CoinsUI : MonoBehaviour
{
    private CoinsController _controller;
    private TMP_Text _coinsText;

    [Inject]
    public void Construct(CoinsController controller)
    {
        _controller = controller;
    }
    private void Awake()
    {
        _controller.OnCoinsAdded += UpdateCoins;
        _coinsText = GetComponent<TMP_Text>();
    }
    private void UpdateCoins()
    {
        _coinsText.text = $"Coins:\n {_controller.CurrentCoins}";
    }
    private void OnDisable()
    {
        _controller.OnCoinsAdded -= UpdateCoins;
    }
}
