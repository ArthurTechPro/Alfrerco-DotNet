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
  public class SearchEntry {
    /// <summary>
    /// The score for this row
    /// </summary>
    /// <value>The score for this row</value>
    [DataMember(Name="score", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "score")]
    public float? Score { get; set; }

    /// <summary>
    /// Highlight fragments if requested and available. A match can happen in any of the requested field. 
    /// </summary>
    /// <value>Highlight fragments if requested and available. A match can happen in any of the requested field. </value>
    [DataMember(Name="highlight", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "highlight")]
    public List<SearchEntryHighlight> Highlight { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SearchEntry {\n");
      sb.Append("  Score: ").Append(Score).Append("\n");
      sb.Append("  Highlight: ").Append(Highlight).Append("\n");
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
