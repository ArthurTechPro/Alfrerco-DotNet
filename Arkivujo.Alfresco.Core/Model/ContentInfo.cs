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
  public class ContentInfo {
    /// <summary>
    /// Gets or Sets MimeType
    /// </summary>
    [DataMember(Name="mimeType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mimeType")]
    public string MimeType { get; set; }

    /// <summary>
    /// Gets or Sets MimeTypeName
    /// </summary>
    [DataMember(Name="mimeTypeName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mimeTypeName")]
    public string MimeTypeName { get; set; }

    /// <summary>
    /// Gets or Sets SizeInBytes
    /// </summary>
    [DataMember(Name="sizeInBytes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "sizeInBytes")]
    public int? SizeInBytes { get; set; }

    /// <summary>
    /// Gets or Sets Encoding
    /// </summary>
    [DataMember(Name="encoding", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "encoding")]
    public string Encoding { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ContentInfo {\n");
      sb.Append("  MimeType: ").Append(MimeType).Append("\n");
      sb.Append("  MimeTypeName: ").Append(MimeTypeName).Append("\n");
      sb.Append("  SizeInBytes: ").Append(SizeInBytes).Append("\n");
      sb.Append("  Encoding: ").Append(Encoding).Append("\n");
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
