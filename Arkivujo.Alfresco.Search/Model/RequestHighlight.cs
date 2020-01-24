using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Search.Model {

  /// <summary>
  /// Request that highlight fragments to be added to result set rows The properties reflect SOLR highlighting parameters. 
  /// </summary>
  [DataContract]
  public class RequestHighlight {
    /// <summary>
    /// The string used to mark the start of a highlight in a fragment.
    /// </summary>
    /// <value>The string used to mark the start of a highlight in a fragment.</value>
    [DataMember(Name="prefix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prefix")]
    public string Prefix { get; set; }

    /// <summary>
    /// The string used to mark the end of a highlight in a fragment.
    /// </summary>
    /// <value>The string used to mark the end of a highlight in a fragment.</value>
    [DataMember(Name="postfix", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postfix")]
    public string Postfix { get; set; }

    /// <summary>
    /// The maximum number of distinct highlight snippets to return for each highlight field.
    /// </summary>
    /// <value>The maximum number of distinct highlight snippets to return for each highlight field.</value>
    [DataMember(Name="snippetCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "snippetCount")]
    public int? SnippetCount { get; set; }

    /// <summary>
    /// The character length of each snippet.
    /// </summary>
    /// <value>The character length of each snippet.</value>
    [DataMember(Name="fragmentSize", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fragmentSize")]
    public int? FragmentSize { get; set; }

    /// <summary>
    /// The number of characters to be considered for highlighting. Matches after this count will not be shown.
    /// </summary>
    /// <value>The number of characters to be considered for highlighting. Matches after this count will not be shown.</value>
    [DataMember(Name="maxAnalyzedChars", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "maxAnalyzedChars")]
    public int? MaxAnalyzedChars { get; set; }

    /// <summary>
    /// If fragments over lap they can be  merged into one larger fragment
    /// </summary>
    /// <value>If fragments over lap they can be  merged into one larger fragment</value>
    [DataMember(Name="mergeContiguous", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mergeContiguous")]
    public bool? MergeContiguous { get; set; }

    /// <summary>
    /// Should phrases be identified.
    /// </summary>
    /// <value>Should phrases be identified.</value>
    [DataMember(Name="usePhraseHighlighter", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "usePhraseHighlighter")]
    public bool? UsePhraseHighlighter { get; set; }

    /// <summary>
    /// The fields to highlight and field specific configuration properties for each field
    /// </summary>
    /// <value>The fields to highlight and field specific configuration properties for each field</value>
    [DataMember(Name="fields", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fields")]
    public List<RequestHighlightFields> Fields { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RequestHighlight {\n");
      sb.Append("  Prefix: ").Append(Prefix).Append("\n");
      sb.Append("  Postfix: ").Append(Postfix).Append("\n");
      sb.Append("  SnippetCount: ").Append(SnippetCount).Append("\n");
      sb.Append("  FragmentSize: ").Append(FragmentSize).Append("\n");
      sb.Append("  MaxAnalyzedChars: ").Append(MaxAnalyzedChars).Append("\n");
      sb.Append("  MergeContiguous: ").Append(MergeContiguous).Append("\n");
      sb.Append("  UsePhraseHighlighter: ").Append(UsePhraseHighlighter).Append("\n");
      sb.Append("  Fields: ").Append(Fields).Append("\n");
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
