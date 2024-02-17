using UnityEngine;

public class Vindictive : TradingBehaviour
{
    public TradingBehaviour.Type GetType() {return TradingBehaviour.Type.Vindictive;}
    private bool flag;

    public TradingBehaviour.Behaviour BeginTrading()
    {
        flag = false;
        return TradingBehaviour.Behaviour.Honest;
    }
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        if (flag)
        {
            return TradingBehaviour.Behaviour.Lying;
        }

        if (opponentLastBehaviour == TradingBehaviour.Behaviour.Lying)
        {
            flag = true;
        }
        return TradingBehaviour.Behaviour.Honest;
    }
}
