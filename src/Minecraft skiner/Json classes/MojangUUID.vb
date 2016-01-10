Imports Newtonsoft.Json

Public Class MojangUUID
    <JsonProperty("id")> Public UUID As String
    <JsonProperty("name")> Public Name As String
End Class
