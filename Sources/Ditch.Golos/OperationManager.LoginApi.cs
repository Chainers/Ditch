﻿using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Golos.Operations.Enums;
using Ditch.Golos.Operations.Get;

namespace Ditch.Golos
{   /**
           * @brief The login_api class implements the bottom layer of the RPC API
           *
           * All other APIs must be requested from this Api.
           */

    /// <summary>
    /// login_api
    /// \libraries\application\include\golos\application\Api.hpp
    /// </summary>
    public partial class OperationManager
    {

        /**
          * @brief Authenticate to the RPC server
          * @param user Username to login with
          * @param password Password to login with
          * @return True if logged in successfully; false otherwise
          *
          * @note This must be called prior to requesting other APIs. Other APIs may not be accessible until the client
          * has sucessfully authenticated.
          */
        /// <summary>
        /// API name: login
        /// 
        /// </summary>
        /// <param name="user">API type: string</param>
        /// <param name="password">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: bool</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<bool> Login(string user, string password, CancellationToken token)
        {
            return CustomGetRequest<bool>("login", token, user, password);
        }

        /// <summary>
        /// API name: get_api_by_name
        /// 
        /// </summary>
        /// <param name="apiName">API type: string</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: api_ptr</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<ApiPtr> GetApiByName(string apiName, CancellationToken token)
        //{
        //    return CustomGetRequest<ApiPtr>("get_api_by_name", token, apiName);
        //}

        ///// <summary>
        ///// API name: get_version
        ///// 
        ///// </summary>
        ///// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        ///// <returns>API type: steem_version_info</returns>
        ///// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<SteemVersionInfo> GetVersion(CancellationToken token)
        //{
        //    return CustomGetRequest<SteemVersionInfo>("get_version", token);
        //}


        /// internal method, not exposed via JSON RPC
        /// <summary>
        /// API name: on_api_startup
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: void</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse OnApiStartup(CancellationToken token)
        //{
        //    return CustomGetRequest("on_api_startup", token);
        //}

        #region follow_api

        /// <summary>
        /// 
        /// Возвращает список: Либо всех подписчиков пользователя 'following'. 
        /// Либо если указано имя пользователя в параметре 'startFollower' возвращается список совпадающих подписчиков
        /// </summary>
        /// <param name="following"></param>
        /// <param name="startFollower"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<FollowApiObj[]> GetFollowers(string following, string startFollower, FollowType followType, UInt16 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<FollowApiObj[]>("call", token, "follow_api", "get_followers", new object[] { following, startFollower, followType.ToString().ToLower(), limit });
        //}

        /// <summary>
        /// 
        /// Aналогично GetFollowers только для подписок
        /// </summary>
        /// <param name="follower"></param>
        /// <param name="startFollowing"></param>
        /// <param name="followType"></param>
        /// <param name="limit"></param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns></returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        //public JsonRpcResponse<FollowApiObj[]> GetFollowing(string follower, string startFollowing, FollowType followType, UInt16 limit, CancellationToken token)
        //{
        //    return CustomGetRequest<FollowApiObj[]>("call", token, "follow_api", "get_following", new object[] { follower, startFollowing, followType.ToString().ToLower(), limit });
        //}

        #endregion
    }
}