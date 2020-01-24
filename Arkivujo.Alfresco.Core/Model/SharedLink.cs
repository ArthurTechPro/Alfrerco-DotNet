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
  public class SharedLink {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets ExpiresAt
    /// </summary>
    [DataMember(Name="expiresAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "expiresAt")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Gets or Sets NodeId
    /// </summary>
    [DataMember(Name="nodeId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nodeId")]
    public string NodeId { get; set; }

    /// <summary>
    /// The name must not contain spaces or the following special characters: * \" < > \\ / ? : and |. The character . must not be used at the end of the name. 
    /// </summary>
    /// <value>The name must not contain spaces or the following special characters: * \" < > \\ / ? : and |. The character . must not be used at the end of the name. </value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

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
    /// Gets or Sets SharedByUser
    /// </summary>
    [DataMember(Name="sharedByUser", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sharedByUser")]
    public UserInfo SharedByUser { get; set; }

    /// <summary>
    /// Gets or Sets Content
    /// </summary>
    [DataMember(Name="content", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "content")]
    public ContentInfo Content { get; set; }

    /// <summary>
    /// The allowable operations for the Quickshare link itself. See allowableOperationsOnTarget for the allowable operations pertaining to the linked content node. 
    /// </summary>
    /// <value>The allowable operations for the Quickshare link itself. See allowableOperationsOnTarget for the allowable operations pertaining to the linked content node. </value>
    [DataMember(Name="allowableOperations", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "allowableOperations")]
    public List<string> AllowableOperations { get; set; }

    /// <summary>
    /// The allowable operations for the content node being shared. 
    /// </summary>
    /// <value>The allowable operations for the content node being shared. </value>
    [DataMember(Name="allowableOperationsOnTarget", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "allowableOperationsOnTarget")]
    public List<string> AllowableOperationsOnTarget { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SharedLink {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
      sb.Append("  NodeId: ").Append(NodeId).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Title: ").Append(Title).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  ModifiedAt: ").Append(ModifiedAt).Append("\n");
      sb.Append("  ModifiedByUser: ").Append(ModifiedByUser).Append("\n");
      sb.Append("  SharedByUser: ").Append(SharedByUser).Append("\n");
      sb.Append("  Content: ").Append(Content).Append("\n");
      sb.Append("  AllowableOperations: ").Append(AllowableOperations).Append("\n");
      sb.Append("  AllowableOperationsOnTarget: ").Append(AllowableOperationsOnTarget).Append("\n");
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
