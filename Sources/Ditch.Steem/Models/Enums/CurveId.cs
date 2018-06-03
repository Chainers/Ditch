using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Enums
{
    // TODO:  Rename these curves to match naming in manual.md

    /// <summary>
    /// curve_id
    /// libraries\protocol\include\steem\protocol\misc_utilities.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum CurveId
    {

        /// <summary>
        /// API name: quadratic
        /// 
        /// </summary>
        Quadratic,

        /// <summary>
        /// API name: quadratic_curation
        /// 
        /// </summary>
        QuadraticCuration,

        /// <summary>
        /// API name: linear
        /// 
        /// </summary>
        Linear,

        /// <summary>
        /// API name: square_root
        /// 
        /// </summary>
        SquareRoot
    }
}
