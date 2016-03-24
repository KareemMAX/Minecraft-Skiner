Imports Newtonsoft.Json

Public Class UUID
    <JsonProperty("uuid")> Public UUID As String
    <JsonProperty("full_uuid")> Public FormatedUUID As String
    <JsonProperty("name")> Public Name As String
    <JsonProperty("took")> Public Took As Integer
    <JsonProperty("source")> Public Source As String
    <JsonProperty("query")> Public OrigenalName As String
End Class
