Imports OpenTK
Imports OpenTK.Graphics.OpenGL
Imports System.Drawing.Imaging
Imports System.ComponentModel

Public Class Renderer3D
    Private _Skin As Bitmap
    ''' <summary>
    ''' The visible skin on the renderer
    ''' </summary>
    ''' <returns>The visible skin</returns>
    <Description("The current skin"), Category("Appearance")> Property Skin As Bitmap
        Set(value As Bitmap)
            If Not value.Height = 64 And value.Width = 64 Then 'Check the skin
                Throw New ExSkinRes
            End If
            _Skin = value
        End Set
        Get
            Return _Skin
        End Get
    End Property

    Dim _showhead As Boolean = True
    ''' <summary>
    ''' Show the head or not
    ''' </summary>
    ''' <returns>Show the head or not</returns>
    <Description("Shows the head layer or not"), Category("Appearance")> Property ShowHead As Boolean
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
    <Description("Shows the second head layer or not"), Category("Appearance")> Property Show2ndHead As Boolean
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
    <Description("Shows the body layer or not"), Category("Appearance")> Property ShowBody As Boolean
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
    <Description("Shows the second body layer or not"), Category("Appearance")> Property Show2ndBody As Boolean
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
    <Description("Shows the right arm layer or not"), Category("Appearance")> Property ShowRightArm As Boolean
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
    <Description("Shows the second right arm layer or not"), Category("Appearance")> Property Show2ndRightArm As Boolean
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
    <Description("Shows the left arm layer or not"), Category("Appearance")> Property ShowLeftArm As Boolean
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
    <Description("Shows the second left arm layer or not"), Category("Appearance")> Property Show2ndLeftArm As Boolean
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
    <Description("Shows the right leg layer or not"), Category("Appearance")> Property ShowRightLeg As Boolean
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
    <Description("Shows the second right leg layer or not"), Category("Appearance")> Property Show2ndRightLeg As Boolean
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
    <Description("Shows the left leg layer or not"), Category("Appearance")> Property ShowLeftLeg As Boolean
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
    <Description("Shows the second left leg layer or not"), Category("Appearance")> Property Show2ndLeftLeg As Boolean
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
    <Description("The current player model"), Category("Appearance")> Property Model As Models

    ''' <summary>
    ''' X rotation
    ''' </summary>
    ''' <returns>X rotattion</returns>
    <Description("The X rotation of the model"), Category("Appearance")> Property RotationX As Integer

    ''' <summary>
    ''' Y rotation
    ''' </summary>
    ''' <returns>Y rotation</returns>
    <Description("The Y rotation of the model"), Category("Appearance")> Property RotationY As Integer

    Dim _Zoom As Double = 1
    <Description("The zoom value"), Category("Appearance")> Property Zoom As Double
        Set(value As Double)
            If value < 1 Then
                value = 1
            ElseIf value > 10 Then
                value = 10
            End If

            _Zoom = value
        End Set
        Get
            Return _Zoom
        End Get
    End Property

    Dim _LookX As Double = 0
    <Description("The X axis offset from the orignal point (for zoom)"), Category("Appearance")> Property LookX As Double
        Set(value As Double)
            If value < -8 Then
                value = -8
            ElseIf value > 8 Then
                value = 8
            End If

            _LookX = value
        End Set
        Get
            Return _LookX
        End Get
    End Property


    Dim _LookY As Double = 0
    <Description("The Y axis offset from the orignal point (for zoom)"), Category("Appearance")> Property LookY As Double
        Set(value As Double)
            If value < -16 Then
                value = -16
            ElseIf value > 16 Then
                value = 16
            End If

            _LookY = value
        End Set
        Get
            Return _LookY
        End Get
    End Property

    ''' <summary>
    ''' The current color picker
    ''' </summary>
    <Description("The current color picker"), Category("Behavior")>
    Property ColorPicker As New ColorPicker

    <Description("Can paint on the skin"), Category("Behavior")>
    Property Paintable As Boolean = True

    ''' <summary>
    ''' Stop the paint faction
    ''' </summary>
    ''' <returns>Is stopped or not</returns>
    <Description("Render it or not (only used when design because when it became false in design mode it crashs VS and can be removed in the release)"), Category("Behavior")>
    Property InDesignMode As Boolean = True

    Dim perspective As Matrix4 = Matrix4.CreatePerspectiveFieldOfView(Zoom ^ -1, Width / Height, 1, 100) 'Setup Perspective
    Dim lookat As Matrix4 = Matrix4.LookAt(LookX, LookY, 36, LookX, LookY, 0, 0, 1, 1) 'Setup camera

#Disable Warning BC40000
    Private Sub GlControl_Paint(sender As Object, e As PaintEventArgs) Handles GlControl.Paint
        If InDesignMode Then Exit Sub

        GlControl.MakeCurrent()

        GL.ClearColor(BackColor)
        'First Clear Buffers
        GL.Clear(ClearBufferMask.ColorBufferBit)
        GL.Clear(ClearBufferMask.DepthBufferBit)

        'Basic Setup for viewing
        perspective = Matrix4.CreatePerspectiveFieldOfView(Zoom ^ -1, Width / Height, 1, 100) 'Setup Perspective
        lookat = Matrix4.LookAt(LookX, LookY, 36, LookX, LookY, 0, 0, 1, 1) 'Setup camera
        GL.MatrixMode(MatrixMode.Projection) 'Load Perspective
        GL.LoadIdentity()
        GL.LoadMatrix(perspective)
        GL.MatrixMode(MatrixMode.Modelview) 'Load Camera
        GL.LoadIdentity()
        GL.LoadMatrix(lookat)
        GL.Viewport(0, 0, GlControl.Width, GlControl.Height) 'Size of window
        GL.Enable(EnableCap.DepthTest) 'Enable correct Z Drawings
        GL.Enable(EnableCap.Texture2D) 'Enable textures
        GL.DepthFunc(DepthFunction.Less) 'Enable correct Z Drawings
        'GL.Disable(EnableCap.Blend) 'Disable transparent
        GL.Disable(EnableCap.AlphaTest) 'Disable transparent

        'Load the textures
        Dim texID As Integer = 1
        GL.BindTexture(TextureTarget.Texture2D, texID)
        Dim data As BitmapData = Skin.LockBits(New Rectangle(0, 0, 64, 64),
   ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppPArgb)
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 64, 64, 0,
    Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0)
        Skin.UnlockBits(data)
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D)
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureMinFilter.Nearest)
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureMagFilter.Nearest)

        Const TexVal As Double = 1 / 64

        'Rotating
        GL.Rotate(RotationX, -1, 0, 0)
        GL.Rotate(RotationY, 0, 1, 0)

        GL.BindTexture(TextureTarget.ProxyTexture2D, texID)
        'Vertex goes (X,Y,Z)
        GL.Begin(BeginMode.Quads)
        'Body
        If ShowBody Then
            'Face 1
            GL.TexCoord2(TexVal * 20, TexVal * 20)
            GL.Vertex3(-4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 20, TexVal * 32)
            GL.Vertex3(-4, -4, 2)
            'Face 2
            GL.TexCoord2(TexVal * 40, TexVal * 20)
            GL.Vertex3(-4, 8, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 20)
            GL.Vertex3(4, 8, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 32)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 40, TexVal * 32)
            GL.Vertex3(-4, -4, -2)
            'Face 3
            GL.TexCoord2(TexVal * 20, TexVal * 20)
            GL.Vertex3(-4, 8, 2)
            GL.TexCoord2(TexVal * 16, TexVal * 20)
            GL.Vertex3(-4, 8, -2)
            GL.TexCoord2(TexVal * 16, TexVal * 32)
            GL.Vertex3(-4, -4, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 32)
            GL.Vertex3(-4, -4, 2)
            'Face 4
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(4, 8, 2)
            GL.TexCoord2(TexVal * 32, TexVal * 20)
            GL.Vertex3(4, 8, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 32)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(4, -4, 2)
            'Face 5
            GL.TexCoord2(TexVal * 20, TexVal * 20)
            GL.Vertex3(-4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(4, 8, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 16)
            GL.Vertex3(4, 8, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 16)
            GL.Vertex3(-4, 8, -2)
            'Face 6
            GL.TexCoord2(TexVal * 28, TexVal * 16)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 36, TexVal * 16)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 36, TexVal * 20)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(-4, -4, -2)
        End If

        If ShowHead Then
            'Head
            'Face 1
            GL.TexCoord2(TexVal * 8, TexVal * 8)
            GL.Vertex3(-4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 16)
            GL.Vertex3(4, 8, 4)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(-4, 8, 4)
            'Face 2
            GL.TexCoord2(TexVal * 32, TexVal * 8)
            GL.Vertex3(-4, 16, -4)
            GL.TexCoord2(TexVal * 24, TexVal * 8)
            GL.Vertex3(4, 16, -4)
            GL.TexCoord2(TexVal * 24, TexVal * 16)
            GL.Vertex3(4, 8, -4)
            GL.TexCoord2(TexVal * 32, TexVal * 16)
            GL.Vertex3(-4, 8, -4)
            'Face 3
            GL.TexCoord2(TexVal * 8, TexVal * 8)
            GL.Vertex3(-4, 16, 4)
            GL.TexCoord2(TexVal * 0, TexVal * 8)
            GL.Vertex3(-4, 16, -4)
            GL.TexCoord2(TexVal * 0, TexVal * 16)
            GL.Vertex3(-4, 8, -4)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(-4, 8, 4)
            'Face 4
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(4, 16, 4)
            GL.TexCoord2(TexVal * 24, TexVal * 8)
            GL.Vertex3(4, 16, -4)
            GL.TexCoord2(TexVal * 24, TexVal * 16)
            GL.Vertex3(4, 8, -4)
            GL.TexCoord2(TexVal * 16, TexVal * 16)
            GL.Vertex3(4, 8, 4)
            'Face 5
            GL.TexCoord2(TexVal * 8, TexVal * 8)
            GL.Vertex3(-4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(4, 16, 4)
            GL.TexCoord2(TexVal * 16, TexVal * 0)
            GL.Vertex3(4, 16, -4)
            GL.TexCoord2(TexVal * 8, TexVal * 0)
            GL.Vertex3(-4, 16, -4)
            'Face 6
            GL.TexCoord2(TexVal * 16, TexVal * 8)
            GL.Vertex3(-4, 8, 4)
            GL.TexCoord2(TexVal * 24, TexVal * 8)
            GL.Vertex3(4, 8, 4)
            GL.TexCoord2(TexVal * 24, TexVal * 0)
            GL.Vertex3(4, 8, -4)
            GL.TexCoord2(TexVal * 16, TexVal * 0)
            GL.Vertex3(-4, 8, -4)
        End If

        If Model = Models.Steve Then

            If ShowLeftArm Then
                'LefttArm
                'Face 1
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(8, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 64)
                GL.Vertex3(8, -4, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 48, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 52)
                GL.Vertex3(8, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 64)
                GL.Vertex3(8, -4, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 32, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                GL.TexCoord2(TexVal * 32, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 44, TexVal * 52)
                GL.Vertex3(8, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(8, 8, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 64)
                GL.Vertex3(8, -4, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 64)
                GL.Vertex3(8, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(8, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(8, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 48)
                GL.Vertex3(4, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(4, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 52)
                GL.Vertex3(8, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(8, -4, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(4, -4, -2)
            End If

            If ShowRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-8, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-8, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 56, TexVal * 20)
                GL.Vertex3(-8, 8, -2)
                GL.TexCoord2(TexVal * 52, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 52, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 56, TexVal * 32)
                GL.Vertex3(-8, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 40, TexVal * 20)
                GL.Vertex3(-8, 8, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-8, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-8, -4, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 32)
                GL.Vertex3(-8, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 52, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 52, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-8, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 16)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 16)
                GL.Vertex3(-8, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-8, -4, 2)
                GL.TexCoord2(TexVal * 52, TexVal * 20)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 52, TexVal * 16)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 16)
                GL.Vertex3(-8, -4, -2)
            End If

        Else

            If ShowLeftArm Then
                'LefttArm
                'Face 1
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(7, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 64)
                GL.Vertex3(7, -4, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 46, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 43, TexVal * 52)
                GL.Vertex3(7, 8, -2)
                GL.TexCoord2(TexVal * 43, TexVal * 64)
                GL.Vertex3(7, -4, -2)
                GL.TexCoord2(TexVal * 46, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 32, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                GL.TexCoord2(TexVal * 32, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 43, TexVal * 52)
                GL.Vertex3(7, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(7, 8, -2)
                GL.TexCoord2(TexVal * 39, TexVal * 64)
                GL.Vertex3(7, -4, -2)
                GL.TexCoord2(TexVal * 43, TexVal * 64)
                GL.Vertex3(7, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(7, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 48)
                GL.Vertex3(7, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 48)
                GL.Vertex3(4, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(4, -4, 2)
                GL.TexCoord2(TexVal * 42, TexVal * 52)
                GL.Vertex3(7, -4, 2)
                GL.TexCoord2(TexVal * 42, TexVal * 48)
                GL.Vertex3(7, -4, -2)
                GL.TexCoord2(TexVal * 39, TexVal * 48)
                GL.Vertex3(4, -4, -2)
            End If

            If ShowRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-7, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-7, -4, 2)
                'Face 2
                GL.TexCoord2(TexVal * 54, TexVal * 20)
                GL.Vertex3(-7, 8, -2)
                GL.TexCoord2(TexVal * 51, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 51, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 54, TexVal * 32)
                GL.Vertex3(-7, -4, -2)
                'Face 3
                GL.TexCoord2(TexVal * 40, TexVal * 20)
                GL.Vertex3(-7, 8, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-7, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-7, -4, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 32)
                GL.Vertex3(-7, -4, 2)
                'Face 4
                GL.TexCoord2(TexVal * 51, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 51, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-7, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 16)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 16)
                GL.Vertex3(-7, 8, -2)
                'Face 6
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-7, -4, 2)
                GL.TexCoord2(TexVal * 50, TexVal * 20)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 50, TexVal * 16)
                GL.Vertex3(-4, -4, -2)
                GL.TexCoord2(TexVal * 47, TexVal * 16)
                GL.Vertex3(-7, -4, -2)
            End If

        End If

        If ShowRightLeg Then
            'RightLeg
            'Face 1
            GL.TexCoord2(TexVal * 4, TexVal * 20)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(0, -16, 2)
            GL.TexCoord2(TexVal * 4, TexVal * 32)
            GL.Vertex3(-4, -16, 2)
            'Face 2
            GL.TexCoord2(TexVal * 16, TexVal * 20)
            GL.Vertex3(-4, -4, -2)
            GL.TexCoord2(TexVal * 12, TexVal * 20)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 12, TexVal * 32)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 16, TexVal * 32)
            GL.Vertex3(-4, -16, -2)
            'Face 3
            GL.TexCoord2(TexVal * 4, TexVal * 20)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 0, TexVal * 20)
            GL.Vertex3(-4, -4, -2)
            GL.TexCoord2(TexVal * 0, TexVal * 32)
            GL.Vertex3(-4, -16, -2)
            GL.TexCoord2(TexVal * 4, TexVal * 32)
            GL.Vertex3(-4, -16, 2)
            'Face 4
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 12, TexVal * 20)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 12, TexVal * 32)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(0, -16, 2)
            'Face 5
            GL.TexCoord2(TexVal * 4, TexVal * 20)
            GL.Vertex3(-4, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 4, TexVal * 16)
            GL.Vertex3(-4, -4, -2)
            'Face 6
            GL.TexCoord2(TexVal * 8, TexVal * 20)
            GL.Vertex3(-4, -16, 2)
            GL.TexCoord2(TexVal * 12, TexVal * 20)
            GL.Vertex3(0, -16, 2)
            GL.TexCoord2(TexVal * 12, TexVal * 16)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 8, TexVal * 16)
            GL.Vertex3(-4, -16, -2)
        End If

        If ShowLeftLeg Then
            'LeftLeg
            'Face 1
            GL.TexCoord2(TexVal * 20, TexVal * 52)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 64)
            GL.Vertex3(4, -16, 2)
            GL.TexCoord2(TexVal * 20, TexVal * 64)
            GL.Vertex3(0, -16, 2)
            'Face 2
            GL.TexCoord2(TexVal * 32, TexVal * 52)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 52)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 64)
            GL.Vertex3(4, -16, -2)
            GL.TexCoord2(TexVal * 32, TexVal * 64)
            GL.Vertex3(0, -16, -2)
            'Face 3
            GL.TexCoord2(TexVal * 20, TexVal * 52)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 16, TexVal * 52)
            GL.Vertex3(0, -4, -2)
            GL.TexCoord2(TexVal * 16, TexVal * 64)
            GL.Vertex3(0, -16, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 64)
            GL.Vertex3(0, -16, 2)
            'Face 4
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 52)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 28, TexVal * 64)
            GL.Vertex3(4, -16, -2)
            GL.TexCoord2(TexVal * 24, TexVal * 64)
            GL.Vertex3(4, -16, 2)
            'Face 5
            GL.TexCoord2(TexVal * 20, TexVal * 52)
            GL.Vertex3(0, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 24, TexVal * 48)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 20, TexVal * 48)
            GL.Vertex3(0, -4, -2)
            'Face 6
            GL.TexCoord2(TexVal * 24, TexVal * 52)
            GL.Vertex3(0, -16, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 52)
            GL.Vertex3(4, -16, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 48)
            GL.Vertex3(4, -16, -2)
            GL.TexCoord2(TexVal * 24, TexVal * 48)
            GL.Vertex3(0, -16, -2)
        End If

        GL.End()

        GL.Enable(EnableCap.AlphaTest) 'Enable transparent
        GL.AlphaFunc(AlphaFunction.Greater, 0.4)
        'GL.Enable(EnableCap.Blend) 'Enable transparent
        'GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.DstAlpha)

        GL.Begin(BeginMode.Quads)

        If Show2ndBody Then
            'Face 1
            GL.TexCoord2(TexVal * 20, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 48)
            GL.Vertex3(4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, 2.12)
            'Face 2
            GL.TexCoord2(TexVal * 40, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 32, TexVal * 36)
            GL.Vertex3(4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 32, TexVal * 48)
            GL.Vertex3(4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 40, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, -2.12)
            'Face 3
            GL.TexCoord2(TexVal * 16, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 16, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, 2.12)
            'Face 4
            GL.TexCoord2(TexVal * 32, TexVal * 36)
            GL.Vertex3(4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 48)
            GL.Vertex3(4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 32, TexVal * 48)
            GL.Vertex3(4.24, -4.36, 2.12)
            'Face 5
            GL.TexCoord2(TexVal * 20, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 32)
            GL.Vertex3(-4.24, 8.36, -2.12)
            'Face 6
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(-4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 36, TexVal * 36)
            GL.Vertex3(4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 36, TexVal * 32)
            GL.Vertex3(4.24, -4.36, -2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 32)
            GL.Vertex3(-4.24, -4.36, -2.12)
        End If

        If Show2ndHead Then
            'Head
            'Face 1
            GL.TexCoord2(TexVal * 40, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 16)
            GL.Vertex3(4.24, 7.76, 4.24)
            GL.TexCoord2(TexVal * 40, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, 4.24)
            'Face 2
            GL.TexCoord2(TexVal * 64, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 8)
            GL.Vertex3(4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 16)
            GL.Vertex3(4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 64, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, -4.24)
            'Face 3
            GL.TexCoord2(TexVal * 40, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 32, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 32, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 40, TexVal * 16)
            GL.Vertex3(-4.24, 7.76, 4.24)
            'Face 4
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 8)
            GL.Vertex3(4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 16)
            GL.Vertex3(4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 16)
            GL.Vertex3(4.24, 7.76, 4.24)
            'Face 5
            GL.TexCoord2(TexVal * 40, TexVal * 8)
            GL.Vertex3(-4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(4.24, 16.24, 4.24)
            GL.TexCoord2(TexVal * 48, 0)
            GL.Vertex3(4.24, 16.24, -4.24)
            GL.TexCoord2(TexVal * 40, 0)
            GL.Vertex3(-4.24, 16.24, -4.24)
            'Face 6
            GL.TexCoord2(TexVal * 48, TexVal * 8)
            GL.Vertex3(-4.24, 7.76, 4.24)
            GL.TexCoord2(TexVal * 56, TexVal * 8)
            GL.Vertex3(4.24, 7.76, 4.24)
            GL.TexCoord2(TexVal * 56, 0)
            GL.Vertex3(4.24, 7.76, -4.24)
            GL.TexCoord2(TexVal * 48, 0)
            GL.Vertex3(-4.24, 7.76, -4.24)
        End If

        If Model = Models.Steve Then

            If Show2ndLeftArm Then
                'LeftArm
                'Face 1
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 64)
                GL.Vertex3(8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.88, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 64, TexVal * 52)
                GL.Vertex3(3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 52)
                GL.Vertex3(8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 64)
                GL.Vertex3(8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 64, TexVal * 64)
                GL.Vertex3(3.88, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 48, TexVal * 52)
                GL.Vertex3(3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(3.88, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 60, TexVal * 52)
                GL.Vertex3(8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 64)
                GL.Vertex3(8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 64)
                GL.Vertex3(8.12, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 48)
                GL.Vertex3(8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(3.88, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 52)
                GL.Vertex3(8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 48)
                GL.Vertex3(8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 48)
                GL.Vertex3(3.88, -4.36, -2.12)
            End If

            If Show2ndRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 56, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 40, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, -2.12)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 52, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-8.12, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 36)
                GL.Vertex3(-3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 32)
                GL.Vertex3(-3.88, -4.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-8.12, -4.36, -2.12)
            End If

        Else

            If Show2ndLeftArm Then
                'LefttArm
                'Face 1
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 64)
                GL.Vertex3(7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.91, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 62, TexVal * 52)
                GL.Vertex3(3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 59, TexVal * 52)
                GL.Vertex3(7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 59, TexVal * 64)
                GL.Vertex3(7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 62, TexVal * 64)
                GL.Vertex3(3.91, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 48, TexVal * 52)
                GL.Vertex3(3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(3.91, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 59, TexVal * 52)
                GL.Vertex3(7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 64)
                GL.Vertex3(7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 59, TexVal * 64)
                GL.Vertex3(7.09, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 48)
                GL.Vertex3(7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(3.91, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 58, TexVal * 52)
                GL.Vertex3(7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 58, TexVal * 48)
                GL.Vertex3(7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 48)
                GL.Vertex3(3.91, -4.36, -2.12)
            End If

            If Show2ndRightArm Then
                'RightArm
                'Face 1
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, 2.12)
                'Face 2
                GL.TexCoord2(TexVal * 54, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 51, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 51, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 54, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, -2.12)
                'Face 3
                GL.TexCoord2(TexVal * 40, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, -2.12)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, 2.12)
                'Face 4
                GL.TexCoord2(TexVal * 51, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 51, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, 2.12)
                'Face 5
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-7.09, 8.36, -2.12)
                'Face 6
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 50, TexVal * 36)
                GL.Vertex3(-3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 50, TexVal * 32)
                GL.Vertex3(-3.91, -4.36, -2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-7.09, -4.36, -2.12)
            End If

        End If

        If Show2ndRightLeg Then
            'RightLeg
            'Face 1
            GL.TexCoord2(TexVal * 4, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, 2.12)
            'Face 2
            GL.TexCoord2(TexVal * 16, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 36)
            GL.Vertex3(0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 48)
            GL.Vertex3(0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 16, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, -2.12)
            'Face 3
            GL.TexCoord2(TexVal * 0, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 0, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, 2.12)
            'Face 4
            GL.TexCoord2(TexVal * 12, TexVal * 36)
            GL.Vertex3(0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 48)
            GL.Vertex3(0.12, -16.36, 2.12)
            'Face 5
            GL.TexCoord2(TexVal * 4, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 32)
            GL.Vertex3(-4.12, -3.64, -2.12)
            'Face 6
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(-4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 36)
            GL.Vertex3(0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 32)
            GL.Vertex3(0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 32)
            GL.Vertex3(-4.12, -16.36, -2.12)
        End If

        If Show2ndLeftLeg Then
            'LeftLeg
            'Face 1
            GL.TexCoord2(TexVal * 4, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 64)
            GL.Vertex3(4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, 2.12)
            'Face 2
            GL.TexCoord2(TexVal * 16, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 52)
            GL.Vertex3(4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 64)
            GL.Vertex3(4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 16, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, -2.12)
            'Face 3
            GL.TexCoord2(TexVal * 0, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 0, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, 2.12)
            'Face 4
            GL.TexCoord2(TexVal * 12, TexVal * 52)
            GL.Vertex3(4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 64)
            GL.Vertex3(4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 64)
            GL.Vertex3(4.12, -16.36, 2.12)
            'Face 5
            GL.TexCoord2(TexVal * 4, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 48)
            GL.Vertex3(-0.12, -3.64, -2.12)
            'Face 6
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(-0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 52)
            GL.Vertex3(4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 48)
            GL.Vertex3(4.12, -16.36, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(-0.12, -16.36, -2.12)
        End If
        'Finish the begin mode with "end"
        GL.End()

        'Finally...
        GlControl.SwapBuffers() 'Takes from the 'GL' and puts into control
    End Sub

    Private IsMouseDown As Boolean
    Private IsRightMouseDown As Boolean
    Private IsMouseHidden As Boolean
    Private IsMouseHit As Boolean
    Private OldLoc As Point
    Private MouseLoc As Point

    Private Sub GlControl_MouseDown(sender As Object, e As MouseEventArgs) Handles GlControl.MouseDown
        If Not IsMouseDown AndAlso e.Button = MouseButtons.Left Then
            If Paintable Then
                GlControl.MakeCurrent()
                Dim promatrix As Matrix4
                Dim viewmatrix As Matrix4
                GL.GetFloat(GetPName.ModelviewMatrix, viewmatrix)
                GL.GetFloat(GetPName.ProjectionMatrix, promatrix)
                Dim m As New MouseRay(viewmatrix, promatrix, GlControl.Size, GetCameraPos(viewmatrix), Me)
                m.Pos = e.Location
                If m.Mouse2ndHit <> New Vector3(100, 100, 100) OrElse m.MouseHit <> New Vector3(0, 0, 0) Then
                    IsMouseHit = True
                    Exit Sub
                End If
            End If
            OldLoc = Cursor.Position
            If Not IsMouseHidden Then
                Cursor.Hide()
                IsMouseHidden = True
            End If
            MouseLoc = Cursor.Position
            IsMouseDown = True
        ElseIf Not IsRightMouseDown AndAlso e.Button = MouseButtons.Right Then
            OldLoc = Cursor.Position
            If Not IsMouseHidden Then
                Cursor.Hide()
                IsMouseHidden = True
            End If
            MouseLoc = Cursor.Position
            IsRightMouseDown = True
        End If
    End Sub

    Private Sub GlControl_MouseUp(sender As Object, e As MouseEventArgs) Handles GlControl.MouseUp
        If IsMouseHidden Then
            Cursor.Show()
            IsMouseHidden = False
            Cursor.Position = OldLoc
            IsMouseDown = False
            IsRightMouseDown = False
        End If
        IsMouseHit = False
    End Sub

    Private Sub Move_Tick(sender As Object, e As EventArgs) Handles timMove.Tick
        If IsMouseDown Then
            RotationY += (Cursor.Position.X - MouseLoc.X) * 0.5
            RotationX -= (Cursor.Position.Y - MouseLoc.Y) * 0.5
            Me.Refresh()
            Cursor.Position = New Point(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.Bounds.Height / 2)
            MouseLoc = Cursor.Position
        ElseIf IsRightMouseDown Then
            LookX += -(Cursor.Position.X - MouseLoc.X) * 0.5
            LookY += (Cursor.Position.Y - MouseLoc.Y) * 0.5
            Me.Refresh()
            Cursor.Position = New Point(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.Bounds.Height / 2)
            MouseLoc = Cursor.Position
        End If
    End Sub

    Private Sub Renderer3D_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Zoom += e.Delta * 0.005
        Refresh()
    End Sub

    Private Function GetCameraPos(modelview As Matrix4) As Vector3
        GlControl.MakeCurrent()
        Return Matrix4.Invert(modelview).ExtractTranslation()
    End Function

    Private Sub Paint_Tick(sender As Object, e As EventArgs) Handles timPaint.Tick
        If IsMouseHit Then
            GlControl.MakeCurrent()
            Dim promatrix As Matrix4
            Dim viewmatrix As Matrix4
            GL.GetFloat(GetPName.ModelviewMatrix, viewmatrix)
            GL.GetFloat(GetPName.ProjectionMatrix, promatrix)
            Dim CameraPos As Vector3 = GetCameraPos(viewmatrix)
            Dim m As New MouseRay(viewmatrix, promatrix, GlControl.Size, CameraPos, Me)
            m.Pos = GlControl.PointToClient(New Point(Cursor.Position))
            Dim Mouse2ndHit As Vector3 = m.Mouse2ndHit
            Dim MouseHit As Vector3 = m.MouseHit
            Dim MouseHitDis As Double = Math.Sqrt(Math.Pow(CameraPos.X - MouseHit.X, 2.0F) + Math.Pow(CameraPos.Y - MouseHit.Y, 2.0F) + Math.Pow(CameraPos.Z - MouseHit.Z, 2.0F))
            Dim Mouse2ndHitDis As Double = Math.Sqrt(Math.Pow(CameraPos.X - Mouse2ndHit.X, 2.0F) + Math.Pow(CameraPos.Y - Mouse2ndHit.Y, 2.0F) + Math.Pow(CameraPos.Z - Mouse2ndHit.Z, 2.0F))
            If MouseHitDis > Mouse2ndHitDis Then
                PaintPixel(Mouse2ndHit, True)

                MainForm.Skin = Skin
                MainForm.UpdateImage()
                Exit Sub
            End If
            If MouseHit <> New Vector3(0, 0, 0) Then
                PaintPixel(MouseHit)

                MainForm.Skin = Skin
                MainForm.UpdateImage()
            End If
        End If
    End Sub

    Public Event SkinChanged(sender As Object, NewSkin As Bitmap)

    Sub PaintPixel(Vector As Vector3, Optional Second As Boolean = False)
        Dim Point As Point
        Dim XUp As Vector3
        Dim YUp As Vector3
        If Second Then
            Point = Get2nd2DFrom3D(Vector, XUp, YUp)
        Else
            Point = Get2DFrom3D(Vector, XUp, YUp)
        End If
        If ColorPicker.IsPicking Then
            ColorPicker.Color = Skin.GetPixel(Point.X, Point.Y)
            ColorPicker.IsPicking = False
            ColorPicker.Refresh()
        Else
            Skin.SetPixel(Point.X, Point.Y, ColorPicker.Color)
            If ColorPicker.BrushSize >= 2 Then
                Dim Points(2) As Point
                If Second Then
                    Points(0) = Get2nd2DFrom3D(Vector + XUp)
                    Points(1) = Get2nd2DFrom3D(Vector + XUp - YUp)
                    Points(2) = Get2nd2DFrom3D(Vector - YUp)
                Else
                    Points(0) = Get2DFrom3D(Vector + XUp)
                    Points(1) = Get2DFrom3D(Vector + XUp - YUp)
                    Points(2) = Get2DFrom3D(Vector - YUp)
                End If
                For Each Pixel As Point In Points
                    If Pixel <> New Point(0, 0) Then
                        Skin.SetPixel(Pixel.X, Pixel.Y, ColorPicker.Color)
                    End If
                Next
            End If
            If ColorPicker.BrushSize = 3 Then
                Dim Points(4) As Point
                If Second Then
                    Points(0) = Get2nd2DFrom3D(Vector - XUp)
                    Points(1) = Get2nd2DFrom3D(Vector - XUp - YUp)
                    Points(2) = Get2nd2DFrom3D(Vector + YUp)
                    Points(3) = Get2nd2DFrom3D(Vector - XUp + YUp)
                    Points(4) = Get2nd2DFrom3D(Vector + XUp + YUp)
                Else
                    Points(0) = Get2DFrom3D(Vector - XUp)
                    Points(1) = Get2DFrom3D(Vector - XUp - YUp)
                    Points(2) = Get2DFrom3D(Vector + YUp)
                    Points(3) = Get2DFrom3D(Vector - XUp + YUp)
                    Points(4) = Get2DFrom3D(Vector + XUp + YUp)
                End If
                For Each Pixel As Point In Points
                    If Pixel <> New Point(0, 0) Then
                        Skin.SetPixel(Pixel.X, Pixel.Y, ColorPicker.Color)
                    End If
                Next
            End If
            Refresh()
        End If
        RaiseEvent SkinChanged(Me, Skin)
    End Sub

    Function Get2DFrom3D(Vector As Vector3, ByRef XUp As Vector3, ByRef YUp As Vector3) As Point
        Dim Result As Point
        If Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y < 16 AndAlso Vector.Y > 8 AndAlso Vector.Z = 4 Then
            'ZHead
            Result = New Point(Int(Vector.X + 4 + 8), Int(-Vector.Y + 16 + 8))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y < 16 AndAlso Vector.Y > 8 AndAlso Vector.Z = -4 Then
            'ZHead
            Result = New Point(Int(-Vector.X + 4 + 24), Int(-Vector.Y + 16 + 8))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.Z = 2 Then
            'ZBody
            Result = New Point(Int(Vector.X + 4 + 20), Int(-Vector.Y + 8 + 20))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.Z = -2 Then
            'ZBody
            Result = New Point(Int(-Vector.X + 4 + 32), Int(-Vector.Y + 8 + 20))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < -4 AndAlso Vector.X > -8 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.Z = 2 Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int(Vector.X + 4 + 48), Int(-Vector.Y + 8 + 20))
            Else
                Result = New Point(Int(Vector.X + 4 + 47), Int(-Vector.Y + 8 + 20))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < -4 AndAlso Vector.X > -8 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.Z = -2 Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int(-Vector.X + 4 + 44), Int(-Vector.Y + 8 + 20))
            Else
                Result = New Point(Int(-Vector.X + 4 + 43), Int(-Vector.Y + 8 + 20))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 8 AndAlso Vector.X > 4 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.Z = 2 Then
            'ZArms
            Result = New Point(Int(Vector.X + 4 + 28), Int(-Vector.Y + 8 + 52))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 8 AndAlso Vector.X > 4 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.Z = -2 Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int(-Vector.X + 4 + 48), Int(-Vector.Y + 8 + 52))
            Else
                Result = New Point(Int(-Vector.X + 4 + 46), Int(-Vector.Y + 8 + 52))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 0 AndAlso Vector.X > -4 AndAlso Vector.Y < -4 AndAlso Vector.Y > -16 AndAlso Vector.Z = 2 Then
            'ZLegs
            Result = New Point(Int(Vector.X + 4 + 4), Int(-Vector.Y + 16))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 0 AndAlso Vector.X > -4 AndAlso Vector.Y < -4 AndAlso Vector.Y > -16 AndAlso Vector.Z = -2 Then
            'ZLegs
            Result = New Point(Int(-Vector.X + 4 + 8), Int(-Vector.Y + 16))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4 AndAlso Vector.X > 0 AndAlso Vector.Y < -4 AndAlso Vector.Y > -16 AndAlso Vector.Z = 2 Then
            'ZLegs
            Result = New Point(Int(Vector.X + 4 + 16), Int(-Vector.Y + 48))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4 AndAlso Vector.X > 0 AndAlso Vector.Y < -4 AndAlso Vector.Y > -16 AndAlso Vector.Z = -2 Then
            'ZLegs
            Result = New Point(Int(-Vector.X + 4 + 28), Int(-Vector.Y + 48))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.Z < 4 AndAlso Vector.Z > -4 AndAlso Vector.Y < 16 AndAlso Vector.Y > 8 AndAlso Vector.X = 4 Then
            'XHead
            Result = New Point(Int(-Vector.Z + 20), Int(-Vector.Y + 24))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 4 AndAlso Vector.Z > -4 AndAlso Vector.Y < 16 AndAlso Vector.Y > 8 AndAlso Vector.X = -4 Then
            'XHead
            Result = New Point(Int(Vector.Z + 4), Int(-Vector.Y + 24))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = 4 Then
            'XBody
            If ShowBody AndAlso Not ShowLeftArm Then
                Result = New Point(Int(-Vector.Z + 30), Int(-Vector.Y + 28))
            Else
                Result = New Point(Int(-Vector.Z + 34), Int(-Vector.Y + 60))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = -4 Then
            'XBody
            If ShowBody AndAlso Not ShowRightArm Then
                Result = New Point(Int(Vector.Z + 18), Int(-Vector.Y + 28))
            Else
                Result = New Point(Int(Vector.Z + 50), Int(-Vector.Y + 28))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = 8 Then
            'XArms
            Result = New Point(Int(Vector.Z + 42), Int(-Vector.Y + 60))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = -8 Then
            'XArms
            Result = New Point(Int(-Vector.Z + 42), Int(-Vector.Y + 28))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = 7 Then
            'XArms
            Result = New Point(Int(Vector.Z + 41), Int(-Vector.Y + 60))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = -7 Then
            'XArms
            Result = New Point(Int(-Vector.Z + 42), Int(-Vector.Y + 28))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < -4 AndAlso Vector.Y > -16 AndAlso Vector.X = 4 Then
            'XLeg
            Result = New Point(Int(-Vector.Z + 26), Int(-Vector.Y + 48))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < -4 AndAlso Vector.Y > -16 AndAlso Vector.X = -4 Then
            'XLeg
            Result = New Point(Int(Vector.Z + 2), Int(-Vector.Y + 16))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < -4 AndAlso Vector.Y > -16 AndAlso Vector.X = 0 Then
            'XLeg
            If ShowLeftLeg Then
                Result = New Point(Int(Vector.Z + 18), Int(-Vector.Y + 48))
            Else
                Result = New Point(Int(-Vector.Z + 10), Int(-Vector.Y + 16))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 4 AndAlso Vector.Z > -4 AndAlso Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y = 16 Then
            'YHead
            Result = New Point(Int(Vector.X + 12), Int(Vector.Z + 4))
            XUp.X = 1
            YUp.Z = 1
        ElseIf ShowHead AndAlso Vector.Z < 4 AndAlso Vector.Z > -4 AndAlso Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y = 8 Then
            'YHead
            Result = New Point(Int(Vector.X + 20), Int(Vector.Z + 4))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y = 8 Then
            'YBody
            Result = New Point(Int(Vector.X + 24), Int(Vector.Z + 18))
            XUp.X = 1
            YUp.Z = 1
        ElseIf ShowBody AndAlso (Not ShowLeftLeg OrElse Not ShowRightLeg) AndAlso Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 4 AndAlso Vector.X > -4 AndAlso Vector.Y = -4 Then
            'YBody
            Result = New Point(Int(Vector.X + 32), Int(-Vector.Z + 18))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 8 AndAlso Vector.X > 4 AndAlso Vector.Y = 8 Then
            'YArms
            Result = New Point(Int(Vector.X + 32), Int(Vector.Z + 50))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 8 AndAlso Vector.X > 4 AndAlso Vector.Y = -4 Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int(Vector.X + 36), Int(Vector.Z + 50))
            Else
                Result = New Point(Int(Vector.X + 35), Int(Vector.Z + 50))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < -4 AndAlso Vector.X > -8 AndAlso Vector.Y = 8 Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int(Vector.X + 52), Int(Vector.Z + 18))
            Else
                Result = New Point(Int(Vector.X + 51), Int(Vector.Z + 18))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < -4 AndAlso Vector.X > -8 AndAlso Vector.Y = -4 Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int(Vector.X + 56), Int(Vector.Z + 18))
            Else
                Result = New Point(Int(Vector.X + 54), Int(Vector.Z + 18))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf ShowLeftLeg AndAlso Not ShowBody AndAlso Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 4 AndAlso Vector.X > 0 AndAlso Vector.Y = -4 Then
            'YLeg
            Result = New Point(Int(Vector.X + 20), Int(Vector.Z + 50))
            XUp.X = 1
            YUp.Z = 1
        ElseIf ShowRightLeg AndAlso Not ShowBody AndAlso Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 0 AndAlso Vector.X > -4 AndAlso Vector.Y = -4 Then
            'YLeg
            Result = New Point(Int(Vector.X + 8), Int(Vector.Z + 18))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 4 AndAlso Vector.X > 0 AndAlso Vector.Y = -16 Then
            'YLeg
            Result = New Point(Int(Vector.X + 24), Int(Vector.Z + 50))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.X < 0 AndAlso Vector.X > -4 AndAlso Vector.Y = -16 Then
            'YLeg
            Result = New Point(Int(Vector.X + 12), Int(Vector.Z + 18))
            XUp.X = 1
            YUp.Z = 1
        End If

        Return Result
    End Function

    Function Get2nd2DFrom3D(Vector As Vector3, ByRef XUp As Vector3, ByRef YUp As Vector3) As Point
        Dim Result As Point
        If Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.Z = 4.24F Then
            'ZHead
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 40), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.Z = -4.24F Then
            'ZHead
            Result = New Point(Int((-Vector.X + 4.24) / 1.06 + 56), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = 2.12F Then
            'ZBody
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 20), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = -2.12F Then
            'ZBody
            Result = New Point(Int((-Vector.X + 4.24) / 1.06 + 32), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = 2.12F Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X + 3.88) / 1.06 + 48), Int((-Vector.Y + 8.36) / 1.06 + 36))
            Else
                Result = New Point(Int((Vector.X + 3.88) / 1.06 + 47), Int((-Vector.Y + 8.36) / 1.06 + 36))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = -2.12F Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 45), Int((-Vector.Y + 8.36) / 1.06 + 36))
            Else
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 44), Int((-Vector.Y + 8.36) / 1.06 + 36))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = 2.12F Then
            'ZArms
            Result = New Point(Int((Vector.X + 3.88) / 1.06 + 45), Int((-Vector.Y + 8.36) / 1.06 + 52))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = -2.12F Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 64), Int((-Vector.Y + 8.36) / 1.06 + 52))
            Else
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 62), Int((-Vector.Y + 8.36) / 1.06 + 52))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 0.12 AndAlso Vector.X > -4.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = 2.12F Then
            'ZLegs
            Result = New Point(Int((Vector.X + 4.12) / 1.06 + 4), Int((-Vector.Y - 16.36) / 1.06 + 48))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 0.12 AndAlso Vector.X > -4.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = -2.12F Then
            'ZLegs
            Result = New Point(Int((-Vector.X + 4.12) / 1.06 + 8), Int((-Vector.Y - 16.36) / 1.06 + 48))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4.12 AndAlso Vector.X > -0.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = 2.12F Then
            'ZLegs
            Result = New Point(Int((Vector.X + 0.12) / 1.06 + 4), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.X < 4.12 AndAlso Vector.X > -0.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = -2.12F Then
            'ZLegs
            Result = New Point(Int((-Vector.X + 0.12) / 1.06 + 16), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.X = 4.24F Then
            'XHead
            Result = New Point(Int((-Vector.Z + 4.24) / 1.06 + 48), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.X = -4.24F Then
            'XHead
            Result = New Point(Int((Vector.Z + 4.24) / 1.06 + 32), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.X = 4.24F Then
            'XBody
            Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 28), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.X = -4.24F Then
            'XBody
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 16), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = 8.12F OrElse Vector.X = 7.09F) Then
            'XArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 56), Int((-Vector.Y + 8.36) / 1.06 + 52))
            Else
                Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 55), Int((-Vector.Y + 8.36) / 1.06 + 52))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = -8.12F OrElse Vector.X = -7.09F) Then
            'XArms
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 40), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = 3.88F OrElse Vector.X = 3.91F) Then
            'XArms
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 48), Int((-Vector.Y + 8.36) / 1.06 + 52))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = -3.88F OrElse Vector.X = -3.91F) Then
            'XArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 48), Int((-Vector.Y + 8.36) / 1.06 + 36))
            Else
                Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 47), Int((-Vector.Y + 8.36) / 1.06 + 36))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = 4.24F Then
            'XLeg
            Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 8), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = -4.24F Then
            'XLeg
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06), Int((-Vector.Y - 3.64) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = 0.12F Then
            'XLeg
            Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 8), Int((-Vector.Y - 3.64) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = -0.12F Then
            'XLeg
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = 16.24F Then
            'YHead
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 40), Int((Vector.Z + 4.24) / 1.06))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = 7.76F Then
            'YHead
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 48), Int((Vector.Z + 4.24) / 1.06))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = 8.36F Then
            'YBody
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 20), Int((Vector.Z + 2.12) / 1.06 + 32))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = -4.36F Then
            'YBody
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 28), Int((Vector.Z + 2.12) / 1.06 + 32))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y = 8.36F Then
            'YArms
            Result = New Point(Int((Vector.X - 3.88) / 1.06 + 52), Int((Vector.Z + 2.12) / 1.06 + 48))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y = -4.36F Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X - 3.88) / 1.06 + 56), Int((Vector.Z + 2.12) / 1.06 + 48))
            Else
                Result = New Point(Int((Vector.X - 3.88) / 1.06 + 55), Int((Vector.Z + 2.12) / 1.06 + 48))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y = 8.36F Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 44), Int((Vector.Z + 2.12) / 1.06 + 32))
            Else
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 43), Int((Vector.Z + 2.12) / 1.06 + 32))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y = -4.36F Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 48), Int((Vector.Z + 2.12) / 1.06 + 32))
            Else
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 46), Int((Vector.Z + 2.12) / 1.06 + 32))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -0.12 AndAlso Vector.Y = -3.64F Then
            'YLeg
            Result = New Point(Int((Vector.X + 0.12) / 1.06 + 4), Int((Vector.Z + 2.12) / 1.06 + 48))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 0.12 AndAlso Vector.X > -4.24 AndAlso Vector.Y = -3.64F Then
            'YLeg
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 4), Int((Vector.Z + 2.12) / 1.06 + 32))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -0.12 AndAlso Vector.Y = -16.36F Then
            'YLeg
            Result = New Point(Int((Vector.X + 0.12) / 1.06 + 8), Int((Vector.Z + 2.12) / 1.06 + 48))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 0.12 AndAlso Vector.X > -4.24 AndAlso Vector.Y = -16.36F Then
            'YLeg
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 8), Int((Vector.Z + 2.12) / 1.06 + 32))
            XUp.X = 1
            YUp.Z = 1
        End If

        Return Result
    End Function

    Function Get2DFrom3D(Vector As Vector3)
        Return Get2DFrom3D(Vector, New Vector3, New Vector3)
    End Function
    Function Get2nd2DFrom3D(Vector As Vector3)
        Return Get2nd2DFrom3D(Vector, New Vector3, New Vector3)
    End Function
End Class
