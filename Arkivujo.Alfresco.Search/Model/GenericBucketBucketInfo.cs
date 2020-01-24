using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Additional information of nested facet
  /// </summary>
  [DataContract]
  public class GenericBucketBucketInfo {
    /// <summary>
    /// The start of range
    /// </summary>
    /// <value>The start of range</value>
    [DataMember(Name="start", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "start")]
    public string Start { get; set; }

    /// <summary>
    /// Includes values greater or equal to \"start\"
    /// </summary>
    /// <value>Includes values greater or equal to \"start\"</value>
    [DataMember(Name="startInclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "startInclusive")]
    public bool? StartInclusive { get; set; }

    /// <summary>
    /// The end of range
    /// </summary>
    /// <value>The end of range</value>
    [DataMember(Name="end", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "end")]
    public string End { get; set; }

    /// <summary>
    /// Includes values less than or equal to \"end\"
    /// </summary>
    /// <value>Includes values less than or equal to \"end\"</value>
    [DataMember(Name="endInclusive", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "endInclusive")]
    public bool? EndInclusive { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GenericBucketBucketInfo {\n");
      sb.Append("  Start: ").Append(Start).Append("\n");
      sb.Append("  StartInclusive: ").Append(StartInclusive).Append("\n");
      sb.Append("  End: ").Append(End).Append("\n");
      sb.Append("  EndInclusive: ").Append(EndInclusive).Append("\n");
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
