Imports System.Management
Module Module_GSMDetector
    Public Function ModemsConnected() As String
        Dim modems As String = ""
        Try
            Dim searcher As New ManagementObjectSearcher(
                "root\CIMV2",
                "SELECT * FROM Win32_POTSModem")

            For Each queryObj As ManagementObject In searcher.Get()
                If queryObj("Status") = "OK" Then
                    modems = modems & (queryObj("AttachedTo") & " - " & queryObj("Description") & "***")
                End If
            Next
        Catch err As ManagementException
            MessageBox.Show("An error occurred while querying for WMI data: " & err.Message)
            Return ""
        End Try
        Return modems
    End Function
    Public Function queryCOMPorts()
        Dim i As Integer = 0
        Dim PortList As New List(Of String)
        Dim ports() As String
        ports = Split(ModemsConnected(), "---")
        While i <> ports.Length
            PortList.AddRange(ports)
            i += 1
        End While
        Dim ActivePorts As Array = PortList.ToArray
        Return ActivePorts
    End Function
End Module
