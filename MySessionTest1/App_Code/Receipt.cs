using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Receipt
/// </summary>
public class Receipt
{
    string shop;
    string receipt_sn;
    double amount;

    public string Shop
    {
        get
        {
            return shop;
        }

        set
        {
            shop = value;
        }
    }



    public string Receipt_sn
    {
        get
        {
            return receipt_sn;
        }

        set
        {
            receipt_sn = value;
        }
    }

    public double Amount
    {
        get
        {
            return amount;
        }

        set
        {
            amount = value;
        }
    }

    public Receipt()
    {
    }
    public Receipt(string shop, string receipt_sn, double amount)
    {
        this.Shop = shop;
        this.Receipt_sn = receipt_sn;
        this.Amount = amount;
    }

}