using System;
using System.Numerics;

public class ERC1155 : NFTBase 
{
    public BigInteger TokenId { get; set; }
    public ERC1155(string address, BigInteger _tokenId) : base(address)
    {
        TokenId = _tokenId;
    }
}
