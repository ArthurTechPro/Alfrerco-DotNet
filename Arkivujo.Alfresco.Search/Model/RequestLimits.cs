using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Limit the time and resources used for query execution
  /// </summary>
  [DataContract]
  public class RequestLimits {
    /// <summary>
    /// Maximum time for post query permission evaluation
    /// </summary>
    /// <value>Maximum time for post query permission evaluation</value>
    [DataMember(Name="permissionEvaluationTime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "permissionEvaluationTime")]
    public int? PermissionEvaluationTime { get; set; }

    /// <summary>
    /// Maximum count of post query permission evaluations
    /// </summary>
    /// <value>Maximum count of post query permission evaluations</value>
    [DataMember(Name="permissionEvaluationCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "permissionEvaluationCount")]
    public int? PermissionEvaluationCount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestLimits {\n");
      sb.Append("  PermissionEvaluationTime: ").Append(PermissionEvaluationTime).Append("\n");
      sb.Append("  PermissionEvaluationCount: ").Append(PermissionEvaluationCount).Append("\n");
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
