using UnityEngine;

public class Unpredictable : TradingBehaviour
{
    public TradingBehaviour.Type GetType() {return TradingBehaviour.Type.Unpredictable;}
    public TradingBehaviour.Behaviour BeginTrading()
    {
        if (Random.Range(0,2) == 0)
        {
            return TradingBehaviour.Behaviour.Honest;
        }
        return TradingBehaviour.Behaviour.Lying;
    }
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        if (Random.Range(0,2) == 0)
        {
            return TradingBehaviour.Behaviour.Honest;
        }
        return TradingBehaviour.Behaviour.Lying;
    }
}
