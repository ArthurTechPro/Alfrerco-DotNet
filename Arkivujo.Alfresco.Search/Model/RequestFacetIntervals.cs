using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Facet Intervals
  /// </summary>
  [DataContract]
  public class RequestFacetIntervals {
    /// <summary>
    /// Sets the intervals for all fields.
    /// </summary>
    /// <value>Sets the intervals for all fields.</value>
    [DataMember(Name="sets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sets")]
    public List<RequestFacetSet> Sets { get; set; }

    /// <summary>
    /// Specifies the fields to facet by interval.
    /// </summary>
    /// <value>Specifies the fields to facet by interval.</value>
    [DataMember(Name="intervals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "intervals")]
    public List<RequestFacetIntervalsIntervals> Intervals { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestFacetIntervals {\n");
      sb.Append("  Sets: ").Append(Sets).Append("\n");
      sb.Append("  Intervals: ").Append(Intervals).Append("\n");
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
