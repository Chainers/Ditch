[![Build Status](https://travis-ci.org/Chainers/Ditch.svg?branch=master)](https://travis-ci.org/Chainers/Ditch)

[Documentation](https://chainers.github.io/Ditch/)|[Site](https://ditch.surge.sh)|[Telegram (ru)](https://t.me/steepshot_ru)|[Telegram (en)](https://t.me/steepshot_en)|[Follow us (ru)](https://golos.io/@steepshot)|[Follow us (en)](https://steemit.com/@steepshot)
---|---|---|---|---|---

# Ditch
The essence of the library is to generate a transaction according to the required operations (vote, comment, etc.), sign the transaction and broadcast to the Graphene-based blockchain. 

## Supported chains:
 * Golos (hf 0.18.0)
 * Steem (hf 0.19.4)
 * EOS (DAWN 3.0)
  
## Additional features:
 * Transliteration (Cyrillic to Latin)
 * Base58 converter
 * Can connect by https or socket (wss)

## Usage
    //set global properties
    public void SetUp()
    {
        var jss = new JsonSerializerSettings
            {
                DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                Culture = CultureInfo.InvariantCulture
            };
        
        //_operationManager = new OperationManager(new WebSocketManager(jss), jss);
        _operationManager = new OperationManager(new HttpManager(jss), jss);
        
        // Steem
        //var url = _operationManager.TryConnectTo(new List<string> {"wss://steemd.steemit.com", }, CancellationToken.None);
        var url = _operationManager.TryConnectTo(new List<string> { "https://api.steemit.com", }, CancellationToken.None);
        
        // Golos
        //var url = _operationManager.TryConnectTo(new List<string> { "wss://ws.golos.io", }, CancellationToken.None);
        //var url = _operationManager.TryConnectTo(new List<string> { "https://public-ws.golos.io", }, CancellationToken.None);
        
        if (!string.IsNullOrEmpty(url))
            Console.WriteLine($"Conected to {url}");
        YouPrivateKeys = new List<byte[]>
        {
            Base58.GetBytes("5**************************************************") \\WIF
        };
        YouLogin = "username";
    }
    
    //Create new post with some beneficiaries
    var postOp = new PostOperation("parentPermlink", YouLogin, "Title", "Body", "jsonMetadata");
    var benOp = new BeneficiariesOperation(YouLogin, postOp.Permlink, _operationManager.SbdSymbol, new Beneficiary("someBeneficiarName", 1000));
    var responce = _operationManager.BroadcastOperations(YouPrivateKeys, CancellationToken.None, postOp, benOp);
    
    //UpVote
    var voteOp = new UpVoteOperation(YouLogin, "someUserName", "somePermlink");
    var responce = _operationManager.BroadcastOberations(YouPrivateKeys, CancellationToken.None, voteOp);
    
    //Follow
    var followOp = new FollowOperation(YouLogin, "someUserName", FollowType.Blog, YouLogin);
    var responce = _operationManager.BroadcastOperations(YouPrivateKeys, CancellationToken.None, followOp);
