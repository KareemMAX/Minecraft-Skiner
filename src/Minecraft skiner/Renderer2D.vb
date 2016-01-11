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
        AntiClockwist = 3
    End Enum
    ''' <summary>
    ''' The view port angle
    ''' </summary>
    ''' <returns>The view port angle</returns>
    Property ViewPortAngle As Angles

    Dim _showhead As Boolean = True
    ''' <summary>
    ''' Show the head or not
    ''' </summary>
    ''' <returns>Show the head or not</returns>
    Property ShowHead As Boolean
        Set(value As Boolean)
            Refresh()
            _showhead = value
        End Set
        Get
            Return _showhead
        End Get
    End Property
    Dim _show2ndhead As Boolean = True
    ''' <summary>
    ''' Show the second head layer or not
    ''' </summary>
    ''' <returns>Show the second head layer or not</returns>
    Property Show2ndHead As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndhead = value
        End Set
        Get
            Return _show2ndhead
        End Get
    End Property
    Dim _showbody As Boolean = True
    ''' <summary>
    ''' Show the body or not
    ''' </summary>
    ''' <returns>Show the body or not</returns>
    Property ShowBody As Boolean
        Set(value As Boolean)
            Refresh()
            _showbody = value
        End Set
        Get
            Return _showbody
        End Get
    End Property
    Dim _show2ndbody As Boolean = True
    ''' <summary>
    ''' Show the second body layer or not
    ''' </summary>
    ''' <returns>Show the second body layer or not</returns>
    Property Show2ndBody As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndbody = value
        End Set
        Get
            Return _show2ndbody
        End Get
    End Property
    Dim _showra As Boolean = True
    ''' <summary>
    ''' Show the right arm or not
    ''' </summary>
    ''' <returns>Show the right arm or not</returns>
    Property ShowRightArm As Boolean
        Set(value As Boolean)
            Refresh()
            _showra = value
        End Set
        Get
            Return _showra
        End Get
    End Property
    Dim _show2ndra As Boolean = True
    ''' <summary>
    ''' Show the second right arm layer or not
    ''' </summary>
    ''' <returns>Show the second right arm layer or not</returns>
    Property Show2ndRightArm As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndra = value
        End Set
        Get
            Return _show2ndra
        End Get
    End Property
    Dim _showla As Boolean = True
    ''' <summary>
    ''' Show the left arm or not
    ''' </summary>
    ''' <returns>Show the leftht arm or not</returns>
    Property ShowLeftArm As Boolean
        Set(value As Boolean)
            Refresh()
            _showla = value
        End Set
        Get
            Return _showla
        End Get
    End Property
    Dim _show2ndla As Boolean = True
    ''' <summary>
    ''' Show the second left arm layer or not
    ''' </summary>
    ''' <returns>Show the second left arm layer or not</returns>
    Property Show2ndLeftArm As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndla = value
        End Set
        Get
            Return _show2ndla
        End Get
    End Property
    Dim _showrl As Boolean = True
    ''' <summary>
    ''' Show the right leg or not
    ''' </summary>
    ''' <returns>Show the right leg or not</returns>
    Property ShowRightLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _showrl = value
        End Set
        Get
            Return _showrl
        End Get
    End Property
    Dim _show2ndrl As Boolean = True
    ''' <summary>
    ''' Show the second right leg layer or not
    ''' </summary>
    ''' <returns>Show the second right leg layer or not</returns>
    Property Show2ndRightLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndrl = value
        End Set
        Get
            Return _show2ndrl
        End Get
    End Property
    Dim _showll As Boolean = True
    ''' <summary>
    ''' Show the left leg or not
    ''' </summary>
    ''' <returns>Show the leftht leg or not</returns>
    Property ShowLeftLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _showll = value
        End Set
        Get
            Return _showll
        End Get
    End Property
    Dim _show2ndll As Boolean = True
    ''' <summary>
    ''' Show the second left leg layer or not
    ''' </summary>
    ''' <returns>Show the second left leg layer or not</returns>
    Property Show2ndLeftLeg As Boolean
        Set(value As Boolean)
            Refresh()
            _show2ndll = value
        End Set
        Get
            Return _show2ndll
        End Get
    End Property


    Enum Models
        Steve
        Alex
    End Enum
    ''' <summary>
    ''' The rendered model
    ''' </summary>
    ''' <returns>The rendered model</returns>
    Property Model As Models

    Private Sub Renderer2D_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim currentContext As BufferedGraphicsContext
        Dim g As BufferedGraphics 'Create graphics
        currentContext = BufferedGraphicsManager.Current
        g = currentContext.Allocate(Me.CreateGraphics,
   Me.DisplayRectangle)
        g.Graphics.Clear(BackColor)
        Dim Middle As New Point(Width / 2, Height / 2) 'Know the middle point
        g.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.Graphics.TranslateTransform(Middle.X - (8 * 9), Middle.Y - (16 * 9))
        g.Graphics.ScaleTransform(9, 9)

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
                Dim LABM As New Bitmap(16, 32) 'tmp bitmap
                Dim LAG As Graphics = Graphics.FromImage(LABM) 'tmp garphics
                If Model = Models.Steve Then
                    RAG.DrawImage(Skin, New Rectangle(0, 8, 4, 12), New Rectangle(44, 20, 4, 12), GraphicsUnit.Pixel) 'Drawing the right arm
                    LAG.DrawImage(Skin, New Rectangle(12, 8, 4, 12), New Rectangle(36, 52, 4, 12), GraphicsUnit.Pixel) 'Drawing the left arm
                Else
                    RAG.DrawImage(Skin, New Rectangle(1, 8, 3, 12), New Rectangle(44, 20, 3, 12), GraphicsUnit.Pixel) 'Drawing the right arm
                    LAG.DrawImage(Skin, New Rectangle(12, 8, 3, 12), New Rectangle(36, 52, 3, 12), GraphicsUnit.Pixel) 'Drawing the left arm
                End If
                Dim RLBM As New Bitmap(16, 32) 'tmp bitmap
                Dim RLG As Graphics = Graphics.FromImage(RLBM) 'tmp garphics
                RLG.DrawImage(Skin, New Rectangle(4, 20, 4, 12), New Rectangle(4, 20, 4, 12), GraphicsUnit.Pixel) 'Drawing the right leg
                Dim LLBM As New Bitmap(16, 32) 'tmp bitmap
                Dim LLG As Graphics = Graphics.FromImage(LLBM) 'tmp garphics
                LLG.DrawImage(Skin, New Rectangle(8, 20, 4, 12), New Rectangle(20, 52, 4, 12), GraphicsUnit.Pixel) 'Drawing the left leg
                If ShowHead Then
                    g.Graphics.DrawImage(HeadBM, 0, 0)
                End If
                If ShowBody Then
                    g.Graphics.DrawImage(BodyBM, 0, 0)
                End If
                If ShowRightArm Then
                    g.Graphics.DrawImage(RABM, 0, 0)
                End If
                If ShowLeftArm Then
                    g.Graphics.DrawImage(LABM, 0, 0)
                End If
                If ShowRightLeg Then
                    g.Graphics.DrawImage(RLBM, 0, 0)
                End If
                If ShowLeftLeg Then
                    g.Graphics.DrawImage(LLBM, 0, 0)
                End If
                g.Graphics.ScaleTransform(1.05F, 1.05F)
                g.Graphics.TranslateTransform(-0.3, -0.5)
                Dim Head2BM As New Bitmap(16, 32) 'tmp bitmap
                Dim Head2G As Graphics = Graphics.FromImage(Head2BM) 'tmp garphics
                Head2G.DrawImage(Skin, New Rectangle(4, 0, 8, 8), New Rectangle(40, 8, 8, 8), GraphicsUnit.Pixel) 'Drawing the head
                Dim Body2BM As New Bitmap(16, 32) 'tmp bitmap
                Dim Body2G As Graphics = Graphics.FromImage(Body2BM) 'tmp garphics
                Body2G.DrawImage(Skin, New Rectangle(4, 8, 8, 12), New Rectangle(20, 36, 8, 12), GraphicsUnit.Pixel) 'Drawing the Body
                Dim RA2BM As New Bitmap(16, 32) 'tmp bitmap
                Dim RA2G As Graphics = Graphics.FromImage(RA2BM) 'tmp garphics
                Dim LA2BM As New Bitmap(16, 32) 'tmp bitmap
                Dim LA2G As Graphics = Graphics.FromImage(LA2BM) 'tmp garphics
                If Model = Models.Steve Then
                    RA2G.DrawImage(Skin, New Rectangle(0, 8, 4, 12), New Rectangle(44, 36, 4, 12), GraphicsUnit.Pixel) 'Drawing the right arm
                    LA2G.DrawImage(Skin, New Rectangle(12, 8, 4, 12), New Rectangle(52, 52, 4, 12), GraphicsUnit.Pixel) 'Drawing the left arm
                Else
                    RA2G.DrawImage(Skin, New Rectangle(1, 8, 3, 12), New Rectangle(44, 36, 3, 12), GraphicsUnit.Pixel) 'Drawing the right arm
                    LA2G.DrawImage(Skin, New Rectangle(12, 8, 3, 12), New Rectangle(52, 52, 3, 12), GraphicsUnit.Pixel) 'Drawing the left arm
                End If
                Dim RL2BM As New Bitmap(16, 32) 'tmp bitmap
                Dim RL2G As Graphics = Graphics.FromImage(RL2BM) 'tmp garphics
                RL2G.DrawImage(Skin, New Rectangle(4, 20, 4, 12), New Rectangle(4, 36, 4, 12), GraphicsUnit.Pixel) 'Drawing the right leg
                Dim LL2BM As New Bitmap(16, 32) 'tmp bitmap
                Dim LL2G As Graphics = Graphics.FromImage(LL2BM) 'tmp garphics
                LL2G.DrawImage(Skin, New Rectangle(8, 20, 4, 12), New Rectangle(4, 52, 4, 12), GraphicsUnit.Pixel) 'Drawing the left leg
                If Show2ndHead Then
                    g.Graphics.DrawImage(Head2BM, 0, 0)
                End If
                If Show2ndBody Then
                    g.Graphics.DrawImage(Body2BM, 0, 0)
                End If
                If Show2ndRightArm Then
                    g.Graphics.DrawImage(RA2BM, 0, 0)
                End If
                If Show2ndLeftArm Then
                    g.Graphics.DrawImage(LA2BM, 0, 0)
                End If
                If Show2ndRightLeg Then
                    g.Graphics.DrawImage(RL2BM, 0, 0)
                End If
                If Show2ndLeftLeg Then
                    g.Graphics.DrawImage(LL2BM, 0, 0)
                End If
            Case Sides.Back

            Case Sides.Left

            Case Sides.Right

            Case Sides.Top

            Case Sides.Bottom

        End Select
        g.Render(e.Graphics)
    End Sub
End Class
