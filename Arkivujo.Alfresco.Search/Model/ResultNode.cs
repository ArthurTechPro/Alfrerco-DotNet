using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ResultNode : Node {
    /// <summary>
    /// Gets or Sets Search
    /// </summary>
    [DataMember(Name="search", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "search")]
    public SearchEntry Search { get; set; }

    /// <summary>
    /// Gets or Sets ArchivedByUser
    /// </summary>
    [DataMember(Name="archivedByUser", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "archivedByUser")]
    public UserInfo ArchivedByUser { get; set; }

    /// <summary>
    /// Gets or Sets ArchivedAt
    /// </summary>
    [DataMember(Name="archivedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "archivedAt")]
    public DateTime? ArchivedAt { get; set; }

    /// <summary>
    /// Gets or Sets VersionLabel
    /// </summary>
    [DataMember(Name="versionLabel", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "versionLabel")]
    public string VersionLabel { get; set; }

    /// <summary>
    /// Gets or Sets VersionComment
    /// </summary>
    [DataMember(Name="versionComment", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "versionComment")]
    public string VersionComment { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ResultNode {\n");
      sb.Append("  Search: ").Append(Search).Append("\n");
      sb.Append("  ArchivedByUser: ").Append(ArchivedByUser).Append("\n");
      sb.Append("  ArchivedAt: ").Append(ArchivedAt).Append("\n");
      sb.Append("  VersionLabel: ").Append(VersionLabel).Append("\n");
      sb.Append("  VersionComment: ").Append(VersionComment).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public  new string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
