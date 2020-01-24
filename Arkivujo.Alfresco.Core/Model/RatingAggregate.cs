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
  public class RatingAggregate {
    /// <summary>
    /// Gets or Sets NumberOfRatings
    /// </summary>
    [DataMember(Name="numberOfRatings", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numberOfRatings")]
    public int? NumberOfRatings { get; set; }

    /// <summary>
    /// Gets or Sets Average
    /// </summary>
    [DataMember(Name="average", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "average")]
    public int? Average { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RatingAggregate {\n");
      sb.Append("  NumberOfRatings: ").Append(NumberOfRatings).Append("\n");
      sb.Append("  Average: ").Append(Average).Append("\n");
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
