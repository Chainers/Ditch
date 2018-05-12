robocopy ..\Sources\Ditch.Core\bin\Debug\netstandard2.0\ bin\
robocopy ..\Sources\Ditch.Golos\bin\Debug\netstandard2.0\ bin\
robocopy ..\Sources\Ditch.Steem\bin\Debug\netstandard2.0\ bin\
robocopy ..\Sources\Ditch.EOS\bin\Debug\netstandard2.0\ bin\

robocopy ..\Sources\packages\WebSocket4Net.0.15.0\lib\net45\ bin\
robocopy ..\Sources\packages\System.Diagnostics.DiagnosticSource.4.4.1\lib\net46\ bin\
robocopy ..\Sources\packages\SuperSocket.ClientEngine.0.9.0\lib\net45\ bin\
robocopy ..\Sources\packages\Newtonsoft.Json.10.0.3\lib\net45\ bin\
robocopy ..\Sources\packages\Ditch.Core.3.0.5\lib\netstandard2.0\ bin\
robocopy ..\Sources\packages\Cryptography.ECDSA.Secp256k1.1.0.1\lib\netstandard1.3\ bin\

robocopy ..\Tools\MarkdownDocNet\ bin\ /xf *.md *.txt
