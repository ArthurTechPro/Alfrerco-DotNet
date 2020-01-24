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
  public class ErrorError {
    /// <summary>
    /// Gets or Sets ErrorKey
    /// </summary>
    [DataMember(Name="errorKey", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "errorKey")]
    public string ErrorKey { get; set; }

    /// <summary>
    /// Gets or Sets StatusCode
    /// </summary>
    [DataMember(Name="statusCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "statusCode")]
    public int? StatusCode { get; set; }

    /// <summary>
    /// Gets or Sets BriefSummary
    /// </summary>
    [DataMember(Name="briefSummary", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "briefSummary")]
    public string BriefSummary { get; set; }

    /// <summary>
    /// Gets or Sets StackTrace
    /// </summary>
    [DataMember(Name="stackTrace", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "stackTrace")]
    public string StackTrace { get; set; }

    /// <summary>
    /// Gets or Sets DescriptionURL
    /// </summary>
    [DataMember(Name="descriptionURL", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "descriptionURL")]
    public string DescriptionURL { get; set; }

    /// <summary>
    /// Gets or Sets LogId
    /// </summary>
    [DataMember(Name="logId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "logId")]
    public string LogId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ErrorError {\n");
      sb.Append("  ErrorKey: ").Append(ErrorKey).Append("\n");
      sb.Append("  StatusCode: ").Append(StatusCode).Append("\n");
      sb.Append("  BriefSummary: ").Append(BriefSummary).Append("\n");
      sb.Append("  StackTrace: ").Append(StackTrace).Append("\n");
      sb.Append("  DescriptionURL: ").Append(DescriptionURL).Append("\n");
      sb.Append("  LogId: ").Append(LogId).Append("\n");
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
