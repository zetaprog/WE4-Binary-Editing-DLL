Imports System.IO
Imports System.Linq

Public Class FileProcessor
    ' Winning Eleven 2002 Stats
    Public Property Feet As Integer
    Public Property Boots As Integer
    Public Property Aggression As Integer
    Public Property Curve As Integer
    Public Property Jump As Integer
    Public Property Head As Integer
    Public Property Technique As Integer
    Public Property PassAcc As Integer
    Public Property ShotAcc As Integer
    Public Property ShotPwr As Integer
    Public Property Defense As Integer
    Public Property Offense As Integer
    Public Property Acceleration As Integer
    Public Property Dribble As Integer
    Public Property Speed As Integer
    Public Property Stamina As Integer
    Public Property BodyBalance As Integer
    Public Property Response As Integer
    Public Property Age As Integer
    Public Property Body As Integer
    Public Property SkinColor As Integer
    Public Property FeetOutside As Integer
    Public Property Height As Integer
    Public Property HairColorFace As Integer
    Public Property HairFace As Integer
    Public Property HairColor As Integer
    Public Property Hair As Integer
    Public Property Position As Integer

    Public Property FeintTypeB As Integer

    Public Property PlayerNumber As Integer

    Public numberPlayer(22) As Integer ' O 23 jugadores por nacionalidad (índice 0-22)


    ' Método para leer y procesar bytes desde un archivo
    Public Sub ReadToFile(filePath As String, offset As Long)
        ' Leer 12 bytes desde el archivo en la posición especificada
        Dim bytes(11) As Byte
        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            fs.Position = offset
            fs.Read(bytes, 0, 12)
        End Using

        ' Invertir los bytes
        Dim invertedBytes(11) As Byte
        For i As Integer = 0 To bytes.Length - 1
            invertedBytes(i) = bytes(bytes.Length - 1 - i)
        Next

        ' Convertir los bytes a una cadena binaria
        Dim binString As String = String.Join("", invertedBytes.Select(Function(b) Convert.ToString(b, 2).PadLeft(8, "0"c)))

        ' Convertir binario a decimal (función auxiliar)
        Boots = BinToDec(binString.Substring(2, 3)) ' BOOTS (110)
        Aggression = BinToDec(binString.Substring(5, 3)) ' AGRESSION (110)
        Curve = BinToDec(binString.Substring(8, 3)) ' CURVE (111)
        Jump = BinToDec(binString.Substring(11, 3)) ' JUMP (111)
        Head = BinToDec(binString.Substring(14, 3)) ' HEAD (111)
        Technique = BinToDec(binString.Substring(17, 3)) ' TECHNIQUE (111)
        PassAcc = BinToDec(binString.Substring(20, 3)) ' PASS (111)
        ShotAcc = BinToDec(binString.Substring(23, 3)) ' SHOT ACCURACY (111)
        ShotPwr = BinToDec(binString.Substring(26, 3)) ' SHOT POWER (111)
        Defense = BinToDec(binString.Substring(29, 3)) ' DEFENSE (111)
        Offense = BinToDec(binString.Substring(32, 3)) ' OFFENSE (111)
        Acceleration = BinToDec(binString.Substring(35, 3)) ' ACCELERATION (111)
        Speed = BinToDec(binString.Substring(38, 3)) ' SPEED (111)
        Dribble = BinToDec(binString.Substring(41, 3)) '  DRIBBLE (111)
        Stamina = BinToDec(binString.Substring(44, 3)) ' STAMINA (111)
        BodyBalance = BinToDec(binString.Substring(47, 3)) ' BODY BALANCE (011)
        FeintTypeB = BinToDec(binString.Substring(50, 2)) ' RESPONSE (0111)
        Feet = BinToDec(binString.Substring(52, 2)) ' FEET (01)
        Age = BinToDec(binString.Substring(54, 5)) ' AGE (11111)
        Body = BinToDec(binString.Substring(59, 3)) ' BODY (111)
        SkinColor = BinToDec(binString.Substring(62, 2)) ' SKIN COLOR (11)
        FeetOutside = BinToDec(binString.Substring(64, 1)) ' FEET OUTSIDE (1)
        PlayerNumber = BinToDec(binString.Substring(65, 5)) ' PlayerNumber (00000)
        Height = BinToDec(binString.Substring(70, 6)) ' HEIGHT (111111)
        HairColorFace = BinToDec(binString.Substring(76, 3)) ' HAIR COLOR FACE (110)
        HairFace = BinToDec(binString.Substring(79, 4)) ' HAIR FACE (0110)
        HairColor = BinToDec(binString.Substring(83, 4)) ' HAIR COLOR (0111)
        Hair = BinToDec(binString.Substring(87, 5)) ' HAIR (11111)
        Position = BinToDec(binString.Substring(92, 4)) ' POSITION (0111)
    End Sub

    ' Método para escribir los datos procesados en el archivo
    Public Sub WriteToFile(filePath As String, offset As Long)

        Dim binString As New Text.StringBuilder()

        ' === ORDEN EXACTO SEGÚN ReadToFile (con FEET en su posición correcta) ===

        binString.Append(DecToBin(Boots, 3))           ' BOOTS (110)
        binString.Append(DecToBin(Aggression, 3))      ' AGGRESSION (110)
        binString.Append(DecToBin(Curve, 3))           ' CURVE (111)
        binString.Append(DecToBin(Jump, 3))            ' JUMP (111)
        binString.Append(DecToBin(Head, 3))            ' HEAD (111)
        binString.Append(DecToBin(Technique, 3))       ' TECHNIQUE (111)
        binString.Append(DecToBin(PassAcc, 3))         ' PASS (111)
        binString.Append(DecToBin(ShotAcc, 3))         ' SHOT ACC (111)
        binString.Append(DecToBin(ShotPwr, 3))         ' SHOT PWR (111)
        binString.Append(DecToBin(Defense, 3))         ' DEFENSE (111)
        binString.Append(DecToBin(Offense, 3))         ' OFFENSE (111)
        binString.Append(DecToBin(Acceleration, 3))    ' ACCELERATION (111)
        binString.Append(DecToBin(Dribble, 3))         ' DRIBBLE (111)
        binString.Append(DecToBin(Speed, 3))           ' SPEED (111)
        binString.Append(DecToBin(Stamina, 3))         ' STAMINA (111)

        binString.Append(DecToBin(BodyBalance, 3))     ' BODY BALANCE (011)
        binString.Append(DecToBin(FeintTypeB, 2))      ' FEINT TYPE B (011)
        binString.Append(DecToBin(Feet, 2))            ' FEET (01)

        binString.Append(DecToBin(Age, 5))             ' AGE (11111)
        binString.Append(DecToBin(Body, 3))            ' BODY (111)
        binString.Append(DecToBin(SkinColor, 2))       ' SKIN (11)
        binString.Append(DecToBin(FeetOutside, 1))     ' FEET OUTSIDE (1)
        binString.Append(DecToBin(PlayerNumber, 5))    ' NUMBER (00000)
        binString.Append(DecToBin(Height, 6))          ' HEIGHT (111111)
        binString.Append(DecToBin(HairColorFace, 3))   ' HAIR COLOR FACE (110)
        binString.Append(DecToBin(HairFace, 4))        ' HAIR FACE (0110)
        binString.Append(DecToBin(HairColor, 4))       ' HAIR COLOR (0111)
        binString.Append(DecToBin(Hair, 5))            ' HAIR (11111)
        binString.Append(DecToBin(Position, 4))        ' POSITION (0111)

        ' === Convertir en bytes ===
        Dim newBytes(11) As Byte
        For i As Integer = 0 To 11
            newBytes(i) = Convert.ToByte(binString.ToString().Substring(i * 8, 8), 2)
        Next

        ' === Invertir antes de escribir ===
        Dim invertedBytes = newBytes.Reverse().ToArray()

        ' === Guardar en archivo ===
        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Write)
            fs.Position = offset
            fs.Write(invertedBytes, 0, 12)
        End Using

    End Sub


    ' Convertir binario a decimal
    Private Function BinToDec(bin As String) As Integer
        Return Convert.ToInt32(bin, 2)
    End Function

    ' Convertir decimal a binario
    Private Function DecToBin(value As Integer, bits As Integer) As String
        Return Convert.ToString(value, 2).PadLeft(bits, "0"c)
    End Function

    Public Sub LeerNationNumbers(filePath As String, offsetInicial As Long)
        Dim bufferSize As Integer = 4
        Dim bytenum(bufferSize - 1) As Byte
        Dim binaryStringBuilder As New System.Text.StringBuilder()
        Dim binaryString As String
        Dim count As Integer = 0
        Dim cadenatamaño As Integer = 5
        Dim bloque As Integer
        Dim offsetnum As Long = offsetInicial

        Array.Clear(numberPlayer, 0, numberPlayer.Length)

        For bloque = 1 To 4 ' 4 bloques de 6 números = 24 (último puede tener solo 5)
            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
                fs.Position = offsetnum
                fs.Read(bytenum, 0, bufferSize)
            End Using

            Array.Reverse(bytenum)
            binaryStringBuilder.Clear()

            For Each b As Byte In bytenum
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, "0"c))
            Next

            binaryString = binaryStringBuilder.ToString()
            cadenatamaño = 5

            For k = 0 To 5
                If count >= numberPlayer.Length Then Exit For

                Dim startBit As Integer = binaryString.Length - cadenatamaño
                Dim ReadNumber As String = binaryString.Substring(startBit, 5)
                numberPlayer(count) = Convert.ToInt32(ReadNumber, 2) + 1
                count += 1
                cadenatamaño += 5
            Next

            offsetnum += bufferSize
        Next
    End Sub
    Public Sub EscribirNationNumbers(filePath As String, offsetInicial As Long)
        Dim count As Integer = 0
        Dim offsetnum As Long = offsetInicial

        While count < numberPlayer.Length
            Dim binaryStringBuilder As New System.Text.StringBuilder()

            ' Construir bloque de 6 jugadores (30 bits)
            For i As Integer = 0 To 5
                If count < numberPlayer.Length Then
                    ' Convertir a binario de 5 bits y restar 1
                    Dim binValue As String = Convert.ToString(numberPlayer(count) - 1, 2).PadLeft(5, "0"c)

                    ' Insertar al principio (orden invertido)
                    binaryStringBuilder.Insert(0, binValue)
                    count += 1
                End If
            Next

            ' Convertir la cadena binaria a bytes (desde derecha a izquierda)
            Dim binaryString As String = binaryStringBuilder.ToString()
            Dim byteList As New List(Of Byte)

            For i As Integer = binaryString.Length To 1 Step -8
                Dim chunkStart As Integer = Math.Max(0, i - 8)
                Dim chunk As String = binaryString.Substring(chunkStart, i - chunkStart)
                byteList.Add(Convert.ToByte(chunk, 2))
            Next

            Dim bytesToWrite() As Byte = byteList.ToArray()

            ' Escribir en el archivo con FileStream
            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Write)
                fs.Position = offsetnum
                fs.Write(bytesToWrite, 0, bytesToWrite.Length)
            End Using

            ' Incrementar el offset (4 bytes por bloque de 6 jugadores)
            offsetnum += 4
        End While
    End Sub


    Public Function LeerClubNumber(filePath As String, offset As Long) As Integer()
        Dim cantidadJugadores As Integer = 23
        Dim buffer(cantidadJugadores - 1) As Byte
        Dim numeros(cantidadJugadores - 1) As Integer

        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            fs.Position = offset
            fs.Read(buffer, 0, cantidadJugadores)
        End Using

        For i As Integer = 0 To cantidadJugadores - 1
            ' Se suma 1 para que 0 sea 1, 1 sea 2, etc.
            numeros(i) = buffer(i) + 1
        Next

        Return numeros
    End Function


    Public Sub GuardarClubNumber(filePath As String, offset As Long, numeros() As Integer)
        If numeros Is Nothing OrElse numeros.Length <> 23 Then
            Throw New ArgumentException("El array debe tener exactamente 23 elementos.")
        End If

        Dim buffer(22) As Byte
        For i As Integer = 0 To 22
            ' Restar 1 para convertir 1?0, 2?1, etc., antes de guardar
            buffer(i) = CByte(Math.Max(0, numeros(i) - 1))
        Next

        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Write)
            fs.Position = offset
            fs.Write(buffer, 0, buffer.Length)
        End Using
    End Sub



End Class
