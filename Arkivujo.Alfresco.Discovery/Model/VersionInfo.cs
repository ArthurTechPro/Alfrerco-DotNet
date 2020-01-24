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
  public class VersionInfo {
    /// <summary>
    /// Gets or Sets Major
    /// </summary>
    [DataMember(Name="major", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "major")]
    public string Major { get; set; }

    /// <summary>
    /// Gets or Sets Minor
    /// </summary>
    [DataMember(Name="minor", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "minor")]
    public string Minor { get; set; }

    /// <summary>
    /// Gets or Sets Patch
    /// </summary>
    [DataMember(Name="patch", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "patch")]
    public string Patch { get; set; }

    /// <summary>
    /// Gets or Sets Hotfix
    /// </summary>
    [DataMember(Name="hotfix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "hotfix")]
    public string Hotfix { get; set; }

    /// <summary>
    /// Gets or Sets Schema
    /// </summary>
    [DataMember(Name="schema", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "schema")]
    public int? Schema { get; set; }

    /// <summary>
    /// Gets or Sets Label
    /// </summary>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// Gets or Sets Display
    /// </summary>
    [DataMember(Name="display", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "display")]
    public string Display { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class VersionInfo {\n");
      sb.Append("  Major: ").Append(Major).Append("\n");
      sb.Append("  Minor: ").Append(Minor).Append("\n");
      sb.Append("  Patch: ").Append(Patch).Append("\n");
      sb.Append("  Hotfix: ").Append(Hotfix).Append("\n");
      sb.Append("  Schema: ").Append(Schema).Append("\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  Display: ").Append(Display).Append("\n");
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
