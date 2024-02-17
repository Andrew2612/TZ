using UnityEngine;
using UnityEngine.UI;

public class Guild : MonoBehaviour
{
    [SerializeField] private GameObject _merchantLabel;
    [SerializeField] private Transform _layout;

    private const uint N = 60;
    private const uint MERCHANTS_YEAR_REPLACE = 12;

    private Merchant[] _merchants = new Merchant[N];
    private Trader _trader = new Trader();

    private void Awake()
    {
        CreateMerchants();
    }

    private void CreateMerchants()
    {
        Merchant m = null;
        GameObject Merchant = null;
        for (int i = 0; i < N; i++)
        {
            Merchant = GameObject.Instantiate(_merchantLabel);
            Merchant.transform.SetParent(_layout);

            m = Merchant.GetComponent<Merchant>();

            if (i < 10) {m.InitBehaviour(new Altruist());}
            else if (i < 20) {m.InitBehaviour(new Crook());}
            else if (i < 30) {m.InitBehaviour(new Tricky());}
            else if (i < 36) {m.InitBehaviour(new Unpredictable());}
            else if (i < 40) {m.InitBehaviour(new BestType());}
            else if (i < 50) {m.InitBehaviour(new Vindictive());}
            else if (i < 60) {m.InitBehaviour(new Quirky());}

            _merchants[i] = m;
        }
    }

    public void StartNewYear()
    {
        UpdateMerchants();
    }

    private void UpdateMerchants()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                _trader.Trade(_merchants[i], _merchants[j]);
            }
        }
        Shellsort();
        ReplacePoorMerchants();
    }

    private void Shellsort ()
    {
        for (int i = 1; i < N; i++)
        {
            int j = i;
            while (j > 0)
            {    
                if (_merchants[j - 1].GetGold() < _merchants[j].GetGold())
                {
                    (_merchants[j - 1], _merchants[j]) = (_merchants[j], _merchants[j - 1]);
                }
                j--;
            }
        }
        for (int i = 0; i < N; i++)
        {
            _merchants[i].SetSiblingIndex(i);
        }
    }

    private void ReplacePoorMerchants()
    {
        Merchant m = null;
        for (uint i = 0; i < MERCHANTS_YEAR_REPLACE; i++)
        {
            Destroy(_layout.GetChild((int)(N - i - 1)).gameObject);

            GameObject Merchant = GameObject.Instantiate(_merchantLabel);
            Merchant.transform.SetParent(_layout);

            m = Merchant.GetComponent<Merchant>();

            _merchants[N - i - 1] = m;

            m.InitBehaviour(_merchants[i].GetType());
        }
    }
}
