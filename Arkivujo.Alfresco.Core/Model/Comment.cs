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
  public class Comment {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Content
    /// </summary>
    [DataMember(Name="content", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "content")]
    public string Content { get; set; }

    /// <summary>
    /// Gets or Sets CreatedBy
    /// </summary>
    [DataMember(Name="createdBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdBy")]
    public Person CreatedBy { get; set; }

    /// <summary>
    /// Gets or Sets CreatedAt
    /// </summary>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or Sets Edited
    /// </summary>
    [DataMember(Name="edited", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "edited")]
    public bool? Edited { get; set; }

    /// <summary>
    /// Gets or Sets ModifiedBy
    /// </summary>
    [DataMember(Name="modifiedBy", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modifiedBy")]
    public Person ModifiedBy { get; set; }

    /// <summary>
    /// Gets or Sets ModifiedAt
    /// </summary>
    [DataMember(Name="modifiedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "modifiedAt")]
    public DateTime? ModifiedAt { get; set; }

    /// <summary>
    /// Gets or Sets CanEdit
    /// </summary>
    [DataMember(Name="canEdit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "canEdit")]
    public bool? CanEdit { get; set; }

    /// <summary>
    /// Gets or Sets CanDelete
    /// </summary>
    [DataMember(Name="canDelete", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "canDelete")]
    public bool? CanDelete { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Comment {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Content: ").Append(Content).Append("\n");
      sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  Edited: ").Append(Edited).Append("\n");
      sb.Append("  ModifiedBy: ").Append(ModifiedBy).Append("\n");
      sb.Append("  ModifiedAt: ").Append(ModifiedAt).Append("\n");
      sb.Append("  CanEdit: ").Append(CanEdit).Append("\n");
      sb.Append("  CanDelete: ").Append(CanDelete).Append("\n");
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
