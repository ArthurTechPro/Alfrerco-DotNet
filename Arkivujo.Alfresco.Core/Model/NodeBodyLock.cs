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
  public class NodeBodyLock {
    /// <summary>
    /// Gets or Sets TimeToExpire
    /// </summary>
    [DataMember(Name="timeToExpire", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "timeToExpire")]
    public int? TimeToExpire { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets Lifetime
    /// </summary>
    [DataMember(Name="lifetime", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lifetime")]
    public string Lifetime { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class NodeBodyLock {\n");
      sb.Append("  TimeToExpire: ").Append(TimeToExpire).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Lifetime: ").Append(Lifetime).Append("\n");
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
