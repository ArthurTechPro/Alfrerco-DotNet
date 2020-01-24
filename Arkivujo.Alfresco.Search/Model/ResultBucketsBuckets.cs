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
  public class ResultBucketsBuckets {
    /// <summary>
    /// The bucket label
    /// </summary>
    /// <value>The bucket label</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// The filter query you can use to apply this facet
    /// </summary>
    /// <value>The filter query you can use to apply this facet</value>
    [DataMember(Name="filterQuery", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "filterQuery")]
    public string FilterQuery { get; set; }

    /// <summary>
    /// The count for the bucket
    /// </summary>
    /// <value>The count for the bucket</value>
    [DataMember(Name="count", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "count")]
    public int? Count { get; set; }

    /// <summary>
    /// An optional field for additional display information
    /// </summary>
    /// <value>An optional field for additional display information</value>
    [DataMember(Name="display", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "display")]
    public Object Display { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResultBucketsBuckets {\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  FilterQuery: ").Append(FilterQuery).Append("\n");
      sb.Append("  Count: ").Append(Count).Append("\n");
      sb.Append("  Display: ").Append(Display).Append("\n");
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
