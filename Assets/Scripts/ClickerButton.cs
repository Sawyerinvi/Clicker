using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ClickerButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _earnedTextPrefab;
    [SerializeField] private Button _ClickerButton;
    private CoinsController _controller;
    private ClickerStats _clickerStats;
    [Inject]
    public void Construct(CoinsController coinsController, ClickerStats clickerStats)
    {
        _controller = coinsController;
        _clickerStats = clickerStats;
    }
    private void Awake()
    {
        _ClickerButton.onClick.AddListener(() => Click(_clickerStats.MouseClick));
        _clickerStats.OnUpgradeLevel1 += StartLevel1;
        _clickerStats.OnUpgradeLevel2 += StartLevel2;
    }
    public void Click(int coins)
    {
        var random = Random.Range(0, 100);
        bool isCrit = random  < _clickerStats.CritChance;
        Vector3 position = new Vector3(Random.Range(-75, 75),Random.Range(50, 80), 0);
        TMP_Text newText = Instantiate(_earnedTextPrefab, position, Quaternion.identity);
        newText.transform.SetParent(transform, false);

        if (isCrit)
        {
            coins = Mathf.CeilToInt(coins * _clickerStats.CritMulty);
            newText.GetComponent<TMP_Text>().color = Color.yellow;
        }
        newText.GetComponent<TMP_Text>().text = coins.ToString();
        _controller.AddCoins(coins);
    }
    private void StartLevel1()
    {
        StartCoroutine(AutoClikLevel1());
    }
    private void StartLevel2()
    {
        StartCoroutine(AutoClikLevel2());
    }
    private IEnumerator AutoClikLevel1()
    {
        while (true)
        {
            yield return new WaitForSeconds(_clickerStats.Level1Speed);
            Click(_clickerStats.Level1Click);
            yield return null;
        }

    }
    private IEnumerator AutoClikLevel2()
    {
        while (true)
        {
            yield return new WaitForSeconds(_clickerStats.Level2Speed);
            Click(_clickerStats.Level2Click);
            yield return null;
        }

    }
}
