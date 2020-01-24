using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Facet range
  /// </summary>
  [DataContract]
  public class RequestRange {
    /// <summary>
    /// The name of the field to perform range
    /// </summary>
    /// <value>The name of the field to perform range</value>
    [DataMember(Name="field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "field")]
    public string Field { get; set; }

    /// <summary>
    /// The start of the range
    /// </summary>
    /// <value>The start of the range</value>
    [DataMember(Name="start", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "start")]
    public string Start { get; set; }

    /// <summary>
    /// The end of the range
    /// </summary>
    /// <value>The end of the range</value>
    [DataMember(Name="end", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "end")]
    public string End { get; set; }

    /// <summary>
    /// Bucket size
    /// </summary>
    /// <value>Bucket size</value>
    [DataMember(Name="gap", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "gap")]
    public string Gap { get; set; }

    /// <summary>
    /// If true means that the last bucket will end at “end” even if it is less than “gap” wide.
    /// </summary>
    /// <value>If true means that the last bucket will end at “end” even if it is less than “gap” wide.</value>
    [DataMember(Name="hardend", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hardend")]
    public bool? Hardend { get; set; }

    /// <summary>
    /// before, after, between, non, all
    /// </summary>
    /// <value>before, after, between, non, all</value>
    [DataMember(Name="other", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "other")]
    public List<string> Other { get; set; }

    /// <summary>
    /// lower, upper, edge, outer, all
    /// </summary>
    /// <value>lower, upper, edge, outer, all</value>
    [DataMember(Name="include", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "include")]
    public List<string> Include { get; set; }

    /// <summary>
    /// A label to include as a pivot reference
    /// </summary>
    /// <value>A label to include as a pivot reference</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// Filter queries to exclude when calculating statistics
    /// </summary>
    /// <value>Filter queries to exclude when calculating statistics</value>
    [DataMember(Name="excludeFilters", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "excludeFilters")]
    public List<string> ExcludeFilters { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestRange {\n");
      sb.Append("  Field: ").Append(Field).Append("\n");
      sb.Append("  Start: ").Append(Start).Append("\n");
      sb.Append("  End: ").Append(End).Append("\n");
      sb.Append("  Gap: ").Append(Gap).Append("\n");
      sb.Append("  Hardend: ").Append(Hardend).Append("\n");
      sb.Append("  Other: ").Append(Other).Append("\n");
      sb.Append("  Include: ").Append(Include).Append("\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  ExcludeFilters: ").Append(ExcludeFilters).Append("\n");
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
