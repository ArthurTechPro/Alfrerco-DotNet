using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RequestPagination {
    /// <summary>
    /// The maximum number of items to return in the query results
    /// </summary>
    /// <value>The maximum number of items to return in the query results</value>
    [DataMember(Name="maxItems", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxItems")]
    public int? MaxItems { get; set; }

    /// <summary>
    /// The number of items to skip from the start of the query set
    /// </summary>
    /// <value>The number of items to skip from the start of the query set</value>
    [DataMember(Name="skipCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "skipCount")]
    public int? SkipCount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestPagination {\n");
      sb.Append("  MaxItems: ").Append(MaxItems).Append("\n");
      sb.Append("  SkipCount: ").Append(SkipCount).Append("\n");
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
