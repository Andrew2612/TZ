using UnityEngine;

public class Trader
{
    private const uint _errorChance = 5;
    private int _error;

    private const int MIN_TRADES = 5;
    private const int MAX_TRADES = 10;
    private int _numOfTrades;
    private int _currentTrade;

    private Merchant _first, _second;
    private TradingBehaviour.Behaviour[] _firstBehaviour = new TradingBehaviour.Behaviour[MAX_TRADES];
    private TradingBehaviour.Behaviour[] _secondBehaviour = new TradingBehaviour.Behaviour[MAX_TRADES];
    
    public void Trade(Merchant first, Merchant second)
    {
        _first = first;
        _second = second;
        _currentTrade = 0;

        _firstBehaviour[0] = first.BeginTrading();
        _secondBehaviour[0] = second.BeginTrading();
        AddError();
        GiveRewards();

        _numOfTrades = Random.Range(MIN_TRADES, MAX_TRADES + 1);
        for (_currentTrade = 1; _currentTrade < _numOfTrades; _currentTrade++)
        {
            _firstBehaviour[_currentTrade] = 
                first.GetBehaviour(_currentTrade, _secondBehaviour[_currentTrade - 1]);

            _secondBehaviour[_currentTrade] = 
                second.GetBehaviour(_currentTrade, _firstBehaviour[_currentTrade - 1]);
            AddError();
            GiveRewards();
        }
    }

    private void AddError()
    {
        _error = Random.Range(0, 100);
        if (_error < _errorChance)
        {
            if (_firstBehaviour[_currentTrade] == TradingBehaviour.Behaviour.Honest)
            {
                _firstBehaviour[_currentTrade] = TradingBehaviour.Behaviour.Lying;
            }
            else
            {
                _firstBehaviour[_currentTrade] = TradingBehaviour.Behaviour.Honest;
            }
        }

        _error = Random.Range(0, 100);
        if (_error < _errorChance)
        {
            if (_secondBehaviour[_currentTrade] == TradingBehaviour.Behaviour.Honest)
            {
                _secondBehaviour[_currentTrade] = TradingBehaviour.Behaviour.Lying;
            }
            else
            {
                _secondBehaviour[_currentTrade] = TradingBehaviour.Behaviour.Honest;
            }
        }
    }

    private void GiveRewards()
    {
        if (_firstBehaviour[_currentTrade] == TradingBehaviour.Behaviour.Honest)
        {
            if (_secondBehaviour[_currentTrade] == TradingBehaviour.Behaviour.Honest)
            {
                _first.AddGold(4);
                _second.AddGold(4);
            }
            else
            {
                _first.AddGold(1);
                _second.AddGold(5);
            }
        }
        else
        {
            if (_secondBehaviour[_currentTrade] == TradingBehaviour.Behaviour.Honest)
            {
                _first.AddGold(5);
                _second.AddGold(1);
            }
            else
            {
                _first.AddGold(2);
                _second.AddGold(2);
            }
        }
    }
}
