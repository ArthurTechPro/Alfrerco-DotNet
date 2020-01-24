using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Arkivujo.Alfresco.Core.Model {

  /// <summary>
  /// Activities describe any past activity in a site, for example creating an item of content, commenting on a node, liking an item of content. 
  /// </summary>
  [DataContract]
  public class Activity {
    /// <summary>
    /// The id of the person who performed the activity
    /// </summary>
    /// <value>The id of the person who performed the activity</value>
    [DataMember(Name="postPersonId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postPersonId")]
    public string PostPersonId { get; set; }

    /// <summary>
    /// The unique id of the activity
    /// </summary>
    /// <value>The unique id of the activity</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// The unique id of the site on which the activity was performed
    /// </summary>
    /// <value>The unique id of the site on which the activity was performed</value>
    [DataMember(Name="siteId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "siteId")]
    public string SiteId { get; set; }

    /// <summary>
    /// The date time at which the activity was performed
    /// </summary>
    /// <value>The date time at which the activity was performed</value>
    [DataMember(Name="postedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "postedAt")]
    public DateTime? PostedAt { get; set; }

    /// <summary>
    /// The feed on which this activity was posted
    /// </summary>
    /// <value>The feed on which this activity was posted</value>
    [DataMember(Name="feedPersonId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "feedPersonId")]
    public string FeedPersonId { get; set; }

    /// <summary>
    /// An object summarizing the activity
    /// </summary>
    /// <value>An object summarizing the activity</value>
    [DataMember(Name="activitySummary", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "activitySummary")]
    public Dictionary<string, string> ActivitySummary { get; set; }

    /// <summary>
    /// The type of the activity posted
    /// </summary>
    /// <value>The type of the activity posted</value>
    [DataMember(Name="activityType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "activityType")]
    public string ActivityType { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Activity {\n");
      sb.Append("  PostPersonId: ").Append(PostPersonId).Append("\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  SiteId: ").Append(SiteId).Append("\n");
      sb.Append("  PostedAt: ").Append(PostedAt).Append("\n");
      sb.Append("  FeedPersonId: ").Append(FeedPersonId).Append("\n");
      sb.Append("  ActivitySummary: ").Append(ActivitySummary).Append("\n");
      sb.Append("  ActivityType: ").Append(ActivityType).Append("\n");
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
