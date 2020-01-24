using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Core.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Pagination {
    /// <summary>
    /// The number of objects in the entries array. 
    /// </summary>
    /// <value>The number of objects in the entries array. </value>
    [DataMember(Name="count", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "count")]
    public long? Count { get; set; }

    /// <summary>
    /// A boolean value which is **true** if there are more entities in the collection beyond those in this response. A true value means a request with a larger value for the **skipCount** or the **maxItems** parameter will return more entities. 
    /// </summary>
    /// <value>A boolean value which is **true** if there are more entities in the collection beyond those in this response. A true value means a request with a larger value for the **skipCount** or the **maxItems** parameter will return more entities. </value>
    [DataMember(Name="hasMoreItems", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hasMoreItems")]
    public bool? HasMoreItems { get; set; }

    /// <summary>
    /// An integer describing the total number of entities in the collection. The API might not be able to determine this value, in which case this property will not be present. 
    /// </summary>
    /// <value>An integer describing the total number of entities in the collection. The API might not be able to determine this value, in which case this property will not be present. </value>
    [DataMember(Name="totalItems", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalItems")]
    public long? TotalItems { get; set; }

    /// <summary>
    /// An integer describing how many entities exist in the collection before those included in this list. If there was no **skipCount** parameter then the default value is 0. 
    /// </summary>
    /// <value>An integer describing how many entities exist in the collection before those included in this list. If there was no **skipCount** parameter then the default value is 0. </value>
    [DataMember(Name="skipCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "skipCount")]
    public long? SkipCount { get; set; }

    /// <summary>
    /// The value of the **maxItems** parameter used to generate this list. If there was no **maxItems** parameter then the default value is 100. 
    /// </summary>
    /// <value>The value of the **maxItems** parameter used to generate this list. If there was no **maxItems** parameter then the default value is 100. </value>
    [DataMember(Name="maxItems", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxItems")]
    public long? MaxItems { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Pagination {\n");
      sb.Append("  Count: ").Append(Count).Append("\n");
      sb.Append("  HasMoreItems: ").Append(HasMoreItems).Append("\n");
      sb.Append("  TotalItems: ").Append(TotalItems).Append("\n");
      sb.Append("  SkipCount: ").Append(SkipCount).Append("\n");
      sb.Append("  MaxItems: ").Append(MaxItems).Append("\n");
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
