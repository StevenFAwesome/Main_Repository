Imports System.Speech.Synthesis
Module SpeechModule



    Sub Main()

        Dim synth As New SpeechSynthesizer

        ' Dim voices = synth.GetInstalledVoices()
        'For Each v As InstalledVoice In voices
        'System.Console.WriteLine(v.VoiceInfo.Name)
        'synth.SelectVoice(v.VoiceInfo.Name)
        ' synth.SelectVoice(VoiceInfo.Equals =)
        synth.Speak("Hello from ") ' & v.VoiceInfo.Name)
        ' Next
    End Sub

End Module



