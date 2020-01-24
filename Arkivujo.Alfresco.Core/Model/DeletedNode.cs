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
  public class DeletedNode : Node {
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
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class DeletedNode {\n");
      sb.Append("  ArchivedByUser: ").Append(ArchivedByUser).Append("\n");
      sb.Append("  ArchivedAt: ").Append(ArchivedAt).Append("\n");
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
