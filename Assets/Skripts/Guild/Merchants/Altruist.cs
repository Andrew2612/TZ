using UnityEngine;

public class Altruist : TradingBehaviour
{
    public TradingBehaviour.Type GetType() {return TradingBehaviour.Type.Altruist;}
    public TradingBehaviour.Behaviour BeginTrading()
    {
        return TradingBehaviour.Behaviour.Honest;
    }
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        return TradingBehaviour.Behaviour.Honest;
    }
}
