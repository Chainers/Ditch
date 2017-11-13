# Ditch
The essence of the library is to generate a transaction according to the required operations (vote, comment, etc.), sign the transaction and broadcast to the Graphene-based blockchain. 

## Supported chains:
 * Golos
 * Steem
 
## Supported operations

DatabaseApi:
* GetTrendingTags - Returns a list of tags (tags) that include word combinations
* GetState - Displays the current network status.
* GetActiveWitnesses - Displays a list of all active delegates.
* GetMinerQueue - Creates a list of the miners waiting to enter the DPOW chain to create the block.
* GetBlockHeader - Retrieve a block header
* GetBlock - Retrieve a full, signed block
* GetOpsInBlock - Get sequence of operations included/generated within a particular block
* GetConfig - Displays the current node configuration.
* GetDynamicGlobalProperties - Returns the block chain's rapidly-changing properties.
* GetChainProperties - Displays the commission for creating the user, the maximum block size and the GBG interest rate
* GetCurrentMedianHistoryPrice - Displays the current median price of conversion
* GetFeedHistory - Displays the conversion history
* GetWitnessSchedule - Displays the current delegation status.
* GetHardforkVersion - Displays the current version of the network.
* GetNextScheduledHardfork - Displays the date and version of HardFork
* GetKeyReferences -
* GetAccountReferences -
* LookupAccountNames - Get a list of accounts by name
* LookupAccounts - Returns the names of users close to the phrase.
* GetAccountCount - Get the total number of accounts registered with the blockchain
* GetOwnerHistory - Displays the user name if he changed the ownership of the blockchain
* GetRecoveryRequest - Returns true if the user is in recovery status.
* GetEscrow - Returns the operations implemented through mediation.
* GetWithdrawRoutes - Returns all transfers to the user's account, depending on the type
* GetAccountBandwidth - Displays user actions based on type
* GetSavingsWithdrawFrom - Returns the output data from 'SAFE' for this user
* GetSavingsWithdrawTo - Returns the output data from 'SAFE' for this user
* GetWitnesses - Get a list of witnesses by ID
* GetConversionRequests - Returns the current requests for conversion by the specified user
* GetWitnessByAccount - Get the witness owned by a given account
* GetWitnessesByVote - This method is used to fetch witnesses with pagination.
* LookupWitnessAccounts -  Get names and IDs for registered witnesses
* GetWitnessCount - Get the total number of witnesses registered with the blockchain
* GetOrderBook - Gets the current order book for STEEM:SBD market
* GetOpenOrders - Get open orders 

Get:
* GetContent
* GetAccounts
* GetCustomRequest
* VerifyAuthority
* GetFollowing
* GetFollowers
* GetAccountHistory
* GetTrendingCategories
* GetBestCategories
* GetActiveCategories
* GetRecentCategories

Post:
* VoteOperation (vote) 
  * UpVoteOperation inherit VoteOperation
  * DownVoteOperation inherit VoteOperation
  * FlagOperation inherit VoteOperation
* CustomJsonOperation (custom_json)
  * RePostOperation inherit CustomJsonOperation
  * FollowOperation inherit CustomJsonOperation
  * UnfollowOperation inherit FollowOperation
* CommentOperation (comment)
  * PostOperation inherit CommentOperation
  * ReplyOperation inherit CommentOperation
* CommentOptionsOperation (comment_options) 
  * BeneficiaresOperation (beneficiaries) inherit CommentOptionsOperation
 
## Additional features:
 * Transliteration (Cyrillic to Latin)
 * Base58 converter

## Usage
    //set global properties
    public void SetUp()
    {
        _operationManager = new OperationManager();
        var url = _operationManager.TryConnectTo(new List<string> {"wss://steemd.steemit.com"}) // Steem
        //var url = _operationManager.TryConnectTo(new List<string> { "wss://ws.golos.io" }); // Golos
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
    var responce = _operationManager.BroadcastOperations(YouPrivateKeys, postOp, benOp);
    
    //UpVote
    var voteOp = new UpVoteOperation(YouLogin, "someUserName", "somePermlink");
    var responce = _operationManager.BroadcastOberations(YouPrivateKeys, voteOp);
    
    //Follow
    var followOp = new FollowOperation(YouLogin, "someUserName", FollowType.Blog, YouLogin);
    var responce = _operationManager.BroadcastOperations(YouPrivateKeys, followOp);

## Sources

The library is written based on the article https://steemit.com/steem/@xeroc/steem-transaction-signing-in-a-nutshell as well as the existing code:
* https://github.com/steemit/steem
* https://github.com/xeroc/piston-lib
* https://github.com/xeroc/python-graphenelib

## References

* [Cryptography.ECDSA.Secp256k1 (>= 1.0.1)](https://github.com/Chainers/Cryptography.ECDSA)
* [NETStandard.Library (>= 1.6.1)](https://www.nuget.org/packages/NETStandard.Library)
* [Newtonsoft.Json (>= 10.0.3)](https://www.nuget.org/packages/Newtonsoft.Json)
* [WebSocket4Net (>= 0.15.0-beta9)](https://www.nuget.org/packages/WebSocket4Net)

## Feedback

* https://t.me/steepshot_en
* https://t.me/steepshot_ru