Public Class ExSkinRes
    Inherits Exception
    Overloads ReadOnly Property Message
        Get
            Return "The skin resolution must be 64 x 64 or 64 x 32."
        End Get
    End Property
End Class
