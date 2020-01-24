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
  public class RequestFacetIntervalsIntervals {
    /// <summary>
    /// The field to facet on
    /// </summary>
    /// <value>The field to facet on</value>
    [DataMember(Name="field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "field")]
    public string Field { get; set; }

    /// <summary>
    /// A label to use to identify the field facet
    /// </summary>
    /// <value>A label to use to identify the field facet</value>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// Sets the intervals for all fields.
    /// </summary>
    /// <value>Sets the intervals for all fields.</value>
    [DataMember(Name="sets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sets")]
    public List<RequestFacetSet> Sets { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestFacetIntervalsIntervals {\n");
      sb.Append("  Field: ").Append(Field).Append("\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  Sets: ").Append(Sets).Append("\n");
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
