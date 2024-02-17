using UnityEngine;

public class BestType : TradingBehaviour
{
    public TradingBehaviour.Type GetType() {return TradingBehaviour.Type.BestType;}
    private bool flagCrook;
    private bool flagAltruist;
    private bool flagVindictive;
    private bool flag;

    public TradingBehaviour.Behaviour BeginTrading()
    {
        flagCrook = false;
        flagAltruist = false;
        flagVindictive = false;
        return TradingBehaviour.Behaviour.Honest;
    }
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        if (numOfTrade == 1)
        {
            if (opponentLastBehaviour == TradingBehaviour.Behaviour.Lying)
            {
                flagCrook = true;
                return TradingBehaviour.Behaviour.Lying;
            }
            return TradingBehaviour.Behaviour.Honest;
        }
        if (flagCrook)
        {
            return TradingBehaviour.Behaviour.Lying;
        }

        if (numOfTrade < 6)
        {
            return TradingBehaviour.Behaviour.Honest;
        }
        return TradingBehaviour.Behaviour.Lying;
    }
}