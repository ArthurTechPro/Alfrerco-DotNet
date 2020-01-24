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
  public class StatusInfo {
    /// <summary>
    /// Gets or Sets IsReadOnly
    /// </summary>
    [DataMember(Name="isReadOnly", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isReadOnly")]
    public bool? IsReadOnly { get; set; }

    /// <summary>
    /// Gets or Sets IsAuditEnabled
    /// </summary>
    [DataMember(Name="isAuditEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isAuditEnabled")]
    public bool? IsAuditEnabled { get; set; }

    /// <summary>
    /// Gets or Sets IsQuickShareEnabled
    /// </summary>
    [DataMember(Name="isQuickShareEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isQuickShareEnabled")]
    public bool? IsQuickShareEnabled { get; set; }

    /// <summary>
    /// Gets or Sets IsThumbnailGenerationEnabled
    /// </summary>
    [DataMember(Name="isThumbnailGenerationEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isThumbnailGenerationEnabled")]
    public bool? IsThumbnailGenerationEnabled { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class StatusInfo {\n");
      sb.Append("  IsReadOnly: ").Append(IsReadOnly).Append("\n");
      sb.Append("  IsAuditEnabled: ").Append(IsAuditEnabled).Append("\n");
      sb.Append("  IsQuickShareEnabled: ").Append(IsQuickShareEnabled).Append("\n");
      sb.Append("  IsThumbnailGenerationEnabled: ").Append(IsThumbnailGenerationEnabled).Append("\n");
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
