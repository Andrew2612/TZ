using UnityEngine;

public class Quirky : TradingBehaviour
{
    public TradingBehaviour.Type GetType() {return TradingBehaviour.Type.Quirky;}
    private bool flag;

    public TradingBehaviour.Behaviour BeginTrading()
    {
        flag = false;
        return TradingBehaviour.Behaviour.Honest;
    }
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        if (numOfTrade < 5)
        {
            if (opponentLastBehaviour == TradingBehaviour.Behaviour.Lying)
            {
                flag = true;
            }

            switch (numOfTrade)
            {
                case 1:
                    return TradingBehaviour.Behaviour.Honest;
                case 2:
                    return TradingBehaviour.Behaviour.Lying;
                case 3:
                    return TradingBehaviour.Behaviour.Honest;
                case 4:
                    return TradingBehaviour.Behaviour.Honest;
            }
        }

        if (flag)
        {
            return TradingBehaviour.Behaviour.Honest;
        }
        
        if (numOfTrade == 5)
        {
            return TradingBehaviour.Behaviour.Honest;
        }
        return opponentLastBehaviour;
    }
}
