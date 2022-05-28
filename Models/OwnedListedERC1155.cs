using System;
using System.Numerics;

public class OwnedListedERC1155
{
	public ERC1155 NFT { get; }
	public BigInteger Balance { get; set; }
	public BigInteger TokenID { get; set; }
	public string Name { get; set; }
	public OwnedListedERC1155(ERC1155 nft, BigInteger tokenID, string name)
	{
		NFT = nft;
		TokenID = tokenID;
		Name = name;
	}
}
