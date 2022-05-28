using System;
using System.Numerics;

public class OwnedListedERC20
{
	public ERC20 Token { get; }
	public BigInteger Balance { get; set; }

	public OwnedListedERC20(ERC20 token)
	{
		Token = token;
	}
}
