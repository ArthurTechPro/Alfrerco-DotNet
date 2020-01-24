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
  public class Version {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets VersionComment
    /// </summary>
    [DataMember(Name="versionComment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "versionComment")]
    public string VersionComment { get; set; }

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
    /// Gets or Sets IsFolder
    /// </summary>
    [DataMember(Name="isFolder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isFolder")]
    public bool? IsFolder { get; set; }

    /// <summary>
    /// Gets or Sets IsFile
    /// </summary>
    [DataMember(Name="isFile", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isFile")]
    public bool? IsFile { get; set; }

    /// <summary>
    /// Gets or Sets ModifiedAt
    /// </summary>
    [DataMember(Name="modifiedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modifiedAt")]
    public DateTime? ModifiedAt { get; set; }

    /// <summary>
    /// Gets or Sets ModifiedByUser
    /// </summary>
    [DataMember(Name="modifiedByUser", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modifiedByUser")]
    public UserInfo ModifiedByUser { get; set; }

    /// <summary>
    /// Gets or Sets Content
    /// </summary>
    [DataMember(Name="content", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "content")]
    public ContentInfo Content { get; set; }

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
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Version {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  VersionComment: ").Append(VersionComment).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  NodeType: ").Append(NodeType).Append("\n");
      sb.Append("  IsFolder: ").Append(IsFolder).Append("\n");
      sb.Append("  IsFile: ").Append(IsFile).Append("\n");
      sb.Append("  ModifiedAt: ").Append(ModifiedAt).Append("\n");
      sb.Append("  ModifiedByUser: ").Append(ModifiedByUser).Append("\n");
      sb.Append("  Content: ").Append(Content).Append("\n");
      sb.Append("  AspectNames: ").Append(AspectNames).Append("\n");
      sb.Append("  Properties: ").Append(Properties).Append("\n");
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
