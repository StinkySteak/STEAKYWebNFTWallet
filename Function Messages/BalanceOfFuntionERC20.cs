using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

[Function("balanceOf", "uint256")]
public class BalanceOfFuntionERC20 : FunctionMessage
{
    [Parameter("address", "account", 1)] public string? Account { get; set; }
}
