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
  public class SearchEntryHighlight {
    /// <summary>
    /// The field where a match occurred (one of the fields defined on the request)
    /// </summary>
    /// <value>The field where a match occurred (one of the fields defined on the request)</value>
    [DataMember(Name="field", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "field")]
    public string Field { get; set; }

    /// <summary>
    /// Any number of snippets for the specified field highlighting the matching text
    /// </summary>
    /// <value>Any number of snippets for the specified field highlighting the matching text</value>
    [DataMember(Name="snippets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "snippets")]
    public List<string> Snippets { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SearchEntryHighlight {\n");
      sb.Append("  Field: ").Append(Field).Append("\n");
      sb.Append("  Snippets: ").Append(Snippets).Append("\n");
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
