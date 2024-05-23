Imports System.Security.Cryptography
Imports System.Text.Encoding
Module Cyper
    Dim hasha As String = "MahmoudShamran99_ComputerScience"
    'تشفير وفك تشفير بيانات بستخدام MD5
    '    خوارزمية أم دي 5 أو خوارزمية هضم الرسالة الخامسة (بالإنجليزية: Message Digest MD5 algorithm)
    '‏ هي دالة الاختزال المسمّاة دالة هاش تشفيرية
    ' (Message Digest) والتي تُعتبر من أكثر دوال الاختزال انتشارًا في علم التشفير وأمن المعلومات نظرًا لسهولة تنفيذها وصعوبة اختراقها. 
    'يشمل ذلك نظرة سريعة على أهميّتها، طريقة تطويرها من النظريّة التي تتّبعها ومُخرجاتها،
    ' والنسخ السابقة لها إم دي2, إم دي4 المطوّرة في مختبرات إم آي تي MIT عن طريق الدكتور رونالد ريفست.
    ' يُفرّق أيضًا بين MD5 وبقيّة دوال الاختزال عن طريق أبرز خصائصها التقنيّة ومميّزاتها، ثُم يوضّح بشيءٍ من التفصيل خطوات تنفيذها بدءًا من طريقة الاختزال،
    ' مرورًا بالجولات الأربع انتهاءً باختزال الرسالة الأصليّة إلى شكلها النهائيّ
    '.وأخيرًا يُلقي هذا المقال نظرة سريعة على عيوب ونقاط ضعف هذه الدالّة نسبةً إلى ثباتها أمام محاولات الاختراق
    '، وسلسلة محاولات الكسر الناجحة التي حصلت عليها مُنذ بداية تطويرها.
    Public Function Encrypt(x As String)
        Dim z As String
        Dim txt() As Byte = UTF8.GetBytes(x)
        Dim md5 As New MD5CryptoServiceProvider
        Dim keymd5() As Byte = md5.ComputeHash(UTF8.GetBytes(hasha))
        Dim trip As New TripleDESCryptoServiceProvider
        trip.Key = keymd5
        trip.Mode = CipherMode.ECB
        trip.Padding = PaddingMode.PKCS7
        Dim trans As ICryptoTransform = trip.CreateEncryptor
        Dim result() As Byte = trans.TransformFinalBlock(txt, 0, txt.Length)
        z = System.Convert.ToBase64String(result, 0, result.Length)
        Return z
    End Function

    Public Function Decrypt(x As String)
        Dim z As String
        Dim txt() As Byte = System.Convert.FromBase64String(x)
        Dim md5 As New MD5CryptoServiceProvider
        Dim keymd5() As Byte = md5.ComputeHash(UTF8.GetBytes(hasha))
        Dim trip As New TripleDESCryptoServiceProvider
        trip.Key = keymd5
        trip.Mode = CipherMode.ECB
        trip.Padding = PaddingMode.PKCS7
        Dim trans As ICryptoTransform = trip.CreateDecryptor
        Dim result() As Byte = trans.TransformFinalBlock(txt, 0, txt.Length)
        z = UTF8.GetString(result)
        Return z
    End Function
End Module
