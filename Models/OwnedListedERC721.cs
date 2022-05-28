using System;
using System.Numerics;

public class OwnedListedERC721
{
	public ERC721 NFT { get; }
	public BigInteger Balance { get; set; }
	public string Name { get; set; }
	public OwnedListedERC721(ERC721 nft, string name)
	{
		NFT = nft;
		Name = name;
	}
}
