Imports Newtonsoft.Json

Namespace Image
    Public Class ImageRespone
        <JsonProperty("data")> Public Data As Data
    End Class

    Public Class Data
        <JsonProperty("link")> Public Link As String
        <JsonProperty("deletehash")> Public DeleteHash As String
    End Class
End Namespace
