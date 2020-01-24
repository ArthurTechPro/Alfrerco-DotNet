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
  public class ChildAssociationInfo {
    /// <summary>
    /// Gets or Sets AssocType
    /// </summary>
    [DataMember(Name="assocType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "assocType")]
    public string AssocType { get; set; }

    /// <summary>
    /// Gets or Sets IsPrimary
    /// </summary>
    [DataMember(Name="isPrimary", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isPrimary")]
    public bool? IsPrimary { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ChildAssociationInfo {\n");
      sb.Append("  AssocType: ").Append(AssocType).Append("\n");
      sb.Append("  IsPrimary: ").Append(IsPrimary).Append("\n");
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
