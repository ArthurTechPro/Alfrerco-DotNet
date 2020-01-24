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
  public class Group {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name="displayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "displayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or Sets IsRoot
    /// </summary>
    [DataMember(Name="isRoot", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isRoot")]
    public bool? IsRoot { get; set; }

    /// <summary>
    /// Gets or Sets ParentIds
    /// </summary>
    [DataMember(Name="parentIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parentIds")]
    public List<string> ParentIds { get; set; }

    /// <summary>
    /// Gets or Sets Zones
    /// </summary>
    [DataMember(Name="zones", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "zones")]
    public List<string> Zones { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Group {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
      sb.Append("  IsRoot: ").Append(IsRoot).Append("\n");
      sb.Append("  ParentIds: ").Append(ParentIds).Append("\n");
      sb.Append("  Zones: ").Append(Zones).Append("\n");
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
