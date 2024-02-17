using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    private TradingBehaviour _tradingBehaviour;
    private TradingBehaviour.Type _tradingType;
    public TradingBehaviour.Type GetType() {return _tradingType;}
    public void InitBehaviour(TradingBehaviour t)
    {
        _tradingBehaviour = t;
        _tradingType = t.GetType();
    }
    public void InitBehaviour(TradingBehaviour.Type t)
    {
        _tradingType = t;
        switch (t)
        {
            case TradingBehaviour.Type.Altruist:
                _tradingBehaviour = new Altruist();
                return;
            case TradingBehaviour.Type.Crook:
                _tradingBehaviour = new Crook();
                return;
            case TradingBehaviour.Type.Tricky:
                _tradingBehaviour = new Tricky();
                return;
            case TradingBehaviour.Type.Unpredictable:
                _tradingBehaviour = new Unpredictable();
                return;
            case TradingBehaviour.Type.Vindictive:
                _tradingBehaviour = new Vindictive();
                return;
            case TradingBehaviour.Type.Quirky:
                _tradingBehaviour = new Quirky();
                return;
            case TradingBehaviour.Type.BestType:
                _tradingBehaviour = new BestType();
                return;
        }
    }

    private Text _nameText;
    private Text _goldText;
    private void Start()
    {
        _nameText = transform.GetChild(1).GetComponent<Text>();
        _nameText.text = _tradingType.ToString();
        _goldText = transform.GetChild(2).GetComponent<Text>();
        _goldText.text = _gold.ToString();
    }

    private uint _gold;
    public uint GetGold() {return _gold;}
    public void AddGold(uint gold)
    {
        _gold += gold;
        _goldText.text = _gold.ToString();
    }
    public void SetSiblingIndex(int i)
    {
        transform.SetSiblingIndex(i);
    }
    public TradingBehaviour.Behaviour BeginTrading() {return _tradingBehaviour.BeginTrading();}
    public TradingBehaviour.Behaviour GetBehaviour(int numOfTrade, TradingBehaviour.Behaviour opponentLastBehaviour)
    {
        return _tradingBehaviour.GetBehaviour(numOfTrade, opponentLastBehaviour);
    }
}

public interface TradingBehaviour 
{
    public enum Behaviour {Honest, Lying}
    public Behaviour BeginTrading();
    public Behaviour GetBehaviour(int numOfTrade, Behaviour opponentLastBehaviour);

    public enum Type
    {
        Altruist, Crook, Tricky, Unpredictable, Vindictive, Quirky, BestType
    }
    public Type GetType();
}
