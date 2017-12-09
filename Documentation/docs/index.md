<a id="Ditch.Steem.OperationManager"></a>
## OperationManager
*class Ditch.Steem.OperationManager*

database_api
libraries\app\include\steemit\app\database_api.hpp

**Methods**

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

<a id="Ditch.Steem.OperationManager.CreateTransaction(Ditch.Steem.Operations.Get.DynamicGlobalPropertyApiObj,System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Steem.Operations.Post.BaseOperation[])"></a>

* *Transaction* **CreateTransaction** *(DynamicGlobalPropertyApiObj propertyApiObj, IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] operations)*  

<a id="Ditch.Steem.OperationManager.GetTrendingTags(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;TagApiObj[]&gt;* **GetTrendingTags** *(String afterTag, UInt32 limit, CancellationToken token)*  
  API name: get_trending_tags

Returns a list of tags (tags) that include word combinations
Возращает список меток(тэгов) включающие словосочетания  

<a id="Ditch.Steem.OperationManager.GetState(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;State&gt;* **GetState** *(String path, CancellationToken token)*  
  API name: get_state

This API is a short-cut for returning all of the state required for a particular URL with a single query.
Отображает текущее состояние сети.  

<a id="Ditch.Steem.OperationManager.GetActiveWitnesses(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetActiveWitnesses** *(CancellationToken token)*  
  API name: get_active_witnesses

Displays a list of all active delegates.
Отображает список всех активных делегатов.  

<a id="Ditch.Steem.OperationManager.GetMinerQueue(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetMinerQueue** *(CancellationToken token)*  
  API name: get_miner_queue

Creates a list of the miners waiting to enter the DPOW chain to create the block.
Создает список майнеров, ожидающих попасть в DPOW цепочку, чтобы создать блок.  

<a id="Ditch.Steem.OperationManager.GetBlockHeader(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BlockHeader&gt;* **GetBlockHeader** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block_header

Retrieve a block header
Возвращает все данные о блоке  

<a id="Ditch.Steem.OperationManager.GetBlock(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SignedBlockApiObj&gt;* **GetBlock** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block

Retrieve a full, signed block
Возвращает все данные о блоке включая транзакции  

<a id="Ditch.Steem.OperationManager.GetOpsInBlock(System.UInt32,System.Boolean,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AppliedOperation[]&gt;* **GetOpsInBlock** *(UInt32 blockNum, Boolean onlyVirtual, CancellationToken token)*  
  API name: get_ops_in_block

Get sequence of operations included/generated within a particular block
Возвращает все операции в блоке, если параметр 'onlyVirtual' true то возвращает только виртуальные операции  

<a id="Ditch.Steem.OperationManager.GetConfig(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetConfig** *(CancellationToken token)*  
  API name: get_config

Displays the current node configuration.
Отображает текущую конфигурацию узла.  

<a id="Ditch.Steem.OperationManager.GetSchema(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String&gt;* **GetSchema** *(CancellationToken token)*  
  API name: get_schema  

<a id="Ditch.Steem.OperationManager.GetDynamicGlobalProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;DynamicGlobalPropertyApiObj&gt;* **GetDynamicGlobalProperties** *(CancellationToken token)*  
  API name: get_dynamic_global_properties

Returns the block chain's rapidly-changing properties.
The returned object contains information that changes every block interval
such as the head block number, the next witness, etc.
@see \c get_global_properties() for less-frequently changing properties  

<a id="Ditch.Steem.OperationManager.GetChainProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ChainProperties&gt;* **GetChainProperties** *(CancellationToken token)*  
  API name: get_chain_properties

Displays the commission for creating the user, the maximum block size and the GBG interest rate
Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.  

<a id="Ditch.Steem.OperationManager.GetCurrentMedianHistoryPrice(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Price&gt;* **GetCurrentMedianHistoryPrice** *(CancellationToken token)*  
  API name: get_current_median_history_price

Displays the current median price of conversion
Отображает текущую медианную цену конвертации.  

<a id="Ditch.Steem.OperationManager.GetFeedHistory(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FeedHistoryApiObj&gt;* **GetFeedHistory** *(CancellationToken token)*  
  API name: get_feed_history

Displays the conversion history
Отображает историю конверсий.  

<a id="Ditch.Steem.OperationManager.GetWitnessSchedule(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessScheduleApiObj&gt;* **GetWitnessSchedule** *(CancellationToken token)*  
  API name: get_witness_schedule

Displays the current delegation status.
Отображает текущее состояние делегирования.  

<a id="Ditch.Steem.OperationManager.GetHardforkVersion(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String&gt;* **GetHardforkVersion** *(CancellationToken token)*  
  API name: get_hardfork_version

Displays the current version of the network.
Отображает текущую версию сети.  

<a id="Ditch.Steem.OperationManager.GetNextScheduledHardfork(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ScheduledHardfork&gt;* **GetNextScheduledHardfork** *(CancellationToken token)*  
  API name: get_next_scheduled_hardfork

Displays the date and version of HardFork
Отображает дату и версию HardFork  

<a id="Ditch.Steem.OperationManager.GetKeyReferences(System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse&lt;String[][]&gt;* **GetKeyReferences** *(CancellationToken token, Object[] keys)*  
  API name: get_key_references

Находит и возвращает имена пользователей по публичному ключу  

<a id="Ditch.Steem.OperationManager.GetAccounts(System.Threading.CancellationToken,System.String[])"></a>

* *JsonRpcResponse&lt;ExtendedAccount[]&gt;* **GetAccounts** *(CancellationToken token, String[] names)*  
  API name: get_accounts

Get user accounts by user names  

<a id="Ditch.Steem.OperationManager.GetAccountReferences(System.UInt64,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetAccountReferences** *(UInt64 accountId, CancellationToken token)*  
  API name: get_account_references  

<a id="Ditch.Steem.OperationManager.LookupAccountNames(System.Threading.CancellationToken,System.String[])"></a>

* *JsonRpcResponse&lt;AccountApiObj[]&gt;* **LookupAccountNames** *(CancellationToken token, String[] accountNames)*  
  API name: lookup_account_names

Get a list of accounts by name
This function has semantics identical to @ref get_objects
Возращает данные по заданным аккаунтам  

<a id="Ditch.Steem.OperationManager.LookupAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **LookupAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_accounts

Returns the names of users close to the phrase.
Возвращает имена пользователей близких к шаблону.  

<a id="Ditch.Steem.OperationManager.GetAccountCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetAccountCount** *(CancellationToken token)*  
  API name: get_account_count

Get the total number of accounts registered with the blockchain
Возвращает количество зарегестрированных пользователей.  

<a id="Ditch.Steem.OperationManager.GetOwnerHistory(System.Threading.CancellationToken,System.String[])"></a>

* *JsonRpcResponse&lt;OwnerAuthorityHistoryApiObj[]&gt;* **GetOwnerHistory** *(CancellationToken token, String[] account)*  
  API name: get_owner_history

Displays the user name if he changed the ownership of the blockchain
Отображает имя пользователя если он изменил право собственности на блокчейн  

<a id="Ditch.Steem.OperationManager.GetRecoveryRequest(System.Threading.CancellationToken,System.String[])"></a>

* *JsonRpcResponse&lt;AccountRecoveryRequestApiObj[]&gt;* **GetRecoveryRequest** *(CancellationToken token, String[] account)*  
  API name: get_recovery_request

Returns true if the user is in recovery status.
Возвращает true если пользователь в статусе на восстановление.  

<a id="Ditch.Steem.OperationManager.GetEscrow(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;EscrowApiObj&gt;* **GetEscrow** *(String from, UInt32 escrowId, CancellationToken token)*  
  API name: get_escrow

Returns the operations implemented through mediation.
Возвращает операции реализованные с помощью посредничества.  

<a id="Ditch.Steem.OperationManager.GetWithdrawRoutes(System.String,Ditch.Steem.Operations.Enums.WithdrawRouteType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WithdrawRoute[]&gt;* **GetWithdrawRoutes** *(String account, WithdrawRouteType type, CancellationToken token)*  
  API name: get_withdraw_routes

Returns all transfers to the user's account, depending on the type
Возвращает все переводы на счету пользователя в зависимости от типа  

<a id="Ditch.Steem.OperationManager.GetAccountBandwidth(System.String,Ditch.Steem.Operations.Enums.BandwidthType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountBandwidthApiObj&gt;* **GetAccountBandwidth** *(String account, BandwidthType type, CancellationToken token)*  
  API name: get_account_bandwidth

Displays user actions based on type
Отображает действия пользователя в зависимости от типа  

<a id="Ditch.Steem.OperationManager.GetSavingsWithdrawFrom(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawFrom** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_from

Returns the output data from 'SAFE' for this user
Возвращает данные о выводах из 'СЕЙФА' для данного пользователя  

<a id="Ditch.Steem.OperationManager.GetSavingsWithdrawTo(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawTo** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_to

Returns the output data from 'SAFE' for this user
Возвращает данные о выводах из 'СЕЙФА' для данного пользователя  

<a id="Ditch.Steem.OperationManager.GetWitnesses(System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnesses** *(CancellationToken token, Object[] witnessIds)*  
  API name: get_witnesses

Get a list of witnesses by ID  

<a id="Ditch.Steem.OperationManager.GetConversionRequests(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ConvertRequestApiObj[]&gt;* **GetConversionRequests** *(String accountName, CancellationToken token)*  
  API name: get_conversion_requests

Returns the current requests for conversion by the specified user
Возвращает текущие запросы на конвертацию указанным пользователем  

<a id="Ditch.Steem.OperationManager.GetWitnessByAccount(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj&gt;* **GetWitnessByAccount** *(String accountName, CancellationToken token)*  
  API name: get_witness_by_account

Get the witness owned by a given account  

<a id="Ditch.Steem.OperationManager.GetWitnessesByVote(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnessesByVote** *(String from, UInt32 limit, CancellationToken token)*  
  API name: get_witnesses_by_vote

This method is used to fetch witnesses with pagination.  

<a id="Ditch.Steem.OperationManager.LookupWitnessAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object[]&gt;* **LookupWitnessAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_witness_accounts

Get names and IDs for registered witnesses  

<a id="Ditch.Steem.OperationManager.GetWitnessCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetWitnessCount** *(CancellationToken token)*  
  API name: get_witness_count

Get the total number of witnesses registered with the blockchain  

<a id="Ditch.Steem.OperationManager.GetOrderBook(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OrderBook&gt;* **GetOrderBook** *(UInt32 limit, CancellationToken token)*  
  API name: get_order_book

Gets the current order book for STEEM:SBD market  

<a id="Ditch.Steem.OperationManager.GetOpenOrders(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ExtendedLimitOrder[]&gt;* **GetOpenOrders** *(String owner, CancellationToken token)*  
  API name: get_open_orders  

<a id="Ditch.Steem.OperationManager.GetActiveVotes(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;VoteState[]&gt;* **GetActiveVotes** *(String author, String permlink, CancellationToken token)*  
  API name: get_active_votes  

<a id="Ditch.Steem.OperationManager.GetContent(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion&gt;* **GetContent** *(String author, String permlink, CancellationToken token)*  
  API name: get_content

Get post by author and permlink  

<a id="Ditch.Steem.OperationManager.GetContentReplies(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetContentReplies** *(String parent, String parentPermlink, CancellationToken token)*  
  API name: get_content_replies  

<a id="Ditch.Steem.OperationManager.GetTagsUsedByAuthor(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;KeyValuePair`2[]&gt;* **GetTagsUsedByAuthor** *(String author, CancellationToken token)*  
  API name: get_tags_used_by_author  

<a id="Ditch.Steem.OperationManager.GetDiscussionsByAuthorBeforeDate(System.String,System.String,System.DateTime,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetDiscussionsByAuthorBeforeDate** *(String author, String startPermlink, DateTime beforeDate, UInt32 limit, CancellationToken token)*  
  API name: get_discussions_by_author_before_date  

<a id="Ditch.Steem.OperationManager.GetAccountHistory(System.String,System.UInt64,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;KeyValuePair`2[]&gt;* **GetAccountHistory** *(String account, UInt64 from, UInt32 limit, CancellationToken token)*  
  API name: get_account_history


История всех действий пользователя в сети в виде транзакций. При from = -1 будут показаны последние {limit+1} элементов истории. Параметр limit не должен превышать from (исключение from = -1), так как показываются предшествующие {from} элементы истории.  

<a id="Ditch.Steem.OperationManager.OnApiStartup(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **OnApiStartup** *(CancellationToken token)*  
  API name: on_api_startup  

<a id="Ditch.Steem.OperationManager.GetFollowers(System.String,System.String,Ditch.Steem.Operations.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowers** *(String following, String startFollower, FollowType followType, UInt16 limit, CancellationToken token)*  
  Возвращает список: Либо всех подписчиков пользователя 'following'. 
Либо если указано имя пользователя в параметре 'startFollower' возвращается список совпадающих подписчиков.  

<a id="Ditch.Steem.OperationManager.GetFollowing(System.String,System.String,Ditch.Steem.Operations.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowing** *(String follower, String startFollowing, FollowType followType, UInt16 limit, CancellationToken token)*  
  Aналогично GetFollowers только для подписок  


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

<a id="Ditch.Steem.Operations.Get.AccountApiObj"></a>
## AccountApiObj
*class Ditch.Steem.Operations.Get.AccountApiObj*

account_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.AccountApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Owner"></a>

* *Authority* **Owner**  
  used for backup control, can set owner or active  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Active"></a>

* *Authority* **Active**  
  used for all monetary operations, can set active or posting  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Posting"></a>

* *Authority* **Posting**  
  used for voting and posting  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.MemoKey"></a>

* *String* **MemoKey**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Proxy"></a>

* *String* **Proxy**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastOwnerUpdate"></a>

* *DateTime* **LastOwnerUpdate**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastAccountUpdate"></a>

* *DateTime* **LastAccountUpdate**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Mined"></a>

* *Boolean* **Mined**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.OwnerChallenged"></a>

* *Boolean* **OwnerChallenged**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.ActiveChallenged"></a>

* *Boolean* **ActiveChallenged**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastOwnerProved"></a>

* *DateTime* **LastOwnerProved**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastActiveProved"></a>

* *DateTime* **LastActiveProved**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.RecoveryAccount"></a>

* *String* **RecoveryAccount**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.ResetAccount"></a>

* *String* **ResetAccount**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastAccountRecovery"></a>

* *DateTime* **LastAccountRecovery**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.CommentCount"></a>

* *UInt32* **CommentCount**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LifetimeVoteCount"></a>

* *UInt32* **LifetimeVoteCount**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.PostCount"></a>

* *UInt32* **PostCount**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.CanVote"></a>

* *Boolean* **CanVote**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.VotingPower"></a>

* *UInt16* **VotingPower**  
  Current voting power of this account, it falls after every vote  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastVoteTime"></a>

* *DateTime* **LastVoteTime**  
  used to increase the voting power of this account the longer it goes without voting.  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Balance"></a>

* *Money* **Balance**  
  total liquid shares held by this account  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SavingsBalance"></a>

* *Money* **SavingsBalance**  
  total liquid shares held by this account  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SbdBalance"></a>

* *Money* **SbdBalance**  
  Total sbd balance  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SbdSeconds"></a>

* *String* **SbdSeconds**  
  Total sbd * how long it has been hel  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SbdSecondsLastUpdate"></a>

* *DateTime* **SbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SbdLastInterestPayment"></a>

* *DateTime* **SbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SavingsSbdBalance"></a>

* *Money* **SavingsSbdBalance**  
  total sbd balance  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SavingsSbdSeconds"></a>

* *String* **SavingsSbdSeconds**  
  total sbd * how long it has been hel  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SavingsSbdSecondsLastUpdate"></a>

* *DateTime* **SavingsSbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SavingsSbdLastInterestPayment"></a>

* *DateTime* **SavingsSbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.SavingsWithdrawRequests"></a>

* *Byte* **SavingsWithdrawRequests**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.RewardSbdBalance"></a>

* *Money* **RewardSbdBalance**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.RewardSteemBalance"></a>

* *Money* **RewardSteemBalance**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.RewardVestingBalance"></a>

* *Money* **RewardVestingBalance**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.RewardVestingSteem"></a>

* *Money* **RewardVestingSteem**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.CurationRewards"></a>

* *Object* **CurationRewards**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.PostingRewards"></a>

* *Object* **PostingRewards**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.VestingShares"></a>

* *Money* **VestingShares**  
  total vesting shares held by this account, controls its voting power  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.DelegatedVestingShares"></a>

* *Money* **DelegatedVestingShares**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.ReceivedVestingShares"></a>

* *Money* **ReceivedVestingShares**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.VestingWithdrawRate"></a>

* *Money* **VestingWithdrawRate**  
  at the time this is updated it can be at most vesting_shares/104  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.NextVestingWithdrawal"></a>

* *DateTime* **NextVestingWithdrawal**  
  after every withdrawal this is incremented by 1 week  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.Withdrawn"></a>

* *Object* **Withdrawn**  
  Track how many shares have been withdrawn  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.ToWithdraw"></a>

* *Object* **ToWithdraw**  
  Might be able to look this up with operation history.  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.WithdrawRoutes"></a>

* *UInt16* **WithdrawRoutes**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.ProxiedVsfVotes"></a>

* *Object[]* **ProxiedVsfVotes**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.WitnessesVotedFor"></a>

* *UInt16* **WitnessesVotedFor**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.AverageMarketBandwidth"></a>

* *Object* **AverageMarketBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LifetimeMarketBandwidth"></a>

* *Object* **LifetimeMarketBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastMarketBandwidthUpdate"></a>

* *DateTime* **LastMarketBandwidthUpdate**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastPost"></a>

* *DateTime* **LastPost**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.LastRootPost"></a>

* *DateTime* **LastRootPost**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.PostBandwidth"></a>

* *Object* **PostBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.NewAverageBandwidth"></a>

* *Object* **NewAverageBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountApiObj.NewAverageMarketBandwidth"></a>

* *Object* **NewAverageMarketBandwidth**  






---

<a id="Ditch.Steem.Operations.Get.AccountBandwidthApiObj"></a>
## AccountBandwidthApiObj
*class Ditch.Steem.Operations.Get.AccountBandwidthApiObj: Ditch.Steem.Operations.Get.AccountBandwidthObject*

account_bandwidth_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Operations.Get.AccountBandwidthObject"></a>
## AccountBandwidthObject
*class Ditch.Steem.Operations.Get.AccountBandwidthObject*

account_bandwidth_object
steem-0.19.1\libraries\plugins\witness\include\steemit\witness\witness_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.AccountBandwidthObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.AccountBandwidthObject.Account"></a>

* *String* **Account**  


<a id="Ditch.Steem.Operations.Get.AccountBandwidthObject.Type"></a>

* *BandwidthType* **Type**  


<a id="Ditch.Steem.Operations.Get.AccountBandwidthObject.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountBandwidthObject.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Steem.Operations.Get.AccountBandwidthObject.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  






---

<a id="Ditch.Steem.Operations.Get.AccountRecoveryRequestApiObj"></a>
## AccountRecoveryRequestApiObj
*class Ditch.Steem.Operations.Get.AccountRecoveryRequestApiObj*

account_recovery_request_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.AccountRecoveryRequestApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.AccountRecoveryRequestApiObj.AccountToRecover"></a>

* *String* **AccountToRecover**  


<a id="Ditch.Steem.Operations.Get.AccountRecoveryRequestApiObj.NewOwnerAuthority"></a>

* *Authority* **NewOwnerAuthority**  


<a id="Ditch.Steem.Operations.Get.AccountRecoveryRequestApiObj.Expires"></a>

* *DateTime* **Expires**  






---

<a id="Ditch.Steem.Operations.Get.AppliedOperation"></a>
## AppliedOperation
*class Ditch.Steem.Operations.Get.AppliedOperation*

applied_operation
steem-0.19.1\libraries\app\include\steemit\app\applied_operation.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.AppliedOperation.TrxId"></a>

* *Object* **TrxId**  


<a id="Ditch.Steem.Operations.Get.AppliedOperation.Block"></a>

* *UInt32* **Block**  


<a id="Ditch.Steem.Operations.Get.AppliedOperation.TrxInBlock"></a>

* *UInt32* **TrxInBlock**  


<a id="Ditch.Steem.Operations.Get.AppliedOperation.OpInTrx"></a>

* *UInt16* **OpInTrx**  


<a id="Ditch.Steem.Operations.Get.AppliedOperation.VirtualOp"></a>

* *UInt64* **VirtualOp**  


<a id="Ditch.Steem.Operations.Get.AppliedOperation.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Steem.Operations.Get.AppliedOperation.Op"></a>

* *Object[]* **Op**  






---

<a id="Ditch.Steem.Operations.Get.Authority"></a>
## Authority
*class Ditch.Steem.Operations.Get.Authority*

authority
steem-0.19.1\libraries\protocol\include\steemit\protocol\authority.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.Authority.WeightThreshold"></a>

* *UInt32* **WeightThreshold**  


<a id="Ditch.Steem.Operations.Get.Authority.AccountAuths"></a>

* *Object* **AccountAuths**  


<a id="Ditch.Steem.Operations.Get.Authority.KeyAuths"></a>

* *Object[][]* **KeyAuths**  






---

<a id="Ditch.Steem.Operations.Get.BlockHeader"></a>
## BlockHeader
*class Ditch.Steem.Operations.Get.BlockHeader*

block_header
steem-0.19.1\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.BlockHeader.Previous"></a>

* *Object* **Previous**  


<a id="Ditch.Steem.Operations.Get.BlockHeader.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Steem.Operations.Get.BlockHeader.Witness"></a>

* *String* **Witness**  


<a id="Ditch.Steem.Operations.Get.BlockHeader.TransactionMerkleRoot"></a>

* *Object* **TransactionMerkleRoot**  


<a id="Ditch.Steem.Operations.Get.BlockHeader.Extensions"></a>

* *Object* **Extensions**  






---

<a id="Ditch.Steem.Operations.Get.CategoryApiObj"></a>
## CategoryApiObj
*class Ditch.Steem.Operations.Get.CategoryApiObj*

category_api_obj

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.CategoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.CategoryApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Steem.Operations.Get.CategoryApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Steem.Operations.Get.CategoryApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Steem.Operations.Get.CategoryApiObj.Discussions"></a>

* *UInt32* **Discussions**  


<a id="Ditch.Steem.Operations.Get.CategoryApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  






---

<a id="Ditch.Steem.Operations.Get.ChainProperties"></a>
## ChainProperties
*class Ditch.Steem.Operations.Get.ChainProperties*

chain_properties
steem-0.19.1\libraries\protocol\include\steemit\protocol\steem_operations.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.ChainProperties.AccountCreationFee"></a>

* *Money* **AccountCreationFee**  
  This fee, paid in STEEM, is converted into VESTING SHARES for the new account.Accounts 
without vesting shares cannot earn usage rations and therefore are powerless.This minimum 
fee requires all accounts to have some kind of commitment to the network that includes the
 ability to vote and make transactions.  


<a id="Ditch.Steem.Operations.Get.ChainProperties.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  
  This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity  


<a id="Ditch.Steem.Operations.Get.ChainProperties.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  






---

<a id="Ditch.Steem.Operations.Get.CommentApiObj"></a>
## CommentApiObj
*class Ditch.Steem.Operations.Get.CommentApiObj*

comment_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.CommentApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Category"></a>

* *String* **Category**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.ParentAuthor"></a>

* *String* **ParentAuthor**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.ParentPermlink"></a>

* *String* **ParentPermlink**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Author"></a>

* *String* **Author**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Permlink"></a>

* *String* **Permlink**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Title"></a>

* *String* **Title**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Body"></a>

* *String* **Body**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Active"></a>

* *DateTime* **Active**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.LastPayout"></a>

* *DateTime* **LastPayout**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Depth"></a>

* *Byte* **Depth**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Children"></a>

* *UInt32* **Children**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.ChildrenRshares2"></a>

* *String* **ChildrenRshares2**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.NetRshares"></a>

* *Object* **NetRshares**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.VoteRshares"></a>

* *Object* **VoteRshares**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.ChildrenAbsRshares"></a>

* *Object* **ChildrenAbsRshares**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.CashoutTime"></a>

* *DateTime* **CashoutTime**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.MaxCashoutTime"></a>

* *DateTime* **MaxCashoutTime**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.TotalVoteWeight"></a>

* *UInt64* **TotalVoteWeight**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.RewardWeight"></a>

* *UInt16* **RewardWeight**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.TotalPayoutValue"></a>

* *Money* **TotalPayoutValue**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.CuratorPayoutValue"></a>

* *Money* **CuratorPayoutValue**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.AuthorRewards"></a>

* *Object* **AuthorRewards**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.RootComment"></a>

* *UInt64* **RootComment**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Mode"></a>

* *CommentMode* **Mode**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.MaxAcceptedPayout"></a>

* *Money* **MaxAcceptedPayout**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.PercentSteemDollars"></a>

* *UInt16* **PercentSteemDollars**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.AllowReplies"></a>

* *Boolean* **AllowReplies**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.AllowVotes"></a>

* *Boolean* **AllowVotes**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.AllowCurationRewards"></a>

* *Boolean* **AllowCurationRewards**  


<a id="Ditch.Steem.Operations.Get.CommentApiObj.Beneficiaries"></a>

* *Object[]* **Beneficiaries**  






---

<a id="Ditch.Steem.Operations.Get.ConvertRequestApiObj"></a>
## ConvertRequestApiObj
*class Ditch.Steem.Operations.Get.ConvertRequestApiObj: Ditch.Steem.Operations.Get.ConvertRequestObject*

convert_request_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Operations.Get.ConvertRequestObject"></a>
## ConvertRequestObject
*class Ditch.Steem.Operations.Get.ConvertRequestObject*

convert_request_object
steem-0.19.1\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.ConvertRequestObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.ConvertRequestObject.Owner"></a>

* *Object* **Owner**  


<a id="Ditch.Steem.Operations.Get.ConvertRequestObject.Requestid"></a>

* *UInt32* **Requestid**  
  id set by owner,the owner,requestid pair must be unique  


<a id="Ditch.Steem.Operations.Get.ConvertRequestObject.Amount"></a>

* *Money* **Amount**  






---

<a id="Ditch.Steem.Operations.Get.Discussion"></a>
## Discussion
*class Ditch.Steem.Operations.Get.Discussion: Ditch.Steem.Operations.Get.CommentApiObj*

discussion
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.Discussion.Url"></a>

* *String* **Url**  
  /category/@rootauthor/root_permlink#author/permlink  


<a id="Ditch.Steem.Operations.Get.Discussion.RootTitle"></a>

* *String* **RootTitle**  


<a id="Ditch.Steem.Operations.Get.Discussion.PendingPayoutValue"></a>

* *Money* **PendingPayoutValue**  
  sbd  


<a id="Ditch.Steem.Operations.Get.Discussion.TotalPendingPayoutValue"></a>

* *Money* **TotalPendingPayoutValue**  
  sbd including replies  


<a id="Ditch.Steem.Operations.Get.Discussion.ActiveVotes"></a>

* *VoteState[]* **ActiveVotes**  


<a id="Ditch.Steem.Operations.Get.Discussion.Replies"></a>

* *String[]* **Replies**  
  author/slug mapping  


<a id="Ditch.Steem.Operations.Get.Discussion.AuthorReputation"></a>

* *Object* **AuthorReputation**  


<a id="Ditch.Steem.Operations.Get.Discussion.Promoted"></a>

* *Money* **Promoted**  


<a id="Ditch.Steem.Operations.Get.Discussion.BodyLength"></a>

* *UInt32* **BodyLength**  


<a id="Ditch.Steem.Operations.Get.Discussion.RebloggedBy"></a>

* *String[]* **RebloggedBy**  


<a id="Ditch.Steem.Operations.Get.Discussion.FirstRebloggedBy"></a>

* *Object* **FirstRebloggedBy**  


<a id="Ditch.Steem.Operations.Get.Discussion.FirstRebloggedOn"></a>

* *Object* **FirstRebloggedOn**  






---

<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyApiObj"></a>
## DynamicGlobalPropertyApiObj
*class Ditch.Steem.Operations.Get.DynamicGlobalPropertyApiObj: Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject*

Shows an overview of various information regarding the current state of the STEEM network.
dynamic_global_property_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyApiObj.CurrentReserveRatio"></a>

* *UInt32* **CurrentReserveRatio**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyApiObj.AverageBlockSize"></a>

* *UInt64* **AverageBlockSize**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyApiObj.MaxVirtualBandwidth"></a>

* *String* **MaxVirtualBandwidth**  






---

<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject"></a>
## DynamicGlobalPropertyObject
*class Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject*

Shows an overview of various information regarding the current state of the STEEM network.
dynamic_global_property_object
steem-0.19.1\libraries\chain\include\steemit\chain\global_property_object.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.Id"></a>

* *String* **Id**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.HeadBlockNumber"></a>

* *UInt32* **HeadBlockNumber**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.HeadBlockId"></a>

* *String* **HeadBlockId**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.Time"></a>

* *DateTime* **Time**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.CurrentWitness"></a>

* *String* **CurrentWitness**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.TotalPow"></a>

* *UInt64* **TotalPow**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.NumPowWitnesses"></a>

* *UInt32* **NumPowWitnesses**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.VirtualSupply"></a>

* *Money* **VirtualSupply**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.CurrentSupply"></a>

* *Money* **CurrentSupply**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.ConfidentialSupply"></a>

* *Money* **ConfidentialSupply**  
  total asset held in confidential balances  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.CurrentSbdSupply"></a>

* *Money* **CurrentSbdSupply**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.ConfidentialSbdSupply"></a>

* *Money* **ConfidentialSbdSupply**  
  total asset held in confidential balances  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.TotalVestingFundSteem"></a>

* *Money* **TotalVestingFundSteem**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.TotalVestingShares"></a>

* *Money* **TotalVestingShares**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.TotalRewardFundSteem"></a>

* *Money* **TotalRewardFundSteem**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.TotalRewardShares2"></a>

* *String* **TotalRewardShares2**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.PendingRewardedVestingShares"></a>

* *Money* **PendingRewardedVestingShares**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.PendingRewardedVestingSteem"></a>

* *Money* **PendingRewardedVestingSteem**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.SbdPrintRate"></a>

* *UInt16* **SbdPrintRate**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.AverageBlockSize"></a>

* *UInt32* **AverageBlockSize**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.CurrentAslot"></a>

* *UInt64* **CurrentAslot**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.RecentSlotsFilled"></a>

* *String* **RecentSlotsFilled**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.ParticipationCount"></a>

* *Byte* **ParticipationCount**  
  divide by 128 to compute participation percentage  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.LastIrreversibleBlockNum"></a>

* *UInt32* **LastIrreversibleBlockNum**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.MaxVirtualBandwidth"></a>

* *UInt64* **MaxVirtualBandwidth**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.CurrentReserveRatio"></a>

* *UInt64* **CurrentReserveRatio**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.VoteRegenerationPerDay"></a>

* *UInt32* **VoteRegenerationPerDay**  


<a id="Ditch.Steem.Operations.Get.DynamicGlobalPropertyObject.VotePowerReserveRate"></a>

* *UInt32* **VotePowerReserveRate**  






---

<a id="Ditch.Steem.Operations.Get.EscrowApiObj"></a>
## EscrowApiObj
*class Ditch.Steem.Operations.Get.EscrowApiObj: Ditch.Steem.Operations.Get.EscrowObject*

escrow_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Operations.Get.EscrowObject"></a>
## EscrowObject
*class Ditch.Steem.Operations.Get.EscrowObject*

escrow_object
steem-0.19.1\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.EscrowObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.EscrowId"></a>

* *UInt32* **EscrowId**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.From"></a>

* *String* **From**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.To"></a>

* *String* **To**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.Agent"></a>

* *String* **Agent**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.RatificationDeadline"></a>

* *DateTime* **RatificationDeadline**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.EscrowExpiration"></a>

* *DateTime* **EscrowExpiration**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.SbdBalance"></a>

* *Money* **SbdBalance**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.SteemBalance"></a>

* *Money* **SteemBalance**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.PendingFee"></a>

* *Money* **PendingFee**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.ToApproved"></a>

* *Boolean* **ToApproved**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.AgentApproved"></a>

* *Boolean* **AgentApproved**  


<a id="Ditch.Steem.Operations.Get.EscrowObject.Disputed"></a>

* *Boolean* **Disputed**  






---

<a id="Ditch.Steem.Operations.Get.ExtendedAccount"></a>
## ExtendedAccount
*class Ditch.Steem.Operations.Get.ExtendedAccount: Ditch.Steem.Operations.Get.AccountApiObj*

extended_account 
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.ExtendedAccount.VestingBalance"></a>

* *Money* **VestingBalance**  
  convert vesting_shares to vesting steem  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.TransferHistory"></a>

* *Object* **TransferHistory**  
  transfer to/from vesting  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.MarketHistory"></a>

* *Object* **MarketHistory**  
  limit order / cancel / fill  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.PostHistory"></a>

* *Object* **PostHistory**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.VoteHistory"></a>

* *Object* **VoteHistory**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.OtherHistory"></a>

* *Object* **OtherHistory**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.WitnessVotes"></a>

* *String[]* **WitnessVotes**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.TagsUsage"></a>

* *KeyValuePair`2[]* **TagsUsage**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.GuestBloggers"></a>

* *KeyValuePair`2[]* **GuestBloggers**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.OpenOrders"></a>

* *Object* **OpenOrders**  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.Comments"></a>

* *String[]* **Comments**  
  permlinks for this user  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.Blog"></a>

* *String[]* **Blog**  
  blog posts for this user  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.Feed"></a>

* *String[]* **Feed**  
  feed posts for this user  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.RecentReplies"></a>

* *String[]* **RecentReplies**  
  blog posts for this user  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.BlogCategory"></a>

* *Object* **BlogCategory**  
  blog posts for this user  


<a id="Ditch.Steem.Operations.Get.ExtendedAccount.Recommended"></a>

* *String[]* **Recommended**  
  posts recommened for this user  






---

<a id="Ditch.Steem.Operations.Get.ExtendedLimitOrder"></a>
## ExtendedLimitOrder
*class Ditch.Steem.Operations.Get.ExtendedLimitOrder*

extended_limit_order
libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.ExtendedLimitOrder.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
= 0;  


<a id="Ditch.Steem.Operations.Get.ExtendedLimitOrder.Rewarded"></a>

* *Boolean* **Rewarded**  
  API name: rewarded
= false;  






---

<a id="Ditch.Steem.Operations.Get.FeedHistoryApiObj"></a>
## FeedHistoryApiObj
*class Ditch.Steem.Operations.Get.FeedHistoryApiObj*

feed_history_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.FeedHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.FeedHistoryApiObj.CurrentMedianHistory"></a>

* *Price* **CurrentMedianHistory**  


<a id="Ditch.Steem.Operations.Get.FeedHistoryApiObj.PriceHistory"></a>

* *Price[]* **PriceHistory**  






---

<a id="Ditch.Steem.Operations.Get.FollowApiObj"></a>
## FollowApiObj
*class Ditch.Steem.Operations.Get.FollowApiObj*

follow_api_obj
steem-0.19.1\libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.FollowApiObj.Follower"></a>

* *String* **Follower**  


<a id="Ditch.Steem.Operations.Get.FollowApiObj.Following"></a>

* *String* **Following**  


<a id="Ditch.Steem.Operations.Get.FollowApiObj.What"></a>

* *FollowType[]* **What**  






---

<a id="Ditch.Steem.Operations.Get.Order"></a>
## Order
*class Ditch.Steem.Operations.Get.Order*

order
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.Order.OrderPrice"></a>

* *Price* **OrderPrice**  
  API name: order_price  


<a id="Ditch.Steem.Operations.Get.Order.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
dollars per steem  


<a id="Ditch.Steem.Operations.Get.Order.Steem"></a>

* *Object* **Steem**  
  API name: steem  


<a id="Ditch.Steem.Operations.Get.Order.Sbd"></a>

* *Object* **Sbd**  
  API name: sbd  


<a id="Ditch.Steem.Operations.Get.Order.Created"></a>

* *DateTime* **Created**  
  API name: created  






---

<a id="Ditch.Steem.Operations.Get.OrderBook"></a>
## OrderBook
*class Ditch.Steem.Operations.Get.OrderBook*

order_book
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.OrderBook.Asks"></a>

* *Order[]* **Asks**  
  API name: asks  


<a id="Ditch.Steem.Operations.Get.OrderBook.Bids"></a>

* *Order[]* **Bids**  
  API name: bids  






---

<a id="Ditch.Steem.Operations.Get.OwnerAuthorityHistoryApiObj"></a>
## OwnerAuthorityHistoryApiObj
*class Ditch.Steem.Operations.Get.OwnerAuthorityHistoryApiObj*

owner_authority_history_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.OwnerAuthorityHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.OwnerAuthorityHistoryApiObj.Account"></a>

* *String* **Account**  


<a id="Ditch.Steem.Operations.Get.OwnerAuthorityHistoryApiObj.PreviousOwnerAuthority"></a>

* *Authority* **PreviousOwnerAuthority**  


<a id="Ditch.Steem.Operations.Get.OwnerAuthorityHistoryApiObj.LastValidTime"></a>

* *DateTime* **LastValidTime**  






---

<a id="Ditch.Steem.Operations.Get.Price"></a>
## Price
*class Ditch.Steem.Operations.Get.Price*

price
steem-0.19.1\libraries\protocol\include\steemit\protocol\asset.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.Price.Base"></a>

* *Money* **Base**  


<a id="Ditch.Steem.Operations.Get.Price.Quote"></a>

* *Money* **Quote**  






---

<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj"></a>
## SavingsWithdrawApiObj
*class Ditch.Steem.Operations.Get.SavingsWithdrawApiObj*

savings_withdraw_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj.From"></a>

* *String* **From**  
  API name: from  


<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj.To"></a>

* *String* **To**  
  API name: to  


<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj.Memo"></a>

* *String* **Memo**  
  API name: memo  


<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj.RequestId"></a>

* *UInt32* **RequestId**  
  API name: request_id
= 0;  


<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj.Amount"></a>

* *Money* **Amount**  
  API name: amount  


<a id="Ditch.Steem.Operations.Get.SavingsWithdrawApiObj.Complete"></a>

* *DateTime* **Complete**  
  API name: complete  






---

<a id="Ditch.Steem.Operations.Get.ScheduledHardfork"></a>
## ScheduledHardfork
*class Ditch.Steem.Operations.Get.ScheduledHardfork*

scheduled_hardfork
steem-0.19.1\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.ScheduledHardfork.HfVersion"></a>

* *String* **HfVersion**  


<a id="Ditch.Steem.Operations.Get.ScheduledHardfork.LiveTime"></a>

* *DateTime* **LiveTime**  






---

<a id="Ditch.Steem.Operations.Get.SignedBlock"></a>
## SignedBlock
*class Ditch.Steem.Operations.Get.SignedBlock: Ditch.Steem.Operations.Get.SignedBlockHeader*

signed_block
steem-0.19.1\libraries\protocol\include\steemit\protocol\block.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.SignedBlock.Transactions"></a>

* *Object[]* **Transactions**  






---

<a id="Ditch.Steem.Operations.Get.SignedBlockApiObj"></a>
## SignedBlockApiObj
*class Ditch.Steem.Operations.Get.SignedBlockApiObj: Ditch.Steem.Operations.Get.SignedBlock*

signed_block_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.SignedBlockApiObj.BlockId"></a>

* *Object* **BlockId**  


<a id="Ditch.Steem.Operations.Get.SignedBlockApiObj.SigningKey"></a>

* *String* **SigningKey**  


<a id="Ditch.Steem.Operations.Get.SignedBlockApiObj.TransactionIds"></a>

* *Object[]* **TransactionIds**  






---

<a id="Ditch.Steem.Operations.Get.SignedBlockHeader"></a>
## SignedBlockHeader
*class Ditch.Steem.Operations.Get.SignedBlockHeader: Ditch.Steem.Operations.Get.BlockHeader*

signed_block_header
steem-0.19.1\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.SignedBlockHeader.WitnessSignature"></a>

* *Object* **WitnessSignature**  






---

<a id="Ditch.Steem.Operations.Get.State"></a>
## State
*class Ditch.Steem.Operations.Get.State*

state
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.State.CurrentRoute"></a>

* *String* **CurrentRoute**  


<a id="Ditch.Steem.Operations.Get.State.Props"></a>

* *DynamicGlobalPropertyApiObj* **Props**  


<a id="Ditch.Steem.Operations.Get.State.CategoryIdx"></a>

* *Object* **CategoryIdx**  


<a id="Ditch.Steem.Operations.Get.State.TagIdx"></a>

* *Object* **TagIdx**  


<a id="Ditch.Steem.Operations.Get.State.DiscussionIdx"></a>

* *Object* **DiscussionIdx**  
  is the global discussion index  


<a id="Ditch.Steem.Operations.Get.State.Categories"></a>

* *Object* **Categories**  


<a id="Ditch.Steem.Operations.Get.State.Tags"></a>

* *Object* **Tags**  


<a id="Ditch.Steem.Operations.Get.State.Content"></a>

* *Object* **Content**  
  map from account/slug to full nested discussion  


<a id="Ditch.Steem.Operations.Get.State.Accounts"></a>

* *Object* **Accounts**  


<a id="Ditch.Steem.Operations.Get.State.PowQueue"></a>

* *String[]* **PowQueue**  
  The list of miners who are queued to produce work  


<a id="Ditch.Steem.Operations.Get.State.Witnesses"></a>

* *Object* **Witnesses**  


<a id="Ditch.Steem.Operations.Get.State.WitnessSchedule"></a>

* *WitnessScheduleApiObj* **WitnessSchedule**  


<a id="Ditch.Steem.Operations.Get.State.FeedPrice"></a>

* *Price* **FeedPrice**  


<a id="Ditch.Steem.Operations.Get.State.Error"></a>

* *String* **Error**  


<a id="Ditch.Steem.Operations.Get.State.MarketData"></a>

* *Object* **MarketData**  






---

<a id="Ditch.Steem.Operations.Get.TagApiObj"></a>
## TagApiObj
*class Ditch.Steem.Operations.Get.TagApiObj*

tag_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.TagApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Steem.Operations.Get.TagApiObj.TotalChildrenRshares2"></a>

* *String* **TotalChildrenRshares2**  


<a id="Ditch.Steem.Operations.Get.TagApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Steem.Operations.Get.TagApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Steem.Operations.Get.TagApiObj.TopPosts"></a>

* *UInt32* **TopPosts**  


<a id="Ditch.Steem.Operations.Get.TagApiObj.Comments"></a>

* *UInt32* **Comments**  


<a id="Ditch.Steem.Operations.Get.TagApiObj.Trending"></a>

* *String* **Trending**  






---

<a id="Ditch.Steem.Operations.Get.VoteState"></a>
## VoteState
*class Ditch.Steem.Operations.Get.VoteState*

vote_state
steem-0.19.1\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.VoteState.Voter"></a>

* *String* **Voter**  


<a id="Ditch.Steem.Operations.Get.VoteState.Weight"></a>

* *UInt64* **Weight**  


<a id="Ditch.Steem.Operations.Get.VoteState.Rshares"></a>

* *Int64* **Rshares**  


<a id="Ditch.Steem.Operations.Get.VoteState.Percent"></a>

* *Int16* **Percent**  


<a id="Ditch.Steem.Operations.Get.VoteState.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Steem.Operations.Get.VoteState.Time"></a>

* *DateTime* **Time**  






---

<a id="Ditch.Steem.Operations.Get.WithdrawRoute"></a>
## WithdrawRoute
*class Ditch.Steem.Operations.Get.WithdrawRoute*

withdraw_route
steem-0.19.1\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.WithdrawRoute.FromAccount"></a>

* *String* **FromAccount**  


<a id="Ditch.Steem.Operations.Get.WithdrawRoute.ToAccount"></a>

* *String* **ToAccount**  


<a id="Ditch.Steem.Operations.Get.WithdrawRoute.Percent"></a>

* *UInt16* **Percent**  


<a id="Ditch.Steem.Operations.Get.WithdrawRoute.AutoVest"></a>

* *Boolean* **AutoVest**  






---

<a id="Ditch.Steem.Operations.Get.WitnessApiObj"></a>
## WitnessApiObj
*class Ditch.Steem.Operations.Get.WitnessApiObj*

witness_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.WitnessApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.Owner"></a>

* *String* **Owner**  
  API name: owner  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.Created"></a>

* *DateTime* **Created**  
  API name: created  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.Url"></a>

* *String* **Url**  
  API name: url  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.TotalMissed"></a>

* *UInt32* **TotalMissed**  
  API name: total_missed
= 0;  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.LastAslot"></a>

* *UInt64* **LastAslot**  
  API name: last_aslot
= 0;  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.LastConfirmedBlockNum"></a>

* *UInt64* **LastConfirmedBlockNum**  
  API name: last_confirmed_block_num
= 0;  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.PowWorker"></a>

* *UInt64* **PowWorker**  
  API name: pow_worker
= 0;  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.SigningKey"></a>

* *Object* **SigningKey**  
  API name: signing_key  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.Props"></a>

* *ChainProperties* **Props**  
  API name: props  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.SbdExchangeRate"></a>

* *Price* **SbdExchangeRate**  
  API name: sbd_exchange_rate  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.LastSbdExchangeUpdate"></a>

* *DateTime* **LastSbdExchangeUpdate**  
  API name: last_sbd_exchange_update  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.Votes"></a>

* *Object* **Votes**  
  API name: votes  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.VirtualLastUpdate"></a>

* *String* **VirtualLastUpdate**  
  API name: virtual_last_update  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.VirtualPosition"></a>

* *String* **VirtualPosition**  
  API name: virtual_position  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.VirtualScheduledTime"></a>

* *String* **VirtualScheduledTime**  
  API name: virtual_scheduled_time  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.LastWork"></a>

* *Object* **LastWork**  
  API name: last_work  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.RunningVersion"></a>

* *Version* **RunningVersion**  
  API name: running_version  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.HardforkVersionVote"></a>

* *Object* **HardforkVersionVote**  
  API name: hardfork_version_vote  


<a id="Ditch.Steem.Operations.Get.WitnessApiObj.HardforkTimeVote"></a>

* *DateTime* **HardforkTimeVote**  
  API name: hardfork_time_vote  






---

<a id="Ditch.Steem.Operations.Get.WitnessScheduleApiObj"></a>
## WitnessScheduleApiObj
*class Ditch.Steem.Operations.Get.WitnessScheduleApiObj: Ditch.Steem.Operations.Get.WitnessScheduleObject*

witness_schedule_api_obj
steem-0.19.1\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject"></a>
## WitnessScheduleObject
*class Ditch.Steem.Operations.Get.WitnessScheduleObject*

witness_schedule_object
steem-0.19.1\libraries\chain\include\steemit\chain\witness_objects.hpp

**Properties and Fields**

<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.CurrentVirtualTime"></a>

* *String* **CurrentVirtualTime**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.NextShuffleBlockNum"></a>

* *UInt32* **NextShuffleBlockNum**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.CurrentShuffledWitnesses"></a>

* *Object* **CurrentShuffledWitnesses**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.NumScheduledWitnesses"></a>

* *Byte* **NumScheduledWitnesses**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.Top19Weight"></a>

* *Byte* **Top19Weight**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.TimeshareWeight"></a>

* *Byte* **TimeshareWeight**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.MinerWeight"></a>

* *Byte* **MinerWeight**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.WitnessPayNormalizationFactor"></a>

* *UInt32* **WitnessPayNormalizationFactor**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.MedianProps"></a>

* *ChainProperties* **MedianProps**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.MajorityVersion"></a>

* *String* **MajorityVersion**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.MaxVotedWitnesses"></a>

* *Byte* **MaxVotedWitnesses**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.MaxMinerWitnesses"></a>

* *Byte* **MaxMinerWitnesses**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.MaxRunnerWitnesses"></a>

* *Byte* **MaxRunnerWitnesses**  


<a id="Ditch.Steem.Operations.Get.WitnessScheduleObject.HardforkRequiredWitnesses"></a>

* *Byte* **HardforkRequiredWitnesses**  






---

