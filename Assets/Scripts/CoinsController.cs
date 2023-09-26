using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController 
{
    private int _currentCoins;

    public event Action OnCoinsAdded;
    public int CurrentCoins => _currentCoins;
    public void AddCoins(int amount)
    {
        _currentCoins += amount;
        OnCoinsAdded?.Invoke();
    }
}
