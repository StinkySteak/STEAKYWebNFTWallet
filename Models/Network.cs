using System;

[System.Serializable]
public class Network
{
    public int ChainID { get; set; }
    public List<OwnedListedERC20>? OwnedListedToken { get; set; } = new List<OwnedListedERC20>();
    public List<OwnedListedERC1155>? OwnedListedERC1155 { get; set; } = new List<OwnedListedERC1155>();
    public List<OwnedListedERC721>? OwnedListedERC721 { get; set; } = new List<OwnedListedERC721>();

    public Network(int chainId)
    {
        ChainID = chainId;
    }
}
