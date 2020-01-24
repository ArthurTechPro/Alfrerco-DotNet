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
  public class ActionBodyExec {
    /// <summary>
    /// Gets or Sets ActionDefinitionId
    /// </summary>
    [DataMember(Name="actionDefinitionId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "actionDefinitionId")]
    public string ActionDefinitionId { get; set; }

    /// <summary>
    /// The entity upon which to execute the action, typically a node ID or similar.
    /// </summary>
    /// <value>The entity upon which to execute the action, typically a node ID or similar.</value>
    [DataMember(Name="targetId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "targetId")]
    public string TargetId { get; set; }

    /// <summary>
    /// Gets or Sets Params
    /// </summary>
    [DataMember(Name="params", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "params")]
    public Object Params { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ActionBodyExec {\n");
      sb.Append("  ActionDefinitionId: ").Append(ActionDefinitionId).Append("\n");
      sb.Append("  TargetId: ").Append(TargetId).Append("\n");
      sb.Append("  Params: ").Append(Params).Append("\n");
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
