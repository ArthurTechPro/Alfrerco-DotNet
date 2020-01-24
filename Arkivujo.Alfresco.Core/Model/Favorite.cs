using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Core.Model {

  /// <summary>
  /// A favorite describes an Alfresco entity that a person has marked as a favorite. The target can be a site, file or folder. 
  /// </summary>
  [DataContract]
  public class Favorite {
    /// <summary>
    /// The guid of the object that is a favorite.
    /// </summary>
    /// <value>The guid of the object that is a favorite.</value>
    [DataMember(Name="targetGuid", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "targetGuid")]
    public string TargetGuid { get; set; }

    /// <summary>
    /// The time the object was made a favorite.
    /// </summary>
    /// <value>The time the object was made a favorite.</value>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or Sets Target
    /// </summary>
    [DataMember(Name="target", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "target")]
    public Object Target { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Favorite {\n");
      sb.Append("  TargetGuid: ").Append(TargetGuid).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  Target: ").Append(Target).Append("\n");
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
