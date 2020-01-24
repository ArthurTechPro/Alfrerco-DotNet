using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Localization settings
  /// </summary>
  [DataContract]
  public class RequestLocalization {
    /// <summary>
    /// A valid timezone id supported by @see java.time.ZoneId
    /// </summary>
    /// <value>A valid timezone id supported by @see java.time.ZoneId</value>
    [DataMember(Name="timezone", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "timezone")]
    public string Timezone { get; set; }

    /// <summary>
    /// A list of Locales defined by IETF BCP 47.  The ordering is significant.  The first locale (leftmost) is used for sort and query localization, whereas the remaining locales are used for query only.
    /// </summary>
    /// <value>A list of Locales defined by IETF BCP 47.  The ordering is significant.  The first locale (leftmost) is used for sort and query localization, whereas the remaining locales are used for query only.</value>
    [DataMember(Name="locales", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locales")]
    public List<string> Locales { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestLocalization {\n");
      sb.Append("  Timezone: ").Append(Timezone).Append("\n");
      sb.Append("  Locales: ").Append(Locales).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
