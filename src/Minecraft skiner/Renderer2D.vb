Public Class Renderer2D
    Private _Skin As Bitmap
    ''' <summary>
    ''' The visible skin on the renderer
    ''' </summary>
    ''' <returns>The visible skin</returns>
    Property Skin As Bitmap
        Set(value As Bitmap)
            If Not (value.Height = 64 Or value.Height = 32) And value.Width = 64 Then 'Check the skin
                Throw New ExSkinRes
            End If
            _Skin = value
        End Set
        Get
            Return _Skin
        End Get
    End Property

    Enum Sides
        Front = 0
        Back = 1
        Left = 2
        Right = 3
        Top = 4
        Bottom = 5
    End Enum
    ''' <summary>
    ''' The view port side
    ''' </summary>
    ''' <returns>The view port side</returns>
    Property ViewPortSide As Sides

    Enum Angles
        Normal = 0
        Clockwist = 1
        UpSideDown = 2
        AntiClockwist =3
    End Enum
    ''' <summary>
    ''' The view port angle
    ''' </summary>
    ''' <returns>The view port angle</returns>
    Property ViewPortAngle As Angles

    ''' <summary>
    ''' Show the head or not
    ''' </summary>
    ''' <returns>Show the head or not</returns>
    Property ShowHead As Boolean = True
    ''' <summary>
    ''' Show the second head layer or not
    ''' </summary>
    ''' <returns>Show the second head layer or not</returns>
    Property Show2ndHead As Boolean = True
    ''' <summary>
    ''' Show the body or not
    ''' </summary>
    ''' <returns>Show the body or not</returns>
    Property ShowBody As Boolean = True
    ''' <summary>
    ''' Show the second body layer or not
    ''' </summary>
    ''' <returns>Show the second body layer or not</returns>
    Property Show2ndBody As Boolean = True
    ''' <summary>
    ''' Show the right arm or not
    ''' </summary>
    ''' <returns>Show the right arm or not</returns>
    Property ShowRightArm As Boolean = True
    ''' <summary>
    ''' Show the second right arm layer or not
    ''' </summary>
    ''' <returns>Show the second right arm layer or not</returns>
    Property Show2ndRightArm As Boolean = True
    ''' <summary>
    ''' Show the left arm or not
    ''' </summary>
    ''' <returns>Show the leftht arm or not</returns>
    Property ShowLeftArm As Boolean = True
    ''' <summary>
    ''' Show the second left arm layer or not
    ''' </summary>
    ''' <returns>Show the second left arm layer or not</returns>
    Property Show2ndLeftArm As Boolean = True
    ''' <summary>
    ''' Show the right leg or not
    ''' </summary>
    ''' <returns>Show the right leg or not</returns>
    Property ShowRightLeg As Boolean = True
    ''' <summary>
    ''' Show the second right leg layer or not
    ''' </summary>
    ''' <returns>Show the second right leg layer or not</returns>
    Property Show2ndRightLeg As Boolean = True
    ''' <summary>
    ''' Show the left leg or not
    ''' </summary>
    ''' <returns>Show the leftht leg or not</returns>
    Property ShowLeftLeg As Boolean = True
    ''' <summary>
    ''' Show the second left leg layer or not
    ''' </summary>
    ''' <returns>Show the second left leg layer or not</returns>
    Property Show2ndLeftLeg As Boolean = True

    Private Sub Renderer2D_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics 'Create graphics
        g.Clear(Color.White)
        Dim Middle As New Point(Width / 2, Height / 2) 'Know the middle point
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.TranslateTransform(Middle.X - (8 * 9), Middle.Y - (16 * 9))
        g.ScaleTransform(9, 9)

        Select Case ViewPortSide
            Case Sides.Front
                Dim HeadBM As New Bitmap(16, 32) 'tmp bitmap
                Dim HeadG As Graphics = Graphics.FromImage(HeadBM) 'tmp garphics
                HeadG.DrawImage(Skin, New Rectangle(4, 0, 8, 8), New Rectangle(8, 8, 8, 8), GraphicsUnit.Pixel) 'Drawing the head
                Dim BodyBM As New Bitmap(16, 32) 'tmp bitmap
                Dim BodyG As Graphics = Graphics.FromImage(BodyBM) 'tmp garphics
                BodyG.DrawImage(Skin, New Rectangle(4, 8, 8, 12), New Rectangle(20, 20, 8, 12), GraphicsUnit.Pixel) 'Drawing the Body
                Dim RABM As New Bitmap(16, 32) 'tmp bitmap
                Dim RAG As Graphics = Graphics.FromImage(RABM) 'tmp garphics
                RAG.DrawImage(Skin, New Rectangle(0, 8, 4, 12), New Rectangle(44, 20, 4, 12), GraphicsUnit.Pixel) 'Drawing the right arm
                Dim LABM As New Bitmap(16, 32) 'tmp bitmap
                Dim LAG As Graphics = Graphics.FromImage(LABM) 'tmp garphics
                LAG.DrawImage(Skin, New Rectangle(12, 8, 4, 12), New Rectangle(36, 52, 4, 12), GraphicsUnit.Pixel) 'Drawing the left arm
                Dim RLBM As New Bitmap(16, 32) 'tmp bitmap
                Dim RLG As Graphics = Graphics.FromImage(RLBM) 'tmp garphics
                RLG.DrawImage(Skin, New Rectangle(4, 20, 4, 12), New Rectangle(4, 20, 4, 12), GraphicsUnit.Pixel) 'Drawing the right leg
                Dim LLBM As New Bitmap(16, 32) 'tmp bitmap
                Dim LLG As Graphics = Graphics.FromImage(LABM) 'tmp garphics
                LAG.DrawImage(Skin, New Rectangle(8, 20, 4, 12), New Rectangle(20, 52, 4, 12), GraphicsUnit.Pixel) 'Drawing the left leg
                Dim FinalBM As New Bitmap(16, 32)
                Dim FinalG As Graphics = Graphics.FromImage(FinalBM)
                If ShowHead Then
                    g.DrawImage(HeadBM, 0, 0)
                End If
                If ShowBody Then
                    g.DrawImage(BodyBM, 0, 0)
                End If
                If ShowRightArm Then
                    g.DrawImage(RABM, 0, 0)
                End If
                If ShowLeftArm Then
                    g.DrawImage(LABM, 0, 0)
                End If
                If ShowRightLeg Then
                    g.DrawImage(RLBM, 0, 0)
                End If
                If ShowLeftLeg Then
                    g.DrawImage(LLBM, 0, 0)
                End If

            Case Sides.Back

            Case Sides.Left

            Case Sides.Right

            Case Sides.Top

            Case Sides.Bottom

        End Select
    End Sub
End Class
