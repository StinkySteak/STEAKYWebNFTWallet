using System;
using Nethereum.Web3;
using Nethereum.Contracts;
using Nethereum.ABI;
using Nethereum.Web3.Accounts;
using System.Numerics;
using Nethereum.JsonRpc.Client;
using Microsoft.JSInterop;
using Nethereum.UI;
using Nethereum.Metamask;
using Nethereum.Hex.HexTypes;

public static class NethereumService
{
    static BigInteger BSC_ChainID_TESTNET = new BigInteger(97);
    static BigInteger BSC_ChainID_MAINNET = new BigInteger(56);

    static BigInteger Rinkeby_ChainID = new BigInteger(4);

    public static string TokenContractAddress = "0xB075b80F560ce64162C6007d524f678D19Cc902f";
    public static string NFTMarketplaceContractAddress = "0x5cbf8310f6a435E3669c209342f7e1D9dBF55b31";
    public static string NFTContractAddress = "0xF5bF509565D0FD1Efda3eF7163dA16BB0D1fBEa9";

    static BigInteger GasPrice = Nethereum.Util.UnitConversion.Convert.ToWei(10, Nethereum.Util.UnitConversion.EthUnit.Gwei);
    static BigInteger Gas = new BigInteger(90000);

    public static bool EthereumAvailable { get; set; }
    public static string? SelectedAccount { get; set; }
    public static string? AuthenticatedAccount { get; set; }
    public static int SelectedChainID { get; set; }

    public static bool IsConnected => EthereumAvailable && !string.IsNullOrEmpty(SelectedAccount);
    public static bool NotConnected => !EthereumAvailable || string.IsNullOrEmpty(SelectedAccount);

    public static async Task<int> QueryERC1155Balance(Web3 web3, int _tokenId, string _account, string _contractAddress)
    {
        BalanceOfFunction_ERC1155 functionMessage = new BalanceOfFunction_ERC1155()
        {
            Account = _account,
            TokenId = _tokenId
        };

        var handler = web3.Eth.GetContractQueryHandler<BalanceOfFunction_ERC1155>();
        var result = await handler.QueryAsync<BigInteger>(_contractAddress, functionMessage);
        return (int)result;
    }
    public static async Task<int> QueryERC721Balance(Web3 web3, string _account, string _contractAddress)
    {
        BalanceOfFunction_ERC721 functionMessage = new BalanceOfFunction_ERC721()
        {
            Account = _account
        };

        var handler = web3.Eth.GetContractQueryHandler<BalanceOfFunction_ERC721>();
        var result = await handler.QueryAsync<BigInteger>(_contractAddress, functionMessage);
        return (int)result;
    }
    public static async Task<BigInteger> QueryERC20Allowance(Web3 web3, string _owner, string _spender)
    {
        AllowanceFunctionMessage functionMessage = new AllowanceFunctionMessage()
        {
            Owner = _owner,
            Spender = _spender
        };

        var handler = web3.Eth.GetContractQueryHandler<AllowanceFunctionMessage>();
        var result = await handler.QueryAsync<BigInteger>(TokenContractAddress, functionMessage);
        Console.WriteLine("Allowance: " + result);
        return result;
    }
    public static async Task<BigInteger> QueryERC20Balance(Web3 web3, string tokenContractAddress, string _owner)
    {
        BalanceOfFuntionERC20 functionMessage = new BalanceOfFuntionERC20()
        {
            Account = _owner,
        };

        var handler = web3.Eth.GetContractQueryHandler<BalanceOfFuntionERC20>();
        var result = await handler.QueryAsync<BigInteger>(tokenContractAddress, functionMessage);
        Console.WriteLine("Balance: " + result);
        return result;
    }
    public static async Task<BigInteger> QueryListingPrice(Web3 web3)
    {
        GetListingPriceFunction functionMessage = new GetListingPriceFunction();

        var handler = web3.Eth.GetContractQueryHandler<GetListingPriceFunction>();
        var result = await handler.QueryAsync<BigInteger>(NFTMarketplaceContractAddress, functionMessage);
        Console.WriteLine("Price: " + result);
        return result;
    }
    public static async Task<string> PurchaseListing(Web3 web3, int _itemId, int _amount)
    {
        OnListingPurchasedFunction functionMessage = new OnListingPurchasedFunction()
        {
            NftContract = NFTContractAddress,
            ItemId = _itemId,
            Amount = _amount,
            Gas = Gas,
            GasPrice = GasPrice
        };

        var handler = web3.Eth.GetContractTransactionHandler<OnListingPurchasedFunction>();
        var result = await handler.SendRequestAndWaitForReceiptAsync(NFTMarketplaceContractAddress, functionMessage);
        Console.WriteLine("Tx hash: " + result.TransactionHash);
        return result.TransactionHash;
    }
    public static async Task ApproveTransaction(Web3 web3)
    {
        ApproveFunctionMessage function = new ApproveFunctionMessage()
        {
            SpenderAddress = NFTMarketplaceContractAddress,
            TokenAmount = new BigInteger(10000000000000000000),
            Gas = Gas,
            GasPrice = GasPrice
        };

        var handler = web3.Eth.GetContractTransactionHandler<ApproveFunctionMessage>();
        var result = await handler.SendRequestAndWaitForReceiptAsync(TokenContractAddress, function);
        Console.WriteLine("Tx hash: " + result.TransactionHash);
    }

    public static async Task TransferERC20(Web3 web3, string? contractAddress, string? addressTo, BigInteger amount)
    {
        TransferERC20Function functionMessage = new TransferERC20Function()
        {
            To = addressTo,
            TokenAmount = amount,
            Gas = Gas
        };

        Console.WriteLine($"web3: {web3} contractAddress: {contractAddress} addressTo: {addressTo} amount: {amount}");

        var handler = web3.Eth.GetContractTransactionHandler<TransferERC20Function>();
        var result = await handler.SendRequestAndWaitForReceiptAsync(contractAddress, functionMessage);
        Console.WriteLine("tx hash: " + result.TransactionHash);
    }
    public static async Task TransferERC721(Web3 web3, string? contractAddress, string? from, string? addressTo, BigInteger tokenId)
    {
        TransferERC721Function functionMessage = new TransferERC721Function()
        {
            From = from,
            To = addressTo,
            TokenId = tokenId,
            Gas = Gas
        };

        var handler = web3.Eth.GetContractTransactionHandler<TransferERC721Function>();
        var result = await handler.SendRequestAndWaitForReceiptAsync(contractAddress, functionMessage);
        Console.WriteLine("tx hash: " + result);
    }
    public static async Task TransferERC1155(Web3 web3, string? contractAddress, string? from, string? addressTo, BigInteger amount, BigInteger tokenId)
    {
        TransferERC1155Function functionMessage = new TransferERC1155Function()
        {
            From = from,
            To = addressTo,
            TokenId = tokenId,
            Amount = amount,
            Data = Array.Empty<byte>(),
            Gas = Gas
        };

        var handler = web3.Eth.GetContractTransactionHandler<TransferERC1155Function>();
        var result = await handler.SendRequestAndWaitForReceiptAsync(contractAddress, functionMessage);
        Console.WriteLine("tx hash: " + result);
    }

    public static async Task<string> QueryNFTUri(Web3 web3, string _contractAddress, uint _tokenId)
    {
        URIFunction functionMessage = new URIFunction()
        {
            TokenId = _tokenId
        };

        var handler = web3.Eth.GetContractQueryHandler<URIFunction>();
        var result = await handler.QueryAsync<string>(_contractAddress, functionMessage);
        Console.WriteLine("Uri: " + result);
        return result;
    }

    public static async Task<HexBigInteger> GetEtherBalance(Web3 web3, string address)
    {
        return await web3.Eth.GetBalance.SendRequestAsync(address);
    }
    public static BigInteger NormalizeToken(BigInteger amount, int decimalLength)
    {
        BigInteger tokenPower = BigInteger.Pow(10, decimalLength);

        var normalizedAmount = BigInteger.Divide(amount, tokenPower);

        return normalizedAmount;
    }

    public async static Task<string> LoadImageMetadata(string _url)
    {
        HttpClient client = new HttpClient();
        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, _url));
        var content = await response.Content.ReadAsByteArrayAsync();

        var base64 = Convert.ToBase64String(content);

        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);

        return imgSrc;
    }
    public async static Task<string> LoadMetadata(string _url)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(_url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        return content;
    }
    public static string ConvertMultiToSingleURL(string url, int tokenId)
    {
        string newUrl = url.Replace("{id}", tokenId.ToString());

        return newUrl;
    }
}
