using UnityEngine;

public class Tricky : TradingBehaviour
{
    public TradingBehaviour.Type GetType() {return TradingBehaviour.Type.Tricky;}
    public TradingBehaviour.Behaviour BeginTrading()
    {
        return TradingBehaviour.Behaviour.Honest;
    }
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        return opponentLastBehaviour;
    }
}
