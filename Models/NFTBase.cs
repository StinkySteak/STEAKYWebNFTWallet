using System;

public class NFTBase
{
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public string? Address {  get; set; }

    public NFTBase(string address)
    {
        Address = address;
    }
}
