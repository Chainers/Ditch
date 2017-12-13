<a id="Ditch.Golos.OperationManager"></a>
## OperationManager
*class Ditch.Golos.OperationManager*

market_history_api
libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp

**Methods**

<a id="Ditch.Golos.OperationManager.GetAccountHistory(System.String,System.UInt64,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetAccountHistory** *(String account, UInt64 from, UInt32 limit, CancellationToken token)*  
  API name: get_account_history
Account operations have sequence numbers from 0 to N where N is the most recent operation.
            
*The history of all user actions on the network in the form of transactions. If from = -1, then are last {limit+1} history elements are shown. Parameter limit should be less or equals {from} (except from = -1). This is because elements preceding {from} are shown.  

<a id="Ditch.Golos.OperationManager.GetPayoutExtensionCost(System.String,System.String,System.DateTime,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Money&gt;* **GetPayoutExtensionCost** *(String author, String permlink, DateTime time, CancellationToken token)*  
  API name: get_payout_extension_cost
Used to retrieve comment payout window extension cost by time  

<a id="Ditch.Golos.OperationManager.GetFollowers(System.String,System.String,Ditch.Golos.Operations.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowers** *(String to, String start, FollowType type, UInt16 limit, CancellationToken token)*  
  API name: get_followers
*Returns the list: Either all of the subscribers of the user are 'following'. Or, if the user name is specified, the list of matching subscribers is returned in the parameter 'startFollower'.  

<a id="Ditch.Golos.OperationManager.GetFollowing(System.String,System.String,Ditch.Golos.Operations.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowing** *(String from, String start, FollowType type, UInt16 limit, CancellationToken token)*  
  API name: get_following  

<a id="Ditch.Golos.OperationManager.GetFollowCount(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowCountApiObj&gt;* **GetFollowCount** *(String account, CancellationToken token)*  
  API name: get_follow_count
*Returns information about the number of subscribers and subscriptions of the specified user.  

<a id="Ditch.Golos.OperationManager.GetFeedEntries(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FeedEntry[]&gt;* **GetFeedEntries** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_feed_entries
*Returns brief information about records from the specified user's tape  

<a id="Ditch.Golos.OperationManager.GetFeed(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CommentFeedEntry[]&gt;* **GetFeed** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_feed
*Returns the complete record data from the specified user's tape.  

<a id="Ditch.Golos.OperationManager.GetBlogEntries(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BlogEntry[]&gt;* **GetBlogEntries** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_blog_entries
*Returns brief information about records from the blog of the specified user.  

<a id="Ditch.Golos.OperationManager.GetBlog(System.String,System.UInt32,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CommentBlogEntry[]&gt;* **GetBlog** *(String account, UInt32 entryId, UInt16 limit, CancellationToken token)*  
  API name: get_blog
*Returns the complete record data from the blog of the specified user.  

<a id="Ditch.Golos.OperationManager.GetAccountReputations(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountReputation[]&gt;* **GetAccountReputations** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: get_account_reputations
*Returns data about the reputation of users filtered by template.  

<a id="Ditch.Golos.OperationManager.GetRebloggedBy(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetRebloggedBy** *(String author, String permlink, CancellationToken token)*  
  API name: get_reblogged_by
Gets list of accounts that have reblogged a particular post
            
*Returns the list of users who either created the record or made it a repost.  

<a id="Ditch.Golos.OperationManager.GetBlogAuthors(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object[][]&gt;* **GetBlogAuthors** *(String blogAccount, CancellationToken token)*  
  API name: get_blog_authors
Gets a list of authors that have had their content reblogged on a given blog account
            
*Returns the list of authors and the number of reposts of this author by the user.  

<a id="Ditch.Golos.OperationManager.Login(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Boolean&gt;* **Login** *(String user, String password, CancellationToken token)*  
  API name: login
Authenticate to the RPC server
            
*Allows you to connect to the accounts on the network.  

<a id="Ditch.Golos.OperationManager.GetApiByName(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetApiByName** *(String apiName, CancellationToken token)*  
  API name: get_api_by_name
*Returns the unique API identifier by its name.  

<a id="Ditch.Golos.OperationManager.GetVersion(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SteemVersionInfo&gt;* **GetVersion** *(CancellationToken token)*  
  API name: get_version
*Returns the version information for the components of the blockchain.  

<a id="Ditch.Golos.OperationManager.BroadcastTransaction(Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **BroadcastTransaction** *(SignedTransaction trx, CancellationToken token)*  
  API name: broadcast_transaction
Broadcast a transaction to the network
            
*The transaction will be checked for validity in the local database prior to broadcasting. If it fails to apply locally, an error will be thrown and the transaction will not be broadcast.  

<a id="Ditch.Golos.OperationManager.BroadcastTransactionWithCallback(System.Object,Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **BroadcastTransactionWithCallback** *(Object cb, SignedTransaction trx, CancellationToken token)*  
  API name: broadcast_transaction_with_callback
this version of broadcast transaction registers a callback method that will be called when the transaction is
included into a block.  The callback method includes the transaction id, block number, and transaction number in the
block.  

<a id="Ditch.Golos.OperationManager.BroadcastTransactionSynchronous(Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **BroadcastTransactionSynchronous** *(SignedTransaction trx, CancellationToken token)*  
  API name: broadcast_transaction_synchronous
This call will not return until the transaction is included in a block.  

<a id="Ditch.Golos.OperationManager.BroadcastBlock(Ditch.Golos.Objects.SignedBlock,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **BroadcastBlock** *(SignedBlock block, CancellationToken token)*  
  API name: broadcast_block  

<a id="Ditch.Golos.OperationManager.SetMaxBlockAge(System.Int32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **SetMaxBlockAge** *(Int32 maxBlockAge, CancellationToken token)*  
  API name: set_max_block_age  

<a id="Ditch.Golos.OperationManager.SetSubscribeCallback(System.Object,System.Boolean,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **SetSubscribeCallback** *(Object cb, Boolean clearFilter, CancellationToken token)*  
  API name: set_subscribe_callback  

<a id="Ditch.Golos.OperationManager.SetPendingTransactionCallback(System.Object,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **SetPendingTransactionCallback** *(Object cb, CancellationToken token)*  
  API name: set_pending_transaction_callback  

<a id="Ditch.Golos.OperationManager.SetBlockAppliedCallback(System.Object,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **SetBlockAppliedCallback** *(Object cb, CancellationToken token)*  
  API name: set_block_applied_callback  

<a id="Ditch.Golos.OperationManager.CancelAllSubscriptions(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **CancelAllSubscriptions** *(CancellationToken token)*  
  API name: cancel_all_subscriptions
Stop receiving any notifications

This unsubscribes from all subscribed markets and objects.  

<a id="Ditch.Golos.OperationManager.SubscribeToMarket(System.Object,System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **SubscribeToMarket** *(Object callback, String a, String b, CancellationToken token)*  

<a id="Ditch.Golos.OperationManager.UnsubscribeFromMarket(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **UnsubscribeFromMarket** *(String a, String b, CancellationToken token)*  
  API name: unsubscribe_from_market
Unsubscribe from updates to a given market  

<a id="Ditch.Golos.OperationManager.GetLimitOrdersByOwner(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ExtendedLimitOrder[]&gt;* **GetLimitOrdersByOwner** *(String owner, CancellationToken token)*  
  API name: get_limit_orders_by_owner  

<a id="Ditch.Golos.OperationManager.GetSettleOrdersByOwner(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ForceSettlementObject[]&gt;* **GetSettleOrdersByOwner** *(String owner, CancellationToken token)*  
  API name: get_settle_orders_by_owner  

<a id="Ditch.Golos.OperationManager.GetTicker(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;MarketTicker&gt;* **GetTicker** *(String base, String quote, CancellationToken token)*  
  API name: get_ticker
Returns the ticker for the market assetA:assetB
            
*Returns the market ticker for the internal market  

<a id="Ditch.Golos.OperationManager.GetVolume(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;MarketVolume&gt;* **GetVolume** *(String base, String quote, CancellationToken token)*  
  API name: get_volume
Returns the 24 hour volume for the market assetA:assetB
            
*Returns the market volume for the past 24 hours  

<a id="Ditch.Golos.OperationManager.GetOrderBook(System.String,System.String,System.Byte,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OrderBook&gt;* **GetOrderBook** *(String base, String quote, Byte limit, CancellationToken token)*  
  API name: get_order_book
Returns the order book for the market base:quote
            
*Displays a list of applications on the internal exchange for the purchase and sale of the network  

<a id="Ditch.Golos.OperationManager.GetOrderBook(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OrderBook&gt;* **GetOrderBook** *(UInt32 limit, CancellationToken token)*  
  Gets the current order book for STEEM:SBD market  

<a id="Ditch.Golos.OperationManager.GetTradeHistory(System.String,System.String,System.DateTime,System.DateTime,System.Byte,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;MarketTrade[]&gt;* **GetTradeHistory** *(String base, String quote, DateTime start, DateTime stop, Byte limit, CancellationToken token)*  
  API name: get_trade_history
Returns recent trades for the market assetA:assetB
Note: Currently, timezone offsets are not supported. The time must be UTC.
            
*Returns the trade history for the internal market.  

<a id="Ditch.Golos.OperationManager.GetFillOrderHistory(System.String,System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OrderHistoryObject[]&gt;* **GetFillOrderHistory** *(String a, String b, UInt32 limit, CancellationToken token)*  
  API name: get_fill_order_history  

<a id="Ditch.Golos.OperationManager.GetMarketHistory(System.String,System.String,System.UInt32,System.DateTime,System.DateTime,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BucketObject[]&gt;* **GetMarketHistory** *(String a, String b, UInt32 bucketSeconds, DateTime start, DateTime end, CancellationToken token)*  
  API name: get_market_history
Returns the market history for the internal SBD:STEEM market.
            
*Returns the market history for the internal market.  

<a id="Ditch.Golos.OperationManager.GetLimitOrders(System.String,System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;LimitOrderObject[]&gt;* **GetLimitOrders** *(String a, String b, UInt32 limit, CancellationToken token)*  
  API name: get_limit_orders
Get limit orders in a given market  

<a id="Ditch.Golos.OperationManager.GetCallOrders(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CallOrderObject[]&gt;* **GetCallOrders** *(String a, UInt32 limit, CancellationToken token)*  
  API name: get_call_orders
Get call orders in a given asset  

<a id="Ditch.Golos.OperationManager.GetSettleOrders(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ForceSettlementObject[]&gt;* **GetSettleOrders** *(String a, UInt32 limit, CancellationToken token)*  
  API name: get_settle_orders
Get forced settlement orders in a given asset  

<a id="Ditch.Golos.OperationManager.GetCollateralBids(System.Object,System.UInt32,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CollateralBidObject[]&gt;* **GetCollateralBids** *(Object asset, UInt32 limit, UInt32 start, CancellationToken token)*  
  API name: get_collateral_bids
Get collateral_bid_objects for a given asset  

<a id="Ditch.Golos.OperationManager.GetMarginPositions(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CallOrderObject[]&gt;* **GetMarginPositions** *(String name, CancellationToken token)*  
  API name: get_margin_positions  

<a id="Ditch.Golos.OperationManager.GetKeyReferences(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[][]&gt;* **GetKeyReferences** *(String[] keys, CancellationToken token)*  
  API name: get_key_references  

<a id="Ditch.Golos.OperationManager.TryConnectTo(System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken)"></a>

* *String* **TryConnectTo** *(List&lt;String&gt; urls, CancellationToken token)*  

<a id="Ditch.Golos.OperationManager.RetryConnect(System.Threading.CancellationToken)"></a>

* *String* **RetryConnect** *(CancellationToken token)*  

<a id="Ditch.Golos.OperationManager.BroadcastOperations(System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Golos.Operations.BaseOperation[])"></a>

* *JsonRpcResponse* **BroadcastOperations** *(IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] operations)*  

<a id="Ditch.Golos.OperationManager.VerifyAuthority(System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Golos.Operations.BaseOperation[])"></a>

* *JsonRpcResponse&lt;Boolean&gt;* **VerifyAuthority** *(IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] testOps)*  

<a id="Ditch.Golos.OperationManager.CustomGetRequest(System.String,System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse&lt;T&gt;* **CustomGetRequest** *(String method, CancellationToken token, Object[] data)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Golos.OperationManager.CustomGetRequest(System.String,System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse* **CustomGetRequest** *(String method, CancellationToken token, Object[] data)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Golos.OperationManager.CallRequest(System.String,System.String,System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **CallRequest** *(String api, String method, Object[] data, CancellationToken token)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Golos.OperationManager.CallRequest(System.String,System.String,System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;T&gt;* **CallRequest** *(String api, String method, Object[] data, CancellationToken token)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Golos.OperationManager.CreateTransaction(Ditch.Golos.Objects.DynamicGlobalPropertyObject,System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Golos.Operations.BaseOperation[])"></a>

* *SignedTransaction* **CreateTransaction** *(DynamicGlobalPropertyObject propertyApiObj, IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] operations)*  

<a id="Ditch.Golos.OperationManager.GetTrendingTags(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;TagApiObj[]&gt;* **GetTrendingTags** *(String afterTag, UInt32 limit, CancellationToken token)*  
  API name: get_trending_tags
*Returns a list of tags (tags) that include word combinations  

<a id="Ditch.Golos.OperationManager.GetTrendingCategories(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CategoryApiObj[]&gt;* **GetTrendingCategories** *(String after, UInt32 limit, CancellationToken token)*  
  API name: get_trending_categories
*Returns sorted by value tags starting with a given or similar to it.  

<a id="Ditch.Golos.OperationManager.GetBestCategories(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CategoryApiObj[]&gt;* **GetBestCategories** *(String after, UInt32 limit, CancellationToken token)*  
  API name: get_best_categories  

<a id="Ditch.Golos.OperationManager.GetActiveCategories(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CategoryApiObj[]&gt;* **GetActiveCategories** *(String after, UInt32 limit, CancellationToken token)*  
  API name: get_active_categories  

<a id="Ditch.Golos.OperationManager.GetRecentCategories(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CategoryApiObj[]&gt;* **GetRecentCategories** *(String after, UInt32 limit, CancellationToken token)*  
  API name: get_recent_categories  

<a id="Ditch.Golos.OperationManager.GetActiveWitnesses(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetActiveWitnesses** *(CancellationToken token)*  
  API name: get_active_witnesses
*Displays a list of all active delegates.  

<a id="Ditch.Golos.OperationManager.GetMinerQueue(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetMinerQueue** *(CancellationToken token)*  
  API name: get_miner_queue
*Creates a list of the miners waiting to enter the DPOW chain to create the block.  

<a id="Ditch.Golos.OperationManager.GetState(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;State&gt;* **GetState** *(String path, CancellationToken token)*  
  API name: get_state
This API is a short-cut for returning all of the state required for a particular URL
with a single query.
            
*Displays the current network status.  

<a id="Ditch.Golos.OperationManager.GetBlockHeader(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BlockHeader&gt;* **GetBlockHeader** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block_header
Retrieve a block header

*Returns block for given number  

<a id="Ditch.Golos.OperationManager.GetBlock(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SignedBlock&gt;* **GetBlock** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block
Retrieve a full, signed block
            
*Returns block for given number  

<a id="Ditch.Golos.OperationManager.GetOpsInBlock(System.UInt32,System.Boolean,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AppliedOperation[]&gt;* **GetOpsInBlock** *(UInt32 blockNum, Boolean onlyVirtual, CancellationToken token)*  
  API name: get_ops_in_block
Get sequence of operations included/generated within a particular block
            
*Returns all operations in the block, if the parameter 'onlyVirtual' is true, then returns only the virtual operations  

<a id="Ditch.Golos.OperationManager.GetConfig(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetConfig** *(CancellationToken token)*  
  API name: get_config
Retrieve compile-time constants
            
*Displays the current node configuration.  

<a id="Ditch.Golos.OperationManager.GetDynamicGlobalProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;DynamicGlobalPropertyObject&gt;* **GetDynamicGlobalProperties** *(CancellationToken token)*  
  API name: get_dynamic_global_properties
Retrieve the current @ref dynamic_global_property_object
            
*Displays information about the current network status.  

<a id="Ditch.Golos.OperationManager.GetChainProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ChainProperties&gt;* **GetChainProperties** *(CancellationToken token)*  
  API name: get_chain_properties
*Displays the commission for creating the user, the maximum block size and the GBG interest rate.  

<a id="Ditch.Golos.OperationManager.GetCurrentMedianHistoryPrice(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Price&gt;* **GetCurrentMedianHistoryPrice** *(CancellationToken token)*  
  API name: get_current_median_history_price
*Displays the current median price of conversion  

<a id="Ditch.Golos.OperationManager.GetFeedHistory(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FeedHistoryApiObj&gt;* **GetFeedHistory** *(CancellationToken token)*  
  API name: get_feed_history
*Displays the conversion history  

<a id="Ditch.Golos.OperationManager.GetWitnessSchedule(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessScheduleObject&gt;* **GetWitnessSchedule** *(CancellationToken token)*  
  API name: get_witness_schedule
*Displays the current delegation status.  

<a id="Ditch.Golos.OperationManager.GetHardforkVersion(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String&gt;* **GetHardforkVersion** *(CancellationToken token)*  
  API name: get_hardfork_version
*Displays the current version of the network.  

<a id="Ditch.Golos.OperationManager.GetNextScheduledHardfork(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ScheduledHardfork&gt;* **GetNextScheduledHardfork** *(CancellationToken token)*  
  API name: get_next_scheduled_hardfork
*Displays the date and version of HardFork  

<a id="Ditch.Golos.OperationManager.GetNameCost(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Money&gt;* **GetNameCost** *(String name, CancellationToken token)*  
  API name: get_name_cost  

<a id="Ditch.Golos.OperationManager.GetAccounts(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ExtendedAccount[]&gt;* **GetAccounts** *(String[] names, CancellationToken token)*  
  API name: get_accounts
*Returns data for specified accounts  

<a id="Ditch.Golos.OperationManager.LookupAccountNames(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountApiObj[]&gt;* **LookupAccountNames** *(String[] accountNames, CancellationToken token)*  
  API name: lookup_account_names
Get a list of accounts by name
            
*Returns data for specified accounts  

<a id="Ditch.Golos.OperationManager.LookupAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **LookupAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_accounts
Get names and IDs for registered accounts
            
*Returns the names of users close to the phrase.  

<a id="Ditch.Golos.OperationManager.GetAccountCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetAccountCount** *(CancellationToken token)*  
  API name: get_account_count
Get the total number of accounts registered with the blockchain
            
*Returns the number of registered users.  

<a id="Ditch.Golos.OperationManager.GetOwnerHistory(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OwnerAuthorityHistoryApiObj[]&gt;* **GetOwnerHistory** *(String account, CancellationToken token)*  
  API name: get_owner_history
*Displays the user name if he changed the ownership of the blockchain  

<a id="Ditch.Golos.OperationManager.GetRecoveryRequest(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountRecoveryRequestApiObj&gt;* **GetRecoveryRequest** *(String account, CancellationToken token)*  
  API name: get_recovery_request
*Returns true if the user is in recovery status.  

<a id="Ditch.Golos.OperationManager.GetEscrow(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;EscrowObject&gt;* **GetEscrow** *(String from, UInt32 escrowId, CancellationToken token)*  
  API name: get_escrow
*Returns the operations implemented through mediation.  

<a id="Ditch.Golos.OperationManager.GetWithdrawRoutes(System.String,Ditch.Golos.Operations.Enums.WithdrawRouteType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WithdrawRoute[]&gt;* **GetWithdrawRoutes** *(String account, WithdrawRouteType type, CancellationToken token)*  
  API name: get_withdraw_routes
*Returns all transfers to the user's account, depending on the type  

<a id="Ditch.Golos.OperationManager.GetAccountBandwidth(System.String,Ditch.Golos.Operations.Enums.BandwidthType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountBandwidthObject&gt;* **GetAccountBandwidth** *(String account, BandwidthType type, CancellationToken token)*  
  API name: get_account_bandwidth
*Displays user actions based on type  

<a id="Ditch.Golos.OperationManager.GetSavingsWithdrawFrom(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawFrom** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_from
*Returns the output data from 'SAFE' for this user  

<a id="Ditch.Golos.OperationManager.GetSavingsWithdrawTo(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawTo** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_to
*Returns the output data from 'SAFE' for this user  

<a id="Ditch.Golos.OperationManager.GetWitnesses(System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnesses** *(Object[] witnessIds, CancellationToken token)*  
  API name: get_witnesses
Get a list of witnesses by ID
            
*Displays delegate data according to the specified ID  

<a id="Ditch.Golos.OperationManager.GetConversionRequests(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ConvertRequestObject[]&gt;* **GetConversionRequests** *(String accountName, CancellationToken token)*  
  API name: get_conversion_requests
*Returns the current requests for conversion by the specified user  

<a id="Ditch.Golos.OperationManager.GetWitnessByAccount(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj&gt;* **GetWitnessByAccount** *(String accountName, CancellationToken token)*  
  API name: get_witness_by_account
Get the witness owned by a given account
            
*Displays data about the delegate (if it is) according to the data from the request  

<a id="Ditch.Golos.OperationManager.GetWitnessesByVote(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnessesByVote** *(String from, UInt32 limit, CancellationToken token)*  
  API name: get_witnesses_by_vote
This method is used to fetch witnesses with pagination.
            
*Displays a limited list of delegates approving the vote.  

<a id="Ditch.Golos.OperationManager.LookupWitnessAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **LookupWitnessAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_witness_accounts
Get names and IDs for registered witnesses
            
*Displays a limited list of users who have announced their intention to work as a delegate.  

<a id="Ditch.Golos.OperationManager.GetWitnessCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetWitnessCount** *(CancellationToken token)*  
  API name: get_witness_count
Get the total number of witnesses registered with the blockchain
            
*Displays the number of delegates.  

<a id="Ditch.Golos.OperationManager.GetTransactionHex(Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String&gt;* **GetTransactionHex** *(SignedTransaction trx, CancellationToken token)*  
  API name: get_transaction_hex
Get a hexdump of the serialized binary form of a transaction
            
*Displays the HEX transaction string.  

<a id="Ditch.Golos.OperationManager.VerifyAuthority(Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Boolean&gt;* **VerifyAuthority** *(SignedTransaction trx, CancellationToken token)*  
  API name: verify_authority
*Returns TRUE if the transaction is signed correctly  

<a id="Ditch.Golos.OperationManager.GetActiveVotes(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;VoteState[]&gt;* **GetActiveVotes** *(String author, String permlink, CancellationToken token)*  
  API name: get_active_votes
*Displays the list of users who voted for the specified entry  

<a id="Ditch.Golos.OperationManager.GetContent(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion&gt;* **GetContent** *(String author, String permlink, CancellationToken token)*  
  API name: get_content
*Gets information about the publication, with the exception of comments  

<a id="Ditch.Golos.OperationManager.GetContentReplies(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetContentReplies** *(String parent, String parentPermlink, CancellationToken token)*  
  API name: get_content_replies
*Displays a list of all comments for the selected publication  

<a id="Ditch.Golos.OperationManager.GetTagsUsedByAuthor(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;KeyValuePair`2[]&gt;* **GetTagsUsedByAuthor** *(String author, CancellationToken token)*  
  API name: get_tags_used_by_author
Used to retrieve top 1000 tags list used by an author sorted by most frequently used  

<a id="Ditch.Golos.OperationManager.GetRepliesByLastUpdate(System.String,System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetRepliesByLastUpdate** *(String startAuthor, String startPermlink, UInt32 limit, CancellationToken token)*  
  API name: get_replies_by_last_update
*Return the active discussions with the highest cumulative pending payouts without respect to category, total  pending payout means the pending payout of all children as well.  

<a id="Ditch.Golos.OperationManager.GetDiscussionsByAuthorBeforeDate(System.String,System.String,System.DateTime,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetDiscussionsByAuthorBeforeDate** *(String author, String startPermlink, DateTime beforeDate, UInt32 limit, CancellationToken token)*  
  API name: get_discussions_by_author_before_date
This method is used to fetch all posts/comments by start_author that occur after before_date and start_permlink with up to limit being returned.

If start_permlink is empty then only before_date will be considered. If both are specified the eariler to the two metrics will be used. This
should allow easy pagination.
            
*Displays a limited number of user publications  


**Properties and Fields**

<a id="Ditch.Golos.OperationManager.ChainId"></a>

* *Byte[]* **ChainId**  


<a id="Ditch.Golos.OperationManager.SbdSymbol"></a>

* *String* **SbdSymbol**  


<a id="Ditch.Golos.OperationManager.Version"></a>

* *Int32* **Version**  


<a id="Ditch.Golos.OperationManager.IsConnected"></a>

* *Boolean* **IsConnected**  






---

<a id="Ditch.Golos.Protocol.SignedTransaction"></a>
## SignedTransaction
*class Ditch.Golos.Protocol.SignedTransaction: Ditch.Golos.Protocol.Transaction*

signed_transaction
libraries\protocol\include\golos\protocol\transaction.hpp

**Properties and Fields**

<a id="Ditch.Golos.Protocol.SignedTransaction.Operations"></a>

* *Object[][]* **Operations**  


<a id="Ditch.Golos.Protocol.SignedTransaction.Signatures"></a>

* *List&lt;Byte[]&gt;* **Signatures**  
  API name: signatures  


<a id="Ditch.Golos.Protocol.SignedTransaction.SignaturesStr"></a>

* *String[]* **SignaturesStr**  






---

<a id="Ditch.Golos.Protocol.Transaction"></a>
## Transaction
*class Ditch.Golos.Protocol.Transaction*

transaction
libraries\protocol\include\golos\protocol\transaction.hpp

**Properties and Fields**

<a id="Ditch.Golos.Protocol.Transaction.ChainId"></a>

* *Byte[]* **ChainId**  


<a id="Ditch.Golos.Protocol.Transaction.RefBlockNum"></a>

* *UInt16* **RefBlockNum**  
  API name: ref_block_num
= 0;  


<a id="Ditch.Golos.Protocol.Transaction.RefBlockPrefix"></a>

* *UInt32* **RefBlockPrefix**  
  API name: ref_block_prefix
= 0;  


<a id="Ditch.Golos.Protocol.Transaction.Expiration"></a>

* *DateTime* **Expiration**  
  API name: expiration  


<a id="Ditch.Golos.Protocol.Transaction.BaseOperations"></a>

* *BaseOperation[]* **BaseOperations**  
  API name: operations  


<a id="Ditch.Golos.Protocol.Transaction.Extensions"></a>

* *Object[]* **Extensions**  
  API name: extensions  






---

<a id="Ditch.Golos.Objects.AccountApiObj"></a>
## AccountApiObj
*class Ditch.Golos.Objects.AccountApiObj*

account_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.AccountApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Golos.Objects.AccountApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Golos.Objects.AccountApiObj.Owner"></a>

* *Authority* **Owner**  
  used for backup control, can set owner or active  


<a id="Ditch.Golos.Objects.AccountApiObj.Active"></a>

* *Authority* **Active**  
  used for all monetary operations, can set active or posting  


<a id="Ditch.Golos.Objects.AccountApiObj.Posting"></a>

* *Authority* **Posting**  
  used for voting and posting  


<a id="Ditch.Golos.Objects.AccountApiObj.MemoKey"></a>

* *String* **MemoKey**  


<a id="Ditch.Golos.Objects.AccountApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Golos.Objects.AccountApiObj.Proxy"></a>

* *String* **Proxy**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastOwnerUpdate"></a>

* *DateTime* **LastOwnerUpdate**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastAccountUpdate"></a>

* *DateTime* **LastAccountUpdate**  


<a id="Ditch.Golos.Objects.AccountApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Golos.Objects.AccountApiObj.Mined"></a>

* *Boolean* **Mined**  


<a id="Ditch.Golos.Objects.AccountApiObj.OwnerChallenged"></a>

* *Boolean* **OwnerChallenged**  


<a id="Ditch.Golos.Objects.AccountApiObj.ActiveChallenged"></a>

* *Boolean* **ActiveChallenged**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastOwnerProved"></a>

* *DateTime* **LastOwnerProved**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastActiveProved"></a>

* *DateTime* **LastActiveProved**  


<a id="Ditch.Golos.Objects.AccountApiObj.RecoveryAccount"></a>

* *String* **RecoveryAccount**  


<a id="Ditch.Golos.Objects.AccountApiObj.ResetAccount"></a>

* *String* **ResetAccount**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastAccountRecovery"></a>

* *DateTime* **LastAccountRecovery**  


<a id="Ditch.Golos.Objects.AccountApiObj.CommentCount"></a>

* *UInt32* **CommentCount**  


<a id="Ditch.Golos.Objects.AccountApiObj.LifetimeVoteCount"></a>

* *UInt32* **LifetimeVoteCount**  


<a id="Ditch.Golos.Objects.AccountApiObj.PostCount"></a>

* *UInt32* **PostCount**  


<a id="Ditch.Golos.Objects.AccountApiObj.CanVote"></a>

* *Boolean* **CanVote**  


<a id="Ditch.Golos.Objects.AccountApiObj.VotingPower"></a>

* *UInt16* **VotingPower**  
  Current voting power of this account, it falls after every vote  


<a id="Ditch.Golos.Objects.AccountApiObj.LastVoteTime"></a>

* *DateTime* **LastVoteTime**  
  used to increase the voting power of this account the longer it goes without voting.  


<a id="Ditch.Golos.Objects.AccountApiObj.Balance"></a>

* *Money* **Balance**  
  total liquid shares held by this account  


<a id="Ditch.Golos.Objects.AccountApiObj.SavingsBalance"></a>

* *Money* **SavingsBalance**  
  total liquid shares held by this account  


<a id="Ditch.Golos.Objects.AccountApiObj.SbdBalance"></a>

* *Money* **SbdBalance**  
  Total sbd balance  


<a id="Ditch.Golos.Objects.AccountApiObj.SbdSeconds"></a>

* *String* **SbdSeconds**  
  Total sbd * how long it has been hel  


<a id="Ditch.Golos.Objects.AccountApiObj.SbdSecondsLastUpdate"></a>

* *DateTime* **SbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Golos.Objects.AccountApiObj.SbdLastInterestPayment"></a>

* *DateTime* **SbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Golos.Objects.AccountApiObj.SavingsSbdBalance"></a>

* *Money* **SavingsSbdBalance**  
  total sbd balance  


<a id="Ditch.Golos.Objects.AccountApiObj.SavingsSbdSeconds"></a>

* *String* **SavingsSbdSeconds**  
  total sbd * how long it has been hel  


<a id="Ditch.Golos.Objects.AccountApiObj.SavingsSbdSecondsLastUpdate"></a>

* *DateTime* **SavingsSbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Golos.Objects.AccountApiObj.SavingsSbdLastInterestPayment"></a>

* *DateTime* **SavingsSbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Golos.Objects.AccountApiObj.SavingsWithdrawRequests"></a>

* *Byte* **SavingsWithdrawRequests**  


<a id="Ditch.Golos.Objects.AccountApiObj.RewardSbdBalance"></a>

* *Money* **RewardSbdBalance**  


<a id="Ditch.Golos.Objects.AccountApiObj.RewardSteemBalance"></a>

* *Money* **RewardSteemBalance**  


<a id="Ditch.Golos.Objects.AccountApiObj.RewardVestingBalance"></a>

* *Money* **RewardVestingBalance**  


<a id="Ditch.Golos.Objects.AccountApiObj.RewardVestingSteem"></a>

* *Money* **RewardVestingSteem**  


<a id="Ditch.Golos.Objects.AccountApiObj.CurationRewards"></a>

* *Object* **CurationRewards**  


<a id="Ditch.Golos.Objects.AccountApiObj.PostingRewards"></a>

* *Object* **PostingRewards**  


<a id="Ditch.Golos.Objects.AccountApiObj.VestingShares"></a>

* *Money* **VestingShares**  
  total vesting shares held by this account, controls its voting power  


<a id="Ditch.Golos.Objects.AccountApiObj.DelegatedVestingShares"></a>

* *Money* **DelegatedVestingShares**  


<a id="Ditch.Golos.Objects.AccountApiObj.ReceivedVestingShares"></a>

* *Money* **ReceivedVestingShares**  


<a id="Ditch.Golos.Objects.AccountApiObj.VestingWithdrawRate"></a>

* *Money* **VestingWithdrawRate**  
  at the time this is updated it can be at most vesting_shares/104  


<a id="Ditch.Golos.Objects.AccountApiObj.NextVestingWithdrawal"></a>

* *DateTime* **NextVestingWithdrawal**  
  after every withdrawal this is incremented by 1 week  


<a id="Ditch.Golos.Objects.AccountApiObj.Withdrawn"></a>

* *Object* **Withdrawn**  
  Track how many shares have been withdrawn  


<a id="Ditch.Golos.Objects.AccountApiObj.ToWithdraw"></a>

* *Object* **ToWithdraw**  
  Might be able to look this up with operation history.  


<a id="Ditch.Golos.Objects.AccountApiObj.WithdrawRoutes"></a>

* *UInt16* **WithdrawRoutes**  


<a id="Ditch.Golos.Objects.AccountApiObj.ProxiedVsfVotes"></a>

* *Object[]* **ProxiedVsfVotes**  


<a id="Ditch.Golos.Objects.AccountApiObj.WitnessesVotedFor"></a>

* *UInt16* **WitnessesVotedFor**  


<a id="Ditch.Golos.Objects.AccountApiObj.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Golos.Objects.AccountApiObj.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  


<a id="Ditch.Golos.Objects.AccountApiObj.AverageMarketBandwidth"></a>

* *Object* **AverageMarketBandwidth**  


<a id="Ditch.Golos.Objects.AccountApiObj.LifetimeMarketBandwidth"></a>

* *Object* **LifetimeMarketBandwidth**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastMarketBandwidthUpdate"></a>

* *DateTime* **LastMarketBandwidthUpdate**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastPost"></a>

* *DateTime* **LastPost**  


<a id="Ditch.Golos.Objects.AccountApiObj.LastRootPost"></a>

* *DateTime* **LastRootPost**  


<a id="Ditch.Golos.Objects.AccountApiObj.PostBandwidth"></a>

* *Object* **PostBandwidth**  


<a id="Ditch.Golos.Objects.AccountApiObj.NewAverageBandwidth"></a>

* *Object* **NewAverageBandwidth**  


<a id="Ditch.Golos.Objects.AccountApiObj.NewAverageMarketBandwidth"></a>

* *Object* **NewAverageMarketBandwidth**  






---

<a id="Ditch.Golos.Objects.AccountBandwidthApiObj"></a>
## AccountBandwidthApiObj
*class Ditch.Golos.Objects.AccountBandwidthApiObj: Ditch.Golos.Objects.AccountBandwidthObject*

account_bandwidth_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp\



---

<a id="Ditch.Golos.Objects.AccountBandwidthObject"></a>
## AccountBandwidthObject
*class Ditch.Golos.Objects.AccountBandwidthObject*

account_bandwidth_object
golos-0.16.3\libraries\chain\include\steemit\chain\account_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.AccountBandwidthObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.AccountBandwidthObject.Account"></a>

* *String* **Account**  


<a id="Ditch.Golos.Objects.AccountBandwidthObject.Type"></a>

* *BandwidthType* **Type**  


<a id="Ditch.Golos.Objects.AccountBandwidthObject.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Golos.Objects.AccountBandwidthObject.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Golos.Objects.AccountBandwidthObject.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  






---

<a id="Ditch.Golos.Objects.AccountRecoveryRequestApiObj"></a>
## AccountRecoveryRequestApiObj
*class Ditch.Golos.Objects.AccountRecoveryRequestApiObj*

account_recovery_request_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.AccountRecoveryRequestApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.AccountRecoveryRequestApiObj.AccountToRecover"></a>

* *String* **AccountToRecover**  


<a id="Ditch.Golos.Objects.AccountRecoveryRequestApiObj.NewOwnerAuthority"></a>

* *Authority* **NewOwnerAuthority**  


<a id="Ditch.Golos.Objects.AccountRecoveryRequestApiObj.Expires"></a>

* *DateTime* **Expires**  






---

<a id="Ditch.Golos.Objects.AccountReputation"></a>
## AccountReputation
*class Ditch.Golos.Objects.AccountReputation*

account_reputation
libraries\plugins\follow\include\golos\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.AccountReputation.Account"></a>

* *String* **Account**  
  API name: account  


<a id="Ditch.Golos.Objects.AccountReputation.Reputation"></a>

* *Object* **Reputation**  
  API name: reputation  






---

<a id="Ditch.Golos.Objects.AppliedOperation"></a>
## AppliedOperation
*class Ditch.Golos.Objects.AppliedOperation*

applied_operation
golos-0.16.3\libraries\app\include\steemit\app\applied_operation.hpp\

**Properties and Fields**

<a id="Ditch.Golos.Objects.AppliedOperation.TrxId"></a>

* *Object* **TrxId**  


<a id="Ditch.Golos.Objects.AppliedOperation.Block"></a>

* *UInt32* **Block**  


<a id="Ditch.Golos.Objects.AppliedOperation.TrxInBlock"></a>

* *UInt32* **TrxInBlock**  


<a id="Ditch.Golos.Objects.AppliedOperation.OpInTrx"></a>

* *UInt16* **OpInTrx**  


<a id="Ditch.Golos.Objects.AppliedOperation.VirtualOp"></a>

* *UInt64* **VirtualOp**  


<a id="Ditch.Golos.Objects.AppliedOperation.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Golos.Objects.AppliedOperation.Op"></a>

* *Object[]* **Op**  






---

<a id="Ditch.Golos.Objects.Authority"></a>
## Authority
*class Ditch.Golos.Objects.Authority*

authority
golos-0.16.3\libraries\protocol\include\steemit\protocol\authority.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.Authority.WeightThreshold"></a>

* *UInt32* **WeightThreshold**  


<a id="Ditch.Golos.Objects.Authority.AccountAuths"></a>

* *Object* **AccountAuths**  


<a id="Ditch.Golos.Objects.Authority.KeyAuths"></a>

* *Object[][]* **KeyAuths**  






---

<a id="Ditch.Golos.Objects.BeneficiaryRouteType"></a>
## BeneficiaryRouteType
*class Ditch.Golos.Objects.BeneficiaryRouteType*

beneficiary_route_type
libraries\protocol\include\golos\protocol\operations\comment_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.BeneficiaryRouteType.Account"></a>

* *String* **Account**  
  API name: account  


<a id="Ditch.Golos.Objects.BeneficiaryRouteType.Weight"></a>

* *UInt16* **Weight**  
  API name: weight  






---

<a id="Ditch.Golos.Objects.BlockHeader"></a>
## BlockHeader
*class Ditch.Golos.Objects.BlockHeader*

block_header
golos-0.16.3\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.BlockHeader.Previous"></a>

* *Object* **Previous**  


<a id="Ditch.Golos.Objects.BlockHeader.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Golos.Objects.BlockHeader.Witness"></a>

* *String* **Witness**  


<a id="Ditch.Golos.Objects.BlockHeader.TransactionMerkleRoot"></a>

* *Object* **TransactionMerkleRoot**  


<a id="Ditch.Golos.Objects.BlockHeader.Extensions"></a>

* *Object* **Extensions**  






---

<a id="Ditch.Golos.Objects.BlogEntry"></a>
## BlogEntry
*class Ditch.Golos.Objects.BlogEntry*

blog_entry
libraries\plugins\follow\include\golos\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.BlogEntry.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Objects.BlogEntry.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Golos.Objects.BlogEntry.Blog"></a>

* *String* **Blog**  
  API name: blog  


<a id="Ditch.Golos.Objects.BlogEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Golos.Objects.BlogEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Golos.Objects.BucketObject"></a>
## BucketObject
*class Ditch.Golos.Objects.BucketObject*

bucket_object
libraries\plugins\blockchain_statistics\include\golos\blockchain_statistics\blockchain_statistics_plugin.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.BucketObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.BucketObject.Open"></a>

* *DateTime* **Open**  
  API name: open
Open time of the bucket  


<a id="Ditch.Golos.Objects.BucketObject.Seconds"></a>

* *UInt32* **Seconds**  
  API name: seconds
= 0; ///< Seconds accounted for in the bucket  


<a id="Ditch.Golos.Objects.BucketObject.Blocks"></a>

* *UInt32* **Blocks**  
  API name: blocks
= 0; ///< Blocks produced  


<a id="Ditch.Golos.Objects.BucketObject.Bandwidth"></a>

* *UInt32* **Bandwidth**  
  API name: bandwidth
= 0; ///< Bandwidth in bytes  


<a id="Ditch.Golos.Objects.BucketObject.Operations"></a>

* *UInt32* **Operations**  
  API name: operations
= 0; ///< Operations evaluated  


<a id="Ditch.Golos.Objects.BucketObject.Transactions"></a>

* *UInt32* **Transactions**  
  API name: transactions
= 0; ///< Transactions processed  


<a id="Ditch.Golos.Objects.BucketObject.Transfers"></a>

* *UInt32* **Transfers**  
  API name: transfers
= 0; ///< Account to account transfers  


<a id="Ditch.Golos.Objects.BucketObject.SteemTransferred"></a>

* *Object* **SteemTransferred**  
  API name: steem_transferred
= 0; ///< STEEM transferred from account to account  


<a id="Ditch.Golos.Objects.BucketObject.SbdTransferred"></a>

* *Object* **SbdTransferred**  
  API name: sbd_transferred
= 0; ///< SBD transferred from account to account  


<a id="Ditch.Golos.Objects.BucketObject.SbdPaidAsInterest"></a>

* *Object* **SbdPaidAsInterest**  
  API name: sbd_paid_as_interest
= 0; ///< SBD paid as interest  


<a id="Ditch.Golos.Objects.BucketObject.PaidAccountsCreated"></a>

* *UInt32* **PaidAccountsCreated**  
  API name: paid_accounts_created
= 0; ///< Accounts created with fee  


<a id="Ditch.Golos.Objects.BucketObject.MinedAccountsCreated"></a>

* *UInt32* **MinedAccountsCreated**  
  API name: mined_accounts_created
= 0; ///< Accounts mined for free  


<a id="Ditch.Golos.Objects.BucketObject.RootComments"></a>

* *UInt32* **RootComments**  
  API name: root_comments
= 0; ///< Top level root comments  


<a id="Ditch.Golos.Objects.BucketObject.RootCommentEdits"></a>

* *UInt32* **RootCommentEdits**  
  API name: root_comment_edits
= 0; ///< Edits to root comments  


<a id="Ditch.Golos.Objects.BucketObject.RootCommentsDeleted"></a>

* *UInt32* **RootCommentsDeleted**  
  API name: root_comments_deleted
= 0; ///< Root comments deleted  


<a id="Ditch.Golos.Objects.BucketObject.Replies"></a>

* *UInt32* **Replies**  
  API name: replies
= 0; ///< Replies to comments  


<a id="Ditch.Golos.Objects.BucketObject.ReplyEdits"></a>

* *UInt32* **ReplyEdits**  
  API name: reply_edits
= 0; ///< Edits to replies  


<a id="Ditch.Golos.Objects.BucketObject.RepliesDeleted"></a>

* *UInt32* **RepliesDeleted**  
  API name: replies_deleted
= 0; ///< Replies deleted  


<a id="Ditch.Golos.Objects.BucketObject.NewRootVotes"></a>

* *UInt32* **NewRootVotes**  
  API name: new_root_votes
= 0; ///< New votes on root comments  


<a id="Ditch.Golos.Objects.BucketObject.ChangedRootVotes"></a>

* *UInt32* **ChangedRootVotes**  
  API name: changed_root_votes
= 0; ///< Changed votes on root comments  


<a id="Ditch.Golos.Objects.BucketObject.NewReplyVotes"></a>

* *UInt32* **NewReplyVotes**  
  API name: new_reply_votes
= 0; ///< New votes on replies  


<a id="Ditch.Golos.Objects.BucketObject.ChangedReplyVotes"></a>

* *UInt32* **ChangedReplyVotes**  
  API name: changed_reply_votes
= 0; ///< Changed votes on replies  


<a id="Ditch.Golos.Objects.BucketObject.Payouts"></a>

* *UInt32* **Payouts**  
  API name: payouts
= 0; ///< Number of comment payouts  


<a id="Ditch.Golos.Objects.BucketObject.SbdPaidToAuthors"></a>

* *Object* **SbdPaidToAuthors**  
  API name: sbd_paid_to_authors
= 0; ///< Ammount of SBD paid to authors  


<a id="Ditch.Golos.Objects.BucketObject.VestsPaidToAuthors"></a>

* *Object* **VestsPaidToAuthors**  
  API name: vests_paid_to_authors
= 0; ///< Ammount of VESS paid to authors  


<a id="Ditch.Golos.Objects.BucketObject.VestsPaidToCurators"></a>

* *Object* **VestsPaidToCurators**  
  API name: vests_paid_to_curators
= 0; ///< Ammount of VESTS paid to curators  


<a id="Ditch.Golos.Objects.BucketObject.LiquidityRewardsPaid"></a>

* *Object* **LiquidityRewardsPaid**  
  API name: liquidity_rewards_paid
= 0; ///< Ammount of STEEM paid to market makers  


<a id="Ditch.Golos.Objects.BucketObject.TransfersToVesting"></a>

* *UInt32* **TransfersToVesting**  
  API name: transfers_to_vesting
= 0; ///< Transfers of STEEM into VESTS  


<a id="Ditch.Golos.Objects.BucketObject.SteemVested"></a>

* *Object* **SteemVested**  
  API name: steem_vested
= 0; ///< Ammount of STEEM vested  


<a id="Ditch.Golos.Objects.BucketObject.NewVestingWithdrawalRequests"></a>

* *UInt32* **NewVestingWithdrawalRequests**  
  API name: new_vesting_withdrawal_requests
= 0; ///< New vesting withdrawal requests  


<a id="Ditch.Golos.Objects.BucketObject.ModifiedVestingWithdrawalRequests"></a>

* *UInt32* **ModifiedVestingWithdrawalRequests**  
  API name: modified_vesting_withdrawal_requests
= 0; ///< Changes to vesting withdrawal requests  


<a id="Ditch.Golos.Objects.BucketObject.VestingWithdrawRateDelta"></a>

* *Object* **VestingWithdrawRateDelta**  
  API name: vesting_withdraw_rate_delta
= 0;  


<a id="Ditch.Golos.Objects.BucketObject.VestingWithdrawalsProcessed"></a>

* *UInt32* **VestingWithdrawalsProcessed**  
  API name: vesting_withdrawals_processed
= 0; ///< Number of vesting withdrawals  


<a id="Ditch.Golos.Objects.BucketObject.FinishedVestingWithdrawals"></a>

* *UInt32* **FinishedVestingWithdrawals**  
  API name: finished_vesting_withdrawals
= 0; ///< Processed vesting withdrawals that are now finished  


<a id="Ditch.Golos.Objects.BucketObject.VestsWithdrawn"></a>

* *Object* **VestsWithdrawn**  
  API name: vests_withdrawn
= 0; ///< Ammount of VESTS withdrawn to STEEM  


<a id="Ditch.Golos.Objects.BucketObject.VestsTransferred"></a>

* *Object* **VestsTransferred**  
  API name: vests_transferred
= 0; ///< Ammount of VESTS transferred to another account  


<a id="Ditch.Golos.Objects.BucketObject.SbdConversionRequestsCreated"></a>

* *UInt32* **SbdConversionRequestsCreated**  
  API name: sbd_conversion_requests_created
= 0; ///< SBD conversion requests created  


<a id="Ditch.Golos.Objects.BucketObject.SbdToBeConverted"></a>

* *Object* **SbdToBeConverted**  
  API name: sbd_to_be_converted
= 0; ///< Amount of SBD to be converted  


<a id="Ditch.Golos.Objects.BucketObject.SbdConversionRequestsFilled"></a>

* *UInt32* **SbdConversionRequestsFilled**  
  API name: sbd_conversion_requests_filled
= 0; ///< SBD conversion requests filled  


<a id="Ditch.Golos.Objects.BucketObject.SteemConverted"></a>

* *Object* **SteemConverted**  
  API name: steem_converted
= 0; ///< Amount of STEEM that was converted  


<a id="Ditch.Golos.Objects.BucketObject.LimitOrdersCreated"></a>

* *UInt32* **LimitOrdersCreated**  
  API name: limit_orders_created
= 0; ///< Limit orders created  


<a id="Ditch.Golos.Objects.BucketObject.LimitOrdersFilled"></a>

* *UInt32* **LimitOrdersFilled**  
  API name: limit_orders_filled
= 0; ///< Limit orders filled  


<a id="Ditch.Golos.Objects.BucketObject.LimitOrdersCancelled"></a>

* *UInt32* **LimitOrdersCancelled**  
  API name: limit_orders_cancelled
= 0; ///< Limit orders cancelled  


<a id="Ditch.Golos.Objects.BucketObject.TotalPow"></a>

* *UInt32* **TotalPow**  
  API name: total_pow
= 0; ///< POW submitted  


<a id="Ditch.Golos.Objects.BucketObject.EstimatedHashpower"></a>

* *String* **EstimatedHashpower**  
  API name: estimated_hashpower
= 0; ///< Estimated average hashpower over interval  






---

<a id="Ditch.Golos.Objects.CallOrderObject"></a>
## CallOrderObject
*class Ditch.Golos.Objects.CallOrderObject*

call_order_object
libraries\chain\include\golos\chain\objects\market_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.CallOrderObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.CallOrderObject.OrderId"></a>

* *Object* **OrderId**  
  API name: order_id  


<a id="Ditch.Golos.Objects.CallOrderObject.Borrower"></a>

* *String* **Borrower**  
  API name: borrower  


<a id="Ditch.Golos.Objects.CallOrderObject.Collateral"></a>

* *Object* **Collateral**  
  API name: collateral
call_price.base.asset_id, access via get_collateral  


<a id="Ditch.Golos.Objects.CallOrderObject.Debt"></a>

* *Object* **Debt**  
  API name: debt
call_price.quote.asset_id, access via get_collateral  


<a id="Ditch.Golos.Objects.CallOrderObject.CallPrice"></a>

* *Price* **CallPrice**  
  API name: call_price
Debt / Collateral  






---

<a id="Ditch.Golos.Objects.CategoryApiObj"></a>
## CategoryApiObj
*class Ditch.Golos.Objects.CategoryApiObj*

category_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.CategoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.CategoryApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Golos.Objects.CategoryApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Golos.Objects.CategoryApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Golos.Objects.CategoryApiObj.Discussions"></a>

* *UInt32* **Discussions**  


<a id="Ditch.Golos.Objects.CategoryApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  






---

<a id="Ditch.Golos.Objects.ChainProperties"></a>
## ChainProperties
*class Ditch.Golos.Objects.ChainProperties*

chain_properties
golos-0.16.3\libraries\protocol\include\steemit\protocol\steem_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.ChainProperties.AccountCreationFee"></a>

* *Money* **AccountCreationFee**  
  This fee, paid in STEEM, is converted into VESTING SHARES for the new account.Accounts 
without vesting shares cannot earn usage rations and therefore are powerless.This minimum 
fee requires all accounts to have some kind of commitment to the network that includes the
 ability to vote and make transactions.  


<a id="Ditch.Golos.Objects.ChainProperties.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  
  This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity  


<a id="Ditch.Golos.Objects.ChainProperties.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  






---

<a id="Ditch.Golos.Objects.CollateralBidObject"></a>
## CollateralBidObject
*class Ditch.Golos.Objects.CollateralBidObject*

collateral_bid_object
libraries\chain\include\golos\chain\objects\market_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.CollateralBidObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.CollateralBidObject.Bidder"></a>

* *String* **Bidder**  
  API name: bidder  


<a id="Ditch.Golos.Objects.CollateralBidObject.InvSwanPrice"></a>

* *Price* **InvSwanPrice**  
  API name: inv_swan_price
Collateral / Debt  






---

<a id="Ditch.Golos.Objects.CommentApiObj"></a>
## CommentApiObj
*class Ditch.Golos.Objects.CommentApiObj*

comment_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.CommentApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Golos.Objects.CommentApiObj.Category"></a>

* *String* **Category**  


<a id="Ditch.Golos.Objects.CommentApiObj.ParentAuthor"></a>

* *String* **ParentAuthor**  


<a id="Ditch.Golos.Objects.CommentApiObj.ParentPermlink"></a>

* *String* **ParentPermlink**  


<a id="Ditch.Golos.Objects.CommentApiObj.Author"></a>

* *String* **Author**  


<a id="Ditch.Golos.Objects.CommentApiObj.Permlink"></a>

* *String* **Permlink**  


<a id="Ditch.Golos.Objects.CommentApiObj.Title"></a>

* *String* **Title**  


<a id="Ditch.Golos.Objects.CommentApiObj.Body"></a>

* *String* **Body**  


<a id="Ditch.Golos.Objects.CommentApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Golos.Objects.CommentApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  


<a id="Ditch.Golos.Objects.CommentApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Golos.Objects.CommentApiObj.Active"></a>

* *DateTime* **Active**  


<a id="Ditch.Golos.Objects.CommentApiObj.LastPayout"></a>

* *DateTime* **LastPayout**  


<a id="Ditch.Golos.Objects.CommentApiObj.Depth"></a>

* *Byte* **Depth**  


<a id="Ditch.Golos.Objects.CommentApiObj.Children"></a>

* *UInt32* **Children**  


<a id="Ditch.Golos.Objects.CommentApiObj.ChildrenRshares2"></a>

* *String* **ChildrenRshares2**  


<a id="Ditch.Golos.Objects.CommentApiObj.NetRshares"></a>

* *Object* **NetRshares**  


<a id="Ditch.Golos.Objects.CommentApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Golos.Objects.CommentApiObj.VoteRshares"></a>

* *Object* **VoteRshares**  


<a id="Ditch.Golos.Objects.CommentApiObj.ChildrenAbsRshares"></a>

* *Object* **ChildrenAbsRshares**  


<a id="Ditch.Golos.Objects.CommentApiObj.CashoutTime"></a>

* *DateTime* **CashoutTime**  


<a id="Ditch.Golos.Objects.CommentApiObj.MaxCashoutTime"></a>

* *DateTime* **MaxCashoutTime**  


<a id="Ditch.Golos.Objects.CommentApiObj.TotalVoteWeight"></a>

* *UInt64* **TotalVoteWeight**  


<a id="Ditch.Golos.Objects.CommentApiObj.RewardWeight"></a>

* *UInt16* **RewardWeight**  


<a id="Ditch.Golos.Objects.CommentApiObj.TotalPayoutValue"></a>

* *Money* **TotalPayoutValue**  


<a id="Ditch.Golos.Objects.CommentApiObj.CuratorPayoutValue"></a>

* *Money* **CuratorPayoutValue**  


<a id="Ditch.Golos.Objects.CommentApiObj.AuthorRewards"></a>

* *Object* **AuthorRewards**  


<a id="Ditch.Golos.Objects.CommentApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Golos.Objects.CommentApiObj.RootComment"></a>

* *UInt64* **RootComment**  


<a id="Ditch.Golos.Objects.CommentApiObj.Mode"></a>

* *CommentMode* **Mode**  


<a id="Ditch.Golos.Objects.CommentApiObj.MaxAcceptedPayout"></a>

* *Money* **MaxAcceptedPayout**  


<a id="Ditch.Golos.Objects.CommentApiObj.PercentSteemDollars"></a>

* *UInt16* **PercentSteemDollars**  


<a id="Ditch.Golos.Objects.CommentApiObj.AllowReplies"></a>

* *Boolean* **AllowReplies**  


<a id="Ditch.Golos.Objects.CommentApiObj.AllowVotes"></a>

* *Boolean* **AllowVotes**  


<a id="Ditch.Golos.Objects.CommentApiObj.AllowCurationRewards"></a>

* *Boolean* **AllowCurationRewards**  


<a id="Ditch.Golos.Objects.CommentApiObj.Beneficiaries"></a>

* *Object[]* **Beneficiaries**  






---

<a id="Ditch.Golos.Objects.CommentApiObject"></a>
## CommentApiObject
*class Ditch.Golos.Objects.CommentApiObject*

comment_api_object
libraries\application\include\golos\application\api_objects\comment_api_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.CommentApiObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.CommentApiObject.Category"></a>

* *String* **Category**  
  API name: category  


<a id="Ditch.Golos.Objects.CommentApiObject.ParentAuthor"></a>

* *String* **ParentAuthor**  
  API name: parent_author  


<a id="Ditch.Golos.Objects.CommentApiObject.ParentPermlink"></a>

* *String* **ParentPermlink**  
  API name: parent_permlink  


<a id="Ditch.Golos.Objects.CommentApiObject.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Objects.CommentApiObject.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Golos.Objects.CommentApiObject.Title"></a>

* *String* **Title**  
  API name: title  


<a id="Ditch.Golos.Objects.CommentApiObject.Body"></a>

* *String* **Body**  
  API name: body  


<a id="Ditch.Golos.Objects.CommentApiObject.JsonMetadata"></a>

* *String* **JsonMetadata**  
  API name: json_metadata  


<a id="Ditch.Golos.Objects.CommentApiObject.LastUpdate"></a>

* *DateTime* **LastUpdate**  
  API name: last_update  


<a id="Ditch.Golos.Objects.CommentApiObject.Created"></a>

* *DateTime* **Created**  
  API name: created  


<a id="Ditch.Golos.Objects.CommentApiObject.Active"></a>

* *DateTime* **Active**  
  API name: active  


<a id="Ditch.Golos.Objects.CommentApiObject.LastPayout"></a>

* *DateTime* **LastPayout**  
  API name: last_payout  


<a id="Ditch.Golos.Objects.CommentApiObject.Depth"></a>

* *Byte* **Depth**  
  API name: depth  


<a id="Ditch.Golos.Objects.CommentApiObject.Children"></a>

* *UInt32* **Children**  
  API name: children  


<a id="Ditch.Golos.Objects.CommentApiObject.ChildrenRshares2"></a>

* *String* **ChildrenRshares2**  
  API name: children_rshares2  


<a id="Ditch.Golos.Objects.CommentApiObject.NetRshares"></a>

* *Object* **NetRshares**  
  API name: net_rshares  


<a id="Ditch.Golos.Objects.CommentApiObject.AbsRshares"></a>

* *Object* **AbsRshares**  
  API name: abs_rshares  


<a id="Ditch.Golos.Objects.CommentApiObject.VoteRshares"></a>

* *Object* **VoteRshares**  
  API name: vote_rshares  


<a id="Ditch.Golos.Objects.CommentApiObject.ChildrenAbsRshares"></a>

* *Object* **ChildrenAbsRshares**  
  API name: children_abs_rshares  


<a id="Ditch.Golos.Objects.CommentApiObject.CashoutTime"></a>

* *DateTime* **CashoutTime**  
  API name: cashout_time  


<a id="Ditch.Golos.Objects.CommentApiObject.MaxCashoutTime"></a>

* *DateTime* **MaxCashoutTime**  
  API name: max_cashout_time  


<a id="Ditch.Golos.Objects.CommentApiObject.TotalVoteWeight"></a>

* *UInt64* **TotalVoteWeight**  
  API name: total_vote_weight  


<a id="Ditch.Golos.Objects.CommentApiObject.RewardWeight"></a>

* *UInt16* **RewardWeight**  
  API name: reward_weight  


<a id="Ditch.Golos.Objects.CommentApiObject.TotalPayoutValue"></a>

* *Money* **TotalPayoutValue**  
  API name: total_payout_value  


<a id="Ditch.Golos.Objects.CommentApiObject.CuratorPayoutValue"></a>

* *Money* **CuratorPayoutValue**  
  API name: curator_payout_value  


<a id="Ditch.Golos.Objects.CommentApiObject.AuthorRewards"></a>

* *Object* **AuthorRewards**  
  API name: author_rewards  


<a id="Ditch.Golos.Objects.CommentApiObject.NetVotes"></a>

* *Int32* **NetVotes**  
  API name: net_votes  


<a id="Ditch.Golos.Objects.CommentApiObject.RootComment"></a>

* *Object* **RootComment**  
  API name: root_comment  


<a id="Ditch.Golos.Objects.CommentApiObject.MaxAcceptedPayout"></a>

* *Money* **MaxAcceptedPayout**  
  API name: max_accepted_payout  


<a id="Ditch.Golos.Objects.CommentApiObject.PercentSteemDollars"></a>

* *UInt16* **PercentSteemDollars**  
  API name: percent_steem_dollars  


<a id="Ditch.Golos.Objects.CommentApiObject.AllowReplies"></a>

* *Boolean* **AllowReplies**  
  API name: allow_replies  


<a id="Ditch.Golos.Objects.CommentApiObject.AllowVotes"></a>

* *Boolean* **AllowVotes**  
  API name: allow_votes  


<a id="Ditch.Golos.Objects.CommentApiObject.AllowCurationRewards"></a>

* *Boolean* **AllowCurationRewards**  
  API name: allow_curation_rewards  


<a id="Ditch.Golos.Objects.CommentApiObject.Beneficiaries"></a>

* *BeneficiaryRouteType[]* **Beneficiaries**  
  API name: beneficiaries  






---

<a id="Ditch.Golos.Objects.CommentBlogEntry"></a>
## CommentBlogEntry
*class Ditch.Golos.Objects.CommentBlogEntry*

comment_blog_entry
libraries\plugins\follow\include\golos\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.CommentBlogEntry.Comment"></a>

* *CommentApiObject* **Comment**  
  API name: comment  


<a id="Ditch.Golos.Objects.CommentBlogEntry.Blog"></a>

* *String* **Blog**  
  API name: blog  


<a id="Ditch.Golos.Objects.CommentBlogEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Golos.Objects.CommentBlogEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Golos.Objects.CommentFeedEntry"></a>
## CommentFeedEntry
*class Ditch.Golos.Objects.CommentFeedEntry*

comment_feed_entry
libraries\plugins\follow\include\golos\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.CommentFeedEntry.Comment"></a>

* *CommentApiObject* **Comment**  
  API name: comment  


<a id="Ditch.Golos.Objects.CommentFeedEntry.ReblogBy"></a>

* *String[]* **ReblogBy**  
  API name: reblog_by  


<a id="Ditch.Golos.Objects.CommentFeedEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Golos.Objects.CommentFeedEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Golos.Objects.ConvertRequestApiObj"></a>
## ConvertRequestApiObj
*class Ditch.Golos.Objects.ConvertRequestApiObj: Ditch.Golos.Objects.ConvertRequestObject*

convert_request_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Golos.Objects.ConvertRequestObject"></a>
## ConvertRequestObject
*class Ditch.Golos.Objects.ConvertRequestObject*

convert_request_object
golos-0.16.3\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.ConvertRequestObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.ConvertRequestObject.Owner"></a>

* *Object* **Owner**  


<a id="Ditch.Golos.Objects.ConvertRequestObject.Requestid"></a>

* *UInt32* **Requestid**  
  id set by owner,the owner,requestid pair must be unique  


<a id="Ditch.Golos.Objects.ConvertRequestObject.Amount"></a>

* *Money* **Amount**  






---

<a id="Ditch.Golos.Objects.Discussion"></a>
## Discussion
*class Ditch.Golos.Objects.Discussion: Ditch.Golos.Objects.CommentApiObj*

discussion
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.Discussion.Url"></a>

* *String* **Url**  
  /category/@rootauthor/root_permlink#author/permlink  


<a id="Ditch.Golos.Objects.Discussion.RootTitle"></a>

* *String* **RootTitle**  


<a id="Ditch.Golos.Objects.Discussion.PendingPayoutValue"></a>

* *Money* **PendingPayoutValue**  
  sbd  


<a id="Ditch.Golos.Objects.Discussion.TotalPendingPayoutValue"></a>

* *Money* **TotalPendingPayoutValue**  
  sbd including replies  


<a id="Ditch.Golos.Objects.Discussion.ActiveVotes"></a>

* *VoteState[]* **ActiveVotes**  


<a id="Ditch.Golos.Objects.Discussion.Replies"></a>

* *String[]* **Replies**  
  author/slug mapping  


<a id="Ditch.Golos.Objects.Discussion.AuthorReputation"></a>

* *Object* **AuthorReputation**  


<a id="Ditch.Golos.Objects.Discussion.Promoted"></a>

* *Money* **Promoted**  


<a id="Ditch.Golos.Objects.Discussion.BodyLength"></a>

* *UInt32* **BodyLength**  


<a id="Ditch.Golos.Objects.Discussion.RebloggedBy"></a>

* *String[]* **RebloggedBy**  


<a id="Ditch.Golos.Objects.Discussion.FirstRebloggedBy"></a>

* *Object* **FirstRebloggedBy**  


<a id="Ditch.Golos.Objects.Discussion.FirstRebloggedOn"></a>

* *Object* **FirstRebloggedOn**  






---

<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject"></a>
## DynamicGlobalPropertyObject
*class Ditch.Golos.Objects.DynamicGlobalPropertyObject*

dynamic_global_property_object
libraries\chain\include\golos\chain\objects\global_property_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.Id"></a>

* *String* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.HeadBlockNumber"></a>

* *UInt32* **HeadBlockNumber**  
  API name: head_block_number
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.HeadBlockId"></a>

* *String* **HeadBlockId**  
  API name: head_block_id  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.Time"></a>

* *DateTime* **Time**  
  API name: time  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.CurrentWitness"></a>

* *String* **CurrentWitness**  
  API name: current_witness  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.TotalPow"></a>

* *UInt64* **TotalPow**  
  API name: total_pow
= -1;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.NumPowWitnesses"></a>

* *UInt32* **NumPowWitnesses**  
  API name: num_pow_witnesses
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.VirtualSupply"></a>

* *Money* **VirtualSupply**  
  API name: virtual_supply
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.CurrentSupply"></a>

* *Money* **CurrentSupply**  
  API name: current_supply
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.ConfidentialSupply"></a>

* *Money* **ConfidentialSupply**  
  API name: confidential_supply
= asset<0,17,0>(0, STEEM_SYMBOL_NAME); ///< total asset held in confidential balances  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.CurrentSbdSupply"></a>

* *Money* **CurrentSbdSupply**  
  API name: current_sbd_supply
= asset<0,17,0>(0, SBD_SYMBOL_NAME);  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.ConfidentialSbdSupply"></a>

* *Money* **ConfidentialSbdSupply**  
  API name: confidential_sbd_supply
= asset<0,17,0>(0, SBD_SYMBOL_NAME); ///< total asset held in confidential balances  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.TotalVestingFundSteem"></a>

* *Money* **TotalVestingFundSteem**  
  API name: total_vesting_fund_steem
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.TotalVestingShares"></a>

* *Money* **TotalVestingShares**  
  API name: total_vesting_shares
= asset<0,17,0>(0, VESTS_SYMBOL);  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.TotalRewardFundSteem"></a>

* *Money* **TotalRewardFundSteem**  
  API name: total_reward_fund_steem
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.TotalRewardShares2"></a>

* *String* **TotalRewardShares2**  
  API name: total_reward_shares2
the running total of REWARD^2  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  
  API name: sbd_interest_rate
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.SbdPrintRate"></a>

* *UInt16* **SbdPrintRate**  
  API name: sbd_print_rate
= STEEMIT_100_PERCENT;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.AverageBlockSize"></a>

* *UInt32* **AverageBlockSize**  
  API name: average_block_size
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  
  API name: maximum_block_size
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.CurrentAslot"></a>

* *UInt64* **CurrentAslot**  
  API name: current_aslot
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.RecentSlotsFilled"></a>

* *String* **RecentSlotsFilled**  
  API name: recent_slots_filled  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.ParticipationCount"></a>

* *Byte* **ParticipationCount**  
  API name: participation_count
= 0; ///< Divide by 128 to compute participation percentage  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.LastIrreversibleBlockNum"></a>

* *UInt32* **LastIrreversibleBlockNum**  
  API name: last_irreversible_block_num
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.MaxVirtualBandwidth"></a>

* *UInt64* **MaxVirtualBandwidth**  
  API name: max_virtual_bandwidth
= 0;  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.CurrentReserveRatio"></a>

* *UInt64* **CurrentReserveRatio**  


<a id="Ditch.Golos.Objects.DynamicGlobalPropertyObject.VoteRegenerationPerDay"></a>

* *UInt32* **VoteRegenerationPerDay**  
  API name: vote_regeneration_per_day
= 40;  






---

<a id="Ditch.Golos.Objects.EscrowApiObj"></a>
## EscrowApiObj
*class Ditch.Golos.Objects.EscrowApiObj: Ditch.Golos.Objects.EscrowObject*

escrow_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Golos.Objects.EscrowObject"></a>
## EscrowObject
*class Ditch.Golos.Objects.EscrowObject*

escrow_object
golos-0.16.3\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.EscrowObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.EscrowObject.EscrowId"></a>

* *UInt32* **EscrowId**  


<a id="Ditch.Golos.Objects.EscrowObject.From"></a>

* *String* **From**  


<a id="Ditch.Golos.Objects.EscrowObject.To"></a>

* *String* **To**  


<a id="Ditch.Golos.Objects.EscrowObject.Agent"></a>

* *String* **Agent**  


<a id="Ditch.Golos.Objects.EscrowObject.RatificationDeadline"></a>

* *DateTime* **RatificationDeadline**  


<a id="Ditch.Golos.Objects.EscrowObject.EscrowExpiration"></a>

* *DateTime* **EscrowExpiration**  


<a id="Ditch.Golos.Objects.EscrowObject.SbdBalance"></a>

* *Money* **SbdBalance**  


<a id="Ditch.Golos.Objects.EscrowObject.SteemBalance"></a>

* *Money* **SteemBalance**  


<a id="Ditch.Golos.Objects.EscrowObject.PendingFee"></a>

* *Money* **PendingFee**  


<a id="Ditch.Golos.Objects.EscrowObject.ToApproved"></a>

* *Boolean* **ToApproved**  


<a id="Ditch.Golos.Objects.EscrowObject.AgentApproved"></a>

* *Boolean* **AgentApproved**  


<a id="Ditch.Golos.Objects.EscrowObject.Disputed"></a>

* *Boolean* **Disputed**  






---

<a id="Ditch.Golos.Objects.ExtendedAccount"></a>
## ExtendedAccount
*class Ditch.Golos.Objects.ExtendedAccount: Ditch.Golos.Objects.AccountApiObj*

extended_account 
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.ExtendedAccount.VestingBalance"></a>

* *Money* **VestingBalance**  
  convert vesting_shares to vesting steem  


<a id="Ditch.Golos.Objects.ExtendedAccount.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Golos.Objects.ExtendedAccount.TransferHistory"></a>

* *Object* **TransferHistory**  
  transfer to/from vesting  


<a id="Ditch.Golos.Objects.ExtendedAccount.MarketHistory"></a>

* *Object* **MarketHistory**  
  limit order / cancel / fill  


<a id="Ditch.Golos.Objects.ExtendedAccount.PostHistory"></a>

* *Object* **PostHistory**  


<a id="Ditch.Golos.Objects.ExtendedAccount.VoteHistory"></a>

* *Object* **VoteHistory**  


<a id="Ditch.Golos.Objects.ExtendedAccount.OtherHistory"></a>

* *Object* **OtherHistory**  


<a id="Ditch.Golos.Objects.ExtendedAccount.WitnessVotes"></a>

* *String[]* **WitnessVotes**  


<a id="Ditch.Golos.Objects.ExtendedAccount.TagsUsage"></a>

* *KeyValuePair`2[]* **TagsUsage**  


<a id="Ditch.Golos.Objects.ExtendedAccount.GuestBloggers"></a>

* *KeyValuePair`2[]* **GuestBloggers**  


<a id="Ditch.Golos.Objects.ExtendedAccount.OpenOrders"></a>

* *Object* **OpenOrders**  


<a id="Ditch.Golos.Objects.ExtendedAccount.Comments"></a>

* *String[]* **Comments**  
  permlinks for this user  


<a id="Ditch.Golos.Objects.ExtendedAccount.Blog"></a>

* *String[]* **Blog**  
  blog posts for this user  


<a id="Ditch.Golos.Objects.ExtendedAccount.Feed"></a>

* *String[]* **Feed**  
  feed posts for this user  


<a id="Ditch.Golos.Objects.ExtendedAccount.RecentReplies"></a>

* *String[]* **RecentReplies**  
  blog posts for this user  


<a id="Ditch.Golos.Objects.ExtendedAccount.BlogCategory"></a>

* *Object* **BlogCategory**  
  blog posts for this user  


<a id="Ditch.Golos.Objects.ExtendedAccount.Recommended"></a>

* *String[]* **Recommended**  
  posts recommened for this user  






---

<a id="Ditch.Golos.Objects.ExtendedLimitOrder"></a>
## ExtendedLimitOrder
*class Ditch.Golos.Objects.ExtendedLimitOrder*

extended_limit_order
libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.ExtendedLimitOrder.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
= 0;  


<a id="Ditch.Golos.Objects.ExtendedLimitOrder.Rewarded"></a>

* *Boolean* **Rewarded**  
  API name: rewarded
= false;  






---

<a id="Ditch.Golos.Objects.FeedEntry"></a>
## FeedEntry
*class Ditch.Golos.Objects.FeedEntry*

feed_entry
libraries\plugins\follow\include\golos\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.FeedEntry.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Objects.FeedEntry.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Golos.Objects.FeedEntry.ReblogBy"></a>

* *String[]* **ReblogBy**  
  API name: reblog_by  


<a id="Ditch.Golos.Objects.FeedEntry.ReblogOn"></a>

* *DateTime* **ReblogOn**  
  API name: reblog_on  


<a id="Ditch.Golos.Objects.FeedEntry.EntryId"></a>

* *UInt32* **EntryId**  
  API name: entry_id
= 0;  






---

<a id="Ditch.Golos.Objects.FeedHistoryApiObj"></a>
## FeedHistoryApiObj
*class Ditch.Golos.Objects.FeedHistoryApiObj*

feed_history_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.FeedHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.FeedHistoryApiObj.CurrentMedianHistory"></a>

* *Price* **CurrentMedianHistory**  


<a id="Ditch.Golos.Objects.FeedHistoryApiObj.PriceHistory"></a>

* *Price[]* **PriceHistory**  






---

<a id="Ditch.Golos.Objects.FollowApiObj"></a>
## FollowApiObj
*class Ditch.Golos.Objects.FollowApiObj*

follow_api_obj
golos-0.16.3\libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.FollowApiObj.Follower"></a>

* *String* **Follower**  


<a id="Ditch.Golos.Objects.FollowApiObj.Following"></a>

* *String* **Following**  


<a id="Ditch.Golos.Objects.FollowApiObj.What"></a>

* *FollowType[]* **What**  






---

<a id="Ditch.Golos.Objects.FollowCountApiObj"></a>
## FollowCountApiObj
*class Ditch.Golos.Objects.FollowCountApiObj*

follow_count_api_obj
libraries\plugins\follow\include\golos\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.FollowCountApiObj.Account"></a>

* *String* **Account**  
  API name: account  


<a id="Ditch.Golos.Objects.FollowCountApiObj.FollowerCount"></a>

* *UInt32* **FollowerCount**  
  API name: follower_count
= 0;  


<a id="Ditch.Golos.Objects.FollowCountApiObj.FollowingCount"></a>

* *UInt32* **FollowingCount**  
  API name: following_count
= 0;  






---

<a id="Ditch.Golos.Objects.ForceSettlementObject"></a>
## ForceSettlementObject
*class Ditch.Golos.Objects.ForceSettlementObject*

force_settlement_object
libraries\chain\include\golos\chain\objects\market_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.ForceSettlementObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.ForceSettlementObject.Owner"></a>

* *String* **Owner**  
  API name: owner  


<a id="Ditch.Golos.Objects.ForceSettlementObject.SettlementId"></a>

* *Object* **SettlementId**  
  API name: settlement_id  


<a id="Ditch.Golos.Objects.ForceSettlementObject.Balance"></a>

* *Money* **Balance**  
  API name: balance  


<a id="Ditch.Golos.Objects.ForceSettlementObject.SettlementDate"></a>

* *DateTime* **SettlementDate**  
  API name: settlement_date  






---

<a id="Ditch.Golos.Objects.HistoryKey"></a>
## HistoryKey
*class Ditch.Golos.Objects.HistoryKey*

history_key
libraries\plugins\market_history\include\golos\market_history\order_history_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.HistoryKey.Sequence"></a>

* *Int64* **Sequence**  
  API name: sequence
= 0;  






---

<a id="Ditch.Golos.Objects.LimitOrderObject"></a>
## LimitOrderObject
*class Ditch.Golos.Objects.LimitOrderObject*

limit_order_object
libraries\chain\include\golos\chain\objects\market_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.LimitOrderObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.LimitOrderObject.Created"></a>

* *DateTime* **Created**  
  API name: created  


<a id="Ditch.Golos.Objects.LimitOrderObject.Expiration"></a>

* *DateTime* **Expiration**  
  API name: expiration  


<a id="Ditch.Golos.Objects.LimitOrderObject.Seller"></a>

* *String* **Seller**  
  API name: seller  


<a id="Ditch.Golos.Objects.LimitOrderObject.OrderId"></a>

* *Object* **OrderId**  
  API name: order_id
= 0;  


<a id="Ditch.Golos.Objects.LimitOrderObject.ForSale"></a>

* *Object* **ForSale**  
  API name: for_sale
asset id is sell_price.base.symbol  


<a id="Ditch.Golos.Objects.LimitOrderObject.SellPrice"></a>

* *Price* **SellPrice**  
  API name: sell_price  


<a id="Ditch.Golos.Objects.LimitOrderObject.DeferredFee"></a>

* *Object* **DeferredFee**  
  API name: deferred_fee  






---

<a id="Ditch.Golos.Objects.MarketTicker"></a>
## MarketTicker
*class Ditch.Golos.Objects.MarketTicker*

market_ticker
libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.MarketTicker.Base"></a>

* *String* **Base**  
  API name: base  


<a id="Ditch.Golos.Objects.MarketTicker.Quote"></a>

* *String* **Quote**  
  API name: quote  


<a id="Ditch.Golos.Objects.MarketTicker.Latest"></a>

* *Double* **Latest**  
  API name: latest  


<a id="Ditch.Golos.Objects.MarketTicker.LowestAsk"></a>

* *Double* **LowestAsk**  
  API name: lowest_ask  


<a id="Ditch.Golos.Objects.MarketTicker.HighestBid"></a>

* *Double* **HighestBid**  
  API name: highest_bid  


<a id="Ditch.Golos.Objects.MarketTicker.PercentChange"></a>

* *Double* **PercentChange**  
  API name: percent_change  


<a id="Ditch.Golos.Objects.MarketTicker.BaseVolume"></a>

* *Double* **BaseVolume**  
  API name: base_volume  


<a id="Ditch.Golos.Objects.MarketTicker.QuoteVolume"></a>

* *Double* **QuoteVolume**  
  API name: quote_volume  






---

<a id="Ditch.Golos.Objects.MarketTrade"></a>
## MarketTrade
*class Ditch.Golos.Objects.MarketTrade*

market_trade
libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.MarketTrade.Date"></a>

* *DateTime* **Date**  
  API name: date  


<a id="Ditch.Golos.Objects.MarketTrade.Price"></a>

* *Double* **Price**  
  API name: price  


<a id="Ditch.Golos.Objects.MarketTrade.Amount"></a>

* *Double* **Amount**  
  API name: amount  


<a id="Ditch.Golos.Objects.MarketTrade.Value"></a>

* *Double* **Value**  
  API name: value  


<a id="Ditch.Golos.Objects.MarketTrade.Side1AccountName"></a>

* *String* **Side1AccountName**  
  API name: side1_account_name  


<a id="Ditch.Golos.Objects.MarketTrade.Side2AccountName"></a>

* *String* **Side2AccountName**  
  API name: side2_account_name  






---

<a id="Ditch.Golos.Objects.MarketVolume"></a>
## MarketVolume
*class Ditch.Golos.Objects.MarketVolume*

market_volume
libraries\plugins\market_history\include\golos\market_history\market_history_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.MarketVolume.Base"></a>

* *String* **Base**  
  API name: base  


<a id="Ditch.Golos.Objects.MarketVolume.Quote"></a>

* *String* **Quote**  
  API name: quote  


<a id="Ditch.Golos.Objects.MarketVolume.BaseVolume"></a>

* *Double* **BaseVolume**  
  API name: base_volume  


<a id="Ditch.Golos.Objects.MarketVolume.QuoteVolume"></a>

* *Double* **QuoteVolume**  
  API name: quote_volume  






---

<a id="Ditch.Golos.Objects.Order"></a>
## Order
*class Ditch.Golos.Objects.Order*

order
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.Order.OrderPrice"></a>

* *Price* **OrderPrice**  
  API name: order_price  


<a id="Ditch.Golos.Objects.Order.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
dollars per steem  


<a id="Ditch.Golos.Objects.Order.Steem"></a>

* *Object* **Steem**  
  API name: steem  


<a id="Ditch.Golos.Objects.Order.Sbd"></a>

* *Object* **Sbd**  
  API name: sbd  


<a id="Ditch.Golos.Objects.Order.Created"></a>

* *DateTime* **Created**  
  API name: created  






---

<a id="Ditch.Golos.Objects.OrderBook"></a>
## OrderBook
*class Ditch.Golos.Objects.OrderBook*

order_book
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.OrderBook.Asks"></a>

* *Order[]* **Asks**  
  API name: asks  


<a id="Ditch.Golos.Objects.OrderBook.Bids"></a>

* *Order[]* **Bids**  
  API name: bids  






---

<a id="Ditch.Golos.Objects.OrderHistoryObject"></a>
## OrderHistoryObject
*class Ditch.Golos.Objects.OrderHistoryObject*

order_history_object
libraries\plugins\market_history\include\golos\market_history\order_history_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.OrderHistoryObject.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.OrderHistoryObject.Key"></a>

* *HistoryKey* **Key**  
  API name: key  


<a id="Ditch.Golos.Objects.OrderHistoryObject.Time"></a>

* *DateTime* **Time**  
  API name: time  


<a id="Ditch.Golos.Objects.OrderHistoryObject.Op"></a>

* *Object* **Op**  
  API name: op  






---

<a id="Ditch.Golos.Objects.OwnerAuthorityHistoryApiObj"></a>
## OwnerAuthorityHistoryApiObj
*class Ditch.Golos.Objects.OwnerAuthorityHistoryApiObj*

owner_authority_history_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.OwnerAuthorityHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.OwnerAuthorityHistoryApiObj.Account"></a>

* *String* **Account**  


<a id="Ditch.Golos.Objects.OwnerAuthorityHistoryApiObj.PreviousOwnerAuthority"></a>

* *Authority* **PreviousOwnerAuthority**  


<a id="Ditch.Golos.Objects.OwnerAuthorityHistoryApiObj.LastValidTime"></a>

* *DateTime* **LastValidTime**  






---

<a id="Ditch.Golos.Objects.Price"></a>
## Price
*class Ditch.Golos.Objects.Price*

price
golos-0.16.3\libraries\protocol\include\steemit\protocol\asset.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.Price.Base"></a>

* *Money* **Base**  


<a id="Ditch.Golos.Objects.Price.Quote"></a>

* *Money* **Quote**  






---

<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj"></a>
## SavingsWithdrawApiObj
*class Ditch.Golos.Objects.SavingsWithdrawApiObj*

savings_withdraw_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj.From"></a>

* *String* **From**  
  API name: from  


<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj.To"></a>

* *String* **To**  
  API name: to  


<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj.Memo"></a>

* *String* **Memo**  
  API name: memo  


<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj.RequestId"></a>

* *UInt32* **RequestId**  
  API name: request_id
= 0;  


<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj.Amount"></a>

* *Money* **Amount**  
  API name: amount  


<a id="Ditch.Golos.Objects.SavingsWithdrawApiObj.Complete"></a>

* *DateTime* **Complete**  
  API name: complete  






---

<a id="Ditch.Golos.Objects.ScheduledHardfork"></a>
## ScheduledHardfork
*class Ditch.Golos.Objects.ScheduledHardfork*

scheduled_hardfork
golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.ScheduledHardfork.HfVersion"></a>

* *String* **HfVersion**  


<a id="Ditch.Golos.Objects.ScheduledHardfork.LiveTime"></a>

* *DateTime* **LiveTime**  






---

<a id="Ditch.Golos.Objects.SignedBlock"></a>
## SignedBlock
*class Ditch.Golos.Objects.SignedBlock: Ditch.Golos.Objects.SignedBlockHeader*

signed_block
golos-0.16.3\libraries\protocol\include\steemit\protocol\block.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.SignedBlock.Transactions"></a>

* *Object[]* **Transactions**  






---

<a id="Ditch.Golos.Objects.SignedBlockApiObj"></a>
## SignedBlockApiObj
*class Ditch.Golos.Objects.SignedBlockApiObj: Ditch.Golos.Objects.SignedBlock*

signed_block_api_obj
golos-0.16.3\libraries\protocol\include\steemit\protocol\block.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.SignedBlockApiObj.BlockId"></a>

* *Object* **BlockId**  


<a id="Ditch.Golos.Objects.SignedBlockApiObj.SigningKey"></a>

* *String* **SigningKey**  


<a id="Ditch.Golos.Objects.SignedBlockApiObj.TransactionIds"></a>

* *Object[]* **TransactionIds**  






---

<a id="Ditch.Golos.Objects.SignedBlockHeader"></a>
## SignedBlockHeader
*class Ditch.Golos.Objects.SignedBlockHeader: Ditch.Golos.Objects.BlockHeader*

signed_block_header
golos-0.16.3\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.SignedBlockHeader.WitnessSignature"></a>

* *Object* **WitnessSignature**  






---

<a id="Ditch.Golos.Objects.State"></a>
## State
*class Ditch.Golos.Objects.State*

state
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.State.CurrentRoute"></a>

* *String* **CurrentRoute**  


<a id="Ditch.Golos.Objects.State.Props"></a>

* *DynamicGlobalPropertyObject* **Props**  


<a id="Ditch.Golos.Objects.State.CategoryIdx"></a>

* *Object* **CategoryIdx**  


<a id="Ditch.Golos.Objects.State.TagIdx"></a>

* *Object* **TagIdx**  


<a id="Ditch.Golos.Objects.State.DiscussionIdx"></a>

* *Object* **DiscussionIdx**  
  is the global discussion index  


<a id="Ditch.Golos.Objects.State.Categories"></a>

* *Object* **Categories**  


<a id="Ditch.Golos.Objects.State.Tags"></a>

* *Object* **Tags**  


<a id="Ditch.Golos.Objects.State.Content"></a>

* *Object* **Content**  
  map from account/slug to full nested discussion  


<a id="Ditch.Golos.Objects.State.Accounts"></a>

* *Object* **Accounts**  


<a id="Ditch.Golos.Objects.State.PowQueue"></a>

* *String[]* **PowQueue**  
  The list of miners who are queued to produce work  


<a id="Ditch.Golos.Objects.State.Witnesses"></a>

* *Object* **Witnesses**  


<a id="Ditch.Golos.Objects.State.WitnessSchedule"></a>

* *WitnessScheduleApiObj* **WitnessSchedule**  


<a id="Ditch.Golos.Objects.State.FeedPrice"></a>

* *Price* **FeedPrice**  


<a id="Ditch.Golos.Objects.State.Error"></a>

* *String* **Error**  


<a id="Ditch.Golos.Objects.State.MarketData"></a>

* *Object* **MarketData**  






---

<a id="Ditch.Golos.Objects.SteemVersionInfo"></a>
## SteemVersionInfo
*class Ditch.Golos.Objects.SteemVersionInfo*

steem_version_info
libraries\application\include\golos\application\api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.SteemVersionInfo.BlockchainVersion"></a>

* *String* **BlockchainVersion**  
  API name: blockchain_version  


<a id="Ditch.Golos.Objects.SteemVersionInfo.SteemRevision"></a>

* *String* **SteemRevision**  
  API name: steem_revision  


<a id="Ditch.Golos.Objects.SteemVersionInfo.FcRevision"></a>

* *String* **FcRevision**  
  API name: fc_revision  






---

<a id="Ditch.Golos.Objects.TagApiObj"></a>
## TagApiObj
*class Ditch.Golos.Objects.TagApiObj*

tag_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.TagApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Golos.Objects.TagApiObj.TotalChildrenRshares2"></a>

* *String* **TotalChildrenRshares2**  


<a id="Ditch.Golos.Objects.TagApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Golos.Objects.TagApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Golos.Objects.TagApiObj.TopPosts"></a>

* *UInt32* **TopPosts**  


<a id="Ditch.Golos.Objects.TagApiObj.Comments"></a>

* *UInt32* **Comments**  


<a id="Ditch.Golos.Objects.TagApiObj.Trending"></a>

* *String* **Trending**  






---

<a id="Ditch.Golos.Objects.VoteState"></a>
## VoteState
*class Ditch.Golos.Objects.VoteState*

vote_state
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.VoteState.Voter"></a>

* *String* **Voter**  


<a id="Ditch.Golos.Objects.VoteState.Weight"></a>

* *UInt64* **Weight**  


<a id="Ditch.Golos.Objects.VoteState.Rshares"></a>

* *Int64* **Rshares**  


<a id="Ditch.Golos.Objects.VoteState.Percent"></a>

* *Int16* **Percent**  


<a id="Ditch.Golos.Objects.VoteState.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Golos.Objects.VoteState.Time"></a>

* *DateTime* **Time**  






---

<a id="Ditch.Golos.Objects.WithdrawRoute"></a>
## WithdrawRoute
*class Ditch.Golos.Objects.WithdrawRoute*

withdraw_route
golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.WithdrawRoute.FromAccount"></a>

* *String* **FromAccount**  


<a id="Ditch.Golos.Objects.WithdrawRoute.ToAccount"></a>

* *String* **ToAccount**  


<a id="Ditch.Golos.Objects.WithdrawRoute.Percent"></a>

* *UInt16* **Percent**  


<a id="Ditch.Golos.Objects.WithdrawRoute.AutoVest"></a>

* *Boolean* **AutoVest**  






---

<a id="Ditch.Golos.Objects.WitnessApiObj"></a>
## WitnessApiObj
*class Ditch.Golos.Objects.WitnessApiObj*

witness_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.WitnessApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Objects.WitnessApiObj.Owner"></a>

* *String* **Owner**  
  API name: owner  


<a id="Ditch.Golos.Objects.WitnessApiObj.Created"></a>

* *DateTime* **Created**  
  API name: created  


<a id="Ditch.Golos.Objects.WitnessApiObj.Url"></a>

* *String* **Url**  
  API name: url  


<a id="Ditch.Golos.Objects.WitnessApiObj.TotalMissed"></a>

* *UInt32* **TotalMissed**  
  API name: total_missed
= 0;  


<a id="Ditch.Golos.Objects.WitnessApiObj.LastAslot"></a>

* *UInt64* **LastAslot**  
  API name: last_aslot
= 0;  


<a id="Ditch.Golos.Objects.WitnessApiObj.LastConfirmedBlockNum"></a>

* *UInt64* **LastConfirmedBlockNum**  
  API name: last_confirmed_block_num
= 0;  


<a id="Ditch.Golos.Objects.WitnessApiObj.PowWorker"></a>

* *UInt64* **PowWorker**  
  API name: pow_worker
= 0;  


<a id="Ditch.Golos.Objects.WitnessApiObj.SigningKey"></a>

* *Object* **SigningKey**  
  API name: signing_key  


<a id="Ditch.Golos.Objects.WitnessApiObj.Props"></a>

* *ChainProperties* **Props**  
  API name: props  


<a id="Ditch.Golos.Objects.WitnessApiObj.SbdExchangeRate"></a>

* *Price* **SbdExchangeRate**  
  API name: sbd_exchange_rate  


<a id="Ditch.Golos.Objects.WitnessApiObj.LastSbdExchangeUpdate"></a>

* *DateTime* **LastSbdExchangeUpdate**  
  API name: last_sbd_exchange_update  


<a id="Ditch.Golos.Objects.WitnessApiObj.Votes"></a>

* *Object* **Votes**  
  API name: votes  


<a id="Ditch.Golos.Objects.WitnessApiObj.VirtualLastUpdate"></a>

* *String* **VirtualLastUpdate**  
  API name: virtual_last_update  


<a id="Ditch.Golos.Objects.WitnessApiObj.VirtualPosition"></a>

* *String* **VirtualPosition**  
  API name: virtual_position  


<a id="Ditch.Golos.Objects.WitnessApiObj.VirtualScheduledTime"></a>

* *String* **VirtualScheduledTime**  
  API name: virtual_scheduled_time  


<a id="Ditch.Golos.Objects.WitnessApiObj.LastWork"></a>

* *Object* **LastWork**  
  API name: last_work  


<a id="Ditch.Golos.Objects.WitnessApiObj.RunningVersion"></a>

* *Version* **RunningVersion**  
  API name: running_version  


<a id="Ditch.Golos.Objects.WitnessApiObj.HardforkVersionVote"></a>

* *Object* **HardforkVersionVote**  
  API name: hardfork_version_vote  


<a id="Ditch.Golos.Objects.WitnessApiObj.HardforkTimeVote"></a>

* *DateTime* **HardforkTimeVote**  
  API name: hardfork_time_vote  






---

<a id="Ditch.Golos.Objects.WitnessScheduleApiObj"></a>
## WitnessScheduleApiObj
*class Ditch.Golos.Objects.WitnessScheduleApiObj: Ditch.Golos.Objects.WitnessScheduleObject*

witness_schedule_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Golos.Objects.WitnessScheduleObject"></a>
## WitnessScheduleObject
*class Ditch.Golos.Objects.WitnessScheduleObject*

witness_schedule_object
golos-0.16.3\libraries\chain\include\steemit\chain\witness_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Objects.WitnessScheduleObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.CurrentVirtualTime"></a>

* *String* **CurrentVirtualTime**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.NextShuffleBlockNum"></a>

* *UInt32* **NextShuffleBlockNum**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.CurrentShuffledWitnesses"></a>

* *Object* **CurrentShuffledWitnesses**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.NumScheduledWitnesses"></a>

* *Byte* **NumScheduledWitnesses**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.Top19Weight"></a>

* *Byte* **Top19Weight**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.TimeshareWeight"></a>

* *Byte* **TimeshareWeight**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.MinerWeight"></a>

* *Byte* **MinerWeight**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.WitnessPayNormalizationFactor"></a>

* *UInt32* **WitnessPayNormalizationFactor**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.MedianProps"></a>

* *ChainProperties* **MedianProps**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.MajorityVersion"></a>

* *String* **MajorityVersion**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.MaxVotedWitnesses"></a>

* *Byte* **MaxVotedWitnesses**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.MaxMinerWitnesses"></a>

* *Byte* **MaxMinerWitnesses**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.MaxRunnerWitnesses"></a>

* *Byte* **MaxRunnerWitnesses**  


<a id="Ditch.Golos.Objects.WitnessScheduleObject.HardforkRequiredWitnesses"></a>

* *Byte* **HardforkRequiredWitnesses**  






---

<a id="Ditch.Golos.Operations.BaseOperation"></a>
## BaseOperation
*class Ditch.Golos.Operations.BaseOperation*

base_operation
libraries\protocol\include\golos\protocol\base.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.BaseOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.BaseOperation.TypeName"></a>

* *String* **TypeName**  






---

<a id="Ditch.Golos.Operations.CommentOperation"></a>
## CommentOperation
*class Ditch.Golos.Operations.CommentOperation: Ditch.Golos.Operations.BaseOperation*

comment_operation
libraries\protocol\include\golos\protocol\operations\comment_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.CommentOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.CommentOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.CommentOperation.ParentAuthor"></a>

* *String* **ParentAuthor**  
  API name: parent_author  


<a id="Ditch.Golos.Operations.CommentOperation.ParentPermlink"></a>

* *String* **ParentPermlink**  
  API name: parent_permlink  


<a id="Ditch.Golos.Operations.CommentOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Operations.CommentOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Golos.Operations.CommentOperation.Title"></a>

* *String* **Title**  
  API name: title  


<a id="Ditch.Golos.Operations.CommentOperation.Body"></a>

* *String* **Body**  
  API name: body  


<a id="Ditch.Golos.Operations.CommentOperation.JsonMetadata"></a>

* *String* **JsonMetadata**  
  API name: json_metadata  






---

<a id="Ditch.Golos.Operations.CommentOptionsOperation"></a>
## CommentOptionsOperation
*class Ditch.Golos.Operations.CommentOptionsOperation: Ditch.Golos.Operations.BaseOperation*

comment_options_operation
libraries\protocol\include\golos\protocol\operations\comment_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.CommentOptionsOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.MaxAcceptedPayoutStr"></a>

* *String* **MaxAcceptedPayoutStr**  
  API name: max_accepted_payout 
= {1000000000, SBD_SYMBOL_NAME};   
SBD value of the maximum payout this post will receive  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.MaxAcceptedPayout"></a>

* *Money* **MaxAcceptedPayout**  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.PercentSteemDollars"></a>

* *UInt16* **PercentSteemDollars**  
  API name: percent_steem_dollars
= STEEMIT_100_PERCENT; 
the percent of Golos Gold to key, unkept amounts will be received as Golos Power  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.AllowVotes"></a>

* *Boolean* **AllowVotes**  
  API name: allow_votes
= true; /// allows a post to receive votes;  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.AllowCurationRewards"></a>

* *Boolean* **AllowCurationRewards**  
  API name: allow_curation_rewards
= true; 
allows voters to recieve curation rewards. Rewards return to reward fund.  


<a id="Ditch.Golos.Operations.CommentOptionsOperation.Extensions"></a>

* *Object[]* **Extensions**  
  API name: extensions  






---

<a id="Ditch.Golos.Operations.DeleteCommentOperation"></a>
## DeleteCommentOperation
*class Ditch.Golos.Operations.DeleteCommentOperation: Ditch.Golos.Operations.BaseOperation*

delete_comment_operation
libraries\protocol\include\golos\protocol\operations\comment_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.DeleteCommentOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.DeleteCommentOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.DeleteCommentOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Operations.DeleteCommentOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  






---

<a id="Ditch.Golos.Operations.FollowOperation"></a>
## FollowOperation
*class Ditch.Golos.Operations.FollowOperation: Ditch.Golos.Operations.CustomJsonOperation*

Follow / Unfollow some author



---

<a id="Ditch.Golos.Operations.OperationType"></a>
## OperationType
*enum Ditch.Golos.Operations.OperationType*

https://github.com/steemit/steem/blob/master/libraries/protocol/include/steemit/protocol/operations.hpp
 NOTE= do not change the order of any operations

**Enum Values**

* **Vote16**
* **Comment16**
* **Transfer16**
* **TransferToVesting16**
* **WithdrawVesting16**
* **LimitOrderCreate16**
* **LimitOrderCancel16**
* **FeedPublish16**
* **Convert16**
* **AccountCreate16**
* **AccountUpdate16**
* **WitnessUpdate16**
* **AccountWitnessVote16**
* **AccountWitnessProxy16**
* **Pow16**
* **Custom**
* **ReportOverProduction16**
* **DeleteComment16**
* **CustomJson**
* **CommentOptions16**
* **SetWithdrawVestingRoute16**
* **LimitOrderCreate216**
* **ChallengeAuthority16**
* **ProveAuthority16**
* **RequestAccountRecovery16**
* **RecoverAccount16**
* **ChangeRecoveryAccount16**
* **EscrowTransfer16**
* **EscrowDispute16**
* **EscrowRelease16**
* **Pow216**
* **EscrowApprove16**
* **TransferToSavings16**
* **TransferFromSavings16**
* **CancelTransferFromSavings16**
* **CustomBinary**
* **DeclineVotingRights16**
* **ResetAccount16**
* **SetResetAccount16**
* **CommentBenefactorReward16**
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
* **ReportOverProduction**
* **DeleteComment**
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
* **DeclineVotingRights**
* **ResetAccount**
* **SetResetAccount**
* **CommentBenefactorReward**
* **DelegateVestingShares**
* **AccountCreateWithDelegation**
* **CommentPayoutExtension**
* **AssetCreate**
* **AssetUpdate**
* **AssetUpdateBitasset**
* **AssetUpdateFeedProducers**
* **AssetIssue**
* **AssetReserve**
* **AssetFundFeePool**
* **AssetSettle**
* **AssetForceSettle**
* **AssetGlobalSettle**
* **AssetPublishFeed**
* **AssetClaimFees**
* **CallOrderUpdate**
* **AccountWhitelist**
* **OverrideTransfer**
* **ProposalCreate**
* **ProposalUpdate**
* **ProposalDelete**
* **BidCollateral**
* **FillConvertRequest16**
* **AuthorReward16**
* **CurationReward16**
* **CommentReward16**
* **LiquidityReward16**
* **Interest16**
* **FillVestingWithdraw16**
* **FillOrder16**
* **ShutdownWitness16**
* **FillTransferFromSavings16**
* **Hardfork16**
* **CommentPayoutUpdate16**
* **FillConvertRequest**
* **AuthorReward**
* **CurationReward**
* **CommentReward**
* **LiquidityReward**
* **Interest**
* **FillVestingWithdraw**
* **FillOrder**
* **ShutdownWitness**
* **FillTransferFromSavings**
* **Hardfork**
* **CommentPayoutUpdate**
* **ReturnVestingDelegation**
* **AssetSettleCancel**
* **FillCallOrder**
* **FillSettlementOrder**
* **ExecuteBid**


---

<a id="Ditch.Golos.Operations.RePostOperation"></a>
## RePostOperation
*class Ditch.Golos.Operations.RePostOperation: Ditch.Golos.Operations.CustomJsonOperation*

Repost some post by author and permlink (loads all additional parameters from the blockchain)



---

<a id="Ditch.Golos.Operations.UnfollowOperation"></a>
## UnfollowOperation
*class Ditch.Golos.Operations.UnfollowOperation: Ditch.Golos.Operations.FollowOperation*

Unfollow some author



---

<a id="Ditch.Golos.Operations.VoteOperation"></a>
## VoteOperation
*class Ditch.Golos.Operations.VoteOperation: Ditch.Golos.Operations.BaseOperation*

Vote up/down/flag post

**Properties and Fields**

<a id="Ditch.Golos.Operations.VoteOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.VoteOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.VoteOperation.Voter"></a>

* *String* **Voter**  


<a id="Ditch.Golos.Operations.VoteOperation.Author"></a>

* *String* **Author**  


<a id="Ditch.Golos.Operations.VoteOperation.Permlink"></a>

* *String* **Permlink**  


<a id="Ditch.Golos.Operations.VoteOperation.Weight"></a>

* *Int16* **Weight**  
  An weignt from 0 to 10000. -10000 for flag  






---

<a id="Ditch.Golos.Operations.Enums.WithdrawRouteType"></a>
## WithdrawRouteType
*enum Ditch.Golos.Operations.Enums.WithdrawRouteType*

withdraw_route_type
golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp

**Enum Values**

* **Incoming**
* **Outgoing**
* **All**


---

