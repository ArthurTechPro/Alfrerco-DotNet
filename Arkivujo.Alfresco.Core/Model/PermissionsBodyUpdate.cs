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
  public class PermissionsBodyUpdate {
    /// <summary>
    /// Gets or Sets IsInheritanceEnabled
    /// </summary>
    [DataMember(Name="isInheritanceEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isInheritanceEnabled")]
    public bool? IsInheritanceEnabled { get; set; }

    /// <summary>
    /// Gets or Sets LocallySet
    /// </summary>
    [DataMember(Name="locallySet", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "locallySet")]
    public List<PermissionElement> LocallySet { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PermissionsBodyUpdate {\n");
      sb.Append("  IsInheritanceEnabled: ").Append(IsInheritanceEnabled).Append("\n");
      sb.Append("  LocallySet: ").Append(LocallySet).Append("\n");
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
