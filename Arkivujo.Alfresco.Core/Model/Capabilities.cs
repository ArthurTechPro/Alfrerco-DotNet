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
  public class Capabilities {
    /// <summary>
    /// Gets or Sets IsAdmin
    /// </summary>
    [DataMember(Name="isAdmin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isAdmin")]
    public bool? IsAdmin { get; set; }

    /// <summary>
    /// Gets or Sets IsGuest
    /// </summary>
    [DataMember(Name="isGuest", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isGuest")]
    public bool? IsGuest { get; set; }

    /// <summary>
    /// Gets or Sets IsMutable
    /// </summary>
    [DataMember(Name="isMutable", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isMutable")]
    public bool? IsMutable { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Capabilities {\n");
      sb.Append("  IsAdmin: ").Append(IsAdmin).Append("\n");
      sb.Append("  IsGuest: ").Append(IsGuest).Append("\n");
      sb.Append("  IsMutable: ").Append(IsMutable).Append("\n");
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
