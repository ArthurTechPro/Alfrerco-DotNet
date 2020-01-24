using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Discovery.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class EntitlementsInfo {
    /// <summary>
    /// Gets or Sets MaxUsers
    /// </summary>
    [DataMember(Name="maxUsers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxUsers")]
    public long? MaxUsers { get; set; }

    /// <summary>
    /// Gets or Sets MaxDocs
    /// </summary>
    [DataMember(Name="maxDocs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxDocs")]
    public long? MaxDocs { get; set; }

    /// <summary>
    /// Gets or Sets IsClusterEnabled
    /// </summary>
    [DataMember(Name="isClusterEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isClusterEnabled")]
    public bool? IsClusterEnabled { get; set; }

    /// <summary>
    /// Gets or Sets IsCryptodocEnabled
    /// </summary>
    [DataMember(Name="isCryptodocEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isCryptodocEnabled")]
    public bool? IsCryptodocEnabled { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class EntitlementsInfo {\n");
      sb.Append("  MaxUsers: ").Append(MaxUsers).Append("\n");
      sb.Append("  MaxDocs: ").Append(MaxDocs).Append("\n");
      sb.Append("  IsClusterEnabled: ").Append(IsClusterEnabled).Append("\n");
      sb.Append("  IsCryptodocEnabled: ").Append(IsCryptodocEnabled).Append("\n");
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
