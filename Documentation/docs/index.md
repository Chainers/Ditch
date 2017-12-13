# Ditch

Library for interaction with graphene-based blockchains.

***

## Overview

Ditch is a **safe**, **fast**, **simple** and **downright gorgeous** library written in **C#** using **.NET standard 2.0**

### Safe

The library independently signs transactions, therefore the user's **private key is never transferred** to third-party resources.

### Fast

For signing transaction used the most performance realization of **ECDSA [Secp256k1](https://github.com/Chainers/Cryptography.ECDSA).**

### Simple

Library already know how to generates, signs and sends transaction to blockchain. You need only set you data.

### Work anywhere

[.NET standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support) allows easily attach library to **Android**, **iOS** and **windows** applications.

### Free

The library distributed under the [MIT](https://github.com/Chainers/Ditch/blob/master/LICENSE) license.

***

## Installation

### Install with a Package Manager

To work with Steem <span class="Icon steempower" style="display: inline-block; width: 1.12rem; height: 1.12rem;"><svg viewBox="0 0 28 29" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><title>steem</title><g id="Page-1" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd"><g id="steem" fill-rule="nonzero"><path d="M4.22924444,3.23195745 C3.94488889,3.09004255 0.337866667,6.07148936 0.337866667,8.265 C0.332888889,11.2631064 4.54533333,18.0552766 5.25466667,20.6825532 C5.86506667,22.9359149 4.21928889,25.6403191 4.67164444,25.7631064 C5.0848,26.0284255 9.01475556,22.0486383 9.16782222,20.3518298 C9.36506667,17.6498936 4.57893333,9.77114894 4.19751111,7.73682979 C3.75511111,5.36253191 4.54782222,3.28502128 4.22924444,3.23195745 L4.22924444,3.23195745 L4.22924444,3.23195745 Z" id="Fill-1" fill="#1A5099"></path><path d="M13.2321778,0.130191489 C12.8700444,-0.0505957447 8.26871111,3.74778723 8.26871111,6.54844681 C8.26373333,10.3715106 13.6353778,19.0338723 14.5394667,22.3812128 C15.3172444,25.2546809 13.2197333,28.7038298 13.7934222,28.8580851 C14.3235556,29.1949787 19.3324444,24.1242979 19.5296889,21.9573191 C19.7823111,18.5131064 13.6764444,8.46738298 13.1904889,5.86910638 C12.6267556,2.84878723 13.6353778,0.197446809 13.2321778,0.130191489 L13.2321778,0.130191489 L13.2321778,0.130191489 Z" id="Fill-2" fill="#4BA2F2"></path><path d="M22.5238222,3.23195745 C22.2419556,3.09004255 18.6324444,6.07148936 18.6324444,8.265 C18.6280889,11.2631064 22.8399111,18.0552766 23.5498667,20.6825532 C24.1596444,22.9359149 22.5144889,25.6403191 22.9662222,25.7631064 C23.3818667,26.0284255 27.3124444,22.0486383 27.4630222,20.3518298 C27.6596444,17.6498936 22.8741333,9.77114894 22.4920889,7.73682979 C22.0503111,5.36253191 22.8424,3.28502128 22.5238222,3.23195745 L22.5238222,3.23195745 Z" id="Fill-3" fill="#1A5099"></path></g></g></svg></span> blockchain, install [Ditch.Steem](https://www.nuget.org/packages/Ditch.Steem):

`PM> Install-Package Ditch.Steem`

To work with Golos <span class="Icon golos" style="display: inline-block; width: 1.12rem; height: 1.12rem;"><svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 158 171.8" style="enable-background:new 0 0 158 171.8;" xml:space="preserve"><title>golos</title><style type="text/css"> .st0{fill:url(#XMLID_33_);} .st1{fill:url(#XMLID_34_);} .st2{fill:#FFFFFF;} </style><g id="XMLID_16_"><linearGradient id="XMLID_33_" gradientUnits="userSpaceOnUse" x1="17.9143" y1="36.2467" x2="91.7842" y2="36.2467"><stop offset="0" style="stop-color:#FF3F3F"></stop><stop offset="1" style="stop-color:#EB0000"></stop></linearGradient><path id="XMLID_3_" class="st0" d="M70.8,66L70.8,66c12.3-5.1,20.9-17.4,20.9-31.7C91.8,15.4,76.6,0,58,0 C39.3,0,24.1,15.4,24.1,34.3c0,10.3,4.5,19.5,11.6,25.8L17.9,72C17.9,72,53.6,75.1,70.8,66z"></path><linearGradient id="XMLID_34_" gradientUnits="userSpaceOnUse" x1="2.400511e-06" y1="89.2769" x2="157.8291" y2="89.2769"><stop offset="0" style="stop-color:#2482C5"></stop><stop offset="1" style="stop-color:#285FAC"></stop></linearGradient><path id="XMLID_11_" class="st1" d="M143.1,103.5c-17-6.1-40.7,5.7-40.7,5.7s18.3-24.5,17.9-60.7C120.1,22,110.7,13.4,103.5,7 c0.6,3.6,0.9,7.3,0.9,11c0,38.4-23.8,64.2-62.1,64.2c-15.9,0-30.5-0.1-42.2-9c0.2,0.6,1.9,7.9,8.7,15.5c3,3.4,7.1,6.8,12.4,9.7 c17.2,9.3,30.4,10.4,31.7,10.5c0.1,0.1,0.1,0.3,0.2,0.4c0,19.1-13.4,46.4-32.4,46.4c-2.9,0-5.7-0.4-8.4-1c-7.4-1.5-12-5.3-12-5.3 s2.6,19.9,24,21.9c23.5,2.2,34.3-2.9,57.6-17.1c24.9-15.2,43.8-31.3,58.3-27.3c11,3,12.8,20.5,12.8,20.5s3.3-6.9,4.3-13 C158.3,128,160.1,109.6,143.1,103.5z"></path></g><g id="XMLID_14_"><path id="XMLID_12_" class="st2" d="M57.2,11.1c7.1,0,13.5,3.2,17.8,8.2l2.7-2.3c-5-5.7-12.4-9.4-20.5-9.4c-5.7,0-11,1.8-15.4,4.8 l2,2.9C47.6,12.7,52.2,11.1,57.2,11.1z"></path></g></svg></span> blockchain, install [Ditch.Golos](https://www.nuget.org/packages/Ditch.Golos):

`PM> Install-Package Ditch.Golos`

### Installation from source code

**Ditch** is **open source** library. You may **download** the latest version from [github](https://github.com/Chainers/Ditch).

Open **Ditch.sln** in Visual Studio 2017 and build&nbsp;it

or 

open **Automation** directory and run **build_solution.cmd**

or

open **cmd** and type `dotnet build *path to Ditch*\Sources\Ditch.sln`
	
> **Note:**

> When the installation is performed through the Package Manager, then all dependent libraries will be loaded automatically. 

> When the installation is performed from the source code - you need to add all references manually!


## Getting Started

All work is managed by OperationManager. It is necessary to add it to the code and initialize.

### Initializing

``` C#
private readonly OperationManager _operationManager;

public void InitializeOperationManager
{
    //specify how to parse json
    var jss = new JsonSerializerSettings
    {
        DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
        Culture = CultureInfo.InvariantCulture
    };
	
	//specify how to connect to blockchain
    var cm = new WebSocketManager(jss);
    _operationManager = new OperationManager(cm, jss);
}	
```

> **Note:**

> Different blockhouses may require different ways to connect (http/https or ws/wss)

> Chose **HttpManager** for https connections or **WebSocketManager** for wss connections.


### Connection to blockchain

Before sending / receiving messages it is also necessary to establish a network connection:

``` C#
public void ConnectToNode()
{
    var cUrls = new List<string> { "wss://ws.golos.io" };
    var conectedTo = _operationManager.TryConnectTo(cUrls, CancellationToken.None);
}
```

You may specify several endpoints. OperationManager sequentially get endpoint from the list, connect to the node and download the node parameters witch necessary for further work.

*conectedTo* returns the endpoint to which the OperationManager was connected or null in case there is no connection.

## Execute get request

To get data from the blockchain, you may use ready-made api methods like:

``` C#
// get node configuration
var dynamicGlobalProperties = _operationManager.GetDynamicGlobalProperties(CancellationToken.None);
```

``` C#
// get hardfork version
var hardforkVersion = _operationManager.GetHardforkVersion(CancellationToken.None);
```

or you also may execute custom request like:

``` C#	
// get node configuration
var dynamicGlobalProperties = _operationManager.CallRequest<object>(KnownApiNames.DatabaseApi, "get_dynamic_global_properties", new object[] { }, CancellationToken.None);
```

``` C#
// get hardfork version
var someClass = _operationManager.CallRequest<SomeClass>("Some blockshain api name", "some blockshain api method name", new object[] { *some input parameters* }, CancellationToken.None);
```

## Execute post request

To write some data to the blockchain you also may use ready-made api methods like:

``` C#
//operation vote up
var operation = new VoteOperation("YouLogin", "some author", "some authors post permlink", 10000);
var responce = _operationManager.BroadcastOperations(new byte[] { Base58.TryGetBytes("you private posting key")}, ct, operation);
```

``` C#
// operations create new post with beneficiaries
var postOperation = new PostOperation("some category", "YouLogin", "post title", "post body", "some metadata");
var beneficiariesOperation = new BeneficiariesOperation("YouLogin", postOperation.Permlink, _operationManager.SbdSymbol, new Beneficiary("KorzunAV", 500));
var responce = _operationManager.BroadcastOperations(new byte[] { Base58.TryGetBytes("you private posting key")}, ct, postOperation, beneficiariesOperation);
```

or you also may execute custom request like:

``` C#
// operation follow
var operation = new FollowOperation("YouLogin", "KorzunAV", FollowType.Blog, "YouLogin");
var prop = _operationManager.GetDynamicGlobalProperties(CancellationToken.None);
var transaction = _operationManager.CreateTransaction(prop.Result, new byte[] { Base58.TryGetBytes("you private posting key")}, CancellationToken.None, operation);
var resp = _operationManager.BroadcastTransaction(transaction, CancellationToken.None);
```

``` C#
// operation follow
var operation = new SomeCustomOperationInheritBaseOperation(*some parameters*);
var prop = _operationManager.GetDynamicGlobalProperties(CancellationToken.None);
var transaction = _operationManager.CreateTransaction(prop.Result, new byte[] { Base58.TryGetBytes("you private posting key")}, CancellationToken.None, operation);
var resp = _operationManager.BroadcastTransaction(transaction, CancellationToken.None);
```

## Supported blockchains

<svg width="164px" height="164px" version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 158 171.8" style="enable-background:new 0 0 158 171.8;" xml:space="preserve">
<title>golos</title>
<style type="text/css"> .st0{fill:url(#XMLID_33_);} .st1{fill:url(#XMLID_34_);} .st2{fill:#FFFFFF;} </style><g id="XMLID_16_">
<linearGradient id="XMLID_33_" gradientUnits="userSpaceOnUse" x1="17.9143" y1="36.2467" x2="91.7842" y2="36.2467"><stop offset="0" style="stop-color:#FF3F3F"></stop><stop offset="1" style="stop-color:#EB0000"></stop></linearGradient>
<path id="XMLID_3_" class="st0" d="M70.8,66L70.8,66c12.3-5.1,20.9-17.4,20.9-31.7C91.8,15.4,76.6,0,58,0 C39.3,0,24.1,15.4,24.1,34.3c0,10.3,4.5,19.5,11.6,25.8L17.9,72C17.9,72,53.6,75.1,70.8,66z"></path>
<linearGradient id="XMLID_34_" gradientUnits="userSpaceOnUse" x1="2.400511e-06" y1="89.2769" x2="157.8291" y2="89.2769"><stop offset="0" style="stop-color:#2482C5"></stop><stop offset="1" style="stop-color:#285FAC"></stop></linearGradient>
<path id="XMLID_11_" class="st1" d="M143.1,103.5c-17-6.1-40.7,5.7-40.7,5.7s18.3-24.5,17.9-60.7C120.1,22,110.7,13.4,103.5,7 c0.6,3.6,0.9,7.3,0.9,11c0,38.4-23.8,64.2-62.1,64.2c-15.9,0-30.5-0.1-42.2-9c0.2,0.6,1.9,7.9,8.7,15.5c3,3.4,7.1,6.8,12.4,9.7 c17.2,9.3,30.4,10.4,31.7,10.5c0.1,0.1,0.1,0.3,0.2,0.4c0,19.1-13.4,46.4-32.4,46.4c-2.9,0-5.7-0.4-8.4-1c-7.4-1.5-12-5.3-12-5.3 s2.6,19.9,24,21.9c23.5,2.2,34.3-2.9,57.6-17.1c24.9-15.2,43.8-31.3,58.3-27.3c11,3,12.8,20.5,12.8,20.5s3.3-6.9,4.3-13 C158.3,128,160.1,109.6,143.1,103.5z"></path></g><g id="XMLID_14_"><path id="XMLID_12_" class="st2" d="M57.2,11.1c7.1,0,13.5,3.2,17.8,8.2l2.7-2.3c-5-5.7-12.4-9.4-20.5-9.4c-5.7,0-11,1.8-15.4,4.8 l2,2.9C47.6,12.7,52.2,11.1,57.2,11.1z"></path>
</g>
</svg> <svg width="164px" height="164px" viewBox="0 0 28 29" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
 <title>steem</title>
 <desc>Created with Sketch.</desc>
 <defs></defs>
 <g id="Page-1" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
 <g id="steem" fill-rule="nonzero">
 <path d="M4.22924444,3.23195745 C3.94488889,3.09004255 0.337866667,6.07148936 0.337866667,8.265 C0.332888889,11.2631064 4.54533333,18.0552766 5.25466667,20.6825532 C5.86506667,22.9359149 4.21928889,25.6403191 4.67164444,25.7631064 C5.0848,26.0284255 9.01475556,22.0486383 9.16782222,20.3518298 C9.36506667,17.6498936 4.57893333,9.77114894 4.19751111,7.73682979 C3.75511111,5.36253191 4.54782222,3.28502128 4.22924444,3.23195745 L4.22924444,3.23195745 L4.22924444,3.23195745 Z" id="Fill-1" fill="#1A5099"></path>
 <path d="M13.2321778,0.130191489 C12.8700444,-0.0505957447 8.26871111,3.74778723 8.26871111,6.54844681 C8.26373333,10.3715106 13.6353778,19.0338723 14.5394667,22.3812128 C15.3172444,25.2546809 13.2197333,28.7038298 13.7934222,28.8580851 C14.3235556,29.1949787 19.3324444,24.1242979 19.5296889,21.9573191 C19.7823111,18.5131064 13.6764444,8.46738298 13.1904889,5.86910638 C12.6267556,2.84878723 13.6353778,0.197446809 13.2321778,0.130191489 L13.2321778,0.130191489 L13.2321778,0.130191489 Z" id="Fill-2" fill="#4BA2F2"></path>
 <path d="M22.5238222,3.23195745 C22.2419556,3.09004255 18.6324444,6.07148936 18.6324444,8.265 C18.6280889,11.2631064 22.8399111,18.0552766 23.5498667,20.6825532 C24.1596444,22.9359149 22.5144889,25.6403191 22.9662222,25.7631064 C23.3818667,26.0284255 27.3124444,22.0486383 27.4630222,20.3518298 C27.6596444,17.6498936 22.8741333,9.77114894 22.4920889,7.73682979 C22.0503111,5.36253191 22.8424,3.28502128 22.5238222,3.23195745 L22.5238222,3.23195745 Z" id="Fill-3" fill="#1A5099"></path>
 </g></g>
</svg>

## Our Plans

<svg width="164px" height="251px" viewBox="0 0 328 502" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
    <title>BitShares</title>
    <desc>Created with Sketch.</desc>
    <defs>
        <filter x="-50%" y="-50%" width="200%" height="200%" filterUnits="objectBoundingBox" id="filter-1">
            <feOffset dx="-1" dy="3" in="SourceAlpha" result="shadowOffsetOuter1"></feOffset>
            <feGaussianBlur stdDeviation="0.5" in="shadowOffsetOuter1" result="shadowBlurOuter1"></feGaussianBlur>
            <feColorMatrix values="0 0 0 0 0.253253169   0 0 0 0 0.335172461   0 0 0 0 0.39758716  0 0 0 0.688377491 0" type="matrix" in="shadowBlurOuter1" result="shadowMatrixOuter1"></feColorMatrix>
            <feMerge>
                <feMergeNode in="shadowMatrixOuter1"></feMergeNode>
                <feMergeNode in="SourceGraphic"></feMergeNode>
            </feMerge>
        </filter>
    </defs>
    <g id="Github-avatars" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
        <g id="bts-logo-v2">
            <g id="Group" transform="translate(19.000000, 12.000000)">
                <g filter="url(#filter-1)" transform="translate(0.000000, 0.000000)">
                    <path d="M104.448454,298.423579 L7.10542736e-15,196.450628 L7.10542736e-15,318.568585 L95.5321227,318.568585 C97.1698162,311.259335 100.263237,304.306634 104.448454,298.423579 L104.448454,298.423579 Z" id="Shape-13" fill="#4BAFCE"></path>
                    <path d="M96.2313554,339.806491 L-7.10542736e-15,339.806491 C2.19122631,373.22335 15.7037886,403.388839 36.7030407,427.412852 L104.448454,360.398501 C100.613808,354.076393 97.5095708,347.212389 96.2313554,339.806491 L96.2313554,339.806491 Z" id="Shape-14" fill="#62B5D0"></path>
                    <path d="M246.391225,219.558917 C222.519659,198.924361 191.905743,185.53 158.011764,183.176936 L158.011764,278.204497 C165.665243,279.652536 172.407594,282.36761 178.238816,286.711727 L246.391225,219.558917 L246.391225,219.558917 Z" id="Shape-15" fill="#B2D4DF"></path>
                    <path d="M192.827915,358.328438 L259.65946,424.758114 C279.547668,401.427584 292.089781,372.219898 294.598204,339.806491 L200.532356,339.806491 C198.740626,346.752221 196.411376,352.807473 192.827915,358.328438 L192.827915,358.328438 Z" id="Shape-16" fill="#9EC8D7"></path>
                    <path d="M201.410218,318.568585 L297.276369,318.568585 C295.085143,285.151726 281.572581,254.986237 260.573329,230.962224 L192.827915,297.976575 C196.845164,304.298683 199.766799,311.343318 201.410218,318.568585 L201.410218,318.568585 Z" id="Shape-17" fill="#B1D0DA"></path>
                    <path d="M50.8851443,441.470897 C74.7567101,462.105453 105.370627,475.499814 139.264605,477.852878 L139.264605,382.825317 C131.611126,381.377278 124.868776,378.662205 119.037554,374.318088 L50.8851443,441.470897 L50.8851443,441.470897 Z" id="Shape-18" fill="#77BBD2"></path>
                    <path d="M160.689929,382.825317 L160.689929,477.852878 C194.583908,475.680819 225.197825,462.105453 249.069391,441.470897 L181.645884,374.318088 C175.085759,378.662205 168.161183,381.377278 160.689929,382.825317 L160.689929,382.825317 Z" id="Shape-19" fill="#8AC1D5"></path>
                    <path d="M0.36456703,165.295654 C26.0665426,190.62901 106.81814,270.581799 120.30712,284.056988 C126.140192,280.822943 132.155548,277.948236 139.264605,276.510883 L139.264605,121.81571 L0,1.42108547e-13 C-1.29520227e-14,0.179669189 0.36456703,161.522601 0.36456703,165.295654 L0.36456703,165.295654 Z" id="Shape-20" fill="#00587C"></path>
                </g>
            </g>
        </g>
    </g>
</svg>

## Getting help

To get help with Ditch, please use the [telegram ru](https://t.me/steepshot_ru), [telegram en](https://t.me/steepshot_en), [GitHab issues](https://github.com/Chainers/Ditch/issues).
