﻿Public Class LayerSelector
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
    Dim _Show2ndBody As Boolean = True
    ''' <summary>
    ''' Show the second body layer or not
    ''' </summary>
    ''' <returns>Show the second body layer or not</returns>
    Property Show2ndBody As Boolean
        Set(value As Boolean)
            If Is1point7 Then
                _Show2ndBody = False
            Else
                _Show2ndBody = value
            End If
        End Set
        Get
            Return _Show2ndBody
        End Get
    End Property
    ''' <summary>
    ''' Show the right arm or not
    ''' </summary>
    ''' <returns>Show the right arm or not</returns>
    Property ShowRightArm As Boolean = True
    Dim _Show2ndRightArm As Boolean = True
    ''' <summary>
    ''' Show the second right arm layer or not
    ''' </summary>
    ''' <returns>Show the second right arm layer or not</returns>
    Property Show2ndRightArm As Boolean
        Set(value As Boolean)
            If Is1point7 Then
                _Show2ndRightArm = False
            Else
                _Show2ndRightArm = value
            End If
        End Set
        Get
            Return _Show2ndRightArm
        End Get
    End Property
    ''' <summary>
    ''' Show the left arm or not
    ''' </summary>
    ''' <returns>Show the leftht arm or not</returns>
    Property ShowLeftArm As Boolean = True
    Dim _Show2ndLeftArm As Boolean = True
    ''' <summary>
    ''' Show the second left arm layer or not
    ''' </summary>
    ''' <returns>Show the second left arm layer or not</returns>
    Property Show2ndLeftArm As Boolean
        Set(value As Boolean)
            If Is1point7 Then
                _Show2ndLeftArm = False
            Else
                _Show2ndLeftArm = value
            End If
        End Set
        Get
            Return _Show2ndLeftArm
        End Get
    End Property
    ''' <summary>
    ''' Show the right leg or not
    ''' </summary>
    ''' <returns>Show the right leg or not</returns>
    Property ShowRightLeg As Boolean = True
    Dim _Show2ndRightLeg As Boolean = True
    ''' <summary>
    ''' Show the second right leg layer or not
    ''' </summary>
    ''' <returns>Show the second right leg layer or not</returns>
    Property Show2ndRightLeg As Boolean
        Set(value As Boolean)
            If Is1point7 Then
                _Show2ndRightLeg = False
            Else
                _Show2ndRightLeg = value
            End If
        End Set
        Get
            Return _Show2ndRightLeg
        End Get
    End Property
    ''' <summary>
    ''' Show the left leg or not
    ''' </summary>
    ''' <returns>Show the leftht leg or not</returns>
    Property ShowLeftLeg As Boolean = True
    Dim _Show2ndLeftLeg As Boolean = True
    ''' <summary>
    ''' Show the second left leg layer or not
    ''' </summary>
    ''' <returns>Show the second left leg layer or not</returns>
    Property Show2ndLeftLeg As Boolean
        Set(value As Boolean)
            If Is1point7 Then
                _Show2ndLeftLeg = False
            Else
                _Show2ndLeftLeg = value
            End If
        End Set
        Get
            Return _Show2ndLeftLeg
        End Get
    End Property
    ''' <summary>
    ''' Lock the selector to renderer
    ''' </summary>
    ''' <returns>Locked renderer</returns>
    Property _3DRenderer As Renderer3D = New Renderer3D

    Property Is1point7 As Boolean

    Private Sub LayerSelector_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim currentContext As BufferedGraphicsContext
        Dim g As BufferedGraphics 'Create graphics
        currentContext = BufferedGraphicsManager.Current
        g = currentContext.Allocate(Me.CreateGraphics,
   Me.DisplayRectangle)
        g.Graphics.Clear(BackColor)
        g.Graphics.DrawImage(My.Resources.steveheadnone, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        g.Graphics.DrawImage(My.Resources.stevebodynone, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        g.Graphics.DrawImage(My.Resources.steverightarmnone, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        g.Graphics.DrawImage(My.Resources.steveleftarmnone, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        g.Graphics.DrawImage(My.Resources.steverightlegnone, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        g.Graphics.DrawImage(My.Resources.steveleftlegnone, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)

        If ShowBody Then
            g.Graphics.DrawImage(My.Resources.steve1, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndBody Then
            g.Graphics.DrawImage(My.Resources.steve2, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowHead Then
            g.Graphics.DrawImage(My.Resources.steve3, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndHead Then
            g.Graphics.DrawImage(My.Resources.steve4, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowRightArm Then
            g.Graphics.DrawImage(My.Resources.steve5, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndRightArm Then
            g.Graphics.DrawImage(My.Resources.steve6, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowLeftArm Then
            g.Graphics.DrawImage(My.Resources.steve7, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndLeftArm Then
            g.Graphics.DrawImage(My.Resources.steve8, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowRightLeg Then
            g.Graphics.DrawImage(My.Resources.steve9, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndRightLeg Then
            g.Graphics.DrawImage(My.Resources.steve10, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If ShowLeftLeg Then
            g.Graphics.DrawImage(My.Resources.steve11, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        If Show2ndLeftLeg Then
            g.Graphics.DrawImage(My.Resources.steve12, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, 198, 198), GraphicsUnit.Pixel)
        End If
        g.Render(e.Graphics)
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
        ElseIf ShowBody AndAlso Not Show2ndBody Then
            Show2ndBody = True
            ShowBody = False
        ElseIf Not ShowBody AndAlso Show2ndBody Then
            Show2ndBody = False
            ShowBody = False
        ElseIf Not ShowBody AndAlso Not Show2ndBody Then
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
        _3DRenderer.Show2ndBody = Show2ndBody
        _3DRenderer.Show2ndHead = Show2ndHead
        _3DRenderer.Show2ndLeftArm = Show2ndLeftArm
        _3DRenderer.Show2ndLeftLeg = Show2ndLeftLeg
        _3DRenderer.Show2ndRightArm = Show2ndRightArm
        _3DRenderer.Show2ndRightLeg = Show2ndRightLeg
        _3DRenderer.ShowBody = ShowBody
        _3DRenderer.ShowHead = ShowHead
        _3DRenderer.ShowLeftArm = ShowLeftArm
        _3DRenderer.ShowLeftLeg = ShowLeftLeg
        _3DRenderer.ShowRightArm = ShowRightArm
        _3DRenderer.ShowRightLeg = ShowRightLeg
        _3DRenderer.Refresh()
    End Sub
End Class
