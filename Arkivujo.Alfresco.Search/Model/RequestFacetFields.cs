using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Simple facet fields to include The Properties reflect the global properties related to field facts in SOLR. They are described in detail by the SOLR documentation 
  /// </summary>
  [DataContract]
  public class RequestFacetFields {
    /// <summary>
    /// Define specific fields on which to facet (adds SOLR facet.field and f.<field>.facet.* options) 
    /// </summary>
    /// <value>Define specific fields on which to facet (adds SOLR facet.field and f.<field>.facet.* options) </value>
    [DataMember(Name="facets", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "facets")]
    public List<RequestFacetField> Facets { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestFacetFields {\n");
      sb.Append("  Facets: ").Append(Facets).Append("\n");
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
