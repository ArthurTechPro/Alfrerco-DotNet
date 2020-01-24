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
  public class ActionParameterDefinition {
    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets MultiValued
    /// </summary>
    [DataMember(Name="multiValued", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "multiValued")]
    public bool? MultiValued { get; set; }

    /// <summary>
    /// Gets or Sets Mandatory
    /// </summary>
    [DataMember(Name="mandatory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mandatory")]
    public bool? Mandatory { get; set; }

    /// <summary>
    /// Gets or Sets DisplayLabel
    /// </summary>
    [DataMember(Name="displayLabel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "displayLabel")]
    public string DisplayLabel { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ActionParameterDefinition {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  MultiValued: ").Append(MultiValued).Append("\n");
      sb.Append("  Mandatory: ").Append(Mandatory).Append("\n");
      sb.Append("  DisplayLabel: ").Append(DisplayLabel).Append("\n");
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
