<a id="Ditch.Steem.OperationManager"></a>
## OperationManager
*class Ditch.Steem.OperationManager*

market_history_api
\libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp

**Methods**

<a id="Ditch.Steem.OperationManager.BroadcastBlock(Ditch.Steem.Objects.SignedBlock,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **BroadcastBlock** *(SignedBlock block, CancellationToken token)*  
  API name: broadcast_block  

<a id="Ditch.Steem.OperationManager.SetMaxBlockAge(System.Int32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **SetMaxBlockAge** *(Int32 maxBlockAge, CancellationToken token)*  
  API name: set_max_block_age  

<a id="Ditch.Steem.OperationManager.GetTicker(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;MarketTicker&gt;* **GetTicker** *(CancellationToken token)*  
  API name: get_ticker
Returns the market ticker for the internal SBD:STEEM market
            
*Returns the market ticker for the internal market  

<a id="Ditch.Steem.OperationManager.GetVolume(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;MarketVolume&gt;* **GetVolume** *(CancellationToken token)*  
  API name: get_volume
Returns the market volume for the past 24 hours  

<a id="Ditch.Steem.OperationManager.GetOrderBook2(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OrderBook&gt;* **GetOrderBook2** *(UInt32 limit, CancellationToken token)*  
  API name: get_order_book
Returns the current order book for the internal SBD:STEEM market.
            
*Displays a list of applications on the internal exchange for the purchase and sale of the network  

<a id="Ditch.Steem.OperationManager.GetTradeHistory(System.DateTime,System.DateTime,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;MarketTrade[]&gt;* **GetTradeHistory** *(DateTime start, DateTime end, UInt32 limit, CancellationToken token)*  
  API name: get_trade_history
Returns the trade history for the internal SBD:STEEM market.
            
*Returns the trade history for the internal market.  

<a id="Ditch.Steem.OperationManager.GetRecentTrades(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;MarketTrade[]&gt;* **GetRecentTrades** *(UInt32 limit, CancellationToken token)*  
  API name: get_recent_trades
Returns the N most recent trades for the internal SBD:STEEM market.
            
*Returns the N most recent trades for the internal market.  

<a id="Ditch.Steem.OperationManager.GetMarketHistory(System.UInt32,System.DateTime,System.DateTime,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BucketObject[]&gt;* **GetMarketHistory** *(UInt32 bucketSeconds, DateTime start, DateTime end, CancellationToken token)*  
  API name: get_market_history
Returns the market history for the internal SBD:STEEM market.
            
*Returns the market history for the internal market.  

<a id="Ditch.Steem.OperationManager.GetMarketHistoryBuckets(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt32[]&gt;* **GetMarketHistoryBuckets** *(CancellationToken token)*  
  API name: get_market_history_buckets
Returns the bucket seconds being tracked by the plugin.
            
*Returns the bucket seconds being tracked by the plugin  

<a id="Ditch.Steem.OperationManager.GetKeyReferences(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[][]&gt;* **GetKeyReferences** *(String[] keys, CancellationToken token)*  
  API name: get_key_references  

<a id="Ditch.Steem.OperationManager.TryConnectTo(System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken)"></a>

* *String* **TryConnectTo** *(List&lt;String&gt; urls, CancellationToken token)*  

<a id="Ditch.Steem.OperationManager.RetryConnect(System.Threading.CancellationToken)"></a>

* *String* **RetryConnect** *(CancellationToken token)*  

<a id="Ditch.Steem.OperationManager.BroadcastOperations(System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Steem.Operations.Post.BaseOperation[])"></a>

* *JsonRpcResponse* **BroadcastOperations** *(IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] operations)*  

<a id="Ditch.Steem.OperationManager.VerifyAuthority(System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Steem.Operations.Post.BaseOperation[])"></a>

* *JsonRpcResponse&lt;Boolean&gt;* **VerifyAuthority** *(IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] testOps)*  

<a id="Ditch.Steem.OperationManager.CustomGetRequest(System.String,System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse&lt;T&gt;* **CustomGetRequest** *(String method, CancellationToken token, Object[] data)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Steem.OperationManager.CustomGetRequest(System.String,System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse* **CustomGetRequest** *(String method, CancellationToken token, Object[] data)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Steem.OperationManager.CallRequest(System.String,System.String,System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **CallRequest** *(String api, String method, Object[] data, CancellationToken token)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Steem.OperationManager.CallRequest(System.String,System.String,System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;T&gt;* **CallRequest** *(String api, String method, Object[] data, CancellationToken token)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Steem.OperationManager.CreateTransaction(Ditch.Steem.Objects.DynamicGlobalPropertyApiObj,System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Steem.Operations.Post.BaseOperation[])"></a>

* *SignedTransaction* **CreateTransaction** *(DynamicGlobalPropertyApiObj propertyApiObj, IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] operations)*  

<a id="Ditch.Steem.OperationManager.GetTrendingTags(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;TagApiObj[]&gt;* **GetTrendingTags** *(String afterTag, UInt32 limit, CancellationToken token)*  
  API name: get_trending_tags
*Returns a list of tags (tags) that include word combinations  

<a id="Ditch.Steem.OperationManager.GetState(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;State&gt;* **GetState** *(String path, CancellationToken token)*  
  API name: get_state
This API is a short-cut for returning all of the state required for a particular URL
with a single query.
            
*Displays the current network status.  

<a id="Ditch.Steem.OperationManager.GetActiveWitnesses(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetActiveWitnesses** *(CancellationToken token)*  
  API name: get_active_witnesses
*Displays a list of all active delegates.  

<a id="Ditch.Steem.OperationManager.GetMinerQueue(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetMinerQueue** *(CancellationToken token)*  
  API name: get_miner_queue
*Creates a list of the miners waiting to enter the DPOW chain to create the block.  

<a id="Ditch.Steem.OperationManager.GetBlockHeader(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BlockHeader&gt;* **GetBlockHeader** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block_header
Retrieve a block header
            
*Returns block for given number  

<a id="Ditch.Steem.OperationManager.GetBlock(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SignedBlockApiObj&gt;* **GetBlock** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block
Retrieve a full, signed block
            
*Returns block for given number  

<a id="Ditch.Steem.OperationManager.GetOpsInBlock(System.UInt32,System.Boolean,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AppliedOperation[]&gt;* **GetOpsInBlock** *(UInt32 blockNum, Boolean onlyVirtual, CancellationToken token)*  
  API name: get_ops_in_block
Get sequence of operations included/generated within a particular block
            
*Returns all operations in the block, if the parameter 'onlyVirtual' is true, then returns only the virtual operations  

<a id="Ditch.Steem.OperationManager.GetConfig(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetConfig** *(CancellationToken token)*  
  API name: get_config
Retrieve compile-time constants
            
*Displays the current node configuration.  

<a id="Ditch.Steem.OperationManager.GetDynamicGlobalProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;DynamicGlobalPropertyApiObj&gt;* **GetDynamicGlobalProperties** *(CancellationToken token)*  
  API name: get_dynamic_global_properties
Retrieve the current @ref dynamic_global_property_object
            
*Displays information about the current network status.  

<a id="Ditch.Steem.OperationManager.GetChainProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ChainProperties&gt;* **GetChainProperties** *(CancellationToken token)*  
  API name: get_chain_properties
*Displays the commission for creating the user, the maximum block size and the GBG interest rate.  

<a id="Ditch.Steem.OperationManager.GetCurrentMedianHistoryPrice(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Price&gt;* **GetCurrentMedianHistoryPrice** *(CancellationToken token)*  
  API name: get_current_median_history_price
*Displays the current median price of conversion  

<a id="Ditch.Steem.OperationManager.GetFeedHistory(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FeedHistoryApiObj&gt;* **GetFeedHistory** *(CancellationToken token)*  
  API name: get_feed_history
*Displays the conversion history  

<a id="Ditch.Steem.OperationManager.GetWitnessSchedule(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessScheduleApiObj&gt;* **GetWitnessSchedule** *(CancellationToken token)*  
  API name: get_witness_schedule
*Displays the current delegation status.  

<a id="Ditch.Steem.OperationManager.GetHardforkVersion(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String&gt;* **GetHardforkVersion** *(CancellationToken token)*  
  API name: get_hardfork_version
*Displays the current version of the network.  

<a id="Ditch.Steem.OperationManager.GetNextScheduledHardfork(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ScheduledHardfork&gt;* **GetNextScheduledHardfork** *(CancellationToken token)*  
  API name: get_next_scheduled_hardfork
*Displays the date and version of HardFork  

<a id="Ditch.Steem.OperationManager.GetKeyReferences(System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetKeyReferences** *(Object[] key, CancellationToken token)*  
  API name: get_key_references  

<a id="Ditch.Steem.OperationManager.GetAccounts(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ExtendedAccount[]&gt;* **GetAccounts** *(String[] names, CancellationToken token)*  
  API name: get_accounts
*Returns data for specified accounts  

<a id="Ditch.Steem.OperationManager.GetAccountReferences(System.Object,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetAccountReferences** *(Object accountId, CancellationToken token)*  
  API name: get_account_references  

<a id="Ditch.Steem.OperationManager.LookupAccountNames(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountApiObj[]&gt;* **LookupAccountNames** *(String[] accountNames, CancellationToken token)*  
  API name: lookup_account_names
Get a list of accounts by name
            
*Returns data for specified accounts  

<a id="Ditch.Steem.OperationManager.LookupAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **LookupAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_accounts
Get names and IDs for registered accounts
            
*Returns the names of users close to the phrase.  

<a id="Ditch.Steem.OperationManager.GetAccountCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetAccountCount** *(CancellationToken token)*  
  API name: get_account_count
Get the total number of accounts registered with the blockchain
            
*Returns the number of registered users.  

<a id="Ditch.Steem.OperationManager.GetOwnerHistory(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OwnerAuthorityHistoryApiObj[]&gt;* **GetOwnerHistory** *(String account, CancellationToken token)*  
  API name: get_owner_history
*Displays the user name if he changed the ownership of the blockchain  

<a id="Ditch.Steem.OperationManager.GetRecoveryRequest(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountRecoveryRequestApiObj&gt;* **GetRecoveryRequest** *(String account, CancellationToken token)*  
  API name: get_recovery_request
*Returns true if the user is in recovery status.  

<a id="Ditch.Steem.OperationManager.GetEscrow(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;EscrowApiObj&gt;* **GetEscrow** *(String from, UInt32 escrowId, CancellationToken token)*  
  API name: get_escrow
*Returns the operations implemented through mediation.  

<a id="Ditch.Steem.OperationManager.GetWithdrawRoutes(System.String,Ditch.Steem.Enums.WithdrawRouteType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WithdrawRoute[]&gt;* **GetWithdrawRoutes** *(String account, WithdrawRouteType type, CancellationToken token)*  
  API name: get_withdraw_routes
*Returns all transfers to the user's account, depending on the type  

<a id="Ditch.Steem.OperationManager.GetAccountBandwidth(System.String,Ditch.Steem.Enums.BandwidthType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountBandwidthApiObj&gt;* **GetAccountBandwidth** *(String account, BandwidthType type, CancellationToken token)*  
  API name: get_account_bandwidth
*Displays user actions based on type  

<a id="Ditch.Steem.OperationManager.GetSavingsWithdrawFrom(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawFrom** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_from
*Returns the output data from 'SAFE' for this user  

<a id="Ditch.Steem.OperationManager.GetSavingsWithdrawTo(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawTo** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_to
*Returns the output data from 'SAFE' for this user  

<a id="Ditch.Steem.OperationManager.GetWitnesses(System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnesses** *(Object[] witnessIds, CancellationToken token)*  
  API name: get_witnesses
Get a list of witnesses by ID
            
*Displays delegate data according to the specified ID  

<a id="Ditch.Steem.OperationManager.GetConversionRequests(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ConvertRequestApiObj[]&gt;* **GetConversionRequests** *(String accountName, CancellationToken token)*  
  API name: get_conversion_requests
*Returns the current requests for conversion by the specified user  

<a id="Ditch.Steem.OperationManager.GetWitnessByAccount(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj&gt;* **GetWitnessByAccount** *(String accountName, CancellationToken token)*  
  API name: get_witness_by_account
Get the witness owned by a given account
            
*Displays data about the delegate (if it is) according to the data from the request  

<a id="Ditch.Steem.OperationManager.GetWitnessesByVote(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnessesByVote** *(String from, UInt32 limit, CancellationToken token)*  
  API name: get_witnesses_by_vote
This method is used to fetch witnesses with pagination.
            
*Displays a limited list of delegates approving the vote.  

<a id="Ditch.Steem.OperationManager.LookupWitnessAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object[]&gt;* **LookupWitnessAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_witness_accounts
Get names and IDs for registered witnesses
            
*Displays a limited list of users who have announced their intention to work as a delegate.  

<a id="Ditch.Steem.OperationManager.GetWitnessCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetWitnessCount** *(CancellationToken token)*  
  API name: get_witness_count
Get the total number of witnesses registered with the blockchain
            
*Displays the number of delegates.  

<a id="Ditch.Steem.OperationManager.GetOrderBook(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OrderBook&gt;* **GetOrderBook** *(UInt32 limit, CancellationToken token)*  
  API name: get_order_book
Gets the current order book for STEEM:SBD market
            
*Displays a list of applications on the internal exchange for the purchase and sale of the network  

<a id="Ditch.Steem.OperationManager.GetOpenOrders(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ExtendedLimitOrder[]&gt;* **GetOpenOrders** *(String owner, CancellationToken token)*  
  API name: get_open_orders
*Displays a list of orders on the internal exchange for the purchase and sale on the network for the specified user.  

<a id="Ditch.Steem.OperationManager.GetActiveVotes(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;VoteState[]&gt;* **GetActiveVotes** *(String author, String permlink, CancellationToken token)*  
  API name: get_active_votes
*Displays the list of users who voted for the specified entry  

<a id="Ditch.Steem.OperationManager.GetContent(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion&gt;* **GetContent** *(String author, String permlink, CancellationToken token)*  
  API name: get_content
*Gets information about the publication, with the exception of comments  

<a id="Ditch.Steem.OperationManager.GetContentReplies(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetContentReplies** *(String parent, String parentPermlink, CancellationToken token)*  
  API name: get_content_replies
*Displays a list of all comments for the selected publication  

<a id="Ditch.Steem.OperationManager.GetTagsUsedByAuthor(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;KeyValuePair`2[]&gt;* **GetTagsUsedByAuthor** *(String author, CancellationToken token)*  
  API name: get_tags_used_by_author
Used to retrieve top 1000 tags list used by an author sorted by most frequently used  

<a id="Ditch.Steem.OperationManager.GetDiscussionsByAuthorBeforeDate(System.String,System.String,System.DateTime,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetDiscussionsByAuthorBeforeDate** *(String author, String startPermlink, DateTime beforeDate, UInt32 limit, CancellationToken token)*  
  API name: get_discussions_by_author_before_date
This method is used to fetch all posts/comments by start_author that occur after before_date and start_permlink with up to limit being returned.

If start_permlink is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
should allow easy pagination.
            
*Displays a limited number of user publications  

<a id="Ditch.Steem.OperationManager.GetAccountHistory(System.String,System.UInt64,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object[]&gt;* **GetAccountHistory** *(String account, UInt64 from, UInt32 limit, CancellationToken token)*  
  API name: get_account_history
Account operations have sequence numbers from 0 to N where N is the most recent operation. This method
returns operations in the range [from-limit, from]

*The history of all user actions on the network in the form of transactions. If from = -1, then are last {limit+1} history elements are shown. Parameter limit should be less or equals {from} (except from = -1). This is because elements preceding {from} are shown.  

<a id="Ditch.Steem.OperationManager.GetFollowers(System.String,System.String,Ditch.Steem.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowers** *(String to, String start, FollowType type, UInt16 limit, CancellationToken token)*  
  API name: get_followers
*Returns the list: Either all of the subscribers of the user are 'following'. Or, if the user name is specified, the list of matching subscribers is returned in the parameter 'startFollower'.  

<a id="Ditch.Steem.OperationManager.GetFollowing(System.String,System.String,Ditch.Steem.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowing** *(String from, String start, FollowType type, UInt16 limit, CancellationToken token)*  
  API name: get_following  

<a id="Ditch.Steem.OperationManager.GetFollowCount(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowCountApiObj&gt;* **GetFollowCount** *(String account, CancellationToken token)*  
  API name: get_follow_count
*Returns information about the number of subscribers and subscriptions of the specified user.  

<a id="Ditch.Steem.OperationManager.GetFeedEntries(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FeedEntry[]&gt;* **GetFeedEntries** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_feed_entries
*Returns brief information about records from the specified user's tape  

<a id="Ditch.Steem.OperationManager.GetFeed(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CommentFeedEntry[]&gt;* **GetFeed** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_feed
*Returns the complete record data from the specified user's tape.  

<a id="Ditch.Steem.OperationManager.GetBlogEntries(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BlogEntry[]&gt;* **GetBlogEntries** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_blog_entries
*Returns brief information about records from the blog of the specified user.  

<a id="Ditch.Steem.OperationManager.GetBlog(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CommentBlogEntry[]&gt;* **GetBlog** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_blog
*Returns the complete record data from the blog of the specified user.  

<a id="Ditch.Steem.OperationManager.GetAccountReputations(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountReputation[]&gt;* **GetAccountReputations** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: get_account_reputations
*Returns data about the reputation of users filtered by template.  

<a id="Ditch.Steem.OperationManager.GetRebloggedBy(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetRebloggedBy** *(String author, String permlink, CancellationToken token)*  
  API name: get_reblogged_by
Gets list of accounts that have reblogged a particular post
            
*Returns the list of users who either created the record or made it a repost.  

<a id="Ditch.Steem.OperationManager.GetBlogAuthors(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object[][]&gt;* **GetBlogAuthors** *(String blogAccount, CancellationToken token)*  
  API name: get_blog_authors
Gets a list of authors that have had their content reblogged on a given blog account
            
*Returns the list of authors and the number of reposts of this author by the user.  

<a id="Ditch.Steem.OperationManager.Login(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Boolean&gt;* **Login** *(String user, String password, CancellationToken token)*  
  API name: login
Authenticate to the RPC server
            
*Allows you to connect to the accounts on the network.  

<a id="Ditch.Steem.OperationManager.GetApiByName(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetApiByName** *(String apiName, CancellationToken token)*  
  API name: get_api_by_name
*Returns the unique API identifier by its name.  

<a id="Ditch.Steem.OperationManager.GetVersion(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SteemVersionInfo&gt;* **GetVersion** *(CancellationToken token)*  
  API name: get_version
*Returns the version information for the components of the blockchain.  

<a id="Ditch.Steem.OperationManager.BroadcastTransaction(Ditch.Steem.Objects.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **BroadcastTransaction** *(SignedTransaction trx, CancellationToken token)*  
  API name: broadcast_transaction
Broadcast a transaction to the network
            
*The transaction will be checked for validity in the local database prior to broadcasting. If it fails to apply locally, an error will be thrown and the transaction will not be broadcast.  

<a id="Ditch.Steem.OperationManager.BroadcastTransactionWithCallback(System.Object,Ditch.Steem.Objects.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **BroadcastTransactionWithCallback** *(Object cb, SignedTransaction trx, CancellationToken token)*  
  API name: broadcast_transaction_with_callback
this version of broadcast transaction registers a callback method that will be called when the transaction is
included into a block.  The callback method includes the transaction id, block number, and transaction number in the
block.  

<a id="Ditch.Steem.OperationManager.BroadcastTransactionSynchronous(Ditch.Steem.Objects.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **BroadcastTransactionSynchronous** *(SignedTransaction trx, CancellationToken token)*  
  API name: broadcast_transaction_synchronous
This call will not return until the transaction is included in a block.  


**Properties and Fields**

<a id="Ditch.Steem.OperationManager.ChainId"></a>

* *Byte[]* **ChainId**  


<a id="Ditch.Steem.OperationManager.SbdSymbol"></a>

* *String* **SbdSymbol**  


<a id="Ditch.Steem.OperationManager.Version"></a>

* *Int32* **Version**  


<a id="Ditch.Steem.OperationManager.IsConnected"></a>

* *Boolean* **IsConnected**  






---

<a id="Ditch.Steem.Operations.OperationType"></a>
## OperationType
*enum Ditch.Steem.Operations.OperationType*

https://github.com/steemit/steem/blob/master/libraries/protocol/include/steemit/protocol/operations.hpp
 NOTE:  do not change the order of any operations

**Enum Values**

* **Vote**
* **Comment**
* **Transfer**
* **TransferToVesting**
* **WithdrawVesting**
* **LimitOrderCreate**
* **LimitOrderCancel**
* **FeedPublish**
* **Convert**
* **AccountCreate**
* **AccountUpdate**
* **WitnessUpdate**
* **AccountWitnessVote**
* **AccountWitnessProxy**
* **Pow**
* **Custom**
* **ReportOverProduction**
* **DeleteComment**
* **CustomJson**
* **CommentOptions**
* **SetWithdrawVestingRoute**
* **LimitOrderCreate2**
* **ChallengeAuthority**
* **ProveAuthority**
* **RequestAccountRecovery**
* **RecoverAccount**
* **ChangeRecoveryAccount**
* **EscrowTransfer**
* **EscrowDispute**
* **EscrowRelease**
* **Pow2**
* **EscrowApprove**
* **TransferToSavings**
* **TransferFromSavings**
* **CancelTransferFromSavings**
* **CustomBinaryOperation**
* **DeclineVotingRightsOperation**
* **ResetAccountOperation**
* **SetResetAccountOperation**
* **AccountCreateWithDelegation**


---

<a id="Ditch.Steem.Operations.Post.BaseOperation"></a>
## BaseOperation
*class Ditch.Steem.Operations.Post.BaseOperation*

base_operation

**Properties and Fields**

<a id="Ditch.Steem.Operations.Post.BaseOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Steem.Operations.Post.BaseOperation.TypeName"></a>

* *String* **TypeName**  






---

<a id="Ditch.Steem.Operations.Post.CommentOperation"></a>
## CommentOperation
*class Ditch.Steem.Operations.Post.CommentOperation: Ditch.Steem.Operations.Post.BaseOperation*

comment_operation

**Properties and Fields**

<a id="Ditch.Steem.Operations.Post.CommentOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Steem.Operations.Post.CommentOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Steem.Operations.Post.CommentOperation.ParentAuthor"></a>

* *String* **ParentAuthor**  
  API name: parent_author  


<a id="Ditch.Steem.Operations.Post.CommentOperation.ParentPermlink"></a>

* *String* **ParentPermlink**  
  API name: parent_permlink  


<a id="Ditch.Steem.Operations.Post.CommentOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Steem.Operations.Post.CommentOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Steem.Operations.Post.CommentOperation.Title"></a>

* *String* **Title**  
  API name: title  


<a id="Ditch.Steem.Operations.Post.CommentOperation.Body"></a>

* *String* **Body**  
  API name: body  


<a id="Ditch.Steem.Operations.Post.CommentOperation.JsonMetadata"></a>

* *String* **JsonMetadata**  
  API name: json_metadata  






---

<a id="Ditch.Steem.Operations.Post.DeleteCommentOperation"></a>
## DeleteCommentOperation
*class Ditch.Steem.Operations.Post.DeleteCommentOperation: Ditch.Steem.Operations.Post.BaseOperation*

delete_comment_operation
libraries\protocol\include\steemit\protocol\steem_operations.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Post.DeleteCommentOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Steem.Operations.Post.DeleteCommentOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Steem.Operations.Post.DeleteCommentOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Steem.Operations.Post.DeleteCommentOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  






---

<a id="Ditch.Steem.Operations.Post.FollowOperation"></a>
## FollowOperation
*class Ditch.Steem.Operations.Post.FollowOperation: Ditch.Steem.Operations.Post.CustomJsonOperation*

Follow / Unfollow some author



---

<a id="Ditch.Steem.Operations.Post.RePostOperation"></a>
## RePostOperation
*class Ditch.Steem.Operations.Post.RePostOperation: Ditch.Steem.Operations.Post.CustomJsonOperation*

Repost some post by author and permlink (loads all additional parameters from the blockchain)



---

<a id="Ditch.Steem.Operations.Post.UnfollowOperation"></a>
## UnfollowOperation
*class Ditch.Steem.Operations.Post.UnfollowOperation: Ditch.Steem.Operations.Post.FollowOperation*

Unfollow some author



---

<a id="Ditch.Steem.Operations.Post.VoteOperation"></a>
## VoteOperation
*class Ditch.Steem.Operations.Post.VoteOperation: Ditch.Steem.Operations.Post.BaseOperation*

Vote up/down/flag post

**Properties and Fields**

<a id="Ditch.Steem.Operations.Post.VoteOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Steem.Operations.Post.VoteOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Steem.Operations.Post.VoteOperation.Voter"></a>

* *String* **Voter**  


<a id="Ditch.Steem.Operations.Post.VoteOperation.Author"></a>

* *String* **Author**  


<a id="Ditch.Steem.Operations.Post.VoteOperation.Permlink"></a>

* *String* **Permlink**  


<a id="Ditch.Steem.Operations.Post.VoteOperation.Weight"></a>

* *Int16* **Weight**  
  An weignt from 0 to 10000. -10000 for flag  






---

<a id="Ditch.Steem.Objects.AccountApiObj"></a>
## AccountApiObj
*class Ditch.Steem.Objects.AccountApiObj*

account_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.AccountApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Steem.Objects.AccountApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Steem.Objects.AccountApiObj.Owner"></a>

* *Authority* **Owner**  
  used for backup control, can set owner or active  


<a id="Ditch.Steem.Objects.AccountApiObj.Active"></a>

* *Authority* **Active**  
  used for all monetary operations, can set active or posting  


<a id="Ditch.Steem.Objects.AccountApiObj.Posting"></a>

* *Authority* **Posting**  
  used for voting and posting  


<a id="Ditch.Steem.Objects.AccountApiObj.MemoKey"></a>

* *String* **MemoKey**  


<a id="Ditch.Steem.Objects.AccountApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Steem.Objects.AccountApiObj.Proxy"></a>

* *String* **Proxy**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastOwnerUpdate"></a>

* *DateTime* **LastOwnerUpdate**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastAccountUpdate"></a>

* *DateTime* **LastAccountUpdate**  


<a id="Ditch.Steem.Objects.AccountApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Steem.Objects.AccountApiObj.Mined"></a>

* *Boolean* **Mined**  


<a id="Ditch.Steem.Objects.AccountApiObj.OwnerChallenged"></a>

* *Boolean* **OwnerChallenged**  


<a id="Ditch.Steem.Objects.AccountApiObj.ActiveChallenged"></a>

* *Boolean* **ActiveChallenged**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastOwnerProved"></a>

* *DateTime* **LastOwnerProved**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastActiveProved"></a>

* *DateTime* **LastActiveProved**  


<a id="Ditch.Steem.Objects.AccountApiObj.RecoveryAccount"></a>

* *String* **RecoveryAccount**  


<a id="Ditch.Steem.Objects.AccountApiObj.ResetAccount"></a>

* *String* **ResetAccount**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastAccountRecovery"></a>

* *DateTime* **LastAccountRecovery**  


<a id="Ditch.Steem.Objects.AccountApiObj.CommentCount"></a>

* *UInt32* **CommentCount**  


<a id="Ditch.Steem.Objects.AccountApiObj.LifetimeVoteCount"></a>

* *UInt32* **LifetimeVoteCount**  


<a id="Ditch.Steem.Objects.AccountApiObj.PostCount"></a>

* *UInt32* **PostCount**  


<a id="Ditch.Steem.Objects.AccountApiObj.CanVote"></a>

* *Boolean* **CanVote**  


<a id="Ditch.Steem.Objects.AccountApiObj.VotingPower"></a>

* *UInt16* **VotingPower**  
  Current voting power of this account, it falls after every vote  


<a id="Ditch.Steem.Objects.AccountApiObj.LastVoteTime"></a>

* *DateTime* **LastVoteTime**  
  used to increase the voting power of this account the longer it goes without voting.  


<a id="Ditch.Steem.Objects.AccountApiObj.Balance"></a>

* *Money* **Balance**  
  total liquid shares held by this account  


<a id="Ditch.Steem.Objects.AccountApiObj.SavingsBalance"></a>

* *Money* **SavingsBalance**  
  total liquid shares held by this account  


<a id="Ditch.Steem.Objects.AccountApiObj.SbdBalance"></a>

* *Money* **SbdBalance**  
  Total sbd balance  


<a id="Ditch.Steem.Objects.AccountApiObj.SbdSeconds"></a>

* *String* **SbdSeconds**  
  Total sbd * how long it has been hel  


<a id="Ditch.Steem.Objects.AccountApiObj.SbdSecondsLastUpdate"></a>

* *DateTime* **SbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Steem.Objects.AccountApiObj.SbdLastInterestPayment"></a>

* *DateTime* **SbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Steem.Objects.AccountApiObj.SavingsSbdBalance"></a>

* *Money* **SavingsSbdBalance**  
  total sbd balance  


<a id="Ditch.Steem.Objects.AccountApiObj.SavingsSbdSeconds"></a>

* *String* **SavingsSbdSeconds**  
  total sbd * how long it has been hel  


<a id="Ditch.Steem.Objects.AccountApiObj.SavingsSbdSecondsLastUpdate"></a>

* *DateTime* **SavingsSbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Steem.Objects.AccountApiObj.SavingsSbdLastInterestPayment"></a>

* *DateTime* **SavingsSbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Steem.Objects.AccountApiObj.SavingsWithdrawRequests"></a>

* *Byte* **SavingsWithdrawRequests**  


<a id="Ditch.Steem.Objects.AccountApiObj.RewardSbdBalance"></a>

* *Money* **RewardSbdBalance**  


<a id="Ditch.Steem.Objects.AccountApiObj.RewardSteemBalance"></a>

* *Money* **RewardSteemBalance**  


<a id="Ditch.Steem.Objects.AccountApiObj.RewardVestingBalance"></a>

* *Money* **RewardVestingBalance**  


<a id="Ditch.Steem.Objects.AccountApiObj.RewardVestingSteem"></a>

* *Money* **RewardVestingSteem**  


<a id="Ditch.Steem.Objects.AccountApiObj.CurationRewards"></a>

* *Object* **CurationRewards**  


<a id="Ditch.Steem.Objects.AccountApiObj.PostingRewards"></a>

* *Object* **PostingRewards**  


<a id="Ditch.Steem.Objects.AccountApiObj.VestingShares"></a>

* *Money* **VestingShares**  
  total vesting shares held by this account, controls its voting power  


<a id="Ditch.Steem.Objects.AccountApiObj.DelegatedVestingShares"></a>

* *Money* **DelegatedVestingShares**  


<a id="Ditch.Steem.Objects.AccountApiObj.ReceivedVestingShares"></a>

* *Money* **ReceivedVestingShares**  


<a id="Ditch.Steem.Objects.AccountApiObj.VestingWithdrawRate"></a>

* *Money* **VestingWithdrawRate**  
  at the time this is updated it can be at most vesting_shares/104  


<a id="Ditch.Steem.Objects.AccountApiObj.NextVestingWithdrawal"></a>

* *DateTime* **NextVestingWithdrawal**  
  after every withdrawal this is incremented by 1 week  


<a id="Ditch.Steem.Objects.AccountApiObj.Withdrawn"></a>

* *Object* **Withdrawn**  
  Track how many shares have been withdrawn  


<a id="Ditch.Steem.Objects.AccountApiObj.ToWithdraw"></a>

* *Object* **ToWithdraw**  
  Might be able to look this up with operation history.  


<a id="Ditch.Steem.Objects.AccountApiObj.WithdrawRoutes"></a>

* *UInt16* **WithdrawRoutes**  


<a id="Ditch.Steem.Objects.AccountApiObj.ProxiedVsfVotes"></a>

* *Object[]* **ProxiedVsfVotes**  


<a id="Ditch.Steem.Objects.AccountApiObj.WitnessesVotedFor"></a>

* *UInt16* **WitnessesVotedFor**  


<a id="Ditch.Steem.Objects.AccountApiObj.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Steem.Objects.AccountApiObj.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  


<a id="Ditch.Steem.Objects.AccountApiObj.AverageMarketBandwidth"></a>

* *Object* **AverageMarketBandwidth**  


<a id="Ditch.Steem.Objects.AccountApiObj.LifetimeMarketBandwidth"></a>

* *Object* **LifetimeMarketBandwidth**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastMarketBandwidthUpdate"></a>

* *DateTime* **LastMarketBandwidthUpdate**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastPost"></a>

* *DateTime* **LastPost**  


<a id="Ditch.Steem.Objects.AccountApiObj.LastRootPost"></a>

* *DateTime* **LastRootPost**  


<a id="Ditch.Steem.Objects.AccountApiObj.PostBandwidth"></a>

* *Object* **PostBandwidth**  


<a id="Ditch.Steem.Objects.AccountApiObj.NewAverageBandwidth"></a>

* *Object* **NewAverageBandwidth**  


<a id="Ditch.Steem.Objects.AccountApiObj.NewAverageMarketBandwidth"></a>

* *Object* **NewAverageMarketBandwidth**  






---

<a id="Ditch.Steem.Objects.AccountBandwidthApiObj"></a>
## AccountBandwidthApiObj
*class Ditch.Steem.Objects.AccountBandwidthApiObj: Ditch.Steem.Objects.AccountBandwidthObject*

account_bandwidth_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Objects.AccountBandwidthObject"></a>
## AccountBandwidthObject
*class Ditch.Steem.Objects.AccountBandwidthObject*

account_bandwidth_object
steem-0.19.1\libraries\plugins\witness\include\steemit\witness\witness_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.AccountBandwidthObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.AccountBandwidthObject.Account"></a>

* *String* **Account**  


<a id="Ditch.Steem.Objects.AccountBandwidthObject.Type"></a>

* *BandwidthType* **Type**  


<a id="Ditch.Steem.Objects.AccountBandwidthObject.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Steem.Objects.AccountBandwidthObject.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Steem.Objects.AccountBandwidthObject.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  






---

<a id="Ditch.Steem.Objects.AccountRecoveryRequestApiObj"></a>
## AccountRecoveryRequestApiObj
*class Ditch.Steem.Objects.AccountRecoveryRequestApiObj*

account_recovery_request_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.AccountRecoveryRequestApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.AccountRecoveryRequestApiObj.AccountToRecover"></a>

* *String* **AccountToRecover**  


<a id="Ditch.Steem.Objects.AccountRecoveryRequestApiObj.NewOwnerAuthority"></a>

* *Authority* **NewOwnerAuthority**  


<a id="Ditch.Steem.Objects.AccountRecoveryRequestApiObj.Expires"></a>

* *DateTime* **Expires**  






---

<a id="Ditch.Steem.Objects.AccountReputation"></a>
## AccountReputation
*class Ditch.Steem.Objects.AccountReputation*

account_reputation
libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.AccountReputation.Account"></a>

* *String* **Account**  
  API name: account  


<a id="Ditch.Steem.Objects.AccountReputation.Reputation"></a>

* *Object* **Reputation**  
  API name: reputation  






---

<a id="Ditch.Steem.Objects.AppliedOperation"></a>
## AppliedOperation
*class Ditch.Steem.Objects.AppliedOperation*

applied_operation
steem-0.19.1\libraries\app\include\steemit\app\applied_operation.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.AppliedOperation.TrxId"></a>

* *Object* **TrxId**  


<a id="Ditch.Steem.Objects.AppliedOperation.Block"></a>

* *UInt32* **Block**  


<a id="Ditch.Steem.Objects.AppliedOperation.TrxInBlock"></a>

* *UInt32* **TrxInBlock**  


<a id="Ditch.Steem.Objects.AppliedOperation.OpInTrx"></a>

* *UInt16* **OpInTrx**  


<a id="Ditch.Steem.Objects.AppliedOperation.VirtualOp"></a>

* *UInt64* **VirtualOp**  


<a id="Ditch.Steem.Objects.AppliedOperation.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Steem.Objects.AppliedOperation.Op"></a>

* *Object[]* **Op**  






---

<a id="Ditch.Steem.Objects.Authority"></a>
## Authority
*class Ditch.Steem.Objects.Authority*

authority
steem-0.19.1\libraries\protocol\include\steemit\protocol\authority.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.Authority.WeightThreshold"></a>

* *UInt32* **WeightThreshold**  


<a id="Ditch.Steem.Objects.Authority.AccountAuths"></a>

* *Object* **AccountAuths**  


<a id="Ditch.Steem.Objects.Authority.KeyAuths"></a>

* *Object[][]* **KeyAuths**  






---

<a id="Ditch.Steem.Objects.BlockHeader"></a>
## BlockHeader
*class Ditch.Steem.Objects.BlockHeader*

block_header
steem-0.19.1\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.BlockHeader.Previous"></a>

* *Object* **Previous**  


<a id="Ditch.Steem.Objects.BlockHeader.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Steem.Objects.BlockHeader.Witness"></a>

* *String* **Witness**  


<a id="Ditch.Steem.Objects.BlockHeader.TransactionMerkleRoot"></a>

* *Object* **TransactionMerkleRoot**  


<a id="Ditch.Steem.Objects.BlockHeader.Extensions"></a>

* *Object* **Extensions**  






---

<a id="Ditch.Steem.Objects.BlogEntry"></a>
## BlogEntry
*class Ditch.Steem.Objects.BlogEntry*

blog_entry
libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.BlogEntry.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Steem.Objects.BlogEntry.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Steem.Objects.BlogEntry.Blog"></a>

* *String* **Blog**  
  API name: blog  


<a id="Ditch.Steem.Objects.BlogEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Steem.Objects.BlogEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Steem.Objects.BucketObject"></a>
## BucketObject
*class Ditch.Steem.Objects.BucketObject*

bucket_object
libraries\plugins\blockchain_statistics\include\steemit\blockchain_statistics\blockchain_statistics_plugin.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.BucketObject.Id"></a>

* *String* **Id**  
  API name: id  


<a id="Ditch.Steem.Objects.BucketObject.Open"></a>

* *DateTime* **Open**  
  API name: open
Open time of the bucket  


<a id="Ditch.Steem.Objects.BucketObject.Seconds"></a>

* *UInt32* **Seconds**  
  API name: seconds
= 0; ///< Seconds accounted for in the bucket  


<a id="Ditch.Steem.Objects.BucketObject.Blocks"></a>

* *UInt32* **Blocks**  
  API name: blocks
= 0; ///< Blocks produced  


<a id="Ditch.Steem.Objects.BucketObject.Bandwidth"></a>

* *UInt32* **Bandwidth**  
  API name: bandwidth
= 0; ///< Bandwidth in bytes  


<a id="Ditch.Steem.Objects.BucketObject.Operations"></a>

* *UInt32* **Operations**  
  API name: operations
= 0; ///< Operations evaluated  


<a id="Ditch.Steem.Objects.BucketObject.Transactions"></a>

* *UInt32* **Transactions**  
  API name: transactions
= 0; ///< Transactions processed  


<a id="Ditch.Steem.Objects.BucketObject.Transfers"></a>

* *UInt32* **Transfers**  
  API name: transfers
= 0; ///< Account to account transfers  


<a id="Ditch.Steem.Objects.BucketObject.SteemTransferred"></a>

* *Object* **SteemTransferred**  
  API name: steem_transferred
= 0; ///< STEEM transferred from account to account  


<a id="Ditch.Steem.Objects.BucketObject.SbdTransferred"></a>

* *Object* **SbdTransferred**  
  API name: sbd_transferred
= 0; ///< SBD transferred from account to account  


<a id="Ditch.Steem.Objects.BucketObject.SbdPaidAsInterest"></a>

* *Object* **SbdPaidAsInterest**  
  API name: sbd_paid_as_interest
= 0; ///< SBD paid as interest  


<a id="Ditch.Steem.Objects.BucketObject.PaidAccountsCreated"></a>

* *UInt32* **PaidAccountsCreated**  
  API name: paid_accounts_created
= 0; ///< Accounts created with fee  


<a id="Ditch.Steem.Objects.BucketObject.MinedAccountsCreated"></a>

* *UInt32* **MinedAccountsCreated**  
  API name: mined_accounts_created
= 0; ///< Accounts mined for free  


<a id="Ditch.Steem.Objects.BucketObject.RootComments"></a>

* *UInt32* **RootComments**  
  API name: root_comments
= 0; ///< Top level root comments  


<a id="Ditch.Steem.Objects.BucketObject.RootCommentEdits"></a>

* *UInt32* **RootCommentEdits**  
  API name: root_comment_edits
= 0; ///< Edits to root comments  


<a id="Ditch.Steem.Objects.BucketObject.RootCommentsDeleted"></a>

* *UInt32* **RootCommentsDeleted**  
  API name: root_comments_deleted
= 0; ///< Root comments deleted  


<a id="Ditch.Steem.Objects.BucketObject.Replies"></a>

* *UInt32* **Replies**  
  API name: replies
= 0; ///< Replies to comments  


<a id="Ditch.Steem.Objects.BucketObject.ReplyEdits"></a>

* *UInt32* **ReplyEdits**  
  API name: reply_edits
= 0; ///< Edits to replies  


<a id="Ditch.Steem.Objects.BucketObject.RepliesDeleted"></a>

* *UInt32* **RepliesDeleted**  
  API name: replies_deleted
= 0; ///< Replies deleted  


<a id="Ditch.Steem.Objects.BucketObject.NewRootVotes"></a>

* *UInt32* **NewRootVotes**  
  API name: new_root_votes
= 0; ///< New votes on root comments  


<a id="Ditch.Steem.Objects.BucketObject.ChangedRootVotes"></a>

* *UInt32* **ChangedRootVotes**  
  API name: changed_root_votes
= 0; ///< Changed votes on root comments  


<a id="Ditch.Steem.Objects.BucketObject.NewReplyVotes"></a>

* *UInt32* **NewReplyVotes**  
  API name: new_reply_votes
= 0; ///< New votes on replies  


<a id="Ditch.Steem.Objects.BucketObject.ChangedReplyVotes"></a>

* *UInt32* **ChangedReplyVotes**  
  API name: changed_reply_votes
= 0; ///< Changed votes on replies  


<a id="Ditch.Steem.Objects.BucketObject.Payouts"></a>

* *UInt32* **Payouts**  
  API name: payouts
= 0; ///< Number of comment payouts  


<a id="Ditch.Steem.Objects.BucketObject.SbdPaidToAuthors"></a>

* *Object* **SbdPaidToAuthors**  
  API name: sbd_paid_to_authors
= 0; ///< Ammount of SBD paid to authors  


<a id="Ditch.Steem.Objects.BucketObject.VestsPaidToAuthors"></a>

* *Object* **VestsPaidToAuthors**  
  API name: vests_paid_to_authors
= 0; ///< Ammount of VESS paid to authors  


<a id="Ditch.Steem.Objects.BucketObject.VestsPaidToCurators"></a>

* *Object* **VestsPaidToCurators**  
  API name: vests_paid_to_curators
= 0; ///< Ammount of VESTS paid to curators  


<a id="Ditch.Steem.Objects.BucketObject.LiquidityRewardsPaid"></a>

* *Object* **LiquidityRewardsPaid**  
  API name: liquidity_rewards_paid
= 0; ///< Ammount of STEEM paid to market makers  


<a id="Ditch.Steem.Objects.BucketObject.TransfersToVesting"></a>

* *UInt32* **TransfersToVesting**  
  API name: transfers_to_vesting
= 0; ///< Transfers of STEEM into VESTS  


<a id="Ditch.Steem.Objects.BucketObject.SteemVested"></a>

* *Object* **SteemVested**  
  API name: steem_vested
= 0; ///< Ammount of STEEM vested  


<a id="Ditch.Steem.Objects.BucketObject.NewVestingWithdrawalRequests"></a>

* *UInt32* **NewVestingWithdrawalRequests**  
  API name: new_vesting_withdrawal_requests
= 0; ///< New vesting withdrawal requests  


<a id="Ditch.Steem.Objects.BucketObject.ModifiedVestingWithdrawalRequests"></a>

* *UInt32* **ModifiedVestingWithdrawalRequests**  
  API name: modified_vesting_withdrawal_requests
= 0; ///< Changes to vesting withdrawal requests  


<a id="Ditch.Steem.Objects.BucketObject.VestingWithdrawRateDelta"></a>

* *Object* **VestingWithdrawRateDelta**  
  API name: vesting_withdraw_rate_delta
= 0;  


<a id="Ditch.Steem.Objects.BucketObject.VestingWithdrawalsProcessed"></a>

* *UInt32* **VestingWithdrawalsProcessed**  
  API name: vesting_withdrawals_processed
= 0; ///< Number of vesting withdrawals  


<a id="Ditch.Steem.Objects.BucketObject.FinishedVestingWithdrawals"></a>

* *UInt32* **FinishedVestingWithdrawals**  
  API name: finished_vesting_withdrawals
= 0; ///< Processed vesting withdrawals that are now finished  


<a id="Ditch.Steem.Objects.BucketObject.VestsWithdrawn"></a>

* *Object* **VestsWithdrawn**  
  API name: vests_withdrawn
= 0; ///< Ammount of VESTS withdrawn to STEEM  


<a id="Ditch.Steem.Objects.BucketObject.VestsTransferred"></a>

* *Object* **VestsTransferred**  
  API name: vests_transferred
= 0; ///< Ammount of VESTS transferred to another account  


<a id="Ditch.Steem.Objects.BucketObject.SbdConversionRequestsCreated"></a>

* *UInt32* **SbdConversionRequestsCreated**  
  API name: sbd_conversion_requests_created
= 0; ///< SBD conversion requests created  


<a id="Ditch.Steem.Objects.BucketObject.SbdToBeConverted"></a>

* *Object* **SbdToBeConverted**  
  API name: sbd_to_be_converted
= 0; ///< Amount of SBD to be converted  


<a id="Ditch.Steem.Objects.BucketObject.SbdConversionRequestsFilled"></a>

* *UInt32* **SbdConversionRequestsFilled**  
  API name: sbd_conversion_requests_filled
= 0; ///< SBD conversion requests filled  


<a id="Ditch.Steem.Objects.BucketObject.SteemConverted"></a>

* *Object* **SteemConverted**  
  API name: steem_converted
= 0; ///< Amount of STEEM that was converted  


<a id="Ditch.Steem.Objects.BucketObject.LimitOrdersCreated"></a>

* *UInt32* **LimitOrdersCreated**  
  API name: limit_orders_created
= 0; ///< Limit orders created  


<a id="Ditch.Steem.Objects.BucketObject.LimitOrdersFilled"></a>

* *UInt32* **LimitOrdersFilled**  
  API name: limit_orders_filled
= 0; ///< Limit orders filled  


<a id="Ditch.Steem.Objects.BucketObject.LimitOrdersCancelled"></a>

* *UInt32* **LimitOrdersCancelled**  
  API name: limit_orders_cancelled
= 0; ///< Limit orders cancelled  


<a id="Ditch.Steem.Objects.BucketObject.TotalPow"></a>

* *UInt32* **TotalPow**  
  API name: total_pow
= 0; ///< POW submitted  


<a id="Ditch.Steem.Objects.BucketObject.EstimatedHashpower"></a>

* *String* **EstimatedHashpower**  
  API name: estimated_hashpower
= 0; ///< Estimated average hashpower over interval  






---

<a id="Ditch.Steem.Objects.CategoryApiObj"></a>
## CategoryApiObj
*class Ditch.Steem.Objects.CategoryApiObj*

category_api_obj

**Properties and Fields**

<a id="Ditch.Steem.Objects.CategoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.CategoryApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Steem.Objects.CategoryApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Steem.Objects.CategoryApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Steem.Objects.CategoryApiObj.Discussions"></a>

* *UInt32* **Discussions**  


<a id="Ditch.Steem.Objects.CategoryApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  






---

<a id="Ditch.Steem.Objects.ChainProperties"></a>
## ChainProperties
*class Ditch.Steem.Objects.ChainProperties*

chain_properties
steem-0.19.1\libraries\protocol\include\steemit\protocol\steem_operations.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.ChainProperties.AccountCreationFee"></a>

* *Money* **AccountCreationFee**  
  This fee, paid in STEEM, is converted into VESTING SHARES for the new account.Accounts 
without vesting shares cannot earn usage rations and therefore are powerless.This minimum 
fee requires all accounts to have some kind of commitment to the network that includes the
 ability to vote and make transactions.  


<a id="Ditch.Steem.Objects.ChainProperties.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  
  This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity  


<a id="Ditch.Steem.Objects.ChainProperties.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  






---

<a id="Ditch.Steem.Objects.CommentApiObj"></a>
## CommentApiObj
*class Ditch.Steem.Objects.CommentApiObj*

comment_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.CommentApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Steem.Objects.CommentApiObj.Category"></a>

* *String* **Category**  


<a id="Ditch.Steem.Objects.CommentApiObj.ParentAuthor"></a>

* *String* **ParentAuthor**  


<a id="Ditch.Steem.Objects.CommentApiObj.ParentPermlink"></a>

* *String* **ParentPermlink**  


<a id="Ditch.Steem.Objects.CommentApiObj.Author"></a>

* *String* **Author**  


<a id="Ditch.Steem.Objects.CommentApiObj.Permlink"></a>

* *String* **Permlink**  


<a id="Ditch.Steem.Objects.CommentApiObj.Title"></a>

* *String* **Title**  


<a id="Ditch.Steem.Objects.CommentApiObj.Body"></a>

* *String* **Body**  


<a id="Ditch.Steem.Objects.CommentApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Steem.Objects.CommentApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  


<a id="Ditch.Steem.Objects.CommentApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Steem.Objects.CommentApiObj.Active"></a>

* *DateTime* **Active**  


<a id="Ditch.Steem.Objects.CommentApiObj.LastPayout"></a>

* *DateTime* **LastPayout**  


<a id="Ditch.Steem.Objects.CommentApiObj.Depth"></a>

* *Byte* **Depth**  


<a id="Ditch.Steem.Objects.CommentApiObj.Children"></a>

* *UInt32* **Children**  


<a id="Ditch.Steem.Objects.CommentApiObj.ChildrenRshares2"></a>

* *String* **ChildrenRshares2**  


<a id="Ditch.Steem.Objects.CommentApiObj.NetRshares"></a>

* *Object* **NetRshares**  


<a id="Ditch.Steem.Objects.CommentApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Steem.Objects.CommentApiObj.VoteRshares"></a>

* *Object* **VoteRshares**  


<a id="Ditch.Steem.Objects.CommentApiObj.ChildrenAbsRshares"></a>

* *Object* **ChildrenAbsRshares**  


<a id="Ditch.Steem.Objects.CommentApiObj.CashoutTime"></a>

* *DateTime* **CashoutTime**  


<a id="Ditch.Steem.Objects.CommentApiObj.MaxCashoutTime"></a>

* *DateTime* **MaxCashoutTime**  


<a id="Ditch.Steem.Objects.CommentApiObj.TotalVoteWeight"></a>

* *UInt64* **TotalVoteWeight**  


<a id="Ditch.Steem.Objects.CommentApiObj.RewardWeight"></a>

* *UInt16* **RewardWeight**  


<a id="Ditch.Steem.Objects.CommentApiObj.TotalPayoutValue"></a>

* *Money* **TotalPayoutValue**  


<a id="Ditch.Steem.Objects.CommentApiObj.CuratorPayoutValue"></a>

* *Money* **CuratorPayoutValue**  


<a id="Ditch.Steem.Objects.CommentApiObj.AuthorRewards"></a>

* *Object* **AuthorRewards**  


<a id="Ditch.Steem.Objects.CommentApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Steem.Objects.CommentApiObj.RootComment"></a>

* *UInt64* **RootComment**  


<a id="Ditch.Steem.Objects.CommentApiObj.Mode"></a>

* *CommentMode* **Mode**  


<a id="Ditch.Steem.Objects.CommentApiObj.MaxAcceptedPayout"></a>

* *Money* **MaxAcceptedPayout**  


<a id="Ditch.Steem.Objects.CommentApiObj.PercentSteemDollars"></a>

* *UInt16* **PercentSteemDollars**  


<a id="Ditch.Steem.Objects.CommentApiObj.AllowReplies"></a>

* *Boolean* **AllowReplies**  


<a id="Ditch.Steem.Objects.CommentApiObj.AllowVotes"></a>

* *Boolean* **AllowVotes**  


<a id="Ditch.Steem.Objects.CommentApiObj.AllowCurationRewards"></a>

* *Boolean* **AllowCurationRewards**  


<a id="Ditch.Steem.Objects.CommentApiObj.Beneficiaries"></a>

* *Object[]* **Beneficiaries**  






---

<a id="Ditch.Steem.Objects.CommentBlogEntry"></a>
## CommentBlogEntry
*class Ditch.Steem.Objects.CommentBlogEntry*

comment_blog_entry
libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.CommentBlogEntry.Comment"></a>

* *CommentApiObj* **Comment**  
  API name: comment  


<a id="Ditch.Steem.Objects.CommentBlogEntry.Blog"></a>

* *String* **Blog**  
  API name: blog  


<a id="Ditch.Steem.Objects.CommentBlogEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Steem.Objects.CommentBlogEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Steem.Objects.CommentFeedEntry"></a>
## CommentFeedEntry
*class Ditch.Steem.Objects.CommentFeedEntry*

comment_feed_entry
libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.CommentFeedEntry.Comment"></a>

* *Object* **Comment**  
  API name: comment  


<a id="Ditch.Steem.Objects.CommentFeedEntry.ReblogBy"></a>

* *String[]* **ReblogBy**  
  API name: reblog_by  


<a id="Ditch.Steem.Objects.CommentFeedEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Steem.Objects.CommentFeedEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Steem.Objects.ConvertRequestApiObj"></a>
## ConvertRequestApiObj
*class Ditch.Steem.Objects.ConvertRequestApiObj: Ditch.Steem.Objects.ConvertRequestObject*

convert_request_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Objects.ConvertRequestObject"></a>
## ConvertRequestObject
*class Ditch.Steem.Objects.ConvertRequestObject*

convert_request_object
steem-0.19.1\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.ConvertRequestObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.ConvertRequestObject.Owner"></a>

* *Object* **Owner**  


<a id="Ditch.Steem.Objects.ConvertRequestObject.Requestid"></a>

* *UInt32* **Requestid**  
  id set by owner,the owner,requestid pair must be unique  


<a id="Ditch.Steem.Objects.ConvertRequestObject.Amount"></a>

* *Money* **Amount**  






---

<a id="Ditch.Steem.Objects.Discussion"></a>
## Discussion
*class Ditch.Steem.Objects.Discussion: Ditch.Steem.Objects.CommentApiObj*

discussion
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.Discussion.Url"></a>

* *String* **Url**  
  /category/@rootauthor/root_permlink#author/permlink  


<a id="Ditch.Steem.Objects.Discussion.RootTitle"></a>

* *String* **RootTitle**  


<a id="Ditch.Steem.Objects.Discussion.PendingPayoutValue"></a>

* *Money* **PendingPayoutValue**  
  sbd  


<a id="Ditch.Steem.Objects.Discussion.TotalPendingPayoutValue"></a>

* *Money* **TotalPendingPayoutValue**  
  sbd including replies  


<a id="Ditch.Steem.Objects.Discussion.ActiveVotes"></a>

* *VoteState[]* **ActiveVotes**  


<a id="Ditch.Steem.Objects.Discussion.Replies"></a>

* *String[]* **Replies**  
  author/slug mapping  


<a id="Ditch.Steem.Objects.Discussion.AuthorReputation"></a>

* *Object* **AuthorReputation**  


<a id="Ditch.Steem.Objects.Discussion.Promoted"></a>

* *Money* **Promoted**  


<a id="Ditch.Steem.Objects.Discussion.BodyLength"></a>

* *UInt32* **BodyLength**  


<a id="Ditch.Steem.Objects.Discussion.RebloggedBy"></a>

* *String[]* **RebloggedBy**  


<a id="Ditch.Steem.Objects.Discussion.FirstRebloggedBy"></a>

* *Object* **FirstRebloggedBy**  


<a id="Ditch.Steem.Objects.Discussion.FirstRebloggedOn"></a>

* *Object* **FirstRebloggedOn**  






---

<a id="Ditch.Steem.Objects.DynamicGlobalPropertyApiObj"></a>
## DynamicGlobalPropertyApiObj
*class Ditch.Steem.Objects.DynamicGlobalPropertyApiObj: Ditch.Steem.Objects.DynamicGlobalPropertyObject*

Shows an overview of various information regarding the current state of the STEEM network.
dynamic_global_property_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.DynamicGlobalPropertyApiObj.CurrentReserveRatio"></a>

* *UInt32* **CurrentReserveRatio**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyApiObj.AverageBlockSize"></a>

* *UInt64* **AverageBlockSize**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyApiObj.MaxVirtualBandwidth"></a>

* *String* **MaxVirtualBandwidth**  






---

<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject"></a>
## DynamicGlobalPropertyObject
*class Ditch.Steem.Objects.DynamicGlobalPropertyObject*

Shows an overview of various information regarding the current state of the STEEM network.
dynamic_global_property_object
steem-0.19.1\libraries\chain\include\steemit\chain\global_property_object.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.Id"></a>

* *String* **Id**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.HeadBlockNumber"></a>

* *UInt32* **HeadBlockNumber**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.HeadBlockId"></a>

* *String* **HeadBlockId**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.Time"></a>

* *DateTime* **Time**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.CurrentWitness"></a>

* *String* **CurrentWitness**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.TotalPow"></a>

* *UInt64* **TotalPow**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.NumPowWitnesses"></a>

* *UInt32* **NumPowWitnesses**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.VirtualSupply"></a>

* *Money* **VirtualSupply**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.CurrentSupply"></a>

* *Money* **CurrentSupply**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.ConfidentialSupply"></a>

* *Money* **ConfidentialSupply**  
  total asset held in confidential balances  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.CurrentSbdSupply"></a>

* *Money* **CurrentSbdSupply**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.ConfidentialSbdSupply"></a>

* *Money* **ConfidentialSbdSupply**  
  total asset held in confidential balances  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.TotalVestingFundSteem"></a>

* *Money* **TotalVestingFundSteem**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.TotalVestingShares"></a>

* *Money* **TotalVestingShares**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.TotalRewardFundSteem"></a>

* *Money* **TotalRewardFundSteem**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.TotalRewardShares2"></a>

* *String* **TotalRewardShares2**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.PendingRewardedVestingShares"></a>

* *Money* **PendingRewardedVestingShares**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.PendingRewardedVestingSteem"></a>

* *Money* **PendingRewardedVestingSteem**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.SbdPrintRate"></a>

* *UInt16* **SbdPrintRate**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.AverageBlockSize"></a>

* *UInt32* **AverageBlockSize**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.CurrentAslot"></a>

* *UInt64* **CurrentAslot**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.RecentSlotsFilled"></a>

* *String* **RecentSlotsFilled**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.ParticipationCount"></a>

* *Byte* **ParticipationCount**  
  divide by 128 to compute participation percentage  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.LastIrreversibleBlockNum"></a>

* *UInt32* **LastIrreversibleBlockNum**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.MaxVirtualBandwidth"></a>

* *UInt64* **MaxVirtualBandwidth**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.CurrentReserveRatio"></a>

* *UInt64* **CurrentReserveRatio**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.VoteRegenerationPerDay"></a>

* *UInt32* **VoteRegenerationPerDay**  


<a id="Ditch.Steem.Objects.DynamicGlobalPropertyObject.VotePowerReserveRate"></a>

* *UInt32* **VotePowerReserveRate**  






---

<a id="Ditch.Steem.Objects.EscrowApiObj"></a>
## EscrowApiObj
*class Ditch.Steem.Objects.EscrowApiObj: Ditch.Steem.Objects.EscrowObject*

escrow_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Objects.EscrowObject"></a>
## EscrowObject
*class Ditch.Steem.Objects.EscrowObject*

escrow_object
steem-0.19.1\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.EscrowObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.EscrowObject.EscrowId"></a>

* *UInt32* **EscrowId**  


<a id="Ditch.Steem.Objects.EscrowObject.From"></a>

* *String* **From**  


<a id="Ditch.Steem.Objects.EscrowObject.To"></a>

* *String* **To**  


<a id="Ditch.Steem.Objects.EscrowObject.Agent"></a>

* *String* **Agent**  


<a id="Ditch.Steem.Objects.EscrowObject.RatificationDeadline"></a>

* *DateTime* **RatificationDeadline**  


<a id="Ditch.Steem.Objects.EscrowObject.EscrowExpiration"></a>

* *DateTime* **EscrowExpiration**  


<a id="Ditch.Steem.Objects.EscrowObject.SbdBalance"></a>

* *Money* **SbdBalance**  


<a id="Ditch.Steem.Objects.EscrowObject.SteemBalance"></a>

* *Money* **SteemBalance**  


<a id="Ditch.Steem.Objects.EscrowObject.PendingFee"></a>

* *Money* **PendingFee**  


<a id="Ditch.Steem.Objects.EscrowObject.ToApproved"></a>

* *Boolean* **ToApproved**  


<a id="Ditch.Steem.Objects.EscrowObject.AgentApproved"></a>

* *Boolean* **AgentApproved**  


<a id="Ditch.Steem.Objects.EscrowObject.Disputed"></a>

* *Boolean* **Disputed**  






---

<a id="Ditch.Steem.Objects.ExtendedAccount"></a>
## ExtendedAccount
*class Ditch.Steem.Objects.ExtendedAccount: Ditch.Steem.Objects.AccountApiObj*

extended_account 
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.ExtendedAccount.VestingBalance"></a>

* *Money* **VestingBalance**  
  convert vesting_shares to vesting steem  


<a id="Ditch.Steem.Objects.ExtendedAccount.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Steem.Objects.ExtendedAccount.TransferHistory"></a>

* *Object* **TransferHistory**  
  transfer to/from vesting  


<a id="Ditch.Steem.Objects.ExtendedAccount.MarketHistory"></a>

* *Object* **MarketHistory**  
  limit order / cancel / fill  


<a id="Ditch.Steem.Objects.ExtendedAccount.PostHistory"></a>

* *Object* **PostHistory**  


<a id="Ditch.Steem.Objects.ExtendedAccount.VoteHistory"></a>

* *Object* **VoteHistory**  


<a id="Ditch.Steem.Objects.ExtendedAccount.OtherHistory"></a>

* *Object* **OtherHistory**  


<a id="Ditch.Steem.Objects.ExtendedAccount.WitnessVotes"></a>

* *String[]* **WitnessVotes**  


<a id="Ditch.Steem.Objects.ExtendedAccount.TagsUsage"></a>

* *KeyValuePair`2[]* **TagsUsage**  


<a id="Ditch.Steem.Objects.ExtendedAccount.GuestBloggers"></a>

* *KeyValuePair`2[]* **GuestBloggers**  


<a id="Ditch.Steem.Objects.ExtendedAccount.OpenOrders"></a>

* *Object* **OpenOrders**  


<a id="Ditch.Steem.Objects.ExtendedAccount.Comments"></a>

* *String[]* **Comments**  
  permlinks for this user  


<a id="Ditch.Steem.Objects.ExtendedAccount.Blog"></a>

* *String[]* **Blog**  
  blog posts for this user  


<a id="Ditch.Steem.Objects.ExtendedAccount.Feed"></a>

* *String[]* **Feed**  
  feed posts for this user  


<a id="Ditch.Steem.Objects.ExtendedAccount.RecentReplies"></a>

* *String[]* **RecentReplies**  
  blog posts for this user  


<a id="Ditch.Steem.Objects.ExtendedAccount.BlogCategory"></a>

* *Object* **BlogCategory**  
  blog posts for this user  


<a id="Ditch.Steem.Objects.ExtendedAccount.Recommended"></a>

* *String[]* **Recommended**  
  posts recommened for this user  






---

<a id="Ditch.Steem.Objects.ExtendedLimitOrder"></a>
## ExtendedLimitOrder
*class Ditch.Steem.Objects.ExtendedLimitOrder: Ditch.Steem.Objects.LimitOrderApiObj*

extended_limit_order
libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.ExtendedLimitOrder.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
= 0;  


<a id="Ditch.Steem.Objects.ExtendedLimitOrder.Rewarded"></a>

* *Boolean* **Rewarded**  
  API name: rewarded
= false;  






---

<a id="Ditch.Steem.Objects.FeedEntry"></a>
## FeedEntry
*class Ditch.Steem.Objects.FeedEntry*

feed_entry
libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.FeedEntry.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Steem.Objects.FeedEntry.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Steem.Objects.FeedEntry.ReblogBy"></a>

* *String[]* **ReblogBy**  
  API name: reblog_by  


<a id="Ditch.Steem.Objects.FeedEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Steem.Objects.FeedEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Steem.Objects.FeedHistoryApiObj"></a>
## FeedHistoryApiObj
*class Ditch.Steem.Objects.FeedHistoryApiObj*

feed_history_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.FeedHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.FeedHistoryApiObj.CurrentMedianHistory"></a>

* *Price* **CurrentMedianHistory**  


<a id="Ditch.Steem.Objects.FeedHistoryApiObj.PriceHistory"></a>

* *Price[]* **PriceHistory**  






---

<a id="Ditch.Steem.Objects.FollowApiObj"></a>
## FollowApiObj
*class Ditch.Steem.Objects.FollowApiObj*

follow_api_obj
steem-0.19.1\libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.FollowApiObj.Follower"></a>

* *String* **Follower**  


<a id="Ditch.Steem.Objects.FollowApiObj.Following"></a>

* *String* **Following**  


<a id="Ditch.Steem.Objects.FollowApiObj.What"></a>

* *FollowType[]* **What**  






---

<a id="Ditch.Steem.Objects.FollowCountApiObj"></a>
## FollowCountApiObj
*class Ditch.Steem.Objects.FollowCountApiObj*

follow_count_api_obj
libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.FollowCountApiObj.Account"></a>

* *String* **Account**  
  API name: account  


<a id="Ditch.Steem.Objects.FollowCountApiObj.FollowerCount"></a>

* *UInt32* **FollowerCount**  
  API name: follower_count
= 0;  


<a id="Ditch.Steem.Objects.FollowCountApiObj.FollowingCount"></a>

* *UInt32* **FollowingCount**  
  API name: following_count
= 0;  






---

<a id="Ditch.Steem.Objects.LimitOrderApiObj"></a>
## LimitOrderApiObj
*class Ditch.Steem.Objects.LimitOrderApiObj: Ditch.Steem.Objects.LimitOrderObject*

limit_order_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Objects.LimitOrderObject"></a>
## LimitOrderObject
*class Ditch.Steem.Objects.LimitOrderObject*

limit_order_object
libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.LimitOrderObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Steem.Objects.LimitOrderObject.Created"></a>

* *DateTime* **Created**  
  API name: created  


<a id="Ditch.Steem.Objects.LimitOrderObject.Expiration"></a>

* *DateTime* **Expiration**  
  API name: expiration  


<a id="Ditch.Steem.Objects.LimitOrderObject.Seller"></a>

* *String* **Seller**  
  API name: seller  


<a id="Ditch.Steem.Objects.LimitOrderObject.Orderid"></a>

* *UInt32* **Orderid**  
  API name: orderid
= 0;  


<a id="Ditch.Steem.Objects.LimitOrderObject.ForSale"></a>

* *Object* **ForSale**  
  API name: for_sale
asset id is sell_price.base.symbol  


<a id="Ditch.Steem.Objects.LimitOrderObject.SellPrice"></a>

* *Price* **SellPrice**  
  API name: sell_price  






---

<a id="Ditch.Steem.Objects.MarketTicker"></a>
## MarketTicker
*class Ditch.Steem.Objects.MarketTicker*

market_ticker
libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.MarketTicker.Latest"></a>

* *Double* **Latest**  
  API name: latest
= 0;  


<a id="Ditch.Steem.Objects.MarketTicker.LowestAsk"></a>

* *Double* **LowestAsk**  
  API name: lowest_ask
= 0;  


<a id="Ditch.Steem.Objects.MarketTicker.HighestBid"></a>

* *Double* **HighestBid**  
  API name: highest_bid
= 0;  


<a id="Ditch.Steem.Objects.MarketTicker.PercentChange"></a>

* *Double* **PercentChange**  
  API name: percent_change
= 0;  


<a id="Ditch.Steem.Objects.MarketTicker.SteemVolume"></a>

* *Money* **SteemVolume**  
  API name: steem_volume
= asset( 0 , STEEM_SYMBOL );  


<a id="Ditch.Steem.Objects.MarketTicker.SbdVolume"></a>

* *Money* **SbdVolume**  
  API name: sbd_volume
= asset( 0, SBD_SYMBOL );  






---

<a id="Ditch.Steem.Objects.MarketTrade"></a>
## MarketTrade
*class Ditch.Steem.Objects.MarketTrade*

market_trade
libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.MarketTrade.Date"></a>

* *DateTime* **Date**  
  API name: date  


<a id="Ditch.Steem.Objects.MarketTrade.CurrentPays"></a>

* *Money* **CurrentPays**  
  API name: current_pays  


<a id="Ditch.Steem.Objects.MarketTrade.OpenPays"></a>

* *Money* **OpenPays**  
  API name: open_pays  






---

<a id="Ditch.Steem.Objects.MarketVolume"></a>
## MarketVolume
*class Ditch.Steem.Objects.MarketVolume*

market_volume
libraries\plugins\market_history\include\steemit\market_history\market_history_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.MarketVolume.SteemVolume"></a>

* *Money* **SteemVolume**  
  API name: steem_volume
= asset( 0, STEEM_SYMBOL );  


<a id="Ditch.Steem.Objects.MarketVolume.SbdVolume"></a>

* *Money* **SbdVolume**  
  API name: sbd_volume
= asset( 0, SBD_SYMBOL );  






---

<a id="Ditch.Steem.Objects.Order"></a>
## Order
*class Ditch.Steem.Objects.Order*

order
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.Order.OrderPrice"></a>

* *Price* **OrderPrice**  
  API name: order_price  


<a id="Ditch.Steem.Objects.Order.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
dollars per steem  


<a id="Ditch.Steem.Objects.Order.Steem"></a>

* *Object* **Steem**  
  API name: steem  


<a id="Ditch.Steem.Objects.Order.Sbd"></a>

* *Object* **Sbd**  
  API name: sbd  


<a id="Ditch.Steem.Objects.Order.Created"></a>

* *DateTime* **Created**  
  API name: created  






---

<a id="Ditch.Steem.Objects.OrderBook"></a>
## OrderBook
*class Ditch.Steem.Objects.OrderBook*

order_book
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.OrderBook.Asks"></a>

* *Order[]* **Asks**  
  API name: asks  


<a id="Ditch.Steem.Objects.OrderBook.Bids"></a>

* *Order[]* **Bids**  
  API name: bids  






---

<a id="Ditch.Steem.Objects.OwnerAuthorityHistoryApiObj"></a>
## OwnerAuthorityHistoryApiObj
*class Ditch.Steem.Objects.OwnerAuthorityHistoryApiObj*

owner_authority_history_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.OwnerAuthorityHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.OwnerAuthorityHistoryApiObj.Account"></a>

* *String* **Account**  


<a id="Ditch.Steem.Objects.OwnerAuthorityHistoryApiObj.PreviousOwnerAuthority"></a>

* *Authority* **PreviousOwnerAuthority**  


<a id="Ditch.Steem.Objects.OwnerAuthorityHistoryApiObj.LastValidTime"></a>

* *DateTime* **LastValidTime**  






---

<a id="Ditch.Steem.Objects.Price"></a>
## Price
*class Ditch.Steem.Objects.Price*

price
steem-0.19.1\libraries\protocol\include\steemit\protocol\asset.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.Price.Base"></a>

* *Money* **Base**  


<a id="Ditch.Steem.Objects.Price.Quote"></a>

* *Money* **Quote**  






---

<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj"></a>
## SavingsWithdrawApiObj
*class Ditch.Steem.Objects.SavingsWithdrawApiObj*

savings_withdraw_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj.From"></a>

* *String* **From**  
  API name: from  


<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj.To"></a>

* *String* **To**  
  API name: to  


<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj.Memo"></a>

* *String* **Memo**  
  API name: memo  


<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj.RequestId"></a>

* *UInt32* **RequestId**  
  API name: request_id
= 0;  


<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj.Amount"></a>

* *Money* **Amount**  
  API name: amount  


<a id="Ditch.Steem.Objects.SavingsWithdrawApiObj.Complete"></a>

* *DateTime* **Complete**  
  API name: complete  






---

<a id="Ditch.Steem.Objects.ScheduledHardfork"></a>
## ScheduledHardfork
*class Ditch.Steem.Objects.ScheduledHardfork*

scheduled_hardfork
steem-0.19.1\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.ScheduledHardfork.HfVersion"></a>

* *String* **HfVersion**  


<a id="Ditch.Steem.Objects.ScheduledHardfork.LiveTime"></a>

* *DateTime* **LiveTime**  






---

<a id="Ditch.Steem.Objects.SignedBlock"></a>
## SignedBlock
*class Ditch.Steem.Objects.SignedBlock: Ditch.Steem.Objects.SignedBlockHeader*

signed_block
steem-0.19.1\libraries\protocol\include\steemit\protocol\block.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.SignedBlock.Transactions"></a>

* *Object[]* **Transactions**  






---

<a id="Ditch.Steem.Objects.SignedBlockApiObj"></a>
## SignedBlockApiObj
*class Ditch.Steem.Objects.SignedBlockApiObj: Ditch.Steem.Objects.SignedBlock*

signed_block_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.SignedBlockApiObj.BlockId"></a>

* *Object* **BlockId**  


<a id="Ditch.Steem.Objects.SignedBlockApiObj.SigningKey"></a>

* *String* **SigningKey**  


<a id="Ditch.Steem.Objects.SignedBlockApiObj.TransactionIds"></a>

* *Object[]* **TransactionIds**  






---

<a id="Ditch.Steem.Objects.SignedBlockHeader"></a>
## SignedBlockHeader
*class Ditch.Steem.Objects.SignedBlockHeader: Ditch.Steem.Objects.BlockHeader*

signed_block_header
steem-0.19.1\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.SignedBlockHeader.WitnessSignature"></a>

* *Object* **WitnessSignature**  






---

<a id="Ditch.Steem.Objects.SignedTransaction"></a>
## SignedTransaction
*class Ditch.Steem.Objects.SignedTransaction: Ditch.Steem.Objects.Transaction*

signed_transaction
libraries\protocol\include\steemit\protocol\transaction.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.SignedTransaction.Operations"></a>

* *Object[][]* **Operations**  


<a id="Ditch.Steem.Objects.SignedTransaction.Signatures"></a>

* *List&lt;Byte[]&gt;* **Signatures**  
  API name: signatures  


<a id="Ditch.Steem.Objects.SignedTransaction.SignaturesStr"></a>

* *String[]* **SignaturesStr**  






---

<a id="Ditch.Steem.Objects.State"></a>
## State
*class Ditch.Steem.Objects.State*

state
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.State.CurrentRoute"></a>

* *String* **CurrentRoute**  


<a id="Ditch.Steem.Objects.State.Props"></a>

* *DynamicGlobalPropertyApiObj* **Props**  


<a id="Ditch.Steem.Objects.State.CategoryIdx"></a>

* *Object* **CategoryIdx**  


<a id="Ditch.Steem.Objects.State.TagIdx"></a>

* *Object* **TagIdx**  


<a id="Ditch.Steem.Objects.State.DiscussionIdx"></a>

* *Object* **DiscussionIdx**  
  is the global discussion index  


<a id="Ditch.Steem.Objects.State.Categories"></a>

* *Object* **Categories**  


<a id="Ditch.Steem.Objects.State.Tags"></a>

* *Object* **Tags**  


<a id="Ditch.Steem.Objects.State.Content"></a>

* *Object* **Content**  
  map from account/slug to full nested discussion  


<a id="Ditch.Steem.Objects.State.Accounts"></a>

* *Object* **Accounts**  


<a id="Ditch.Steem.Objects.State.PowQueue"></a>

* *String[]* **PowQueue**  
  The list of miners who are queued to produce work  


<a id="Ditch.Steem.Objects.State.Witnesses"></a>

* *Object* **Witnesses**  


<a id="Ditch.Steem.Objects.State.WitnessSchedule"></a>

* *WitnessScheduleApiObj* **WitnessSchedule**  


<a id="Ditch.Steem.Objects.State.FeedPrice"></a>

* *Price* **FeedPrice**  


<a id="Ditch.Steem.Objects.State.Error"></a>

* *String* **Error**  


<a id="Ditch.Steem.Objects.State.MarketData"></a>

* *Object* **MarketData**  






---

<a id="Ditch.Steem.Objects.SteemVersionInfo"></a>
## SteemVersionInfo
*class Ditch.Steem.Objects.SteemVersionInfo*

steem_version_info
libraries\app\include\steemit\app\api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.SteemVersionInfo.BlockchainVersion"></a>

* *String* **BlockchainVersion**  
  API name: blockchain_version  


<a id="Ditch.Steem.Objects.SteemVersionInfo.SteemRevision"></a>

* *String* **SteemRevision**  
  API name: steem_revision  


<a id="Ditch.Steem.Objects.SteemVersionInfo.FcRevision"></a>

* *String* **FcRevision**  
  API name: fc_revision  






---

<a id="Ditch.Steem.Objects.TagApiObj"></a>
## TagApiObj
*class Ditch.Steem.Objects.TagApiObj*

tag_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.TagApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Steem.Objects.TagApiObj.TotalChildrenRshares2"></a>

* *String* **TotalChildrenRshares2**  


<a id="Ditch.Steem.Objects.TagApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Steem.Objects.TagApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Steem.Objects.TagApiObj.TopPosts"></a>

* *UInt32* **TopPosts**  


<a id="Ditch.Steem.Objects.TagApiObj.Comments"></a>

* *UInt32* **Comments**  


<a id="Ditch.Steem.Objects.TagApiObj.Trending"></a>

* *String* **Trending**  






---

<a id="Ditch.Steem.Objects.Transaction"></a>
## Transaction
*class Ditch.Steem.Objects.Transaction*

transaction
libraries\protocol\include\steemit\protocol\transaction.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.Transaction.ChainId"></a>

* *Byte[]* **ChainId**  


<a id="Ditch.Steem.Objects.Transaction.RefBlockNum"></a>

* *UInt16* **RefBlockNum**  
  API name: ref_block_num
= 0;  


<a id="Ditch.Steem.Objects.Transaction.RefBlockPrefix"></a>

* *UInt32* **RefBlockPrefix**  
  API name: ref_block_prefix
= 0;  


<a id="Ditch.Steem.Objects.Transaction.Expiration"></a>

* *DateTime* **Expiration**  
  API name: expiration  


<a id="Ditch.Steem.Objects.Transaction.BaseOperations"></a>

* *BaseOperation[]* **BaseOperations**  
  API name: operations  


<a id="Ditch.Steem.Objects.Transaction.Extensions"></a>

* *Object[]* **Extensions**  
  API name: extensions  






---

<a id="Ditch.Steem.Objects.VoteState"></a>
## VoteState
*class Ditch.Steem.Objects.VoteState*

vote_state
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.VoteState.Voter"></a>

* *String* **Voter**  


<a id="Ditch.Steem.Objects.VoteState.Weight"></a>

* *UInt64* **Weight**  


<a id="Ditch.Steem.Objects.VoteState.Rshares"></a>

* *Int64* **Rshares**  


<a id="Ditch.Steem.Objects.VoteState.Percent"></a>

* *Int16* **Percent**  


<a id="Ditch.Steem.Objects.VoteState.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Steem.Objects.VoteState.Time"></a>

* *DateTime* **Time**  






---

<a id="Ditch.Steem.Objects.WithdrawRoute"></a>
## WithdrawRoute
*class Ditch.Steem.Objects.WithdrawRoute*

withdraw_route
steem-0.19.1\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.WithdrawRoute.FromAccount"></a>

* *String* **FromAccount**  


<a id="Ditch.Steem.Objects.WithdrawRoute.ToAccount"></a>

* *String* **ToAccount**  


<a id="Ditch.Steem.Objects.WithdrawRoute.Percent"></a>

* *UInt16* **Percent**  


<a id="Ditch.Steem.Objects.WithdrawRoute.AutoVest"></a>

* *Boolean* **AutoVest**  






---

<a id="Ditch.Steem.Objects.WitnessApiObj"></a>
## WitnessApiObj
*class Ditch.Steem.Objects.WitnessApiObj*

witness_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.WitnessApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Steem.Objects.WitnessApiObj.Owner"></a>

* *String* **Owner**  
  API name: owner  


<a id="Ditch.Steem.Objects.WitnessApiObj.Created"></a>

* *DateTime* **Created**  
  API name: created  


<a id="Ditch.Steem.Objects.WitnessApiObj.Url"></a>

* *String* **Url**  
  API name: url  


<a id="Ditch.Steem.Objects.WitnessApiObj.TotalMissed"></a>

* *UInt32* **TotalMissed**  
  API name: total_missed
= 0;  


<a id="Ditch.Steem.Objects.WitnessApiObj.LastAslot"></a>

* *UInt64* **LastAslot**  
  API name: last_aslot
= 0;  


<a id="Ditch.Steem.Objects.WitnessApiObj.LastConfirmedBlockNum"></a>

* *UInt64* **LastConfirmedBlockNum**  
  API name: last_confirmed_block_num
= 0;  


<a id="Ditch.Steem.Objects.WitnessApiObj.PowWorker"></a>

* *UInt64* **PowWorker**  
  API name: pow_worker
= 0;  


<a id="Ditch.Steem.Objects.WitnessApiObj.SigningKey"></a>

* *Object* **SigningKey**  
  API name: signing_key  


<a id="Ditch.Steem.Objects.WitnessApiObj.Props"></a>

* *ChainProperties* **Props**  
  API name: props  


<a id="Ditch.Steem.Objects.WitnessApiObj.SbdExchangeRate"></a>

* *Price* **SbdExchangeRate**  
  API name: sbd_exchange_rate  


<a id="Ditch.Steem.Objects.WitnessApiObj.LastSbdExchangeUpdate"></a>

* *DateTime* **LastSbdExchangeUpdate**  
  API name: last_sbd_exchange_update  


<a id="Ditch.Steem.Objects.WitnessApiObj.Votes"></a>

* *Object* **Votes**  
  API name: votes  


<a id="Ditch.Steem.Objects.WitnessApiObj.VirtualLastUpdate"></a>

* *String* **VirtualLastUpdate**  
  API name: virtual_last_update  


<a id="Ditch.Steem.Objects.WitnessApiObj.VirtualPosition"></a>

* *String* **VirtualPosition**  
  API name: virtual_position  


<a id="Ditch.Steem.Objects.WitnessApiObj.VirtualScheduledTime"></a>

* *String* **VirtualScheduledTime**  
  API name: virtual_scheduled_time  


<a id="Ditch.Steem.Objects.WitnessApiObj.LastWork"></a>

* *Object* **LastWork**  
  API name: last_work  


<a id="Ditch.Steem.Objects.WitnessApiObj.RunningVersion"></a>

* *Version* **RunningVersion**  
  API name: running_version  


<a id="Ditch.Steem.Objects.WitnessApiObj.HardforkVersionVote"></a>

* *Object* **HardforkVersionVote**  
  API name: hardfork_version_vote  


<a id="Ditch.Steem.Objects.WitnessApiObj.HardforkTimeVote"></a>

* *DateTime* **HardforkTimeVote**  
  API name: hardfork_time_vote  






---

<a id="Ditch.Steem.Objects.WitnessScheduleApiObj"></a>
## WitnessScheduleApiObj
*class Ditch.Steem.Objects.WitnessScheduleApiObj: Ditch.Steem.Objects.WitnessScheduleObject*

witness_schedule_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Objects.WitnessScheduleObject"></a>
## WitnessScheduleObject
*class Ditch.Steem.Objects.WitnessScheduleObject*

witness_schedule_object
steem-0.19.1\libraries\chain\include\steemit\chain\witness_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Objects.WitnessScheduleObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.CurrentVirtualTime"></a>

* *String* **CurrentVirtualTime**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.NextShuffleBlockNum"></a>

* *UInt32* **NextShuffleBlockNum**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.CurrentShuffledWitnesses"></a>

* *Object* **CurrentShuffledWitnesses**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.NumScheduledWitnesses"></a>

* *Byte* **NumScheduledWitnesses**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.Top19Weight"></a>

* *Byte* **Top19Weight**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.TimeshareWeight"></a>

* *Byte* **TimeshareWeight**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.MinerWeight"></a>

* *Byte* **MinerWeight**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.WitnessPayNormalizationFactor"></a>

* *UInt32* **WitnessPayNormalizationFactor**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.MedianProps"></a>

* *ChainProperties* **MedianProps**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.MajorityVersion"></a>

* *String* **MajorityVersion**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.MaxVotedWitnesses"></a>

* *Byte* **MaxVotedWitnesses**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.MaxMinerWitnesses"></a>

* *Byte* **MaxMinerWitnesses**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.MaxRunnerWitnesses"></a>

* *Byte* **MaxRunnerWitnesses**  


<a id="Ditch.Steem.Objects.WitnessScheduleObject.HardforkRequiredWitnesses"></a>

* *Byte* **HardforkRequiredWitnesses**  






---

