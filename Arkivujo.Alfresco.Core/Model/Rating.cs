using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Core.Model {

  /// <summary>
  /// A person can rate an item of content by liking it. They can also remove their like of an item of content. API methods exist to get a list of ratings and to add a new rating. 
  /// </summary>
  [DataContract]
  public class Rating {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Aggregate
    /// </summary>
    [DataMember(Name="aggregate", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "aggregate")]
    public RatingAggregate Aggregate { get; set; }

    /// <summary>
    /// Gets or Sets RatedAt
    /// </summary>
    [DataMember(Name="ratedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ratedAt")]
    public DateTime? RatedAt { get; set; }

    /// <summary>
    /// The rating. The type is specific to the rating scheme, boolean for the likes and an integer for the fiveStar.
    /// </summary>
    /// <value>The rating. The type is specific to the rating scheme, boolean for the likes and an integer for the fiveStar.</value>
    [DataMember(Name="myRating", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "myRating")]
    public string MyRating { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Rating {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Aggregate: ").Append(Aggregate).Append("\n");
      sb.Append("  RatedAt: ").Append(RatedAt).Append("\n");
      sb.Append("  MyRating: ").Append(MyRating).Append("\n");
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
