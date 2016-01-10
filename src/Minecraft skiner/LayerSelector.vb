Public Class LayerSelector
    Dim _showhead As Boolean = True
    ''' <summary>
    ''' Show the head or not
    ''' </summary>
    ''' <returns>Show the head or not</returns>
    Property ShowHead As Boolean
        Set(value As Boolean)
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
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
            UpdateSelectors()
            _show2ndll = value
        End Set
        Get
            Return _show2ndll
        End Get
    End Property
    ''' <summary>
    ''' Lock the selector to renderer
    ''' </summary>
    ''' <returns>Locked renderer</returns>
    Property Renderer As Renderer2D = New Renderer2D

    Private Sub LayerSelector_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(BackColor)
        If ShowBody Then
            e.Graphics.DrawImage(My.Resources.steve1, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndBody Then
            e.Graphics.DrawImage(My.Resources.steve2, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowHead Then
            e.Graphics.DrawImage(My.Resources.steve3, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndHead Then
            e.Graphics.DrawImage(My.Resources.steve4, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowRightArm Then
            e.Graphics.DrawImage(My.Resources.steve5, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndRightArm Then
            e.Graphics.DrawImage(My.Resources.steve6, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowLeftArm Then
            e.Graphics.DrawImage(My.Resources.steve7, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndLeftArm Then
            e.Graphics.DrawImage(My.Resources.steve8, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowRightLeg Then
            e.Graphics.DrawImage(My.Resources.steve9, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndRightLeg Then
            e.Graphics.DrawImage(My.Resources.steve10, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowLeftLeg Then
            e.Graphics.DrawImage(My.Resources.steve11, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndLeftLeg Then
            e.Graphics.DrawImage(My.Resources.steve12, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
    End Sub

    Private Sub LayerSelector_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Dim gridsize As New SizeF(Width / 198, Height / 198)
        If e.Button = MouseButtons.Left AndAlso e.X >= gridsize.Width * 79 AndAlso e.Y >= gridsize.Height * 17 AndAlso
                e.X <= gridsize.Width * 118 AndAlso e.Y <= gridsize.Height * 56 Then
            SwitchHead()
        ElseIf e.Button = MouseButtons.Left AndAlso e.X >= gridsize.Width * 79 AndAlso e.Y >= gridsize.Height * 59 AndAlso
            e.X <= gridsize.Width * 118 AndAlso e.Y <= gridsize.Height * 118 Then
            SwitchBody()
        ElseIf e.Button = MouseButtons.Left AndAlso e.X >= gridsize.Width * 36 AndAlso e.Y >= gridsize.Height * 53 AndAlso
        e.X <= gridsize.Width * 78 AndAlso e.Y <= gridsize.Height * 116 Then
            SwitchRightArm()
        ElseIf e.Button = MouseButtons.Left AndAlso e.X >= gridsize.Width * 119 AndAlso e.Y >= gridsize.Height * 53 AndAlso
    e.X <= gridsize.Width * 161 AndAlso e.Y <= gridsize.Height * 116 Then
            SwitchLeftArm()
        ElseIf e.Button = MouseButtons.Left AndAlso e.X >= gridsize.Width * 56 AndAlso e.Y >= gridsize.Height * 119 AndAlso
    e.X <= gridsize.Width * 98 AndAlso e.Y <= gridsize.Height * 181 Then
            SwitchRightLeg()
        ElseIf e.Button = MouseButtons.Left AndAlso e.X >= gridsize.Width * 99 AndAlso e.Y >= gridsize.Height * 119 AndAlso
    e.X <= gridsize.Width * 141 AndAlso e.Y <= gridsize.Height * 181 Then
            SwitchLeftLeg()
        End If

    End Sub

    Private Sub SwitchRightArm()
        If ShowRightArm AndAlso Show2ndRightArm Then
            Show2ndRightArm = False
        ElseIf ShowRightArm AndAlso Not Show2ndRightArm Then
            Show2ndRightArm = True
            ShowRightArm = False
        ElseIf Not ShowRightArm AndAlso Show2ndRightArm Then
            Show2ndRightArm = False
            ShowRightArm = False
        ElseIf Not ShowRightArm AndAlso Not Show2ndRightArm Then
            Show2ndRightArm = True
            ShowRightArm = True
        End If
        UpdateSelectors()
        Refresh()
    End Sub

    Private Sub SwitchRightLeg()
        If ShowRightLeg AndAlso Show2ndRightLeg Then
            Show2ndRightLeg = False
        ElseIf ShowRightLeg AndAlso Not Show2ndRightLeg Then
            Show2ndRightLeg = True
            ShowRightLeg = False
        ElseIf Not ShowRightLeg AndAlso Show2ndRightLeg Then
            Show2ndRightLeg = False
            ShowRightLeg = False
        ElseIf Not ShowRightLeg AndAlso Not Show2ndRightLeg Then
            Show2ndRightLeg = True
            ShowRightLeg = True
        End If
        UpdateSelectors()
        Refresh()
    End Sub

    Private Sub SwitchLeftLeg()
        If ShowLeftLeg AndAlso Show2ndLeftLeg Then
            Show2ndLeftLeg = False
        ElseIf ShowLeftLeg AndAlso Not Show2ndLeftLeg Then
            Show2ndLeftLeg = True
            ShowLeftLeg = False
        ElseIf Not ShowLeftLeg AndAlso Show2ndLeftLeg Then
            Show2ndLeftLeg = False
            ShowLeftLeg = False
        ElseIf Not ShowLeftLeg AndAlso Not Show2ndLeftLeg Then
            Show2ndLeftLeg = True
            ShowLeftLeg = True
        End If
        UpdateSelectors()
        Refresh()
    End Sub

    Private Sub SwitchLeftArm()
        If ShowLeftArm AndAlso Show2ndLeftArm Then
            Show2ndLeftArm = False
        ElseIf ShowLeftArm AndAlso Not Show2ndLeftArm Then
            Show2ndLeftArm = True
            ShowLeftArm = False
        ElseIf Not ShowLeftArm AndAlso Show2ndLeftArm Then
            Show2ndLeftArm = False
            ShowLeftArm = False
        ElseIf Not ShowLeftArm AndAlso Not Show2ndLeftArm Then
            Show2ndLeftArm = True
            ShowLeftArm = True
        End If
        UpdateSelectors()
        Refresh()
    End Sub

    Private Sub SwitchBody()
        If ShowBody AndAlso Show2ndBody Then
            Show2ndBody = False
        ElseIf Showbody AndAlso Not Show2ndbody Then
            Show2ndBody = True
            ShowBody = False
        ElseIf Not Showbody AndAlso Show2ndbody Then
            Show2ndBody = False
            ShowBody = False
        ElseIf Not Showbody AndAlso Not Show2ndbody Then
            Show2ndBody = True
            ShowBody = True
        End If
        UpdateSelectors()
        Refresh()
    End Sub

    Private Sub SwitchHead()
        If ShowHead AndAlso Show2ndHead Then
            Show2ndHead = False
        ElseIf ShowHead AndAlso Not Show2ndHead Then
            Show2ndHead = True
            ShowHead = False
        ElseIf Not ShowHead AndAlso Show2ndHead Then
            Show2ndHead = False
            ShowHead = False
        ElseIf Not ShowHead AndAlso Not Show2ndHead Then
            Show2ndHead = True
            ShowHead = True
        End If
        UpdateSelectors()
        Refresh()
    End Sub
    Sub UpdateSelectors()
        Renderer.Show2ndBody = Show2ndBody
        Renderer.Show2ndHead = Show2ndHead
        Renderer.Show2ndLeftArm = Show2ndLeftArm
        Renderer.Show2ndLeftLeg = Show2ndLeftLeg
        Renderer.Show2ndRightArm = Show2ndRightArm
        Renderer.Show2ndRightLeg = Show2ndRightLeg
        Renderer.ShowBody = ShowBody
        Renderer.ShowHead = ShowHead
        Renderer.ShowLeftArm = ShowLeftArm
        Renderer.ShowLeftLeg = ShowLeftLeg
        Renderer.ShowRightArm = ShowRightArm
        Renderer.ShowRightLeg = Show2ndRightLeg
        Renderer.Refresh()
    End Sub
End Class
