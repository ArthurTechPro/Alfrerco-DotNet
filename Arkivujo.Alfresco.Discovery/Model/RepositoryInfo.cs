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
  public class RepositoryInfo {
    /// <summary>
    /// Gets or Sets Edition
    /// </summary>
    [DataMember(Name="edition", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "edition")]
    public string Edition { get; set; }

    /// <summary>
    /// Gets or Sets Version
    /// </summary>
    [DataMember(Name="version", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "version")]
    public VersionInfo Version { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public StatusInfo Status { get; set; }

    /// <summary>
    /// Gets or Sets License
    /// </summary>
    [DataMember(Name="license", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "license")]
    public LicenseInfo License { get; set; }

    /// <summary>
    /// Gets or Sets Modules
    /// </summary>
    [DataMember(Name="modules", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modules")]
    public List<ModuleInfo> Modules { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RepositoryInfo {\n");
      sb.Append("  Edition: ").Append(Edition).Append("\n");
      sb.Append("  Version: ").Append(Version).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  License: ").Append(License).Append("\n");
      sb.Append("  Modules: ").Append(Modules).Append("\n");
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
