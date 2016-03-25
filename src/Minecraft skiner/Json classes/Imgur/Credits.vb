Imports Newtonsoft.Json
Namespace Credits
    Public Class Credits
        <JsonProperty("data")> Public Data As Data
    End Class

    Public Class Data
        <JsonProperty("ClientRemaining")> Public ClientRemaining As Integer
    End Class
End Namespace