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
  public class LicenseInfo {
    /// <summary>
    /// Gets or Sets IssuedAt
    /// </summary>
    [DataMember(Name="issuedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "issuedAt")]
    public DateTime? IssuedAt { get; set; }

    /// <summary>
    /// Gets or Sets ExpiresAt
    /// </summary>
    [DataMember(Name="expiresAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expiresAt")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Gets or Sets RemainingDays
    /// </summary>
    [DataMember(Name="remainingDays", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "remainingDays")]
    public int? RemainingDays { get; set; }

    /// <summary>
    /// Gets or Sets Holder
    /// </summary>
    [DataMember(Name="holder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "holder")]
    public string Holder { get; set; }

    /// <summary>
    /// Gets or Sets Mode
    /// </summary>
    [DataMember(Name="mode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mode")]
    public string Mode { get; set; }

    /// <summary>
    /// Gets or Sets Entitlements
    /// </summary>
    [DataMember(Name="entitlements", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "entitlements")]
    public EntitlementsInfo Entitlements { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LicenseInfo {\n");
      sb.Append("  IssuedAt: ").Append(IssuedAt).Append("\n");
      sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
      sb.Append("  RemainingDays: ").Append(RemainingDays).Append("\n");
      sb.Append("  Holder: ").Append(Holder).Append("\n");
      sb.Append("  Mode: ").Append(Mode).Append("\n");
      sb.Append("  Entitlements: ").Append(Entitlements).Append("\n");
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
