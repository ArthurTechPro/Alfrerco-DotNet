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
  public class ModuleInfo {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Title
    /// </summary>
    [DataMember(Name="title", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets Version
    /// </summary>
    [DataMember(Name="version", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "version")]
    public string Version { get; set; }

    /// <summary>
    /// Gets or Sets InstallDate
    /// </summary>
    [DataMember(Name="installDate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "installDate")]
    public DateTime? InstallDate { get; set; }

    /// <summary>
    /// Gets or Sets InstallState
    /// </summary>
    [DataMember(Name="installState", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "installState")]
    public string InstallState { get; set; }

    /// <summary>
    /// Gets or Sets VersionMin
    /// </summary>
    [DataMember(Name="versionMin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "versionMin")]
    public string VersionMin { get; set; }

    /// <summary>
    /// Gets or Sets VersionMax
    /// </summary>
    [DataMember(Name="versionMax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "versionMax")]
    public string VersionMax { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ModuleInfo {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Version: ").Append(Version).Append("\n");
      sb.Append("  InstallDate: ").Append(InstallDate).Append("\n");
      sb.Append("  InstallState: ").Append(InstallState).Append("\n");
      sb.Append("  VersionMin: ").Append(VersionMin).Append("\n");
      sb.Append("  VersionMax: ").Append(VersionMax).Append("\n");
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
