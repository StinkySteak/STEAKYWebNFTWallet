using System;

public class ERC20
{
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public string? Address { get; set; }
    public int? Decimal { get; set; }

    public ERC20(string name,string symbol,string address,int decimalLength = 18)
    {
        Name = name;
        Symbol = symbol;
        Address = address;
        Decimal = decimalLength;
    }
}
