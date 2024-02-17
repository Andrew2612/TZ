using UnityEngine;

public class Crook : TradingBehaviour
{
    public TradingBehaviour.Type GetType() {return TradingBehaviour.Type.Crook;}
    public TradingBehaviour.Behaviour BeginTrading()
    {
        return TradingBehaviour.Behaviour.Lying;
    }
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        return TradingBehaviour.Behaviour.Lying;
    }
}
