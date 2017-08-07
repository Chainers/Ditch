# Ditch
The essence of the library is to generate a transaction according to the required operations (vote, comment, etc.), sign the transaction and broadcast to the Graphene-based blockchain (Golos/Steem). 

## Supported operations

Get:
* DynamicGlobalProperties
* Content
* GetAccounts
* GetCustomRequest
* VerifyAuthority
* GetFollowing
* GetFollowers
* LookupAccountNames
* LookupAccounts
* GetAccountCount
* GetAccountBandwidth
* GetWitnessSchedule
* GetState
* GetNextScheduledHardfork
* GetKeyReferences
* GetHardforkVersion
* GetFeedHistory
* GetCurrentMedianHistoryPrice
* GetConfig
* GetChainProperties
* GetConversionRequests
* GetAccountHistory
* GetAccountReferences
	
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
  
## Supported chains:
 * Golos
 * Steem
 
## Additional features:
 * Transliteration (Cyrillic to Latin)
 * Base58 converter

## Usage
    //set global properties
    public void SetUp()
    {
        Chain = ChainManager.GetChainInfo(KnownChains.Steem);
        OperationManager = new OperationManager(Chain.Url, Chain.ChainId, Chain.JsonSerializerSettings);
        userPrivateKeys = new List<byte[]>
        {
            Base58.GetBytes(WIF)
        };        
    }
    
    //Create new post with some beneficiaries
    var postOp = new PostOperation("parentPermlink", YouLogin, "Title", "Body", "jsonMetadata");
    var benOp = new BeneficiaresOperation(YouLogin, postOp.Permlink, Chain.SbdSymbol, new Beneficiary("someBeneficiarName", 1000));
    var responce = _operationManager.BroadcastOberations(YouPrivateKeys, postOp, benOp);
    
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
