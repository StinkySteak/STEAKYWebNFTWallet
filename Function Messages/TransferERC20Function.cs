using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("transfer", "bool")]
public class TransferERC20Function : FunctionMessage
{
    [Parameter("address", "recipient", 1)]
    public string? To { get; set; }

    [Parameter("uint256", "amount", 2)]
    public BigInteger TokenAmount { get; set; }
}