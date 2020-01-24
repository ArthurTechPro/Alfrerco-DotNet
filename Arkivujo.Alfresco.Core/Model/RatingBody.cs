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
  public class RatingBody {
    /// <summary>
    /// The rating scheme type. Possible values are likes and fiveStar.
    /// </summary>
    /// <value>The rating scheme type. Possible values are likes and fiveStar.</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// The rating. The type is specific to the rating scheme, boolean for the likes and an integer for the fiveStar
    /// </summary>
    /// <value>The rating. The type is specific to the rating scheme, boolean for the likes and an integer for the fiveStar</value>
    [DataMember(Name="myRating", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "myRating")]
    public string MyRating { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RatingBody {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
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
