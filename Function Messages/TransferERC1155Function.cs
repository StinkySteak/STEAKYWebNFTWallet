using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("safeTransferFrom", "bool")]
public class TransferERC1155Function : FunctionMessage
{
    [Parameter("address", "from", 1)]
    public string? From { get; set; }

    [Parameter("address", "to", 2)]
    public string? To { get; set; }

    [Parameter("uint256", "id", 3)]
    public BigInteger TokenId { get; set; }

    [Parameter("uint256", "amount", 4)]
    public BigInteger Amount { get; set; }

    [Parameter("bytes", "data", 5)]
    public byte[]? Data { get; set; }
}