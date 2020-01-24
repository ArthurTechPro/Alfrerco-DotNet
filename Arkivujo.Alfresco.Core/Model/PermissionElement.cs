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
  public class PermissionElement {
    /// <summary>
    /// Gets or Sets AuthorityId
    /// </summary>
    [DataMember(Name="authorityId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authorityId")]
    public string AuthorityId { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets AccessStatus
    /// </summary>
    [DataMember(Name="accessStatus", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessStatus")]
    public string AccessStatus { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PermissionElement {\n");
      sb.Append("  AuthorityId: ").Append(AuthorityId).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  AccessStatus: ").Append(AccessStatus).Append("\n");
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
