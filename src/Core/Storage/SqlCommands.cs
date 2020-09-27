using System;
using System.Collections.Generic;
using System.Text;

namespace TexasTsa.Services.TsaYourWay.Core.Storage
{
    public class SqlCommands
    {
        public static string CreateCompetitiveEventsTable = 
            $@"IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='{SqlConstants.CompetitiveEventsTableName}')
                CREATE TABLE {SqlConstants.CompetitiveEventsTableName}
                    ({SqlConstants.IdColumnName} nvarchar(MAX),
                    {SqlConstants.CreatedTimestampColumnName} datetime,
                    {SqlConstants.NameColumnName} nvarchar(MAX),
                    {SqlConstants.DescriptionColumnName} text,
                    {SqlConstants.TypeColumnName} nvarchar(MAX),
                    {SqlConstants.ChallengeColumnName} nvarchar(MAX),
                    {SqlConstants.MiddleSchoolColumnName} bit,
                    {SqlConstants.HighSchoolColumnName} bit,
                    {SqlConstants.IndividualColumnName} bit,
                    {SqlConstants.TeamColumnName} bit,
                    {SqlConstants.SubmittableUriColumnName} nvarchar(MAX),
                    {SqlConstants.ContactColumnName} nvarchar(MAX),
                    {SqlConstants.OverviewColumnName} text,
                    {SqlConstants.DetailsColumnName} text,
                    {SqlConstants.RulesColumnName} text,
                    {SqlConstants.StemIntegrationColumnName} text,
                    {SqlConstants.RelatedCareersColumnName} text,
                    {SqlConstants.RubricColumnName} text,
                    {SqlConstants.AttachmentsColumnName} text,
                    {SqlConstants.ShowAlertColumnName} bit,
                    {SqlConstants.AlertColumnName} text,
                    {SqlConstants.ArchiveColumnName} bit,
                    {SqlConstants.ActiveColumnName} bit,
                    {SqlConstants.ObjectIDColumnName} nvarchar(MAX),
                    {SqlConstants.ModifiedTimestampColumnName} datetime,
                    {SqlConstants.VersionColumnName} int)";

        public static string DeleteCompetitiveEvent = 
            $@"DELETE FROM {SqlConstants.CompetitiveEventsTableName} 
                WHERE {SqlConstants.IdColumnName} = {SqlConstants.IdParameterName}";

        public static string GetCompetitiveEvents = $@"SELECT * FROM {SqlConstants.CompetitiveEventsTableName}";

        public static string GetCompetitiveEvent = $@"SELECT TOP(1) * FROM {SqlConstants.CompetitiveEventsTableName} 
            WHERE {SqlConstants.IdColumnName} = {SqlConstants.IdParameterName}";

        public static string InsertCompetitiveEvent =
            $@"INSERT INTO {SqlConstants.CompetitiveEventsTableName}
                ({SqlConstants.IdColumnName},
                {SqlConstants.CreatedTimestampColumnName},
                {SqlConstants.NameColumnName},
                {SqlConstants.DescriptionColumnName},
                {SqlConstants.TypeColumnName},
                {SqlConstants.ChallengeColumnName},
                {SqlConstants.MiddleSchoolColumnName},
                {SqlConstants.HighSchoolColumnName},
                {SqlConstants.IndividualColumnName},
                {SqlConstants.TeamColumnName},
                {SqlConstants.SubmittableUriColumnName},
                {SqlConstants.ContactColumnName},
                {SqlConstants.OverviewColumnName},
                {SqlConstants.DetailsColumnName},
                {SqlConstants.RulesColumnName},
                {SqlConstants.StemIntegrationColumnName},
                {SqlConstants.RelatedCareersColumnName},
                {SqlConstants.RubricColumnName},
                {SqlConstants.AttachmentsColumnName},
                {SqlConstants.ShowAlertColumnName},
                {SqlConstants.AlertColumnName},
                {SqlConstants.ArchiveColumnName},
                {SqlConstants.ActiveColumnName},
                {SqlConstants.ObjectIDColumnName},
                {SqlConstants.ModifiedTimestampColumnName},
                {SqlConstants.VersionColumnName})
            VALUES ({SqlConstants.IdParameterName},
                {SqlConstants.CreatedTimestampParameterName},
                {SqlConstants.NameParameterName},
                {SqlConstants.DescriptionParameterName},
                {SqlConstants.TypeParameterName},
                {SqlConstants.ChallengeParameterName},
                {SqlConstants.MiddleSchoolParameterName},
                {SqlConstants.HighSchoolParameterName},
                {SqlConstants.IndividualParameterName},
                {SqlConstants.TeamParameterName},
                {SqlConstants.SubmittableUriParameterName},
                {SqlConstants.ContactParameterName},
                {SqlConstants.OverviewParameterName},
                {SqlConstants.DetailsParameterName},
                {SqlConstants.RulesParameterName},
                {SqlConstants.StemIntegrationParameterName},
                {SqlConstants.RelatedCareersParameterName},
                {SqlConstants.RubricParameterName},
                {SqlConstants.AttachmentsParameterName},
                {SqlConstants.ShowAlertParameterName},
                {SqlConstants.AlertParameterName},
                {SqlConstants.ArchiveParameterName},
                {SqlConstants.ActiveParameterName},
                {SqlConstants.ObjectIDParameterName},
                {SqlConstants.ModifiedTimestampParameterName},
                {SqlConstants.VersionParameterName})";

        public static string UpdateCompetitiveEvent =
            $@"UPDATE {SqlConstants.CompetitiveEventsTableName}
            SET
                {SqlConstants.NameColumnName} = {SqlConstants.NameParameterName},
                {SqlConstants.DescriptionParameterName} = {SqlConstants.DescriptionParameterName},
                {SqlConstants.TypeParameterName} = {SqlConstants.TypeParameterName},
                {SqlConstants.ChallengeColumnName} = {SqlConstants.ChallengeParameterName},
                {SqlConstants.MiddleSchoolColumnName} = {SqlConstants.MiddleSchoolParameterName},
                {SqlConstants.HighSchoolColumnName} = {SqlConstants.HighSchoolParameterName},
                {SqlConstants.IndividualColumnName} = {SqlConstants.IndividualParameterName},
                {SqlConstants.TeamColumnName} = {SqlConstants.TeamParameterName},
                {SqlConstants.SubmittableUriColumnName} = {SqlConstants.SubmittableUriParameterName},
                {SqlConstants.ContactColumnName} = {SqlConstants.ContactParameterName},
                {SqlConstants.OverviewColumnName} = {SqlConstants.OverviewParameterName},
                {SqlConstants.DetailsColumnName} = {SqlConstants.DetailsParameterName},
                {SqlConstants.RulesColumnName} = {SqlConstants.RulesParameterName},
                {SqlConstants.StemIntegrationColumnName} = {SqlConstants.StemIntegrationParameterName},
                {SqlConstants.RelatedCareersColumnName} = {SqlConstants.RelatedCareersParameterName},
                {SqlConstants.RubricColumnName} = {SqlConstants.RubricParameterName},
                {SqlConstants.AttachmentsColumnName} = {SqlConstants.AttachmentsParameterName},
                {SqlConstants.ShowAlertColumnName} = {SqlConstants.ShowAlertParameterName},
                {SqlConstants.AlertColumnName} = {SqlConstants.AlertParameterName},
                {SqlConstants.ArchiveColumnName} = {SqlConstants.ArchiveParameterName},
                {SqlConstants.ActiveColumnName} = {SqlConstants.ActiveParameterName},
                {SqlConstants.ObjectIDColumnName} = {SqlConstants.ObjectIDParameterName},
                {SqlConstants.ModifiedTimestampColumnName} = {SqlConstants.ModifiedTimestampParameterName},
                {SqlConstants.VersionColumnName} = {SqlConstants.VersionParameterName}
            WHERE
                {SqlConstants.IdColumnName} = {SqlConstants.IdParameterName}";
    }
}
