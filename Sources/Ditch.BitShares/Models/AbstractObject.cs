using Ditch.Core;
using System;
using System.Collections.Generic;
using Ditch.BitShares.Models;
using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     * @class abstract_object
     * @brief   Use the Curiously Recurring Template Pattern to automatically add the ability to
     *  clone, serialize, and move objects polymorphically.
     *
     *  http://en.wikipedia.org/wiki/Curiously_recurring_template_pattern
     */

    /// <summary>
    /// abstract_object
    /// libraries\db\include\graphene\db\object.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class AbstractObject<DerivedClass> : Object
    {
    }
}
