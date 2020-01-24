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
  public class Download {
    /// <summary>
    /// number of files added so far in the zip
    /// </summary>
    /// <value>number of files added so far in the zip</value>
    [DataMember(Name="filesAdded", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "filesAdded")]
    public int? FilesAdded { get; set; }

    /// <summary>
    /// number of bytes added so far in the zip
    /// </summary>
    /// <value>number of bytes added so far in the zip</value>
    [DataMember(Name="bytesAdded", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "bytesAdded")]
    public int? BytesAdded { get; set; }

    /// <summary>
    /// the id of the download node
    /// </summary>
    /// <value>the id of the download node</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// the total number of files to be added in the zip
    /// </summary>
    /// <value>the total number of files to be added in the zip</value>
    [DataMember(Name="totalFiles", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalFiles")]
    public int? TotalFiles { get; set; }

    /// <summary>
    /// the total number of bytes to be added in the zip
    /// </summary>
    /// <value>the total number of bytes to be added in the zip</value>
    [DataMember(Name="totalBytes", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalBytes")]
    public int? TotalBytes { get; set; }

    /// <summary>
    /// the current status of the download node creation
    /// </summary>
    /// <value>the current status of the download node creation</value>
    [DataMember(Name="status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "status")]
    public string Status { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Download {\n");
      sb.Append("  FilesAdded: ").Append(FilesAdded).Append("\n");
      sb.Append("  BytesAdded: ").Append(BytesAdded).Append("\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  TotalFiles: ").Append(TotalFiles).Append("\n");
      sb.Append("  TotalBytes: ").Append(TotalBytes).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
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
