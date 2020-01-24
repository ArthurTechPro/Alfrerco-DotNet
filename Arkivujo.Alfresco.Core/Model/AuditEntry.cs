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
  public class AuditEntry {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets AuditApplicationId
    /// </summary>
    [DataMember(Name="auditApplicationId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "auditApplicationId")]
    public string AuditApplicationId { get; set; }

    /// <summary>
    /// Gets or Sets CreatedByUser
    /// </summary>
    [DataMember(Name="createdByUser", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdByUser")]
    public UserInfo CreatedByUser { get; set; }

    /// <summary>
    /// Gets or Sets CreatedAt
    /// </summary>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or Sets Values
    /// </summary>
    [DataMember(Name="values", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "values")]
    public Dictionary<string, string> Values { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AuditEntry {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  AuditApplicationId: ").Append(AuditApplicationId).Append("\n");
      sb.Append("  CreatedByUser: ").Append(CreatedByUser).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  Values: ").Append(Values).Append("\n");
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
