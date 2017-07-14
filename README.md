# Ditch
The essence of the library is to generate a transaction according to the required operations (vote, comment, etc.), sign the transaction and broadcast to the Graphene-based blockchain (Golos/Steem). 

## Supported operations

Get:
* DynamicGlobalProperties
* Content
* GetAccounts
* GetCustomRequest
* VerifyAuthority 

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
 * Steemit

## Usage
    //set global properties
    GlobalSettings.Init(Name, PostingKey, ChainManager.KnownChains.Steem);
     _operationManager = new OperationManager();
    
    //Create new post with some beneficiaries
    var op1 = new PostOperation(parentPermlink, GlobalSettings.Login, permlink, title, body, jsonMetadata);
    var op2 = new BeneficiaresOperation(GlobalSettings.Login, permlink, GlobalSettings.ChainInfo.SbdSymbol, new Beneficiary(beneficiar, 1000));
    var responce = _operationManager.BroadcastOberations(op1, op2);
    
    //UpVote
    var op1 = new UpVoteOperation(GlobalSettings.Login, author, permlink);
    var responce = _operationManager.BroadcastOberations(op1);

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
