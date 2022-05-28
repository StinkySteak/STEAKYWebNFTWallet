using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("createMarketSale")]
public class OnListingPurchasedFunction : FunctionMessage
{
    [Parameter("address", "nftContract", 1)]
    public string? NftContract { get; set; }

    [Parameter("uint256", "itemId", 2)]
    public BigInteger ItemId { get; set; }

    [Parameter("uint256", "amount", 3)]
    public BigInteger Amount { get; set; }
}
