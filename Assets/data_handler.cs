using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_handler : MonoBehaviour
{
    [SerializeField] playfab_manager pf_m;
    int gold=0, stock=0, silver=0, crypto=0;

    public void gold_add()
    {
        gold++;
    }
    public void gold_remove()
    {
        gold--;
    }
    public void silver_add()
    {
        silver++;
    }
    public void silver_remove()
    {
        silver--;
    }
    public void stock_add()
    {
        stock++;
    }
    public void stock_remove()
    {
        stock--;
    }
    public void crypto_add()
    {
        crypto++;
    }
    public void crypto_remove()
    {
        crypto--;
    }

    public void back_btn()
    {
        pf_m.data_update(gold,silver,crypto,stock);
        pf_m.get_data();
    }
}
