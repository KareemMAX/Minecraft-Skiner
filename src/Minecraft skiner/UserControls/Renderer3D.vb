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
            GL.Vertex3(-4, -4, -2)
            GL.TexCoord2(TexVal * 36, TexVal * 16)
            GL.Vertex3(4, -4, -2)
            GL.TexCoord2(TexVal * 36, TexVal * 20)
            GL.Vertex3(4, -4, 2)
            GL.TexCoord2(TexVal * 28, TexVal * 20)
            GL.Vertex3(-4, -4, 2)
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
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                GL.TexCoord2(TexVal * 32, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                'Face 4
                GL.TexCoord2(TexVal * 44, TexVal * 52)
                GL.Vertex3(8, 8, -2)
                GL.TexCoord2(TexVal * 40, TexVal * 52)
                GL.Vertex3(8, 8, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 64)
                GL.Vertex3(8, -4, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 64)
                GL.Vertex3(8, -4, -2)
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
                GL.Vertex3(-8, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-8, 8, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-8, -4, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 32)
                GL.Vertex3(-8, -4, -2)
                'Face 4
                GL.TexCoord2(TexVal * 52, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 48, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 48, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 52, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
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
                GL.Vertex3(4, 8, -2)
                GL.TexCoord2(TexVal * 36, TexVal * 52)
                GL.Vertex3(4, 8, 2)
                GL.TexCoord2(TexVal * 36, TexVal * 64)
                GL.Vertex3(4, -4, 2)
                GL.TexCoord2(TexVal * 32, TexVal * 64)
                GL.Vertex3(4, -4, -2)
                'Face 4
                GL.TexCoord2(TexVal * 43, TexVal * 52)
                GL.Vertex3(7, 8, -2)
                GL.TexCoord2(TexVal * 39, TexVal * 52)
                GL.Vertex3(7, 8, 2)
                GL.TexCoord2(TexVal * 39, TexVal * 64)
                GL.Vertex3(7, -4, 2)
                GL.TexCoord2(TexVal * 43, TexVal * 64)
                GL.Vertex3(7, -4, -2)
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
                GL.Vertex3(-7, 8, -2)
                GL.TexCoord2(TexVal * 44, TexVal * 20)
                GL.Vertex3(-7, 8, 2)
                GL.TexCoord2(TexVal * 44, TexVal * 32)
                GL.Vertex3(-7, -4, 2)
                GL.TexCoord2(TexVal * 40, TexVal * 32)
                GL.Vertex3(-7, -4, -2)
                'Face 4
                GL.TexCoord2(TexVal * 51, TexVal * 20)
                GL.Vertex3(-4, 8, -2)
                GL.TexCoord2(TexVal * 47, TexVal * 20)
                GL.Vertex3(-4, 8, 2)
                GL.TexCoord2(TexVal * 47, TexVal * 32)
                GL.Vertex3(-4, -4, 2)
                GL.TexCoord2(TexVal * 51, TexVal * 32)
                GL.Vertex3(-4, -4, -2)
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
            GL.Vertex3(-4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 36)
            GL.Vertex3(-4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 20, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 16, TexVal * 48)
            GL.Vertex3(-4.24, -4.36, -2.12)
            'Face 4
            GL.TexCoord2(TexVal * 32, TexVal * 36)
            GL.Vertex3(4.24, 8.36, -2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 36)
            GL.Vertex3(4.24, 8.36, 2.12)
            GL.TexCoord2(TexVal * 28, TexVal * 48)
            GL.Vertex3(4.24, -4.36, 2.12)
            GL.TexCoord2(TexVal * 32, TexVal * 48)
            GL.Vertex3(4.24, -4.36, -2.12)
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
                GL.Vertex3(3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(3.88, -4.36, -2.12)
                'Face 4
                GL.TexCoord2(TexVal * 60, TexVal * 52)
                GL.Vertex3(8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 52)
                GL.Vertex3(8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 56, TexVal * 64)
                GL.Vertex3(8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 60, TexVal * 64)
                GL.Vertex3(8.12, -4.36, -2.12)
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
                GL.Vertex3(-8.12, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-8.12, 8.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, 2.12)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(-8.12, -4.36, -2.12)
                'Face 4
                GL.TexCoord2(TexVal * 52, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, -2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 36)
                GL.Vertex3(-3.88, 8.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 48)
                GL.Vertex3(-3.88, -4.36, -2.12)
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
                GL.Vertex3(3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 52)
                GL.Vertex3(3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 52, TexVal * 64)
                GL.Vertex3(3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 48, TexVal * 64)
                GL.Vertex3(3.91, -4.36, -2.12)
                'Face 4
                GL.TexCoord2(TexVal * 59, TexVal * 52)
                GL.Vertex3(7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 52)
                GL.Vertex3(7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 55, TexVal * 64)
                GL.Vertex3(7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 59, TexVal * 64)
                GL.Vertex3(7.09, -4.36, -2.12)
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
                GL.Vertex3(-7.09, 8.36, -2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 36)
                GL.Vertex3(-7.09, 8.36, 2.12)
                GL.TexCoord2(TexVal * 44, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, 2.12)
                GL.TexCoord2(TexVal * 40, TexVal * 48)
                GL.Vertex3(-7.09, -4.36, -2.12)
                'Face 4
                GL.TexCoord2(TexVal * 51, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, -2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 36)
                GL.Vertex3(-3.91, 8.36, 2.12)
                GL.TexCoord2(TexVal * 47, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, 2.12)
                GL.TexCoord2(TexVal * 51, TexVal * 48)
                GL.Vertex3(-3.91, -4.36, -2.12)
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
            GL.Vertex3(-4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 36)
            GL.Vertex3(-4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 0, TexVal * 48)
            GL.Vertex3(-4.12, -16.36, -2.12)
            'Face 4
            GL.TexCoord2(TexVal * 12, TexVal * 36)
            GL.Vertex3(0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 36)
            GL.Vertex3(0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 48)
            GL.Vertex3(0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 48)
            GL.Vertex3(0.12, -16.36, -2.12)
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
            GL.Vertex3(-0.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 52)
            GL.Vertex3(-0.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 4, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 0, TexVal * 64)
            GL.Vertex3(-0.12, -16.36, -2.12)
            'Face 4
            GL.TexCoord2(TexVal * 12, TexVal * 52)
            GL.Vertex3(4.12, -3.64, -2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 52)
            GL.Vertex3(4.12, -3.64, 2.12)
            GL.TexCoord2(TexVal * 8, TexVal * 64)
            GL.Vertex3(4.12, -16.36, 2.12)
            GL.TexCoord2(TexVal * 12, TexVal * 64)
            GL.Vertex3(4.12, -16.36, -2.12)
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

    Public Event BeginChanged(sender As Object, LastSkin As Bitmap)

    Dim GlobalMouseRay As MouseRay 'To use the var golbaly in the code
    Dim GlobalCameraPos As Vector3

    Private Sub GlControl_MouseDown(sender As Object, e As MouseEventArgs) Handles GlControl.MouseDown
        If Not IsMouseDown AndAlso e.Button = MouseButtons.Left Then 'Left mouse button
            If Paintable Then 'Check if the Skin editor is paintable
                GlControl.MakeCurrent()
                Dim promatrix As Matrix4
                Dim viewmatrix As Matrix4
                GL.GetFloat(GetPName.ModelviewMatrix, viewmatrix)
                GL.GetFloat(GetPName.ProjectionMatrix, promatrix)
                'Get the current mouse ray
                Dim m As New MouseRay(viewmatrix, promatrix, GlControl.Size, GetCameraPos(viewmatrix), Me)
                m.Pos = e.Location
                If m.Mouse2ndHit <> New Vector3(100, 100, 100) OrElse m.MouseHit <> New Vector3(0, 0, 0) Then 'Check if the mouse hit the model or no
                    Dim tmp As Bitmap = Skin.Clone()
                    RaiseEvent BeginChanged(Me, tmp) 'Fire the event
                    IsMouseHit = True

                    Dim CameraPos As Vector3 = GetCameraPos(viewmatrix)
                    GlobalMouseRay = m
                    GlobalCameraPos = CameraPos

                    PaintThread = New Threading.Thread(AddressOf PaintCommander)
                    PaintThread.Start()

                    Exit Sub
                End If
            End If
            'If the ray didn't hit the model then rotate the model
            OldLoc = Cursor.Position 'Store the old mouse position to reset it when the action is over
            If Not IsMouseHidden Then 'Hide the mouse
                Cursor.Hide()
                IsMouseHidden = True
            End If
            MouseLoc = Cursor.Position 'Store the current mouse position to use it for the rotate action
            IsMouseDown = True
        ElseIf Not IsRightMouseDown AndAlso e.Button = MouseButtons.Right Then 'Right mouse button
            OldLoc = Cursor.Position 'Store the old mouse position to reset it when the action is over 
            If Not IsMouseHidden Then 'Hide the mouse
                Cursor.Hide()
                IsMouseHidden = True
            End If
            MouseLoc = Cursor.Position 'Store the current mouse position to use it for the move action
            IsRightMouseDown = True
        End If
    End Sub

    Private Sub GlControl_MouseUp(sender As Object, e As MouseEventArgs) Handles GlControl.MouseUp
        If IsMouseHidden Then
            Cursor.Show() 'Show the mouse
            IsMouseHidden = False
            Cursor.Position = OldLoc 'Rest the mouse position
            IsMouseDown = False 'Clear the booleans
            IsRightMouseDown = False
        End If
        IsMouseHit = False
        ColorPicker.IsPicking = False
    End Sub

    Private Sub Move_Tick(sender As Object, e As EventArgs) Handles timMove.Tick
        If IsMouseDown Then 'Rotate the model
            RotationY += (Cursor.Position.X - MouseLoc.X) * 0.5
            RotationX -= (Cursor.Position.Y - MouseLoc.Y) * 0.5
            Me.Refresh()
            Cursor.Position = New Point(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.Bounds.Height / 2)
            MouseLoc = Cursor.Position
        ElseIf IsRightMouseDown Then 'Move the model
            LookX += -(Cursor.Position.X - MouseLoc.X) * 0.5
            LookY += (Cursor.Position.Y - MouseLoc.Y) * 0.5
            Me.Refresh()
            Cursor.Position = New Point(My.Computer.Screen.Bounds.Width / 2, My.Computer.Screen.Bounds.Height / 2)
            MouseLoc = Cursor.Position
        End If
    End Sub

    Private Sub Renderer3D_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel 'Zoom
        Zoom += e.Delta * 0.005
        Refresh()
    End Sub

    Private Function GetCameraPos(modelview As Matrix4) As Vector3
        GlControl.MakeCurrent()
        Return Matrix4.Invert(modelview).ExtractTranslation()
    End Function
    Dim PaintThread As New Threading.Thread(AddressOf PaintCommander)
    Dim MousePoints As New List(Of Point)
    Dim tmpMousePoints As New List(Of Point)
    Dim PaintThreadSwitcher As Boolean
    Dim EndThreadFlag As Boolean 'To make sure that the thread is done

    Sub PaintCommander()
        Do
            If PaintThreadSwitcher Then
                If tmpMousePoints.Count = 0 Then
                    tmpMousePoints.Add(Cursor.Position)
                ElseIf Not tmpMousePoints.Last = Cursor.Position Then
                    tmpMousePoints.Add(Cursor.Position)
                End If
            Else
                MousePoints.AddRange(tmpMousePoints)
                tmpMousePoints.Clear()
                If MousePoints.Count = 0 Then
                    MousePoints.Add(Cursor.Position)
                ElseIf Not MousePoints.Last = Cursor.Position Then
                    MousePoints.Add(Cursor.Position)
                End If
            End If
            EndThreadFlag = False

            If IsMouseHit = False Then
                tmpMousePoints.Clear()
                MousePoints.Clear()
                PaintThread.Abort()
            End If
        Loop
    End Sub

    Private Sub Paint_Tick(sender As Object, e As EventArgs) Handles timPaint.Tick
        If IsMouseHit Then
            PaintThreadSwitcher = True
            EndThreadFlag = True
            While EndThreadFlag
                'Do nothing untill 'EndThreadFlag = False' then move on
            End While
            For Each P As Point In MousePoints
                GlControl.Invoke(Sub()
                                     GlobalMouseRay.Pos = GlControl.PointToClient(P)
                                 End Sub)
                Dim Mouse2ndHit As Vector3 = GlobalMouseRay.Mouse2ndHit
                Dim MouseHit As Vector3 = GlobalMouseRay.MouseHit
                Dim MouseHitDis As Double = Math.Sqrt(Math.Pow(GlobalCameraPos.X - MouseHit.X, 2.0F) + Math.Pow(GlobalCameraPos.Y - MouseHit.Y, 2.0F) + Math.Pow(GlobalCameraPos.Z - MouseHit.Z, 2.0F))
                Dim Mouse2ndHitDis As Double = Math.Sqrt(Math.Pow(GlobalCameraPos.X - Mouse2ndHit.X, 2.0F) + Math.Pow(GlobalCameraPos.Y - Mouse2ndHit.Y, 2.0F) + Math.Pow(GlobalCameraPos.Z - Mouse2ndHit.Z, 2.0F))
                If MouseHitDis > Mouse2ndHitDis Then
                    PaintPixel(Mouse2ndHit, True)

                ElseIf MouseHit <> New Vector3(0, 0, 0) Then
                    PaintPixel(MouseHit)
                End If
            Next
            MousePoints.Clear()
            PaintThreadSwitcher = False
            MainForm.Skin = Skin.Clone
            MainForm.UpdateImage()
        End If
    End Sub

    Public Event SkinChanged(sender As Object, IsLeft As Boolean)

    Sub PaintPixel(Vector As Vector3, Optional Second As Boolean = False)
        Dim tmpSkin As Bitmap = Skin.Clone
        Dim Point As Point
        Dim XUp As Vector3
        Dim YUp As Vector3
        Dim Left As Boolean
        If Second Then
            Point = Get2nd2DFrom3D(Vector, XUp, YUp)
        Else
            Point = Get2DFrom3D(Vector, XUp, YUp)
            If Point.Y > 31 Then Left = True
        End If
        Dim Points As New List(Of Point)
        If ColorPicker.IsPicking Then
            ColorPicker.Color = tmpSkin.GetPixel(Point.X, Point.Y)
            ColorPicker.Refresh()
        ElseIf ColorPicker.IsFilling Then
            FloodFill(Point.X, Point.Y, ColorPicker.Color)
        Else
            Points.Add(Point)
            If ColorPicker.IsMirroring Then
                Dim MPoint As Point
                If Second Then
                    MPoint = Get2nd2DFrom3D(Vector * New Vector3(-1, 1, 1), XUp, YUp)
                Else
                    MPoint = Get2DFrom3D(Vector * New Vector3(-1, 1, 1), XUp, YUp)
                End If
                Points.Add(MPoint)
            End If
            If ColorPicker.BrushSize >= 2 Then
                If Second Then
                    Points.Add(Get2nd2DFrom3D(Vector + XUp))
                    Points.Add(Get2nd2DFrom3D(Vector + XUp - YUp))
                    Points.Add(Get2nd2DFrom3D(Vector - YUp))
                    If ColorPicker.IsMirroring Then
                        Points.Add(Get2nd2DFrom3D((Vector + XUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2nd2DFrom3D((Vector + XUp - YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2nd2DFrom3D((Vector - YUp) * New Vector3(-1, 1, 1)))
                    End If
                Else
                    Points.Add(Get2DFrom3D(Vector + XUp))
                    Points.Add(Get2DFrom3D(Vector + XUp - YUp))
                    Points.Add(Get2DFrom3D(Vector - YUp))
                    If ColorPicker.IsMirroring Then
                        Points.Add(Get2DFrom3D((Vector + XUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2DFrom3D((Vector + XUp - YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2DFrom3D((Vector - YUp) * New Vector3(-1, 1, 1)))
                    End If
                End If
            End If
            If ColorPicker.BrushSize = 3 Then
                If Second Then
                    Points.Add(Get2nd2DFrom3D(Vector - XUp))
                    Points.Add(Get2nd2DFrom3D(Vector - XUp - YUp))
                    Points.Add(Get2nd2DFrom3D(Vector + YUp))
                    Points.Add(Get2nd2DFrom3D(Vector - XUp + YUp))
                    Points.Add(Get2nd2DFrom3D(Vector + XUp + YUp))
                    If ColorPicker.IsMirroring Then
                        Points.Add(Get2nd2DFrom3D((Vector - XUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2nd2DFrom3D((Vector - XUp - YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2nd2DFrom3D((Vector + YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2nd2DFrom3D((Vector - XUp + YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2nd2DFrom3D((Vector + XUp + YUp) * New Vector3(-1, 1, 1)))
                    End If
                Else
                    Points.Add(Get2DFrom3D(Vector - XUp))
                    Points.Add(Get2DFrom3D(Vector - XUp - YUp))
                    Points.Add(Get2DFrom3D(Vector + YUp))
                    Points.Add(Get2DFrom3D(Vector - XUp + YUp))
                    Points.Add(Get2DFrom3D(Vector + XUp + YUp))
                    If ColorPicker.IsMirroring Then
                        Points.Add(Get2DFrom3D((Vector - XUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2DFrom3D((Vector - XUp - YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2DFrom3D((Vector + YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2DFrom3D((Vector - XUp + YUp) * New Vector3(-1, 1, 1)))
                        Points.Add(Get2DFrom3D((Vector + XUp + YUp) * New Vector3(-1, 1, 1)))
                    End If
                End If
            End If

            For Each Pixel As Point In Points
                If Pixel <> New Point(0, 0) Then
                    Dim Color As Color = ColorPicker.Color

                    If ColorPicker.IsCamoing Then
                        Static rNumber As Random = New Random()
                        Dim B As Integer = Common.RGBtoHSV(Color).Value

                        B += rNumber.Next(-25, 25)
                        If B > 100 Then
                            B -= Common.RGBtoHSV(Color).Value + 25 - 100
                        End If

                        Color = Common.HSVtoRGB(Common.RGBtoHSV(Color).Hue, Common.RGBtoHSV(Color).Saturation, B)
                    End If

                    tmpSkin.SetPixel(Pixel.X, Pixel.Y, Color)
                End If
            Next
            Skin = tmpSkin.Clone
        End If
        tmpSkin.Dispose()
        RaiseEvent SkinChanged(Me, Left)
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
                Result = New Point(Int(Vector.Z + 34), Int(-Vector.Y + 60))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = -4 Then
            'XBody
            If ShowBody AndAlso Not ShowRightArm Then
                Result = New Point(Int(Vector.Z + 18), Int(-Vector.Y + 28))
            Else
                Result = New Point(Int(-Vector.Z + 50), Int(-Vector.Y + 28))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = 8 Then
            'XArms
            Result = New Point(Int(-Vector.Z + 42), Int(-Vector.Y + 60))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = -8 Then
            'XArms
            Result = New Point(Int(Vector.Z + 42), Int(-Vector.Y + 28))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = 7 Then
            'XArms
            Result = New Point(Int(-Vector.Z + 41), Int(-Vector.Y + 60))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Vector.Z < 2 AndAlso Vector.Z > -2 AndAlso Vector.Y < 8 AndAlso Vector.Y > -4 AndAlso Vector.X = -7 Then
            'XArms
            Result = New Point(Int(Vector.Z + 42), Int(-Vector.Y + 28))
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
            Result = New Point(Int(Vector.X + 32), Int(Vector.Z + 18))
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
        If Show2ndHead AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.Z = 4.24F Then
            'ZHead
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 40), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndHead AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.Z = -4.24F Then
            'ZHead
            Result = New Point(Int((-Vector.X + 4.24) / 1.06 + 56), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndBody AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = 2.12F Then
            'ZBody
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 20), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndBody AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = -2.12F Then
            'ZBody
            Result = New Point(Int((-Vector.X + 4.24) / 1.06 + 32), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndRightArm AndAlso Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = 2.12F Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X + 3.88) / 1.06 + 48), Int((-Vector.Y + 8.36) / 1.06 + 36))
            Else
                Result = New Point(Int((Vector.X + 3.88) / 1.06 + 47), Int((-Vector.Y + 8.36) / 1.06 + 36))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndRightArm AndAlso Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = -2.12F Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 45), Int((-Vector.Y + 8.36) / 1.06 + 36))
            Else
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 44), Int((-Vector.Y + 8.36) / 1.06 + 36))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndLeftArm AndAlso Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = 2.12F Then
            'ZArms
            Result = New Point(Int((Vector.X + 3.88) / 1.06 + 45), Int((-Vector.Y + 8.36) / 1.06 + 52))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndLeftArm AndAlso Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.Z = -2.12F Then
            'ZArms
            If Model = Models.Steve Then
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 64), Int((-Vector.Y + 8.36) / 1.06 + 52))
            Else
                Result = New Point(Int((-Vector.X + 3.88) / 1.06 + 62), Int((-Vector.Y + 8.36) / 1.06 + 52))
            End If
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndRightLeg AndAlso Vector.X < 0.12 AndAlso Vector.X > -4.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = 2.12F Then
            'ZLegs
            Result = New Point(Int((Vector.X + 4.12) / 1.06 + 4), Int((-Vector.Y - 16.36) / 1.06 + 48))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndRightLeg AndAlso Vector.X < 0.12 AndAlso Vector.X > -4.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = -2.12F Then
            'ZLegs
            Result = New Point(Int((-Vector.X + 4.12) / 1.06 + 8), Int((-Vector.Y - 16.36) / 1.06 + 48))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndLeftLeg AndAlso Vector.X < 4.12 AndAlso Vector.X > -0.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = 2.12F Then
            'ZLegs
            Result = New Point(Int((Vector.X + 0.12) / 1.06 + 4), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndLeftLeg AndAlso Vector.X < 4.12 AndAlso Vector.X > -0.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.Z = -2.12F Then
            'ZLegs
            Result = New Point(Int((-Vector.X + 0.12) / 1.06 + 16), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.X = 1
            YUp.Y = 1
        ElseIf Show2ndHead AndAlso Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.X = 4.24F Then
            'XHead
            Result = New Point(Int((-Vector.Z + 4.24) / 1.06 + 48), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndHead AndAlso Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.Y < 16.24 AndAlso Vector.Y > 7.76 AndAlso Vector.X = -4.24F Then
            'XHead
            Result = New Point(Int((Vector.Z + 4.24) / 1.06 + 32), Int((-Vector.Y + 16.24) / 1.06 + 8))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndBody AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.X = 4.24F Then
            'XBody
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 28), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndBody AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso Vector.X = -4.24F Then
            'XBody
            Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 16), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndLeftArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = 8.12F OrElse Vector.X = 7.09F) Then
            'XArms
            If Model = Models.Steve Then
                Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 56), Int((-Vector.Y + 8.36) / 1.06 + 52))
            Else
                Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 55), Int((-Vector.Y + 8.36) / 1.06 + 52))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndRightArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = -8.12F OrElse Vector.X = -7.09F) Then
            'XArms
            Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 40), Int((-Vector.Y + 8.36) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndLeftArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = 3.88F OrElse Vector.X = 3.91F) Then
            'XArms
            Result = New Point(Int((Vector.Z + 2.12) / 1.06 + 48), Int((-Vector.Y + 8.36) / 1.06 + 52))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndRightArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < 8.36 AndAlso Vector.Y > -4.36 AndAlso (Vector.X = -3.88F OrElse Vector.X = -3.91F) Then
            'XArms
            If Model = Models.Steve Then
                Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 48), Int((-Vector.Y + 8.36) / 1.06 + 36))
            Else
                Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 47), Int((-Vector.Y + 8.36) / 1.06 + 36))
            End If
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndLeftLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = 4.24F Then
            'XLeg
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 8), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndRightLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = -4.24F Then
            'XLeg
            Result = New Point(Int((Vector.Z + 2.12) / 1.06), Int((-Vector.Y - 3.64) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndRightLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = 0.12F Then
            'XLeg
            Result = New Point(Int((-Vector.Z + 2.12) / 1.06 + 8), Int((-Vector.Y - 3.64) / 1.06 + 36))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndLeftLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.Y < -3.64 AndAlso Vector.Y > -16.36 AndAlso Vector.X = -0.12F Then
            'XLeg
            Result = New Point(Int((Vector.Z + 2.12) / 1.06), Int((-Vector.Y - 3.64) / 1.06 + 52))
            XUp.Z = 1
            YUp.Y = 1
        ElseIf Show2ndHead AndAlso Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = 16.24F Then
            'YHead
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 40), Int((Vector.Z + 4.24) / 1.06))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndHead AndAlso Vector.Z < 4.24 AndAlso Vector.Z > -4.24 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = 7.76F Then
            'YHead
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 48), Int((Vector.Z + 4.24) / 1.06))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndBody AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = 8.36F Then
            'YBody
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 20), Int((Vector.Z + 2.12) / 1.06 + 32))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndBody AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -4.24 AndAlso Vector.Y = -4.36F Then
            'YBody
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 28), Int((Vector.Z + 2.12) / 1.06 + 32))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndLeftArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y = 8.36F Then
            'YArms
            Result = New Point(Int((Vector.X - 3.88) / 1.06 + 52), Int((Vector.Z + 2.12) / 1.06 + 48))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndLeftArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 8.12 AndAlso Vector.X > 3.88 AndAlso Vector.Y = -4.36F Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X - 3.88) / 1.06 + 56), Int((Vector.Z + 2.12) / 1.06 + 48))
            Else
                Result = New Point(Int((Vector.X - 3.88) / 1.06 + 55), Int((Vector.Z + 2.12) / 1.06 + 48))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndRightArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y = 8.36F Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 44), Int((Vector.Z + 2.12) / 1.06 + 32))
            Else
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 43), Int((Vector.Z + 2.12) / 1.06 + 32))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndRightArm AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < -3.88 AndAlso Vector.X > -8.12 AndAlso Vector.Y = -4.36F Then
            'YArms
            If Model = Models.Steve Then
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 48), Int((Vector.Z + 2.12) / 1.06 + 32))
            Else
                Result = New Point(Int((Vector.X + 8.12) / 1.06 + 46), Int((Vector.Z + 2.12) / 1.06 + 32))
            End If
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndLeftLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -0.12 AndAlso Vector.Y = -3.64F Then
            'YLeg
            Result = New Point(Int((Vector.X + 0.12) / 1.06 + 4), Int((Vector.Z + 2.12) / 1.06 + 48))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndRightLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 0.12 AndAlso Vector.X > -4.24 AndAlso Vector.Y = -3.64F Then
            'YLeg
            Result = New Point(Int((Vector.X + 4.24) / 1.06 + 4), Int((Vector.Z + 2.12) / 1.06 + 32))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndLeftLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 4.24 AndAlso Vector.X > -0.12 AndAlso Vector.Y = -16.36F Then
            'YLeg
            Result = New Point(Int((Vector.X + 0.12) / 1.06 + 8), Int((Vector.Z + 2.12) / 1.06 + 48))
            XUp.X = 1
            YUp.Z = 1
        ElseIf Show2ndRightLeg AndAlso Vector.Z < 2.12 AndAlso Vector.Z > -2.12 AndAlso Vector.X < 0.12 AndAlso Vector.X > -4.24 AndAlso Vector.Y = -16.36F Then
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

    Enum SkinPlace
        Head
        Body
        RArm
        LArm
        RLeg
        LLeg
        Head2
        Body2
        RArm2
        LArm2
        RLeg2
        LLeg2
    End Enum

    Sub FloodFill(x As Integer, y As Integer, new_color As Color)
        ' Get the old and new colors.
        Dim old_color As Color = Skin.GetPixel(x, y)

        If old_color.ToArgb <> new_color.ToArgb Then
            Dim CurrentPlace As SkinPlace

            'Get the current section of the skin
            If x < 32 AndAlso y < 16 Then
                CurrentPlace = SkinPlace.Head
            ElseIf x > 31 AndAlso y < 16 Then
                CurrentPlace = SkinPlace.Head2
            ElseIf x < 40 AndAlso x > 15 AndAlso y < 32 AndAlso y > 15 Then
                CurrentPlace = SkinPlace.Body
            ElseIf x < 40 AndAlso x > 15 AndAlso y < 48 AndAlso y > 31 Then
                CurrentPlace = SkinPlace.Body2
            ElseIf x < 56 AndAlso x > 39 AndAlso y < 32 AndAlso y > 15 Then
                CurrentPlace = SkinPlace.RArm
            ElseIf x < 56 AndAlso x > 39 AndAlso y < 48 AndAlso y > 31 Then
                CurrentPlace = SkinPlace.RArm2
            ElseIf x < 48 AndAlso x > 31 AndAlso y > 47 Then
                CurrentPlace = SkinPlace.LArm
            ElseIf x > 47 AndAlso y > 47 Then
                CurrentPlace = SkinPlace.LArm2
            ElseIf x < 16 AndAlso y < 32 AndAlso y > 15 Then
                CurrentPlace = SkinPlace.RLeg
            ElseIf x < 16 AndAlso y < 48 AndAlso y > 31 Then
                CurrentPlace = SkinPlace.RLeg2
            ElseIf x < 32 AndAlso x > 15 AndAlso y > 47 Then
                CurrentPlace = SkinPlace.LLeg
            ElseIf x < 16 AndAlso y > 47 Then
                CurrentPlace = SkinPlace.LLeg2
            End If

            Dim SkinSection As New Bitmap(16, 16)
            Select Case CurrentPlace
                Case SkinPlace.Head
                    SkinSection = Skin.Clone(New Rectangle(0, 0, 32, 16), Skin.PixelFormat)
                Case SkinPlace.Head2
                    SkinSection = Skin.Clone(New Rectangle(32, 0, 32, 16), Skin.PixelFormat)
                    x -= 32
                Case SkinPlace.Body
                    SkinSection = Skin.Clone(New Rectangle(16, 16, 24, 16), Skin.PixelFormat)
                    x -= 16 : y -= 16
                Case SkinPlace.Body2
                    SkinSection = Skin.Clone(New Rectangle(16, 32, 24, 16), Skin.PixelFormat)
                    x -= 16 : y -= 32
                Case SkinPlace.RArm
                    If Model = Models.Steve Then
                        SkinSection = Skin.Clone(New Rectangle(40, 16, 16, 16), Skin.PixelFormat)
                    Else
                        SkinSection = Skin.Clone(New Rectangle(40, 16, 14, 16), Skin.PixelFormat)
                    End If
                    x -= 40 : y -= 16
                Case SkinPlace.RArm2
                    If Model = Models.Steve Then
                        SkinSection = Skin.Clone(New Rectangle(40, 32, 16, 16), Skin.PixelFormat)
                    Else
                        SkinSection = Skin.Clone(New Rectangle(40, 32, 14, 16), Skin.PixelFormat)
                    End If
                    x -= 40 : y -= 32
                Case SkinPlace.LArm
                    If Model = Models.Steve Then
                        SkinSection = Skin.Clone(New Rectangle(32, 48, 16, 16), Skin.PixelFormat)
                    Else
                        SkinSection = Skin.Clone(New Rectangle(32, 48, 14, 16), Skin.PixelFormat)
                    End If
                    x -= 32 : y -= 48
                Case SkinPlace.LArm2
                    If Model = Models.Steve Then
                        SkinSection = Skin.Clone(New Rectangle(48, 48, 16, 16), Skin.PixelFormat)
                    Else
                        SkinSection = Skin.Clone(New Rectangle(48, 48, 14, 16), Skin.PixelFormat)
                    End If
                    x -= 48 : y -= 48
                Case SkinPlace.RLeg
                    SkinSection = Skin.Clone(New Rectangle(0, 16, 16, 16), Skin.PixelFormat)
                    y -= 16
                Case SkinPlace.RLeg2
                    SkinSection = Skin.Clone(New Rectangle(0, 32, 16, 16), Skin.PixelFormat)
                    y -= 32
                Case SkinPlace.LLeg
                    SkinSection = Skin.Clone(New Rectangle(16, 48, 16, 16), Skin.PixelFormat)
                    x -= 16 : y -= 48
                Case SkinPlace.LLeg2
                    SkinSection = Skin.Clone(New Rectangle(0, 48, 16, 16), Skin.PixelFormat)
                    y -= 48
            End Select

            Dim tmpSS As Bitmap = SkinSection
            Dim tmpG As Drawing.Graphics
            Select Case CurrentPlace
                Case SkinPlace.Head, SkinPlace.Head2

                    tmpSS = New Bitmap(32, 24)
                    tmpG = Drawing.Graphics.FromImage(tmpSS)
                    tmpG.DrawImage(SkinSection, 0, 0)
                    tmpG.FillRectangle(New SolidBrush(Color.Transparent), 16, 0, 8, 8)
                    tmpG.DrawImage(SkinSection, New Rectangle(8, 16, 8, 8), New Rectangle(16, 8, 8, -8), GraphicsUnit.Pixel)
                    If x < 24 AndAlso x >= 16 AndAlso y < 8 Then
                        x -= 8 : y = Math.Abs(y - 7) + 16
                    End If

                Case SkinPlace.Body, SkinPlace.Body2

                    tmpSS = New Bitmap(24, 20)
                    tmpG = Drawing.Graphics.FromImage(tmpSS)
                    tmpG.DrawImage(SkinSection, 0, 0)
                    tmpG.FillRectangle(New SolidBrush(Color.Transparent), 12, 0, 8, 4)
                    tmpG.DrawImage(SkinSection, New Rectangle(4, 16, 8, 4), New Rectangle(12, 4, 8, -4), GraphicsUnit.Pixel)
                    If x < 20 AndAlso x >= 12 AndAlso y < 4 Then
                        x -= 8 : y = Math.Abs(y - 3) + 16
                    End If

                Case SkinPlace.LArm, SkinPlace.LArm2, SkinPlace.RArm, SkinPlace.RArm2, SkinPlace.LLeg, SkinPlace.LLeg2, SkinPlace.RLeg, SkinPlace.RLeg2

                    If Model = Models.Alex AndAlso (CurrentPlace = SkinPlace.LArm OrElse CurrentPlace = SkinPlace.LArm2 OrElse CurrentPlace = SkinPlace.RArm OrElse CurrentPlace = SkinPlace.RArm2) Then
                        tmpSS = New Bitmap(14, 20)
                        tmpG = Drawing.Graphics.FromImage(tmpSS)
                        tmpG.DrawImage(SkinSection, 0, 0)
                        tmpG.FillRectangle(New SolidBrush(Color.Transparent), 7, 0, 3, 4)
                        tmpG.DrawImage(SkinSection, New Rectangle(4, 16, 3, 4), New Rectangle(7, 4, 3, -4), GraphicsUnit.Pixel)
                        If x < 10 AndAlso x >= 7 AndAlso y < 4 Then
                            x -= 3 : y = Math.Abs(y - 3) + 16
                        End If
                    Else
                        tmpSS = New Bitmap(16, 20)
                        tmpG = Drawing.Graphics.FromImage(tmpSS)
                        tmpG.DrawImage(SkinSection, 0, 0)
                        tmpG.FillRectangle(New SolidBrush(Color.Transparent), 8, 0, 4, 4)
                        tmpG.DrawImage(SkinSection, New Rectangle(4, 16, 4, 4), New Rectangle(8, 4, 4, -4), GraphicsUnit.Pixel)
                        If x < 12 AndAlso x >= 8 AndAlso y < 4 Then
                            x -= 4 : y = Math.Abs(y - 3) + 16
                        End If
                    End If

            End Select

            SkinSection = tmpSS

            ' Start with the original point in the stack.
            Dim pts As New Stack
            pts.Push(New Point(x, y))
            SkinSection.SetPixel(x, y, new_color)

            ' While the stack is not empty, process a point.
            Do While pts.Count > 0
                Dim pt As Point = pts.Pop()
                CheckPoint(SkinSection, CurrentPlace, pts, pt.X - 1, pt.Y, old_color, new_color)
                CheckPoint(SkinSection, CurrentPlace, pts, pt.X, pt.Y - 1, old_color, new_color)
                CheckPoint(SkinSection, CurrentPlace, pts, pt.X + 1, pt.Y, old_color, new_color)
                CheckPoint(SkinSection, CurrentPlace, pts, pt.X, pt.Y + 1, old_color, new_color)
            Loop

            Select Case CurrentPlace
                Case SkinPlace.Head, SkinPlace.Head2

                    tmpSS = New Bitmap(32, 16)
                    tmpG = Drawing.Graphics.FromImage(tmpSS)
                    tmpG.DrawImage(SkinSection, 0, 0)
                    tmpG.DrawImage(SkinSection, New Rectangle(16, 8, 8, -8), New Rectangle(8, 16, 8, 8), GraphicsUnit.Pixel)

                Case SkinPlace.Body, SkinPlace.Body2

                    tmpSS = New Bitmap(24, 16)
                    tmpG = Drawing.Graphics.FromImage(tmpSS)
                    tmpG.DrawImage(SkinSection, 0, 0)
                    tmpG.DrawImage(SkinSection, New Rectangle(12, 4, 8, -4), New Rectangle(4, 16, 8, 4), GraphicsUnit.Pixel)

                Case SkinPlace.LArm, SkinPlace.LArm2, SkinPlace.RArm, SkinPlace.RArm2, SkinPlace.LLeg, SkinPlace.LLeg2, SkinPlace.RLeg, SkinPlace.RLeg2

                    If Model = Models.Alex AndAlso (CurrentPlace = SkinPlace.LArm OrElse CurrentPlace = SkinPlace.LArm2 OrElse CurrentPlace = SkinPlace.RArm OrElse CurrentPlace = SkinPlace.RArm2) Then
                        tmpSS = New Bitmap(14, 16)
                        tmpG = Drawing.Graphics.FromImage(tmpSS)
                        tmpG.DrawImage(SkinSection, 0, 0)
                        tmpG.DrawImage(SkinSection, New Rectangle(7, 4, 3, -4), New Rectangle(4, 16, 3, 4), GraphicsUnit.Pixel)
                    Else
                        tmpSS = New Bitmap(16, 16)
                        tmpG = Drawing.Graphics.FromImage(tmpSS)
                        tmpG.DrawImage(SkinSection, 0, 0)
                        tmpG.DrawImage(SkinSection, New Rectangle(8, 4, 4, -4), New Rectangle(4, 16, 4, 4), GraphicsUnit.Pixel)
                    End If

            End Select

            tmpG = Drawing.Graphics.FromImage(Skin)
            Select Case CurrentPlace
                Case SkinPlace.Head
                    TransparentFill(Skin, New Rectangle(0, 0, 32, 16))
                    tmpG.DrawImage(tmpSS, 0, 0, 32, 16)
                Case SkinPlace.Head2
                    TransparentFill(Skin, New Rectangle(32, 0, 32, 16))
                    tmpG.DrawImage(tmpSS, 32, 0, 32, 16)
                Case SkinPlace.Body
                    TransparentFill(Skin, New Rectangle(16, 16, 24, 16))
                    tmpG.DrawImage(tmpSS, 16, 16, 24, 16)
                Case SkinPlace.Body2
                    TransparentFill(Skin, New Rectangle(16, 32, 24, 16))
                    tmpG.DrawImage(tmpSS, 16, 32, 24, 16)
                Case SkinPlace.RArm
                    If Model = Models.Steve Then
                        TransparentFill(Skin, New Rectangle(40, 16, 16, 16))
                        tmpG.DrawImage(tmpSS, 40, 16, 16, 16)
                    Else
                        TransparentFill(Skin, New Rectangle(40, 16, 14, 16))
                        tmpG.DrawImage(tmpSS, 40, 16, 14, 16)
                    End If
                Case SkinPlace.RArm2
                    If Model = Models.Steve Then
                        TransparentFill(Skin, New Rectangle(40, 32, 16, 16))
                        tmpG.DrawImage(tmpSS, 40, 32, 16, 16)
                    Else
                        TransparentFill(Skin, New Rectangle(40, 32, 14, 16))
                        tmpG.DrawImage(tmpSS, 40, 32, 14, 16)
                    End If
                Case SkinPlace.LArm
                    If Model = Models.Steve Then
                        TransparentFill(Skin, New Rectangle(32, 48, 16, 16))
                        tmpG.DrawImage(tmpSS, 32, 48, 16, 16)
                    Else
                        TransparentFill(Skin, New Rectangle(32, 48, 14, 16))
                        tmpG.DrawImage(tmpSS, 32, 48, 14, 16)
                    End If
                Case SkinPlace.LArm2
                    If Model = Models.Steve Then
                        TransparentFill(Skin, New Rectangle(48, 48, 16, 16))
                        tmpG.DrawImage(tmpSS, 48, 48, 16, 16)
                    Else
                        TransparentFill(Skin, New Rectangle(48, 48, 14, 16))
                        tmpG.DrawImage(tmpSS, 48, 48, 14, 16)
                    End If
                Case SkinPlace.RLeg
                    TransparentFill(Skin, New Rectangle(0, 16, 16, 16))
                    tmpG.DrawImage(tmpSS, 0, 16, 16, 16)
                Case SkinPlace.RLeg2
                    TransparentFill(Skin, New Rectangle(0, 32, 16, 16))
                    tmpG.DrawImage(tmpSS, 0, 32, 16, 16)
                Case SkinPlace.LLeg
                    TransparentFill(Skin, New Rectangle(16, 48, 16, 16))
                    tmpG.DrawImage(tmpSS, 16, 48, 16, 16)
                Case SkinPlace.LLeg2
                    TransparentFill(Skin, New Rectangle(0, 48, 16, 16))
                    tmpG.DrawImage(tmpSS, 0, 48, 16, 16)
            End Select
            tmpG.Dispose()
            tmpSS.Dispose()
        End If
    End Sub

    ' See if this point should be added to the stack.
    Sub CheckPoint(ByRef SkinSection As Bitmap, SkinPlace As SkinPlace, pts As Stack, x As Integer, y As Integer, old_color As Color, new_color As Color)
        ' Correct the point
        Select Case SkinPlace
            Case SkinPlace.Head, SkinPlace.Head2
                If x = -1 Then x = 31
                If x = 32 Then x = 0

                If y = -1 Then
                    x = Math.Abs(x - 16) + 23
                    y = 8
                ElseIf y = 24 Then
                    x = Math.Abs(x - 16) + 23
                    y = 15
                End If

                If y = 7 Then

                    If x > 23 Then
                        x = Math.Abs(x - 32) + 7
                        y = 0
                    ElseIf x > 15 AndAlso x < 24 Then
                        y = Math.Abs(x - 23)
                        x = 15
                    ElseIf x < 8 Then
                        y = x
                        x = 8
                    End If

                ElseIf y = 16 Then

                    If x > 23 Then
                        x = Math.Abs(x - 32) + 7
                        y = 23
                    ElseIf x > 15 AndAlso x < 24 Then
                        y = x
                        x = 15
                    ElseIf x < 8 Then
                        y = Math.Abs(x - 7) + 16
                        x = 8
                    End If

                End If

                If x = 16 Then

                    If y < 8 Then
                        x = Math.Abs(y - 7) + 16
                        y = 8
                    ElseIf y > 15 Then
                        x = y
                        y = 15
                    End If

                ElseIf x = 7 Then

                    If y < 8 Then
                        x = y
                        y = 8
                    ElseIf y > 15 Then
                        x = Math.Abs(y - 23)
                        y = 15
                    End If

                End If

            Case SkinPlace.Body, SkinPlace.Body2
                If x = -1 Then x = 23
                If x = 24 Then x = 0

                If y = -1 Then
                    x = Math.Abs(x - 12) + 15
                    y = 4
                ElseIf y = 20 Then
                    x = Math.Abs(x - 12) + 15
                    y = 15
                End If

                If y = 3 Then

                    If x > 15 Then
                        x = Math.Abs(x - 24) + 3
                        y = 0
                    ElseIf x > 11 AndAlso x < 16 Then
                        y = Math.Abs(x - 15)
                        x = 11
                    ElseIf x < 4 Then
                        y = x
                        x = 4
                    End If

                ElseIf y = 16 Then

                    If x > 15 Then
                        x = Math.Abs(x - 24) + 3
                        y = 19
                    ElseIf x > 11 AndAlso x < 16 Then
                        y = x + 4
                        x = 11
                    ElseIf x < 4 Then
                        y = Math.Abs(x - 3) + 16
                        x = 4
                    End If

                End If

                If x = 12 Then

                    If y < 4 Then
                        x = Math.Abs(y - 3) + 12
                        y = 4
                    ElseIf y > 15 Then
                        x = y - 4
                        y = 15
                    End If

                ElseIf x = 3 Then

                    If y < 4 Then
                        x = y
                        y = 4
                    ElseIf y > 15 Then
                        x = Math.Abs(y - 19)
                        y = 15
                    End If

                End If

            Case SkinPlace.LArm, SkinPlace.LArm2, SkinPlace.RArm, SkinPlace.RArm2, SkinPlace.LLeg, SkinPlace.LLeg2, SkinPlace.RLeg, SkinPlace.RLeg2

                If Model = Models.Alex AndAlso (SkinPlace = SkinPlace.LArm OrElse SkinPlace = SkinPlace.LArm2 OrElse SkinPlace = SkinPlace.RArm OrElse SkinPlace = SkinPlace.RArm2) Then
                    If x = -1 Then x = 13
                    If x = 14 Then x = 0

                    If y = -1 Then
                        x = Math.Abs(x - 6) + 11
                        y = 4
                    ElseIf y = 20 Then
                        x = Math.Abs(x - 6) + 11
                        y = 15
                    End If

                    If y = 3 Then

                        If x > 10 Then
                            x = Math.Abs(x - 14) + 3
                            y = 0
                        ElseIf x > 6 AndAlso x < 11 Then
                            y = Math.Abs(x - 10)
                            x = 6
                        ElseIf x < 4 Then
                            y = x
                            x = 4
                        End If

                    ElseIf y = 16 Then

                        If x > 10 Then
                            x = Math.Abs(x - 13) + 4
                            y = 19
                        ElseIf x > 6 AndAlso x < 11 Then
                            y = x + 9
                            x = 6
                        ElseIf x < 4 Then
                            y = Math.Abs(x - 3) + 16
                            x = 4
                        End If

                    End If

                    If x = 7 Then

                        If y < 4 Then
                            x = Math.Abs(y - 3) + 7
                            y = 4
                        ElseIf y > 15 Then
                            x = y - 9
                            y = 15
                        End If

                    ElseIf x = 3 Then

                        If y < 4 Then
                            x = y
                            y = 4
                        ElseIf y > 15 Then
                            x = Math.Abs(y - 19)
                            y = 15
                        End If

                    End If
                Else
                    If x = -1 Then x = 15
                    If x = 16 Then x = 0

                    If y = -1 Then
                        x = Math.Abs(x - 7) + 12
                        y = 4
                    ElseIf y = 20 Then
                        x = Math.Abs(x - 7) + 12
                        y = 15
                    End If

                    If y = 3 Then

                        If x > 11 Then
                            x = Math.Abs(x - 16) + 3
                            y = 0
                        ElseIf x > 7 AndAlso x < 12 Then
                            y = Math.Abs(x - 11)
                            x = 7
                        ElseIf x < 4 Then
                            y = x
                            x = 4
                        End If

                    ElseIf y = 16 Then

                        If x > 10 Then
                            x = Math.Abs(x - 16) + 3
                            y = 19
                        ElseIf x > 7 AndAlso x < 12 Then
                            y = x + 8
                            x = 7
                        ElseIf x < 4 Then
                            y = Math.Abs(x - 3) + 16
                            x = 4
                        End If

                    End If

                    If x = 8 Then

                        If y < 4 Then
                            x = Math.Abs(y - 3) + 8
                            y = 4
                        ElseIf y > 15 Then
                            x = y - 8
                            y = 15
                        End If

                    ElseIf x = 3 Then

                        If y < 4 Then
                            x = y
                            y = 4
                        ElseIf y > 15 Then
                            x = Math.Abs(y - 19)
                            y = 15
                        End If

                    End If
                End If

        End Select

        Dim clr As Color = SkinSection.GetPixel(x, y)
        If clr.Equals(old_color) Then
            pts.Push(New Point(x, y))

            Dim Color As Color = new_color

            If ColorPicker.IsCamoing Then
                Static rNumber As Random = New Random()
                Dim B As Integer = Common.RGBtoHSV(Color).Value

                B += rNumber.Next(-25, 25)
                If B > 100 Then
                    B -= Common.RGBtoHSV(Color).Value + 25 - 100
                End If

                Color = Common.HSVtoRGB(Common.RGBtoHSV(Color).Hue, Common.RGBtoHSV(Color).Saturation, B)
            End If
            SkinSection.SetPixel(x, y, Color)
        End If
    End Sub

    Sub TransparentFill(B As Bitmap, R As Rectangle)
        For X = R.Left To R.Right - 1
            For Y = R.Top To R.Bottom - 1
                B.SetPixel(X, Y, Color.Transparent)
            Next
        Next
    End Sub
End Class
