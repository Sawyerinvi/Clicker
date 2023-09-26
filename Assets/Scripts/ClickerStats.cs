using System;

public class ClickerStats
{
    private int _mouseClick = 1;
    private int _level1Click = 10;
    private int _level2Click = 30;
    private float _critChance = 5;
    private float _critMulty = 1.5f;

    private float _level1Speed = 1;
    private float _level2Speed = 0.75f;

    private int _mouseUpgradePrice = 10;
    private int _level1UpgradePrice = 50;
    private int _level2UpgradePrice = 500;
    private int _critChanceUpgradePrice = 1000;
    private int _critMultyUpgradePrice = 5000;

    private bool _level1IsActive;
    private bool _level2IsActive;

    public event Action OnUpgradeLevel1;
    public event Action OnUpgradeLevel2;

    public float Level1Speed => _level1Speed;
    public float Level2Speed => _level2Speed;

    public int MouseClick => _mouseClick;
    public int Level1Click => _level1Click;
    public int Level2Click => _level2Click;
    public float CritChance => _critChance;
    public float CritMulty => _critMulty;

    public int Level1UpgradePrice => _level1UpgradePrice;
    public int Level2UpgradePrice => _level2UpgradePrice;
    public int MouseUpgradePrice => _mouseUpgradePrice;
    public int CritChanceUpgradePrice => _critChanceUpgradePrice;
    public int CritMultyUpgradePrice => _critMultyUpgradePrice;

    public void UpgradeLevel1()
    {
        if (_level1IsActive == false)
        {
            OnUpgradeLevel1?.Invoke();
            _level1IsActive = true;
        }
        _level1Click = (int)(_level1Click * 1.3f + 5);
        _level1Speed *= 0.95f;
        _level1UpgradePrice = _level1UpgradePrice * 2 + 50;

    }
    public void UpgradeLevel2()
    {
        if(_level2IsActive == false)
        {
            OnUpgradeLevel2?.Invoke();
            _level2IsActive = true;
        }
        _level2Click = (int)(_level2Click * 1.3f + 25);
        _level2Speed *= 0.95f;
        _level2UpgradePrice = _level2UpgradePrice * 2 + 250;
    }
    public void UpgradeMouse()
    {
        _mouseClick = (int)(_mouseClick * 1.5f + 2);
        _mouseUpgradePrice = _mouseUpgradePrice * 2 + 10;
    }
    public void CritChanceUpgrade()
    {
        _critChance = _critChance + (100 - _critChance) / 10;
        _critChanceUpgradePrice = _critChanceUpgradePrice * 2 + 1000;
    }
    public void CritMultyUpgrade()
    {
        _critMulty += 0.2f;
        _critMultyUpgradePrice = _critChanceUpgradePrice * 2 + 5000;
    }
}
