using System;
using System.Threading;
using Ditch.Core.JsonRpc;
using Ditch.Core.Models;
using Ditch.Golos.Models.ApiObj;
using Newtonsoft.Json.Linq;

namespace Ditch.Golos
{

    public partial class OperationManager
    {

        /// <summary>
        ///     API name: get_trending_tags
        ///     *Returns a list of tags (tags) that include word combinations
        /// </summary>
        /// <param name="afterTag">API type: std::string</param>
        /// <param name="limit">API type: uint32_t</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: tag_api_obj</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<TagApiObj[]> GetTrendingTags(string afterTag, uint limit, CancellationToken token)
        {
            return CustomGetRequest<TagApiObj[]>(KnownApiNames.Tags, "get_trending_tags", new object[] { afterTag, limit }, token);
        }

        /// <summary>
        /// API name: get_tags_used_by_author
        /// Used to retrieve top 1000 tags list used by an author sorted by most frequently used
        ///
        /// 
        /// </summary>
        /// <param name="author">API type: std::string select tags of this author</param>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>vector of top 1000 tags used by an author sorted by most frequently used</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<MapContainer<string, UInt32>> GetTagsUsedByAuthor(string author, CancellationToken token)
        {
            return CustomGetRequest<MapContainer<string, UInt32>>(KnownApiNames.Tags, "get_tags_used_by_author", new object[] { author }, token);
        }

        /// <summary>
        /// API name: get_languages
        /// 
        /// </summary>
        /// <param name="token">Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.</param>
        /// <returns>API type: discussion  Vector of discussions sorted by children posts amount</returns>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        public JsonRpcResponse<JObject> GetLanguages(CancellationToken token)
        {
            return CustomGetRequest<JObject>(KnownApiNames.Tags, "get_languages", token);
        }
    }
}