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
  public class NodeBodyCreate {
    /// <summary>
    /// The name must not contain spaces or the following special characters: * \" < > \\ / ? : and |. The character . must not be used at the end of the name. 
    /// </summary>
    /// <value>The name must not contain spaces or the following special characters: * \" < > \\ / ? : and |. The character . must not be used at the end of the name. </value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets NodeType
    /// </summary>
    [DataMember(Name="nodeType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nodeType")]
    public string NodeType { get; set; }

    /// <summary>
    /// Gets or Sets AspectNames
    /// </summary>
    [DataMember(Name="aspectNames", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "aspectNames")]
    public List<string> AspectNames { get; set; }

    /// <summary>
    /// Gets or Sets Properties
    /// </summary>
    [DataMember(Name="properties", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "properties")]
    public Dictionary<string, string> Properties { get; set; }

    /// <summary>
    /// Gets or Sets RelativePath
    /// </summary>
    [DataMember(Name="relativePath", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "relativePath")]
    public string RelativePath { get; set; }

    /// <summary>
    /// Gets or Sets Association
    /// </summary>
    [DataMember(Name="association", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "association")]
    public NodeBodyCreateAssociation Association { get; set; }

    /// <summary>
    /// Gets or Sets SecondaryChildren
    /// </summary>
    [DataMember(Name="secondaryChildren", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "secondaryChildren")]
    public List<ChildAssociationBody> SecondaryChildren { get; set; }

    /// <summary>
    /// Gets or Sets Targets
    /// </summary>
    [DataMember(Name="targets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "targets")]
    public List<AssociationBody> Targets { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class NodeBodyCreate {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  NodeType: ").Append(NodeType).Append("\n");
      sb.Append("  AspectNames: ").Append(AspectNames).Append("\n");
      sb.Append("  Properties: ").Append(Properties).Append("\n");
      sb.Append("  RelativePath: ").Append(RelativePath).Append("\n");
      sb.Append("  Association: ").Append(Association).Append("\n");
      sb.Append("  SecondaryChildren: ").Append(SecondaryChildren).Append("\n");
      sb.Append("  Targets: ").Append(Targets).Append("\n");
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
