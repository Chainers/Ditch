<a id="Ditch.Golos.OperationManager"></a>
## OperationManager
*class Ditch.Golos.OperationManager*

database_api
libraries\application\include\golos\application\database_api.hpp

**Methods**

<a id="Ditch.Golos.OperationManager.TryConnectTo(System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken)"></a>

* *String* **TryConnectTo** *(List&lt;String&gt; urls, CancellationToken token)*  

<a id="Ditch.Golos.OperationManager.RetryConnect(System.Threading.CancellationToken)"></a>

* *String* **RetryConnect** *(CancellationToken token)*  

<a id="Ditch.Golos.OperationManager.BroadcastOperations(System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Golos.Operations.Post.BaseOperation[])"></a>

* *JsonRpcResponse* **BroadcastOperations** *(IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] operations)*  

<a id="Ditch.Golos.OperationManager.VerifyAuthority(System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Golos.Operations.Post.BaseOperation[])"></a>

* *JsonRpcResponse&lt;Boolean&gt;* **VerifyAuthority** *(IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] testOps)*  

<a id="Ditch.Golos.OperationManager.CustomGetRequest(System.String,System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse&lt;T&gt;* **CustomGetRequest** *(String method, CancellationToken token, Object[] data)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Golos.OperationManager.CustomGetRequest(System.String,System.Threading.CancellationToken,System.Object[])"></a>

* *JsonRpcResponse* **CustomGetRequest** *(String method, CancellationToken token, Object[] data)*  
  Create and execute custom json-rpc method  

<a id="Ditch.Golos.OperationManager.CreateTransaction(Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject,System.Collections.Generic.IEnumerable`1[[System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]],System.Threading.CancellationToken,Ditch.Golos.Operations.Post.BaseOperation[])"></a>

* *SignedTransaction* **CreateTransaction** *(DynamicGlobalPropertyObject propertyApiObj, IEnumerable&lt;Byte[]&gt; userPrivateKeys, CancellationToken token, BaseOperation[] operations)*  

<a id="Ditch.Golos.OperationManager.GetTrendingTags(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;TagApiObj[]&gt;* **GetTrendingTags** *(String afterTag, UInt32 limit, CancellationToken token)*  
  API name: get_trending_tags
            
Returns a list of tags (tags) that include word combinations
Возращает список меток(тэгов) включающие словосочетания  

<a id="Ditch.Golos.OperationManager.GetTrendingCategories(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;CategoryApiObj[]&gt;* **GetTrendingCategories** *(String after, UInt32 limit, CancellationToken token)*  
  API name: get_trending_categories

Возвращает отсортированные по стоимости тэги начиная с заданного или близко к нему похожего.  

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
Displays a list of all active delegates.
Отображает список всех активных делегатов.  

<a id="Ditch.Golos.OperationManager.GetMinerQueue(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **GetMinerQueue** *(CancellationToken token)*  
  API name: get_miner_queue
Creates a list of the miners waiting to enter the DPOW chain to create the block.
Создает список майнеров, ожидающих попасть в DPOW цепочку, чтобы создать блок.  

<a id="Ditch.Golos.OperationManager.GetState(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;State&gt;* **GetState** *(String path, CancellationToken token)*  
  API name: get_state
This API is a short-cut for returning all of the state required for a particular URL with a single query.
Отображает текущее состояние сети.  

<a id="Ditch.Golos.OperationManager.GetBlockHeader(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;BlockHeader&gt;* **GetBlockHeader** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block_header
Retrieve a block header
Возвращает все данные о блоке  

<a id="Ditch.Golos.OperationManager.GetBlock(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SignedBlock&gt;* **GetBlock** *(UInt32 blockNum, CancellationToken token)*  
  API name: get_block
Retrieve a full, signed block
Возвращает все данные о блоке включая транзакции  

<a id="Ditch.Golos.OperationManager.GetOpsInBlock(System.UInt32,System.Boolean,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AppliedOperation[]&gt;* **GetOpsInBlock** *(UInt32 blockNum, Boolean onlyVirtual, CancellationToken token)*  
  API name: get_ops_in_block
Get sequence of operations included/generated within a particular block
Возвращает все операции в блоке, если параметр 'onlyVirtual' true то возвращает только виртуальные операции  

<a id="Ditch.Golos.OperationManager.GetConfig(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object&gt;* **GetConfig** *(CancellationToken token)*  
  API name: get_config
Displays the current node configuration.
Отображает текущую конфигурацию узла.  

<a id="Ditch.Golos.OperationManager.GetDynamicGlobalProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;DynamicGlobalPropertyObject&gt;* **GetDynamicGlobalProperties** *(CancellationToken token)*  
  API name: get_dynamic_global_properties
Returns the block chain's rapidly-changing properties.
The returned object contains information that changes every block interval
such as the head block number, the next witness, etc.
@see \c get_global_properties() for less-frequently changing properties  

<a id="Ditch.Golos.OperationManager.GetChainProperties(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ChainProperties&gt;* **GetChainProperties** *(CancellationToken token)*  
  API name: get_chain_properties
Displays the commission for creating the user, the maximum block size and the GBG interest rate
Отображает комиссию за создание пользователя, максимальный размер блока и процентную ставку GBG.  

<a id="Ditch.Golos.OperationManager.GetCurrentMedianHistoryPrice(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Price&gt;* **GetCurrentMedianHistoryPrice** *(CancellationToken token)*  
  API name: get_current_median_history_price
Displays the current median price of conversion
Отображает текущую медианную цену конвертации.  

<a id="Ditch.Golos.OperationManager.GetFeedHistory(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FeedHistoryApiObj&gt;* **GetFeedHistory** *(CancellationToken token)*  
  API name: get_feed_history
Displays the conversion history
Отображает историю конверсий.  

<a id="Ditch.Golos.OperationManager.GetWitnessSchedule(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessScheduleObject&gt;* **GetWitnessSchedule** *(CancellationToken token)*  
  API name: get_witness_schedule
Displays the current delegation status.
Отображает текущее состояние делегирования.  

<a id="Ditch.Golos.OperationManager.GetHardforkVersion(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String&gt;* **GetHardforkVersion** *(CancellationToken token)*  
  API name: get_hardfork_version
Displays the current version of the network.
Отображает текущую версию сети.  

<a id="Ditch.Golos.OperationManager.GetNextScheduledHardfork(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ScheduledHardfork&gt;* **GetNextScheduledHardfork** *(CancellationToken token)*  
  API name: get_next_scheduled_hardfork
Displays the date and version of HardFork
Отображает дату и версию HardFork  

<a id="Ditch.Golos.OperationManager.GetNameCost(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Money&gt;* **GetNameCost** *(String name, CancellationToken token)*  
  API name: get_name_cost  

<a id="Ditch.Golos.OperationManager.GetAccounts(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ExtendedAccount[]&gt;* **GetAccounts** *(String[] names, CancellationToken token)*  
  API name: get_accounts
Get user accounts by user names  

<a id="Ditch.Golos.OperationManager.LookupAccountNames(System.String[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountApiObj[]&gt;* **LookupAccountNames** *(String[] accountNames, CancellationToken token)*  
  API name: lookup_account_names
Get a list of accounts by name
This function has semantics identical to @ref get_objects
Возращает данные по заданным аккаунтам  

<a id="Ditch.Golos.OperationManager.LookupAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String[]&gt;* **LookupAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_accounts
Returns the names of users close to the phrase.
Возвращает имена пользователей близких к шаблону.  

<a id="Ditch.Golos.OperationManager.GetAccountCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetAccountCount** *(CancellationToken token)*  
  API name: get_account_count
Get the total number of accounts registered with the blockchain
Возвращает количество зарегестрированных пользователей.  

<a id="Ditch.Golos.OperationManager.GetOwnerHistory(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OwnerAuthorityHistoryApiObj[]&gt;* **GetOwnerHistory** *(String account, CancellationToken token)*  
  API name: get_owner_history
Displays the user name if he changed the ownership of the blockchain
Отображает имя пользователя если он изменил право собственности на блокчейн  

<a id="Ditch.Golos.OperationManager.GetRecoveryRequest(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountRecoveryRequestApiObj&gt;* **GetRecoveryRequest** *(String account, CancellationToken token)*  
  API name: get_recovery_request
Returns true if the user is in recovery status.
Возвращает true если пользователь в статусе на восстановление.  

<a id="Ditch.Golos.OperationManager.GetEscrow(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;EscrowObject&gt;* **GetEscrow** *(String from, UInt32 escrowId, CancellationToken token)*  
  API name: get_escrow
Returns the operations implemented through mediation.
Возвращает операции реализованные с помощью посредничества.  

<a id="Ditch.Golos.OperationManager.GetWithdrawRoutes(System.String,Ditch.Golos.Operations.Enums.WithdrawRouteType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WithdrawRoute[]&gt;* **GetWithdrawRoutes** *(String account, WithdrawRouteType type, CancellationToken token)*  
  API name: get_withdraw_routes
Returns all transfers to the user's account, depending on the type
Возвращает все переводы на счету пользователя в зависимости от типа  

<a id="Ditch.Golos.OperationManager.GetAccountBandwidth(System.String,Ditch.Golos.Operations.Enums.BandwidthType,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;AccountBandwidthObject&gt;* **GetAccountBandwidth** *(String account, BandwidthType type, CancellationToken token)*  
  API name: get_account_bandwidth
Displays user actions based on type
Отображает действия пользователя в зависимости от типа  

<a id="Ditch.Golos.OperationManager.GetSavingsWithdrawFrom(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawFrom** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_from
Returns the output data from 'SAFE' for this user
Возвращает данные о выводах из 'СЕЙФА' для данного пользователя  

<a id="Ditch.Golos.OperationManager.GetSavingsWithdrawTo(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;SavingsWithdrawApiObj[]&gt;* **GetSavingsWithdrawTo** *(String account, CancellationToken token)*  
  API name: get_savings_withdraw_to
Returns the output data from 'SAFE' for this user
Возвращает данные о выводах из 'СЕЙФА' для данного пользователя  

<a id="Ditch.Golos.OperationManager.GetWitnesses(System.Object[],System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnesses** *(Object[] witnessIds, CancellationToken token)*  
  API name: get_witnesses
Get a list of witnesses by ID  

<a id="Ditch.Golos.OperationManager.GetConversionRequests(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;ConvertRequestObject[]&gt;* **GetConversionRequests** *(String accountName, CancellationToken token)*  
  API name: get_conversion_requests
Returns the current requests for conversion by the specified user
Возвращает текущие запросы на конвертацию указанным пользователем  

<a id="Ditch.Golos.OperationManager.GetWitnessByAccount(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj&gt;* **GetWitnessByAccount** *(String accountName, CancellationToken token)*  
  API name: get_witness_by_account
Get the witness owned by a given account  

<a id="Ditch.Golos.OperationManager.GetWitnessesByVote(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;WitnessApiObj[]&gt;* **GetWitnessesByVote** *(String from, UInt32 limit, CancellationToken token)*  
  API name: get_witnesses_by_vote
This method is used to fetch witnesses with pagination.  

<a id="Ditch.Golos.OperationManager.LookupWitnessAccounts(System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Object[]&gt;* **LookupWitnessAccounts** *(String lowerBoundName, UInt32 limit, CancellationToken token)*  
  API name: lookup_witness_accounts
Get names and IDs for registered witnesses  

<a id="Ditch.Golos.OperationManager.GetWitnessCount(System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;UInt64&gt;* **GetWitnessCount** *(CancellationToken token)*  
  API name: get_witness_count
Get the total number of witnesses registered with the blockchain  

<a id="Ditch.Golos.OperationManager.GetTransactionHex(Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;String&gt;* **GetTransactionHex** *(SignedTransaction trx, CancellationToken token)*  
  API name: get_transaction_hex  

<a id="Ditch.Golos.OperationManager.VerifyAuthority(Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Boolean&gt;* **VerifyAuthority** *(SignedTransaction trx, CancellationToken token)*  
  API name: verify_authority  

<a id="Ditch.Golos.OperationManager.GetActiveVotes(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;VoteState[]&gt;* **GetActiveVotes** *(String author, String permlink, CancellationToken token)*  
  API name: get_active_votes  

<a id="Ditch.Golos.OperationManager.GetContent(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion&gt;* **GetContent** *(String author, String permlink, CancellationToken token)*  
  API name: get_content
Get post by author and permlink  

<a id="Ditch.Golos.OperationManager.GetContentReplies(System.String,System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetContentReplies** *(String parent, String parentPermlink, CancellationToken token)*  
  API name: get_content_replies  

<a id="Ditch.Golos.OperationManager.GetTagsUsedByAuthor(System.String,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;KeyValuePair`2[]&gt;* **GetTagsUsedByAuthor** *(String author, CancellationToken token)*  
  API name: get_tags_used_by_author  

<a id="Ditch.Golos.OperationManager.GetRepliesByLastUpdate(System.String,System.String,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetRepliesByLastUpdate** *(String startAuthor, String startPermlink, UInt32 limit, CancellationToken token)*  
  API name: get_replies_by_last_update  

<a id="Ditch.Golos.OperationManager.GetDiscussionsByAuthorBeforeDate(System.String,System.String,System.DateTime,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Discussion[]&gt;* **GetDiscussionsByAuthorBeforeDate** *(String author, String startPermlink, DateTime beforeDate, UInt32 limit, CancellationToken token)*  
  API name: get_discussions_by_author_before_date  

<a id="Ditch.Golos.OperationManager.GetAccountHistory(System.String,System.UInt64,System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;KeyValuePair`2[]&gt;* **GetAccountHistory** *(String account, UInt64 from, UInt32 limit, CancellationToken token)*  
  API name: get_account_history

История всех действий пользователя в сети в виде транзакций. При from = -1 будут показаны последние {limit+1} элементов истории. Параметр limit не должен превышать from (исключение from = -1), так как показываются предшествующие {from} элементы истории.  

<a id="Ditch.Golos.OperationManager.GetPayoutExtensionCost(System.String,System.String,System.DateTime,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;Money&gt;* **GetPayoutExtensionCost** *(String author, String permlink, DateTime time, CancellationToken token)*  
  API name: get_payout_extension_cost  

<a id="Ditch.Golos.OperationManager.GetPayoutExtensionTime(System.String,System.String,Ditch.Core.Money,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;DateTime&gt;* **GetPayoutExtensionTime** *(String author, String permlink, Money cost, CancellationToken token)*  
  API name: get_payout_extension_time  

<a id="Ditch.Golos.OperationManager.BroadcastTransaction(Ditch.Golos.Protocol.SignedTransaction,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse* **BroadcastTransaction** *(SignedTransaction trx, CancellationToken token)*  
  API name: broadcast_transaction  

<a id="Ditch.Golos.OperationManager.GetOrderBook(System.UInt32,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;OrderBook&gt;* **GetOrderBook** *(UInt32 limit, CancellationToken token)*  
  Gets the current order book for STEEM:SBD market  

<a id="Ditch.Golos.OperationManager.GetFollowers(System.String,System.String,Ditch.Golos.Operations.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowers** *(String following, String startFollower, FollowType followType, UInt16 limit, CancellationToken token)*  
  Возвращает список: Либо всех подписчиков пользователя 'following'. 
Либо если указано имя пользователя в параметре 'startFollower' возвращается список совпадающих подписчиков  

<a id="Ditch.Golos.OperationManager.GetFollowing(System.String,System.String,Ditch.Golos.Operations.Enums.FollowType,System.UInt16,System.Threading.CancellationToken)"></a>

* *JsonRpcResponse&lt;FollowApiObj[]&gt;* **GetFollowing** *(String follower, String startFollowing, FollowType followType, UInt16 limit, CancellationToken token)*  
  Aналогично GetFollowers только для подписок  


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

<a id="Ditch.Golos.Operations.Post.BaseOperation"></a>
## BaseOperation
*class Ditch.Golos.Operations.Post.BaseOperation*

base_operation
libraries\protocol\include\golos\protocol\base.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Post.BaseOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.Post.BaseOperation.TypeName"></a>

* *String* **TypeName**  






---

<a id="Ditch.Golos.Operations.Post.CommentOperation"></a>
## CommentOperation
*class Ditch.Golos.Operations.Post.CommentOperation: Ditch.Golos.Operations.Post.BaseOperation*

comment_operation
libraries\protocol\include\golos\protocol\operations\comment_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Post.CommentOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.Post.CommentOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.Post.CommentOperation.ParentAuthor"></a>

* *String* **ParentAuthor**  
  API name: parent_author  


<a id="Ditch.Golos.Operations.Post.CommentOperation.ParentPermlink"></a>

* *String* **ParentPermlink**  
  API name: parent_permlink  


<a id="Ditch.Golos.Operations.Post.CommentOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Operations.Post.CommentOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Golos.Operations.Post.CommentOperation.Title"></a>

* *String* **Title**  
  API name: title  


<a id="Ditch.Golos.Operations.Post.CommentOperation.Body"></a>

* *String* **Body**  
  API name: body  


<a id="Ditch.Golos.Operations.Post.CommentOperation.JsonMetadata"></a>

* *String* **JsonMetadata**  
  API name: json_metadata  






---

<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation"></a>
## CommentOptionsOperation
*class Ditch.Golos.Operations.Post.CommentOptionsOperation: Ditch.Golos.Operations.Post.BaseOperation*

comment_options_operation
libraries\protocol\include\golos\protocol\operations\comment_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.MaxAcceptedPayoutStr"></a>

* *String* **MaxAcceptedPayoutStr**  
  API name: max_accepted_payout 
= {1000000000, SBD_SYMBOL_NAME};   
SBD value of the maximum payout this post will receive  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.MaxAcceptedPayout"></a>

* *Money* **MaxAcceptedPayout**  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.PercentSteemDollars"></a>

* *UInt16* **PercentSteemDollars**  
  API name: percent_steem_dollars
= STEEMIT_100_PERCENT; 
the percent of Golos Gold to key, unkept amounts will be received as Golos Power  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.AllowVotes"></a>

* *Boolean* **AllowVotes**  
  API name: allow_votes
= true; /// allows a post to receive votes;  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.AllowCurationRewards"></a>

* *Boolean* **AllowCurationRewards**  
  API name: allow_curation_rewards
= true; 
allows voters to recieve curation rewards. Rewards return to reward fund.  


<a id="Ditch.Golos.Operations.Post.CommentOptionsOperation.Extensions"></a>

* *Object[]* **Extensions**  
  API name: extensions  






---

<a id="Ditch.Golos.Operations.Post.DeleteCommentOperation"></a>
## DeleteCommentOperation
*class Ditch.Golos.Operations.Post.DeleteCommentOperation: Ditch.Golos.Operations.Post.BaseOperation*

delete_comment_operation
libraries\protocol\include\golos\protocol\operations\comment_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Post.DeleteCommentOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.Post.DeleteCommentOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.Post.DeleteCommentOperation.Author"></a>

* *String* **Author**  
  API name: author  


<a id="Ditch.Golos.Operations.Post.DeleteCommentOperation.Permlink"></a>

* *String* **Permlink**  
  API name: permlink  






---

<a id="Ditch.Golos.Operations.Post.FollowOperation"></a>
## FollowOperation
*class Ditch.Golos.Operations.Post.FollowOperation: Ditch.Golos.Operations.Post.CustomJsonOperation*

Follow / Unfollow some author



---

<a id="Ditch.Golos.Operations.Post.RePostOperation"></a>
## RePostOperation
*class Ditch.Golos.Operations.Post.RePostOperation: Ditch.Golos.Operations.Post.CustomJsonOperation*

Repost some post by author and permlink (loads all additional parameters from the blockchain)



---

<a id="Ditch.Golos.Operations.Post.UnfollowOperation"></a>
## UnfollowOperation
*class Ditch.Golos.Operations.Post.UnfollowOperation: Ditch.Golos.Operations.Post.FollowOperation*

Unfollow some author



---

<a id="Ditch.Golos.Operations.Post.VoteOperation"></a>
## VoteOperation
*class Ditch.Golos.Operations.Post.VoteOperation: Ditch.Golos.Operations.Post.BaseOperation*

Vote up/down/flag post

**Properties and Fields**

<a id="Ditch.Golos.Operations.Post.VoteOperation.TypeName"></a>

* *String* **TypeName**  


<a id="Ditch.Golos.Operations.Post.VoteOperation.Type"></a>

* *OperationType* **Type**  


<a id="Ditch.Golos.Operations.Post.VoteOperation.Voter"></a>

* *String* **Voter**  


<a id="Ditch.Golos.Operations.Post.VoteOperation.Author"></a>

* *String* **Author**  


<a id="Ditch.Golos.Operations.Post.VoteOperation.Permlink"></a>

* *String* **Permlink**  


<a id="Ditch.Golos.Operations.Post.VoteOperation.Weight"></a>

* *Int16* **Weight**  
  An weignt from 0 to 10000. -10000 for flag  






---

<a id="Ditch.Golos.Operations.Get.AccountApiObj"></a>
## AccountApiObj
*class Ditch.Golos.Operations.Get.AccountApiObj*

account_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.AccountApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Owner"></a>

* *Authority* **Owner**  
  used for backup control, can set owner or active  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Active"></a>

* *Authority* **Active**  
  used for all monetary operations, can set active or posting  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Posting"></a>

* *Authority* **Posting**  
  used for voting and posting  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.MemoKey"></a>

* *String* **MemoKey**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Proxy"></a>

* *String* **Proxy**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastOwnerUpdate"></a>

* *DateTime* **LastOwnerUpdate**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastAccountUpdate"></a>

* *DateTime* **LastAccountUpdate**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Mined"></a>

* *Boolean* **Mined**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.OwnerChallenged"></a>

* *Boolean* **OwnerChallenged**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.ActiveChallenged"></a>

* *Boolean* **ActiveChallenged**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastOwnerProved"></a>

* *DateTime* **LastOwnerProved**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastActiveProved"></a>

* *DateTime* **LastActiveProved**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.RecoveryAccount"></a>

* *String* **RecoveryAccount**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.ResetAccount"></a>

* *String* **ResetAccount**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastAccountRecovery"></a>

* *DateTime* **LastAccountRecovery**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.CommentCount"></a>

* *UInt32* **CommentCount**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LifetimeVoteCount"></a>

* *UInt32* **LifetimeVoteCount**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.PostCount"></a>

* *UInt32* **PostCount**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.CanVote"></a>

* *Boolean* **CanVote**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.VotingPower"></a>

* *UInt16* **VotingPower**  
  Current voting power of this account, it falls after every vote  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastVoteTime"></a>

* *DateTime* **LastVoteTime**  
  used to increase the voting power of this account the longer it goes without voting.  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Balance"></a>

* *Money* **Balance**  
  total liquid shares held by this account  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SavingsBalance"></a>

* *Money* **SavingsBalance**  
  total liquid shares held by this account  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SbdBalance"></a>

* *Money* **SbdBalance**  
  Total sbd balance  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SbdSeconds"></a>

* *String* **SbdSeconds**  
  Total sbd * how long it has been hel  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SbdSecondsLastUpdate"></a>

* *DateTime* **SbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SbdLastInterestPayment"></a>

* *DateTime* **SbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SavingsSbdBalance"></a>

* *Money* **SavingsSbdBalance**  
  total sbd balance  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SavingsSbdSeconds"></a>

* *String* **SavingsSbdSeconds**  
  total sbd * how long it has been hel  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SavingsSbdSecondsLastUpdate"></a>

* *DateTime* **SavingsSbdSecondsLastUpdate**  
  the last time the sbd_seconds was updated  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SavingsSbdLastInterestPayment"></a>

* *DateTime* **SavingsSbdLastInterestPayment**  
  used to pay interest at most once per month  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.SavingsWithdrawRequests"></a>

* *Byte* **SavingsWithdrawRequests**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.RewardSbdBalance"></a>

* *Money* **RewardSbdBalance**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.RewardSteemBalance"></a>

* *Money* **RewardSteemBalance**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.RewardVestingBalance"></a>

* *Money* **RewardVestingBalance**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.RewardVestingSteem"></a>

* *Money* **RewardVestingSteem**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.CurationRewards"></a>

* *Object* **CurationRewards**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.PostingRewards"></a>

* *Object* **PostingRewards**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.VestingShares"></a>

* *Money* **VestingShares**  
  total vesting shares held by this account, controls its voting power  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.DelegatedVestingShares"></a>

* *Money* **DelegatedVestingShares**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.ReceivedVestingShares"></a>

* *Money* **ReceivedVestingShares**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.VestingWithdrawRate"></a>

* *Money* **VestingWithdrawRate**  
  at the time this is updated it can be at most vesting_shares/104  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.NextVestingWithdrawal"></a>

* *DateTime* **NextVestingWithdrawal**  
  after every withdrawal this is incremented by 1 week  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.Withdrawn"></a>

* *Object* **Withdrawn**  
  Track how many shares have been withdrawn  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.ToWithdraw"></a>

* *Object* **ToWithdraw**  
  Might be able to look this up with operation history.  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.WithdrawRoutes"></a>

* *UInt16* **WithdrawRoutes**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.ProxiedVsfVotes"></a>

* *Object[]* **ProxiedVsfVotes**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.WitnessesVotedFor"></a>

* *UInt16* **WitnessesVotedFor**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.AverageMarketBandwidth"></a>

* *Object* **AverageMarketBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LifetimeMarketBandwidth"></a>

* *Object* **LifetimeMarketBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastMarketBandwidthUpdate"></a>

* *DateTime* **LastMarketBandwidthUpdate**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastPost"></a>

* *DateTime* **LastPost**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.LastRootPost"></a>

* *DateTime* **LastRootPost**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.PostBandwidth"></a>

* *Object* **PostBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.NewAverageBandwidth"></a>

* *Object* **NewAverageBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountApiObj.NewAverageMarketBandwidth"></a>

* *Object* **NewAverageMarketBandwidth**  






---

<a id="Ditch.Golos.Operations.Get.AccountBandwidthApiObj"></a>
## AccountBandwidthApiObj
*class Ditch.Golos.Operations.Get.AccountBandwidthApiObj: Ditch.Golos.Operations.Get.AccountBandwidthObject*

account_bandwidth_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp\



---

<a id="Ditch.Golos.Operations.Get.AccountBandwidthObject"></a>
## AccountBandwidthObject
*class Ditch.Golos.Operations.Get.AccountBandwidthObject*

account_bandwidth_object
golos-0.16.3\libraries\chain\include\steemit\chain\account_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.AccountBandwidthObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.AccountBandwidthObject.Account"></a>

* *String* **Account**  


<a id="Ditch.Golos.Operations.Get.AccountBandwidthObject.Type"></a>

* *BandwidthType* **Type**  


<a id="Ditch.Golos.Operations.Get.AccountBandwidthObject.AverageBandwidth"></a>

* *Object* **AverageBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountBandwidthObject.LifetimeBandwidth"></a>

* *Object* **LifetimeBandwidth**  


<a id="Ditch.Golos.Operations.Get.AccountBandwidthObject.LastBandwidthUpdate"></a>

* *DateTime* **LastBandwidthUpdate**  






---

<a id="Ditch.Golos.Operations.Get.AccountRecoveryRequestApiObj"></a>
## AccountRecoveryRequestApiObj
*class Ditch.Golos.Operations.Get.AccountRecoveryRequestApiObj*

account_recovery_request_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.AccountRecoveryRequestApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.AccountRecoveryRequestApiObj.AccountToRecover"></a>

* *String* **AccountToRecover**  


<a id="Ditch.Golos.Operations.Get.AccountRecoveryRequestApiObj.NewOwnerAuthority"></a>

* *Authority* **NewOwnerAuthority**  


<a id="Ditch.Golos.Operations.Get.AccountRecoveryRequestApiObj.Expires"></a>

* *DateTime* **Expires**  






---

<a id="Ditch.Golos.Operations.Get.AppliedOperation"></a>
## AppliedOperation
*class Ditch.Golos.Operations.Get.AppliedOperation*

applied_operation
golos-0.16.3\libraries\app\include\steemit\app\applied_operation.hpp\

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.AppliedOperation.TrxId"></a>

* *Object* **TrxId**  


<a id="Ditch.Golos.Operations.Get.AppliedOperation.Block"></a>

* *UInt32* **Block**  


<a id="Ditch.Golos.Operations.Get.AppliedOperation.TrxInBlock"></a>

* *UInt32* **TrxInBlock**  


<a id="Ditch.Golos.Operations.Get.AppliedOperation.OpInTrx"></a>

* *UInt16* **OpInTrx**  


<a id="Ditch.Golos.Operations.Get.AppliedOperation.VirtualOp"></a>

* *UInt64* **VirtualOp**  


<a id="Ditch.Golos.Operations.Get.AppliedOperation.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Golos.Operations.Get.AppliedOperation.Op"></a>

* *Object[]* **Op**  






---

<a id="Ditch.Golos.Operations.Get.Authority"></a>
## Authority
*class Ditch.Golos.Operations.Get.Authority*

authority
golos-0.16.3\libraries\protocol\include\steemit\protocol\authority.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.Authority.WeightThreshold"></a>

* *UInt32* **WeightThreshold**  


<a id="Ditch.Golos.Operations.Get.Authority.AccountAuths"></a>

* *Object* **AccountAuths**  


<a id="Ditch.Golos.Operations.Get.Authority.KeyAuths"></a>

* *Object[][]* **KeyAuths**  






---

<a id="Ditch.Golos.Operations.Get.BlockHeader"></a>
## BlockHeader
*class Ditch.Golos.Operations.Get.BlockHeader*

block_header
golos-0.16.3\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.BlockHeader.Previous"></a>

* *Object* **Previous**  


<a id="Ditch.Golos.Operations.Get.BlockHeader.Timestamp"></a>

* *DateTime* **Timestamp**  


<a id="Ditch.Golos.Operations.Get.BlockHeader.Witness"></a>

* *String* **Witness**  


<a id="Ditch.Golos.Operations.Get.BlockHeader.TransactionMerkleRoot"></a>

* *Object* **TransactionMerkleRoot**  


<a id="Ditch.Golos.Operations.Get.BlockHeader.Extensions"></a>

* *Object* **Extensions**  






---

<a id="Ditch.Golos.Operations.Get.CategoryApiObj"></a>
## CategoryApiObj
*class Ditch.Golos.Operations.Get.CategoryApiObj*

category_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.CategoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.CategoryApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Golos.Operations.Get.CategoryApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Golos.Operations.Get.CategoryApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Golos.Operations.Get.CategoryApiObj.Discussions"></a>

* *UInt32* **Discussions**  


<a id="Ditch.Golos.Operations.Get.CategoryApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  






---

<a id="Ditch.Golos.Operations.Get.ChainProperties"></a>
## ChainProperties
*class Ditch.Golos.Operations.Get.ChainProperties*

chain_properties
golos-0.16.3\libraries\protocol\include\steemit\protocol\steem_operations.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.ChainProperties.AccountCreationFee"></a>

* *Money* **AccountCreationFee**  
  This fee, paid in STEEM, is converted into VESTING SHARES for the new account.Accounts 
without vesting shares cannot earn usage rations and therefore are powerless.This minimum 
fee requires all accounts to have some kind of commitment to the network that includes the
 ability to vote and make transactions.  


<a id="Ditch.Golos.Operations.Get.ChainProperties.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  
  This witnesses vote for the maximum_block_size which is used by the network to tune rate limiting and capacity  


<a id="Ditch.Golos.Operations.Get.ChainProperties.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  






---

<a id="Ditch.Golos.Operations.Get.CommentApiObj"></a>
## CommentApiObj
*class Ditch.Golos.Operations.Get.CommentApiObj*

comment_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.CommentApiObj.Id"></a>

* *UInt64* **Id**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Category"></a>

* *String* **Category**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.ParentAuthor"></a>

* *String* **ParentAuthor**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.ParentPermlink"></a>

* *String* **ParentPermlink**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Author"></a>

* *String* **Author**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Permlink"></a>

* *String* **Permlink**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Title"></a>

* *String* **Title**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Body"></a>

* *String* **Body**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.JsonMetadata"></a>

* *String* **JsonMetadata**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.LastUpdate"></a>

* *DateTime* **LastUpdate**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Created"></a>

* *DateTime* **Created**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Active"></a>

* *DateTime* **Active**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.LastPayout"></a>

* *DateTime* **LastPayout**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Depth"></a>

* *Byte* **Depth**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Children"></a>

* *UInt32* **Children**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.ChildrenRshares2"></a>

* *String* **ChildrenRshares2**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.NetRshares"></a>

* *Object* **NetRshares**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.AbsRshares"></a>

* *Object* **AbsRshares**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.VoteRshares"></a>

* *Object* **VoteRshares**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.ChildrenAbsRshares"></a>

* *Object* **ChildrenAbsRshares**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.CashoutTime"></a>

* *DateTime* **CashoutTime**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.MaxCashoutTime"></a>

* *DateTime* **MaxCashoutTime**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.TotalVoteWeight"></a>

* *UInt64* **TotalVoteWeight**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.RewardWeight"></a>

* *UInt16* **RewardWeight**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.TotalPayoutValue"></a>

* *Money* **TotalPayoutValue**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.CuratorPayoutValue"></a>

* *Money* **CuratorPayoutValue**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.AuthorRewards"></a>

* *Object* **AuthorRewards**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.RootComment"></a>

* *UInt64* **RootComment**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Mode"></a>

* *CommentMode* **Mode**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.MaxAcceptedPayout"></a>

* *Money* **MaxAcceptedPayout**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.PercentSteemDollars"></a>

* *UInt16* **PercentSteemDollars**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.AllowReplies"></a>

* *Boolean* **AllowReplies**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.AllowVotes"></a>

* *Boolean* **AllowVotes**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.AllowCurationRewards"></a>

* *Boolean* **AllowCurationRewards**  


<a id="Ditch.Golos.Operations.Get.CommentApiObj.Beneficiaries"></a>

* *Object[]* **Beneficiaries**  






---

<a id="Ditch.Golos.Operations.Get.ConvertRequestApiObj"></a>
## ConvertRequestApiObj
*class Ditch.Golos.Operations.Get.ConvertRequestApiObj: Ditch.Golos.Operations.Get.ConvertRequestObject*

convert_request_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Golos.Operations.Get.ConvertRequestObject"></a>
## ConvertRequestObject
*class Ditch.Golos.Operations.Get.ConvertRequestObject*

convert_request_object
golos-0.16.3\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.ConvertRequestObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.ConvertRequestObject.Owner"></a>

* *Object* **Owner**  


<a id="Ditch.Golos.Operations.Get.ConvertRequestObject.Requestid"></a>

* *UInt32* **Requestid**  
  id set by owner,the owner,requestid pair must be unique  


<a id="Ditch.Golos.Operations.Get.ConvertRequestObject.Amount"></a>

* *Money* **Amount**  






---

<a id="Ditch.Golos.Operations.Get.Discussion"></a>
## Discussion
*class Ditch.Golos.Operations.Get.Discussion: Ditch.Golos.Operations.Get.CommentApiObj*

discussion
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.Discussion.Url"></a>

* *String* **Url**  
  /category/@rootauthor/root_permlink#author/permlink  


<a id="Ditch.Golos.Operations.Get.Discussion.RootTitle"></a>

* *String* **RootTitle**  


<a id="Ditch.Golos.Operations.Get.Discussion.PendingPayoutValue"></a>

* *Money* **PendingPayoutValue**  
  sbd  


<a id="Ditch.Golos.Operations.Get.Discussion.TotalPendingPayoutValue"></a>

* *Money* **TotalPendingPayoutValue**  
  sbd including replies  


<a id="Ditch.Golos.Operations.Get.Discussion.ActiveVotes"></a>

* *VoteState[]* **ActiveVotes**  


<a id="Ditch.Golos.Operations.Get.Discussion.Replies"></a>

* *String[]* **Replies**  
  author/slug mapping  


<a id="Ditch.Golos.Operations.Get.Discussion.AuthorReputation"></a>

* *Object* **AuthorReputation**  


<a id="Ditch.Golos.Operations.Get.Discussion.Promoted"></a>

* *Money* **Promoted**  


<a id="Ditch.Golos.Operations.Get.Discussion.BodyLength"></a>

* *UInt32* **BodyLength**  


<a id="Ditch.Golos.Operations.Get.Discussion.RebloggedBy"></a>

* *String[]* **RebloggedBy**  


<a id="Ditch.Golos.Operations.Get.Discussion.FirstRebloggedBy"></a>

* *Object* **FirstRebloggedBy**  


<a id="Ditch.Golos.Operations.Get.Discussion.FirstRebloggedOn"></a>

* *Object* **FirstRebloggedOn**  






---

<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject"></a>
## DynamicGlobalPropertyObject
*class Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject*

dynamic_global_property_object
libraries\chain\include\golos\chain\objects\global_property_object.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.Id"></a>

* *String* **Id**  
  API name: id  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.HeadBlockNumber"></a>

* *UInt32* **HeadBlockNumber**  
  API name: head_block_number
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.HeadBlockId"></a>

* *String* **HeadBlockId**  
  API name: head_block_id  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.Time"></a>

* *DateTime* **Time**  
  API name: time  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.CurrentWitness"></a>

* *String* **CurrentWitness**  
  API name: current_witness  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.TotalPow"></a>

* *UInt64* **TotalPow**  
  API name: total_pow
= -1;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.NumPowWitnesses"></a>

* *UInt32* **NumPowWitnesses**  
  API name: num_pow_witnesses
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.VirtualSupply"></a>

* *Money* **VirtualSupply**  
  API name: virtual_supply
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.CurrentSupply"></a>

* *Money* **CurrentSupply**  
  API name: current_supply
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.ConfidentialSupply"></a>

* *Money* **ConfidentialSupply**  
  API name: confidential_supply
= asset<0,17,0>(0, STEEM_SYMBOL_NAME); ///< total asset held in confidential balances  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.CurrentSbdSupply"></a>

* *Money* **CurrentSbdSupply**  
  API name: current_sbd_supply
= asset<0,17,0>(0, SBD_SYMBOL_NAME);  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.ConfidentialSbdSupply"></a>

* *Money* **ConfidentialSbdSupply**  
  API name: confidential_sbd_supply
= asset<0,17,0>(0, SBD_SYMBOL_NAME); ///< total asset held in confidential balances  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.TotalVestingFundSteem"></a>

* *Money* **TotalVestingFundSteem**  
  API name: total_vesting_fund_steem
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.TotalVestingShares"></a>

* *Money* **TotalVestingShares**  
  API name: total_vesting_shares
= asset<0,17,0>(0, VESTS_SYMBOL);  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.TotalRewardFundSteem"></a>

* *Money* **TotalRewardFundSteem**  
  API name: total_reward_fund_steem
= asset<0,17,0>(0, STEEM_SYMBOL_NAME);  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.TotalRewardShares2"></a>

* *String* **TotalRewardShares2**  
  API name: total_reward_shares2
the running total of REWARD^2  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.SbdInterestRate"></a>

* *UInt16* **SbdInterestRate**  
  API name: sbd_interest_rate
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.SbdPrintRate"></a>

* *UInt16* **SbdPrintRate**  
  API name: sbd_print_rate
= STEEMIT_100_PERCENT;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.AverageBlockSize"></a>

* *UInt32* **AverageBlockSize**  
  API name: average_block_size
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.MaximumBlockSize"></a>

* *UInt32* **MaximumBlockSize**  
  API name: maximum_block_size
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.CurrentAslot"></a>

* *UInt64* **CurrentAslot**  
  API name: current_aslot
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.RecentSlotsFilled"></a>

* *String* **RecentSlotsFilled**  
  API name: recent_slots_filled  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.ParticipationCount"></a>

* *Byte* **ParticipationCount**  
  API name: participation_count
= 0; ///< Divide by 128 to compute participation percentage  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.LastIrreversibleBlockNum"></a>

* *UInt32* **LastIrreversibleBlockNum**  
  API name: last_irreversible_block_num
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.MaxVirtualBandwidth"></a>

* *UInt64* **MaxVirtualBandwidth**  
  API name: max_virtual_bandwidth
= 0;  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.CurrentReserveRatio"></a>

* *UInt64* **CurrentReserveRatio**  


<a id="Ditch.Golos.Operations.Get.DynamicGlobalPropertyObject.VoteRegenerationPerDay"></a>

* *UInt32* **VoteRegenerationPerDay**  
  API name: vote_regeneration_per_day
= 40;  






---

<a id="Ditch.Golos.Operations.Get.EscrowApiObj"></a>
## EscrowApiObj
*class Ditch.Golos.Operations.Get.EscrowApiObj: Ditch.Golos.Operations.Get.EscrowObject*

escrow_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Golos.Operations.Get.EscrowObject"></a>
## EscrowObject
*class Ditch.Golos.Operations.Get.EscrowObject*

escrow_object
golos-0.16.3\libraries\chain\include\steemit\chain\steem_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.EscrowObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.EscrowId"></a>

* *UInt32* **EscrowId**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.From"></a>

* *String* **From**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.To"></a>

* *String* **To**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.Agent"></a>

* *String* **Agent**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.RatificationDeadline"></a>

* *DateTime* **RatificationDeadline**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.EscrowExpiration"></a>

* *DateTime* **EscrowExpiration**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.SbdBalance"></a>

* *Money* **SbdBalance**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.SteemBalance"></a>

* *Money* **SteemBalance**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.PendingFee"></a>

* *Money* **PendingFee**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.ToApproved"></a>

* *Boolean* **ToApproved**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.AgentApproved"></a>

* *Boolean* **AgentApproved**  


<a id="Ditch.Golos.Operations.Get.EscrowObject.Disputed"></a>

* *Boolean* **Disputed**  






---

<a id="Ditch.Golos.Operations.Get.ExtendedAccount"></a>
## ExtendedAccount
*class Ditch.Golos.Operations.Get.ExtendedAccount: Ditch.Golos.Operations.Get.AccountApiObj*

extended_account 
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.ExtendedAccount.VestingBalance"></a>

* *Money* **VestingBalance**  
  convert vesting_shares to vesting steem  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.TransferHistory"></a>

* *Object* **TransferHistory**  
  transfer to/from vesting  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.MarketHistory"></a>

* *Object* **MarketHistory**  
  limit order / cancel / fill  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.PostHistory"></a>

* *Object* **PostHistory**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.VoteHistory"></a>

* *Object* **VoteHistory**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.OtherHistory"></a>

* *Object* **OtherHistory**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.WitnessVotes"></a>

* *String[]* **WitnessVotes**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.TagsUsage"></a>

* *KeyValuePair`2[]* **TagsUsage**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.GuestBloggers"></a>

* *KeyValuePair`2[]* **GuestBloggers**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.OpenOrders"></a>

* *Object* **OpenOrders**  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.Comments"></a>

* *String[]* **Comments**  
  permlinks for this user  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.Blog"></a>

* *String[]* **Blog**  
  blog posts for this user  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.Feed"></a>

* *String[]* **Feed**  
  feed posts for this user  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.RecentReplies"></a>

* *String[]* **RecentReplies**  
  blog posts for this user  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.BlogCategory"></a>

* *Object* **BlogCategory**  
  blog posts for this user  


<a id="Ditch.Golos.Operations.Get.ExtendedAccount.Recommended"></a>

* *String[]* **Recommended**  
  posts recommened for this user  






---

<a id="Ditch.Golos.Operations.Get.ExtendedLimitOrder"></a>
## ExtendedLimitOrder
*class Ditch.Golos.Operations.Get.ExtendedLimitOrder*

extended_limit_order
libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.ExtendedLimitOrder.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
= 0;  


<a id="Ditch.Golos.Operations.Get.ExtendedLimitOrder.Rewarded"></a>

* *Boolean* **Rewarded**  
  API name: rewarded
= false;  






---

<a id="Ditch.Golos.Operations.Get.FeedHistoryApiObj"></a>
## FeedHistoryApiObj
*class Ditch.Golos.Operations.Get.FeedHistoryApiObj*

feed_history_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.FeedHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.FeedHistoryApiObj.CurrentMedianHistory"></a>

* *Price* **CurrentMedianHistory**  


<a id="Ditch.Golos.Operations.Get.FeedHistoryApiObj.PriceHistory"></a>

* *Price[]* **PriceHistory**  






---

<a id="Ditch.Golos.Operations.Get.FollowApiObj"></a>
## FollowApiObj
*class Ditch.Golos.Operations.Get.FollowApiObj*

follow_api_obj
golos-0.16.3\libraries\plugins\follow\include\steemit\follow\follow_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.FollowApiObj.Follower"></a>

* *String* **Follower**  


<a id="Ditch.Golos.Operations.Get.FollowApiObj.Following"></a>

* *String* **Following**  


<a id="Ditch.Golos.Operations.Get.FollowApiObj.What"></a>

* *FollowType[]* **What**  






---

<a id="Ditch.Golos.Operations.Get.Order"></a>
## Order
*class Ditch.Golos.Operations.Get.Order*

order
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.Order.OrderPrice"></a>

* *Price* **OrderPrice**  
  API name: order_price  


<a id="Ditch.Golos.Operations.Get.Order.RealPrice"></a>

* *Double* **RealPrice**  
  API name: real_price
dollars per steem  


<a id="Ditch.Golos.Operations.Get.Order.Steem"></a>

* *Object* **Steem**  
  API name: steem  


<a id="Ditch.Golos.Operations.Get.Order.Sbd"></a>

* *Object* **Sbd**  
  API name: sbd  


<a id="Ditch.Golos.Operations.Get.Order.Created"></a>

* *DateTime* **Created**  
  API name: created  






---

<a id="Ditch.Golos.Operations.Get.OrderBook"></a>
## OrderBook
*class Ditch.Golos.Operations.Get.OrderBook*

order_book
libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.OrderBook.Asks"></a>

* *Order[]* **Asks**  
  API name: asks  


<a id="Ditch.Golos.Operations.Get.OrderBook.Bids"></a>

* *Order[]* **Bids**  
  API name: bids  






---

<a id="Ditch.Golos.Operations.Get.OwnerAuthorityHistoryApiObj"></a>
## OwnerAuthorityHistoryApiObj
*class Ditch.Golos.Operations.Get.OwnerAuthorityHistoryApiObj*

owner_authority_history_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.OwnerAuthorityHistoryApiObj.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.OwnerAuthorityHistoryApiObj.Account"></a>

* *String* **Account**  


<a id="Ditch.Golos.Operations.Get.OwnerAuthorityHistoryApiObj.PreviousOwnerAuthority"></a>

* *Authority* **PreviousOwnerAuthority**  


<a id="Ditch.Golos.Operations.Get.OwnerAuthorityHistoryApiObj.LastValidTime"></a>

* *DateTime* **LastValidTime**  






---

<a id="Ditch.Golos.Operations.Get.Price"></a>
## Price
*class Ditch.Golos.Operations.Get.Price*

price
golos-0.16.3\libraries\protocol\include\steemit\protocol\asset.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.Price.Base"></a>

* *Money* **Base**  


<a id="Ditch.Golos.Operations.Get.Price.Quote"></a>

* *Money* **Quote**  






---

<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj"></a>
## SavingsWithdrawApiObj
*class Ditch.Golos.Operations.Get.SavingsWithdrawApiObj*

savings_withdraw_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj.From"></a>

* *String* **From**  
  API name: from  


<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj.To"></a>

* *String* **To**  
  API name: to  


<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj.Memo"></a>

* *String* **Memo**  
  API name: memo  


<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj.RequestId"></a>

* *UInt32* **RequestId**  
  API name: request_id
= 0;  


<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj.Amount"></a>

* *Money* **Amount**  
  API name: amount  


<a id="Ditch.Golos.Operations.Get.SavingsWithdrawApiObj.Complete"></a>

* *DateTime* **Complete**  
  API name: complete  






---

<a id="Ditch.Golos.Operations.Get.ScheduledHardfork"></a>
## ScheduledHardfork
*class Ditch.Golos.Operations.Get.ScheduledHardfork*

scheduled_hardfork
golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.ScheduledHardfork.HfVersion"></a>

* *String* **HfVersion**  


<a id="Ditch.Golos.Operations.Get.ScheduledHardfork.LiveTime"></a>

* *DateTime* **LiveTime**  






---

<a id="Ditch.Golos.Operations.Get.SignedBlock"></a>
## SignedBlock
*class Ditch.Golos.Operations.Get.SignedBlock: Ditch.Golos.Operations.Get.SignedBlockHeader*

signed_block
golos-0.16.3\libraries\protocol\include\steemit\protocol\block.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.SignedBlock.Transactions"></a>

* *Object[]* **Transactions**  






---

<a id="Ditch.Golos.Operations.Get.SignedBlockApiObj"></a>
## SignedBlockApiObj
*class Ditch.Golos.Operations.Get.SignedBlockApiObj: Ditch.Golos.Operations.Get.SignedBlock*

signed_block_api_obj
golos-0.16.3\libraries\protocol\include\steemit\protocol\block.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.SignedBlockApiObj.BlockId"></a>

* *Object* **BlockId**  


<a id="Ditch.Golos.Operations.Get.SignedBlockApiObj.SigningKey"></a>

* *String* **SigningKey**  


<a id="Ditch.Golos.Operations.Get.SignedBlockApiObj.TransactionIds"></a>

* *Object[]* **TransactionIds**  






---

<a id="Ditch.Golos.Operations.Get.SignedBlockHeader"></a>
## SignedBlockHeader
*class Ditch.Golos.Operations.Get.SignedBlockHeader: Ditch.Golos.Operations.Get.BlockHeader*

signed_block_header
golos-0.16.3\libraries\protocol\include\steemit\protocol\block_header.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.SignedBlockHeader.WitnessSignature"></a>

* *Object* **WitnessSignature**  






---

<a id="Ditch.Golos.Operations.Get.State"></a>
## State
*class Ditch.Golos.Operations.Get.State*

state
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.State.CurrentRoute"></a>

* *String* **CurrentRoute**  


<a id="Ditch.Golos.Operations.Get.State.Props"></a>

* *DynamicGlobalPropertyObject* **Props**  


<a id="Ditch.Golos.Operations.Get.State.CategoryIdx"></a>

* *Object* **CategoryIdx**  


<a id="Ditch.Golos.Operations.Get.State.TagIdx"></a>

* *Object* **TagIdx**  


<a id="Ditch.Golos.Operations.Get.State.DiscussionIdx"></a>

* *Object* **DiscussionIdx**  
  is the global discussion index  


<a id="Ditch.Golos.Operations.Get.State.Categories"></a>

* *Object* **Categories**  


<a id="Ditch.Golos.Operations.Get.State.Tags"></a>

* *Object* **Tags**  


<a id="Ditch.Golos.Operations.Get.State.Content"></a>

* *Object* **Content**  
  map from account/slug to full nested discussion  


<a id="Ditch.Golos.Operations.Get.State.Accounts"></a>

* *Object* **Accounts**  


<a id="Ditch.Golos.Operations.Get.State.PowQueue"></a>

* *String[]* **PowQueue**  
  The list of miners who are queued to produce work  


<a id="Ditch.Golos.Operations.Get.State.Witnesses"></a>

* *Object* **Witnesses**  


<a id="Ditch.Golos.Operations.Get.State.WitnessSchedule"></a>

* *WitnessScheduleApiObj* **WitnessSchedule**  


<a id="Ditch.Golos.Operations.Get.State.FeedPrice"></a>

* *Price* **FeedPrice**  


<a id="Ditch.Golos.Operations.Get.State.Error"></a>

* *String* **Error**  


<a id="Ditch.Golos.Operations.Get.State.MarketData"></a>

* *Object* **MarketData**  






---

<a id="Ditch.Golos.Operations.Get.TagApiObj"></a>
## TagApiObj
*class Ditch.Golos.Operations.Get.TagApiObj*

tag_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.TagApiObj.Name"></a>

* *String* **Name**  


<a id="Ditch.Golos.Operations.Get.TagApiObj.TotalChildrenRshares2"></a>

* *String* **TotalChildrenRshares2**  


<a id="Ditch.Golos.Operations.Get.TagApiObj.TotalPayouts"></a>

* *Money* **TotalPayouts**  


<a id="Ditch.Golos.Operations.Get.TagApiObj.NetVotes"></a>

* *Int32* **NetVotes**  


<a id="Ditch.Golos.Operations.Get.TagApiObj.TopPosts"></a>

* *UInt32* **TopPosts**  


<a id="Ditch.Golos.Operations.Get.TagApiObj.Comments"></a>

* *UInt32* **Comments**  


<a id="Ditch.Golos.Operations.Get.TagApiObj.Trending"></a>

* *String* **Trending**  






---

<a id="Ditch.Golos.Operations.Get.VoteState"></a>
## VoteState
*class Ditch.Golos.Operations.Get.VoteState*

vote_state
golos-0.16.3\libraries\app\include\steemit\app\state.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.VoteState.Voter"></a>

* *String* **Voter**  


<a id="Ditch.Golos.Operations.Get.VoteState.Weight"></a>

* *UInt64* **Weight**  


<a id="Ditch.Golos.Operations.Get.VoteState.Rshares"></a>

* *Int64* **Rshares**  


<a id="Ditch.Golos.Operations.Get.VoteState.Percent"></a>

* *Int16* **Percent**  


<a id="Ditch.Golos.Operations.Get.VoteState.Reputation"></a>

* *Object* **Reputation**  


<a id="Ditch.Golos.Operations.Get.VoteState.Time"></a>

* *DateTime* **Time**  






---

<a id="Ditch.Golos.Operations.Get.WithdrawRoute"></a>
## WithdrawRoute
*class Ditch.Golos.Operations.Get.WithdrawRoute*

withdraw_route
golos-0.16.3\libraries\app\include\steemit\app\database_api.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.WithdrawRoute.FromAccount"></a>

* *String* **FromAccount**  


<a id="Ditch.Golos.Operations.Get.WithdrawRoute.ToAccount"></a>

* *String* **ToAccount**  


<a id="Ditch.Golos.Operations.Get.WithdrawRoute.Percent"></a>

* *UInt16* **Percent**  


<a id="Ditch.Golos.Operations.Get.WithdrawRoute.AutoVest"></a>

* *Boolean* **AutoVest**  






---

<a id="Ditch.Golos.Operations.Get.WitnessApiObj"></a>
## WitnessApiObj
*class Ditch.Golos.Operations.Get.WitnessApiObj*

witness_api_obj
libraries\app\include\steemit\app\steem_api_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.WitnessApiObj.Id"></a>

* *Object* **Id**  
  API name: id  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.Owner"></a>

* *String* **Owner**  
  API name: owner  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.Created"></a>

* *DateTime* **Created**  
  API name: created  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.Url"></a>

* *String* **Url**  
  API name: url  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.TotalMissed"></a>

* *UInt32* **TotalMissed**  
  API name: total_missed
= 0;  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.LastAslot"></a>

* *UInt64* **LastAslot**  
  API name: last_aslot
= 0;  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.LastConfirmedBlockNum"></a>

* *UInt64* **LastConfirmedBlockNum**  
  API name: last_confirmed_block_num
= 0;  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.PowWorker"></a>

* *UInt64* **PowWorker**  
  API name: pow_worker
= 0;  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.SigningKey"></a>

* *Object* **SigningKey**  
  API name: signing_key  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.Props"></a>

* *ChainProperties* **Props**  
  API name: props  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.SbdExchangeRate"></a>

* *Price* **SbdExchangeRate**  
  API name: sbd_exchange_rate  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.LastSbdExchangeUpdate"></a>

* *DateTime* **LastSbdExchangeUpdate**  
  API name: last_sbd_exchange_update  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.Votes"></a>

* *Object* **Votes**  
  API name: votes  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.VirtualLastUpdate"></a>

* *String* **VirtualLastUpdate**  
  API name: virtual_last_update  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.VirtualPosition"></a>

* *String* **VirtualPosition**  
  API name: virtual_position  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.VirtualScheduledTime"></a>

* *String* **VirtualScheduledTime**  
  API name: virtual_scheduled_time  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.LastWork"></a>

* *Object* **LastWork**  
  API name: last_work  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.RunningVersion"></a>

* *Version* **RunningVersion**  
  API name: running_version  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.HardforkVersionVote"></a>

* *Object* **HardforkVersionVote**  
  API name: hardfork_version_vote  


<a id="Ditch.Golos.Operations.Get.WitnessApiObj.HardforkTimeVote"></a>

* *DateTime* **HardforkTimeVote**  
  API name: hardfork_time_vote  






---

<a id="Ditch.Golos.Operations.Get.WitnessScheduleApiObj"></a>
## WitnessScheduleApiObj
*class Ditch.Golos.Operations.Get.WitnessScheduleApiObj: Ditch.Golos.Operations.Get.WitnessScheduleObject*

witness_schedule_api_obj
golos-0.16.3\libraries\app\include\steemit\app\steem_api_objects.hpp



---

<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject"></a>
## WitnessScheduleObject
*class Ditch.Golos.Operations.Get.WitnessScheduleObject*

witness_schedule_object
golos-0.16.3\libraries\chain\include\steemit\chain\witness_objects.hpp

**Properties and Fields**

<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.Id"></a>

* *Object* **Id**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.CurrentVirtualTime"></a>

* *String* **CurrentVirtualTime**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.NextShuffleBlockNum"></a>

* *UInt32* **NextShuffleBlockNum**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.CurrentShuffledWitnesses"></a>

* *Object* **CurrentShuffledWitnesses**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.NumScheduledWitnesses"></a>

* *Byte* **NumScheduledWitnesses**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.Top19Weight"></a>

* *Byte* **Top19Weight**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.TimeshareWeight"></a>

* *Byte* **TimeshareWeight**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.MinerWeight"></a>

* *Byte* **MinerWeight**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.WitnessPayNormalizationFactor"></a>

* *UInt32* **WitnessPayNormalizationFactor**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.MedianProps"></a>

* *ChainProperties* **MedianProps**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.MajorityVersion"></a>

* *String* **MajorityVersion**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.MaxVotedWitnesses"></a>

* *Byte* **MaxVotedWitnesses**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.MaxMinerWitnesses"></a>

* *Byte* **MaxMinerWitnesses**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.MaxRunnerWitnesses"></a>

* *Byte* **MaxRunnerWitnesses**  


<a id="Ditch.Golos.Operations.Get.WitnessScheduleObject.HardforkRequiredWitnesses"></a>

* *Byte* **HardforkRequiredWitnesses**  






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

