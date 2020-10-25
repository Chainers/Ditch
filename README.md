[![Build Status](https://travis-ci.org/Chainers/Ditch.svg?branch=master)](https://travis-ci.org/Chainers/Ditch)

[Wiki](https://github.com/Chainers/Ditch/wiki)|[Documentation](https://chainers.github.io/Ditch/)|[Site](https://ditch.surge.sh)|[Telegram (ru)](https://t.me/steepshot_ru)|[Telegram (en)](https://t.me/steepshot_en)|[Follow us (ru)](https://golos.io/@steepshot)|[Follow us (en)](https://steemit.com/@steepshot)
---|---|---|---|---|---|---

# Ditch
The essence of the library is to generate a transaction according to the required operations (vote, comment, etc.), sign the transaction and broadcast to the Graphene-based blockchain. 

## Supported chains:

 * Golos (v0.18.3)  [![NuGet version](https://badge.fury.io/nu/Ditch.Golos.svg)](https://badge.fury.io/nu/Ditch.Golos)
 * Steem (v0.19.10) [![NuGet version](https://badge.fury.io/nu/Ditch.Steem.svg)](https://badge.fury.io/nu/Ditch.Steem)
 * EOS   (v1.1.0)   [![NuGet version](https://badge.fury.io/nu/Ditch.EOS.svg)](https://badge.fury.io/nu/Ditch.EOS)
 * BitShares [![NuGet version](https://badge.fury.io/nu/Ditch.BitShares.svg)](https://badge.fury.io/nu/Ditch.BitShares)
  
## Additional features:
 * Transliteration (Cyrillic to Latin)
 * Base58 converter
 * Can connect by https or socket (wss)

## Usage
    //set global properties
    public void SetUp()
    {
        HttpClient = new HttpClient();
        HttpManager = new HttpManager(HttpClient);
        Api = new OperationManager(HttpManager);
        //Api = new OperationManager(new WebSocketManager());
        
        Api.ConnectTo("https://api.steemit.com", CancellationToken.None);        
        //Api.ConnectTo("wss://ws.golos.io", CancellationToken.None);
        
        YouPrivateKeys = new List<byte[]>
        {
            Base58.GetBytes("5**************************************************") \\WIF
        };
        YouLogin = "username";
    }
    
    //Create new post with some beneficiaries
    var postOp = new PostOperation("parentPermlink", YouLogin, "Title", "Body", "jsonMetadata");
    var benOp = new BeneficiariesOperation(YouLogin, postOp.Permlink, new Asset(1, Config.SteemAssetNumSbd), new Beneficiary("someBeneficiarName", 1000));
    var responce = Api.BroadcastOperations(YouPrivateKeys, new[]{postOp, benOp},CancellationToken.None);
    
    //UpVote
    var voteOp = new UpVoteOperation(YouLogin, "someUserName", "somePermlink");
    var responce = Api.BroadcastOberations(YouPrivateKeys, voteOp, CancellationToken.None);
    
    //Follow
    var followOp = new FollowOperation(YouLogin, "someUserName", FollowType.Blog, YouLogin);
    var responce = Api.BroadcastOperations(YouPrivateKeys, followOp, CancellationToken.None);
