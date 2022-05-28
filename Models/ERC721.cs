using System;
using System.Numerics;

public class ERC721 : NFTBase
{
    public ERC721(string address) : base(address)
    {
        Address = address;
    }
}
