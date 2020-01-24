using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// A list of pivots.
  /// </summary>
  [DataContract]
  public class RequestPivot {
    /// <summary>
    /// A key corresponding to a matching field facet label or stats.
    /// </summary>
    /// <value>A key corresponding to a matching field facet label or stats.</value>
    [DataMember(Name="key", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "key")]
    public string Key { get; set; }

    /// <summary>
    /// Gets or Sets Pivots
    /// </summary>
    [DataMember(Name="pivots", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pivots")]
    public List<RequestPivot> Pivots { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestPivot {\n");
      sb.Append("  Key: ").Append(Key).Append("\n");
      sb.Append("  Pivots: ").Append(Pivots).Append("\n");
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
