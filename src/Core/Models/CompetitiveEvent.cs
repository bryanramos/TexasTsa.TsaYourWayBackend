using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TexasTsa.Services.TsaYourWay.Core.Storage;

namespace TexasTsa.Services.TsaYourWay.Core.Models
{
    public class CompetitiveEvent
    {
        [JsonProperty(PropertyName = "active")]
        public Boolean Active { get; set; }

        [JsonProperty(PropertyName = "attachments")]
        public string Attachments { get; set; }

        [JsonProperty(PropertyName = "alert")]
        public string Alert { get; set; }

        [JsonProperty(PropertyName = "archive")]
        public Boolean Archive { get; set; }

        [JsonProperty(PropertyName = "challenge")]
        public string Challenge { get; set; }

        [JsonProperty(PropertyName = "createdTimestamp")]
        public DateTime CreatedTimestamp { get; set; }

        [JsonProperty(PropertyName = "contact")]
        public string Contact { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "individual")]
        public Boolean Individual { get; set; }

        [JsonProperty(PropertyName = "highschool")]
        public Boolean HighSchool { get; set; }

        [JsonProperty(PropertyName = "middleschool")]
        public Boolean MiddleSchool { get; set; }

        [JsonProperty(PropertyName = "modifiedTimestamp")]
        public DateTime ModifiedTimestamp { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        // for Algolia search engine
        [JsonProperty(PropertyName = "objectID")]
        public string ObjectID { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "relatedCareers")]
        public string RelatedCareers { get; set; }

        [JsonProperty(PropertyName = "rubric")]
        public string Rubric { get; set; }

        [JsonProperty(PropertyName = "rules")]
        public string Rules { get; set; }

        [JsonProperty(PropertyName = "showAlert")]
        public Boolean ShowAlert { get; set; }

        [JsonProperty(PropertyName = "stemIntegration")]
        public string StemIntegration { get; set; }

        [JsonProperty(PropertyName = "submittableUri")]
        public string SubmittableUri { get; set; }

        [JsonProperty(PropertyName = "team")]
        public Boolean Team { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        public static Dictionary<string, object> ToDictionary(CompetitiveEvent competitiveEvent)
        {
            if (competitiveEvent == null) { throw new ArgumentNullException(nameof(competitiveEvent)); }

            return new Dictionary<string, object>
            {
                { SqlConstants.ActiveParameterName, competitiveEvent.Active },
                { SqlConstants.AttachmentsParameterName, competitiveEvent.Attachments },
                { SqlConstants.AlertParameterName, competitiveEvent.Alert },
                { SqlConstants.ArchiveParameterName, competitiveEvent.Archive },
                { SqlConstants.ChallengeParameterName, competitiveEvent.Challenge },
                { SqlConstants.CreatedTimestampParameterName, competitiveEvent.CreatedTimestamp },
                { SqlConstants.ContactParameterName, competitiveEvent.Contact },
                { SqlConstants.DescriptionParameterName, competitiveEvent.Description },
                { SqlConstants.DetailsParameterName, competitiveEvent.Details },
                { SqlConstants.IdParameterName, competitiveEvent.Id },
                { SqlConstants.IndividualParameterName, competitiveEvent.Individual },
                { SqlConstants.HighSchoolParameterName, competitiveEvent.HighSchool },
                { SqlConstants.MiddleSchoolParameterName, competitiveEvent.MiddleSchool },
                { SqlConstants.ModifiedTimestampParameterName, competitiveEvent.ModifiedTimestamp },
                { SqlConstants.NameParameterName, competitiveEvent.Name },
                { SqlConstants.ObjectIDParameterName, competitiveEvent.ObjectID },
                { SqlConstants.OverviewParameterName, competitiveEvent.Overview },
                { SqlConstants.RelatedCareersParameterName, competitiveEvent.RelatedCareers },
                { SqlConstants.RubricParameterName, competitiveEvent.Rubric },
                { SqlConstants.RulesParameterName, competitiveEvent.Rules },
                { SqlConstants.ShowAlertParameterName, competitiveEvent.ShowAlert },
                { SqlConstants.StemIntegrationParameterName, competitiveEvent.StemIntegration },
                { SqlConstants.SubmittableUriParameterName, competitiveEvent.SubmittableUri },
                { SqlConstants.TeamParameterName, competitiveEvent.Team },
                { SqlConstants.TypeParameterName, competitiveEvent.Type },
                { SqlConstants.VersionParameterName, competitiveEvent.Version }
            };
        }
    }
}
